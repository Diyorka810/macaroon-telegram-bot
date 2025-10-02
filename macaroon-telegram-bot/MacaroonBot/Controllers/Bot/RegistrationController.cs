using MacaroonBot.Model;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

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
            if (update.Message != null)
            {
                var chatId = update.Message.Chat.Id;
                var text = update.Message.Text;
                var contact = update.Message.Contact;

                if (text == "/start")
                {
                    var isRegistered = await _registrationService.CheckUserAsync(chatId);

                    if (isRegistered)
                    {
                        await _botClient.SendMessage(
                            chatId,
                            "Добро пожаловать обратно! Вот главное меню:",
                            replyMarkup: MainMenuKeyboard());
                    }
                    else
                    {
                        await _botClient.SendMessage(
                            chatId,
                            "Здравствуйте! Мы поможем вам записать вашего ребёнка на занятия.",
                            replyMarkup: new ReplyKeyboardMarkup(
                                new[]
                                {
                            new KeyboardButton("Записаться на пробное занятие \n (БЕСПЛАТНО)")
                                })
                            {
                                ResizeKeyboard = true,
                                OneTimeKeyboard = true
                            });
                    }
                }
                else
                {
                    var reply = await _registrationService.HandleUpdateAsync(chatId, text, contact);
                    if (!string.IsNullOrEmpty(reply))
                        await _botClient.SendMessage(chatId, reply);
                }
            }

            return Ok();
        }

        private ReplyKeyboardMarkup MainMenuKeyboard()
        {
            return new ReplyKeyboardMarkup(new[]
                    {
                new[] { new KeyboardButton("Расписание"), new KeyboardButton("Оплата") },
                new[] { new KeyboardButton("Контакты") }
            })
            {
                ResizeKeyboard = true
            };
        }
    }
}
