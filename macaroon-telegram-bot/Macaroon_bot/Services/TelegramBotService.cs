using MacaroonBot.Model;
using MacaroonBot.Services;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Macaroon_bot.Services
{
    public class TelegramBotService : ITelegramBotService
    {
        private readonly ITelegramBotClient _botClient;
        private readonly IRegistrationService _registrationService;

        public TelegramBotService(ITelegramBotClient botClient, IRegistrationService registrationService)
        {
            _botClient = botClient;
            _registrationService = registrationService;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var me = await _botClient.GetMe(cancellationToken);
            Console.WriteLine($"Бот @{me.Username} запущен.");

            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = Array.Empty<UpdateType>()
            };

            _botClient.StartReceiving(
                HandleUpdateAsync,
                HandleErrorAsync,
                receiverOptions,
                cancellationToken
            );
        }

        private async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.Message is null) return;

            var chatId = update.Message.Chat.Id;
            var text = update.Message.Text;
            var contact = update.Message.Contact;

            // Вызов бизнес-логики
            var reply = await _registrationService.HandleUpdateAsync(chatId, text, contact);

            if (!string.IsNullOrEmpty(reply))
            {
                await botClient.SendMessage(
                    chatId,
                    reply,
                    cancellationToken: cancellationToken
                );
            }
        }

        private Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Ошибка: {exception.Message}");
            return Task.CompletedTask;
        }
    }
}
