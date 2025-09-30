using Macaroon_bot.Model;
using Telegram.Bot.Types;

namespace MacaroonBot.Model
{
    public class RegistrationService : IRegistrationService
    {
        private readonly ApplicationDBContext _context;
        private readonly Dictionary<long, RegistrationState> _states = new();

        public RegistrationService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<string> HandleUpdateAsync(long chatId, string? text, Contact? contact)
        {
            if (!_states.ContainsKey(chatId))
                _states[chatId] = new RegistrationState();

            var state = _states[chatId];

            switch (state.Step)
            {
                case RegistrationStep.Start:
                    state.Step = RegistrationStep.ParentName;
                    return "Здравствуйте! Введите ваши ФИО полностью (пример: Иванов Иван Иванович).";

                case RegistrationStep.ParentName:
                    if (string.IsNullOrWhiteSpace(text))
                        return "Пожалуйста, введите ФИО полностью.";

                    var parentParts = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    if (parentParts.Length < 3)
                        return "ФИО должно содержать фамилию, имя и отчество.";

                    state.ParentLastName = parentParts[0];
                    state.ParentFirstName = parentParts[1];
                    state.ParentSurName = parentParts[2];
                    state.Step = RegistrationStep.ParentPhone;

                    return "Отправьте номер телефона или используйте кнопку для отправки контакта.";

                case RegistrationStep.ParentPhone:
                    if (contact != null)
                        state.ParentPhone = contact.PhoneNumber;
                    else if (!string.IsNullOrWhiteSpace(text))
                        state.ParentPhone = text;
                    else
                        return "Введите номер телефона или отправьте контакт.";

                    state.Step = RegistrationStep.ChildName;
                    return "Введите ФИО ребёнка полностью (пример: Петров Пётр Петрович).";

                case RegistrationStep.ChildName:
                    if (string.IsNullOrWhiteSpace(text))
                        return "Пожалуйста, введите ФИО ребёнка.";

                    var childParts = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    if (childParts.Length < 3)
                        return "ФИО ребёнка должно содержать фамилию, имя и отчество.";

                    state.ChildLastName = childParts[0];
                    state.ChildFirstName = childParts[1];
                    state.ChildSurName = childParts[2];
                    state.Step = RegistrationStep.ChildBirthDate;

                    return "Укажите дату рождения ребёнка (пример: 01.03.2020).";

                case RegistrationStep.ChildBirthDate:
                    if (!DateTime.TryParse(text, out var dob))
                        return "Некорректный формат даты. Попробуйте снова (пример: 01.03.2020).";

                    state.ChildBirthDate = dob;

                    // --- Сохраняем в БД ---
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
                        DateOfBirth = state.ChildBirthDate!.Value,
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    };

                    parent.Children.Add(child);

                    _context.Parents.Add(parent);
                    await _context.SaveChangesAsync();

                    // Чистим состояние
                    _states.Remove(chatId);

                    return $"Спасибо! Вы успешно записаны на пробное занятие. Мы свяжемся с вами для уточнения даты.";

                default:
                    _states.Remove(chatId); // сброс
                    return "Что-то пошло не так. Давайте начнём регистрацию заново. Введите ваши ФИО.";
            }
        }
    }
}
