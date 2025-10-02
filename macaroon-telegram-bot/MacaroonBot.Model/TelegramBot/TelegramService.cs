using Microsoft.EntityFrameworkCore;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace MacaroonBot.Model
{
    public class TelegramService : ITelegramService
    {
        private readonly IRegistrationService _registrationService;
        private readonly IMenuService _menuService;

        public TelegramService(IRegistrationService registrationService, IMenuService menuService) 
        {
            _registrationService = registrationService;
            _menuService = menuService;
        }

        public async Task<(ReplyKeyboardMarkup?, string)> HandleUpdateAsync(long chatId, string? text, Contact? contact)
        {
            var telegramId = chatId;
            var isUserRegistered = await _registrationService.IsUserRegistered(telegramId);

            if (isUserRegistered)
            {
                return _menuService.GetMainMenuKeyboard();
            }
            else if (text == "/start")
            {
                var keyBoard = new ReplyKeyboardMarkup(
                    [
                        new[] { new KeyboardButton("Записаться на пробное занятие (БЕСПЛАТНО)") },
                    ]
                )
                {
                    ResizeKeyboard = true
                };
                _registrationService.ClearState();
                return (keyBoard, "Здравствуйте! Мы поможем вам записать вашего ребёнка на занятия.");
            }
            else
            {
                return await _registrationService.RegisterAsync(chatId, text, contact);
            }
        }
    }
}
