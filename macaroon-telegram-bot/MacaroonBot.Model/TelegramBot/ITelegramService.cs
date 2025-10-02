using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace MacaroonBot.Model
{
    public interface ITelegramService
    {
        Task<(ReplyKeyboardMarkup, string)> HandleUpdateAsync(long chatId, string? text, Contact? contact);
    }
}