using Macaroon_bot.Model;
using Microsoft.EntityFrameworkCore;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace MacaroonBot.Model
{
    public class RegistrationService : IRegistrationService
    {
        private readonly ApplicationDBContext _context;
        private readonly RegistrationStateStore _store;

        public RegistrationService(ApplicationDBContext context, RegistrationStateStore store)
        {
            _context = context;
            _store = store;
        }

        public async Task<bool> IsUserRegistered(long chatId)
        {
            var telegramId = chatId.ToString();

            return await _context.Parents
                .AnyAsync(p => p.TelegramId == telegramId);
        }

        public void ClearState()
        {
            _store.States.Clear();
        }

        public async Task<(ReplyKeyboardMarkup?, string)> RegisterAsync(long chatId, string? text, Contact? contact)
        {
            var state = _store.States.GetOrAdd(chatId, _ => new RegistrationState());

            switch (state.Step)
            {
                case RegistrationStep.Start:
                    state.Step = RegistrationStep.ParentName;
                    return (null, "Здравствуйте! Введите ваши ФИО полностью (пример: Иванов Иван Иванович).");

                case RegistrationStep.ParentName:
                    if (string.IsNullOrWhiteSpace(text))
                        return (null, "Пожалуйста, введите ФИО полностью.");

                    var parentParts = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    if (parentParts.Length < 3)
                        return (null, "ФИО должно содержать фамилию, имя и отчество.");

                    state.ParentLastName = parentParts[0];
                    state.ParentFirstName = parentParts[1];
                    state.ParentSurName = parentParts[2];
                    state.Step = RegistrationStep.ParentPhone;

                    var phoneKeyboard = new ReplyKeyboardMarkup(new[]
                    {
                        new[]
                        {
                            new KeyboardButton("Отправить номер телефона") { RequestContact = true }
                        }
                    })
                    {
                        ResizeKeyboard = true,
                        OneTimeKeyboard = true
                    };

                    return (phoneKeyboard, "Пожалуйста, отправьте свой номер телефона.");

                case RegistrationStep.ParentPhone:
                    state.ParentPhone = contact?.PhoneNumber ?? text;
                    if (string.IsNullOrEmpty(state.ParentPhone))
                        return (null, "Введите номер телефона или отправьте контакт.");

                    state.Step = RegistrationStep.ChildName;
                    return (null, "Введите ФИО ребёнка полностью (пример: Петров Пётр Петрович).");

                case RegistrationStep.ChildName:
                    if (string.IsNullOrWhiteSpace(text))
                        return (null, "Пожалуйста, введите ФИО ребёнка.");

                    var childParts = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    if (childParts.Length < 3)
                        return (null, "ФИО ребёнка должно содержать фамилию, имя и отчество.");

                    state.ChildLastName = childParts[0];
                    state.ChildFirstName = childParts[1];
                    state.ChildSurName = childParts[2];
                    state.Step = RegistrationStep.ChildBirthDate;

                    return (null, "Укажите дату рождения ребёнка (пример: 01.03.2020).");

                case RegistrationStep.ChildBirthDate:
                    if (!DateTime.TryParse(text, out var dob))
                        return (null, "Некорректный формат даты. Попробуйте снова (пример: 01.03.2020).");

                    state.ChildBirthDate = dob;

                    var parent = new Parent
                    {
                        FirstName = state.ParentFirstName!,
                        LastName = state.ParentLastName!,
                        SurName = state.ParentSurName!,
                        PhoneNumber = state.ParentPhone!,
                        TelegramId = chatId.ToString(),
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    };

                    var child = new Child
                    {
                        FirstName = state.ChildFirstName!,
                        LastName = state.ChildLastName!,
                        SurName = state.ChildSurName!,
                        DateOfBirth = DateOnly.FromDateTime(state.ChildBirthDate!.Value),
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    };

                    parent.Children.Add(child);

                    _context.Parents.Add(parent);
                    await _context.SaveChangesAsync();

                    _store.States.TryRemove(chatId, out _);

                    var keyBoard = new ReplyKeyboardMarkup(
                        [
                            new[] { new KeyboardButton("Меню")},
                        ]
                    )
                    {
                        ResizeKeyboard = true
                    };

                    return (keyBoard, "Спасибо! Вы успешно записаны на пробное занятие.");

                default:
                    _store.States.TryRemove(chatId, out _);
                    return (null, "Что-то пошло не так. Давайте начнём регистрацию заново.");
            }
        }
    }
}
