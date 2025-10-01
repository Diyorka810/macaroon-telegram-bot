using MacaroonBot.Model;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace MacaroonBot.Controllers
{
    [ApiController]
    [Route("api/bot/[controller]")]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationService _registrationService;
        private readonly ITelegramBotClient _botClient;

        public RegistrationController(IRegistrationService registrationService, ITelegramBotClient botClient)
        {
            _registrationService = registrationService;
            _botClient = botClient;
        }

        [HttpPost("update")]
        public async Task<IActionResult> Post([FromBody] Update update)
        {
            var chatId = update.Message.Chat.Id;
            var text = update.Message.Text;
            var contact = update.Message.Contact;

            var reply = await _registrationService.HandleUpdateAsync(chatId, text, contact);
            if (!string.IsNullOrEmpty(reply))
                await _botClient.SendMessage(chatId, reply);

            return Ok();
        }
    }
}
