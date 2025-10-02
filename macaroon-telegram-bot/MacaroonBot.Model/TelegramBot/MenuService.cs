using Macaroon_bot.Model;
using Telegram.Bot.Types.ReplyMarkups;

namespace MacaroonBot.Model
{
    public class MenuService : IMenuService
    {
        private readonly ApplicationDBContext _context;

        public MenuService (ApplicationDBContext context)
        {
            _context = context;
        }

        public (ReplyKeyboardMarkup?, string) GetMainMenuKeyboard()
        {
            var keyBoard = new ReplyKeyboardMarkup(
                [
                    new[] { new KeyboardButton("Расписание")},
                    new[] { new KeyboardButton("Оплата") },
                    new[] { new KeyboardButton("Контакты") }
                ]
            )
            {
                ResizeKeyboard = true
            };
            return (keyBoard, "Меню");
        }
    }
}
