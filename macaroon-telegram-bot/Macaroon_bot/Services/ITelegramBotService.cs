namespace MacaroonBot.Services
{
    public interface ITelegramBotService
    {
        Task StartAsync(CancellationToken cancellationToken);
    }
}
