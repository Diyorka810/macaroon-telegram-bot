using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace MacaroonBot.Model
{
    public interface IRegistrationService
    {
        Task<(ReplyKeyboardMarkup?, string)> RegisterAsync(long chatId, string? text, Contact? contact);
        Task<bool> IsUserRegistered(long chatId);
        void ClearState();
    }
}