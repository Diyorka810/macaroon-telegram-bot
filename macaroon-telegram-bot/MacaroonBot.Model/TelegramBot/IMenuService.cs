using Telegram.Bot.Types.ReplyMarkups;

namespace MacaroonBot.Model
{
    public interface IMenuService
    {
        public (ReplyKeyboardMarkup?, string) GetMainMenuKeyboard();
    }
}