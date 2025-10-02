using MacaroonBot.Model;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace MacaroonBot.Controllers
{
    [ApiController]
    [Route("api/bot/[controller]")]
    public class TelegramController : ControllerBase
    {
        private readonly ITelegramService _telegramService;
        private readonly ITelegramBotClient _botClient;

        public TelegramController(ITelegramService telegramService, ITelegramBotClient botClient)
        {
            _telegramService = telegramService;
            _botClient = botClient;
        }

        [HttpPost("update")]
        public async Task<IActionResult> Post([FromBody] Update update)
        {
            long chatId;
            string? text = null;
            Contact? contact = null;

            if (update.Message != null)
            {
                chatId = update.Message.Chat.Id;
                text = update.Message.Text;
                contact = update.Message.Contact;
            }
            else if (update.CallbackQuery != null)
            {
                chatId = update.CallbackQuery.From.Id;
                text = update.CallbackQuery.Data;
            }
            else
            {
                return Ok();
            }

            var (replyMarkup, messageText) = await _telegramService.HandleUpdateAsync(chatId, text, contact);

            if (replyMarkup == null)
            {
                await _botClient.SendMessage(
                    chatId: chatId,
                    text: messageText,
                    replyMarkup: new ReplyKeyboardRemove()
                );
            }
            else 
            {
                await _botClient.SendMessage(
                    chatId: chatId,
                    text: messageText,
                    replyMarkup: replyMarkup
                );
            }

            return Ok();
        }
    }
}
