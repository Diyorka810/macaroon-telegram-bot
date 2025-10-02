using Telegram.Bot.Types;

namespace MacaroonBot.Model
{
    public interface IRegistrationService
    {
        Task<string> HandleUpdateAsync(long chatId, string? text, Contact? contact);
        Task<bool> CheckUserAsync(long chatId);
    }
}