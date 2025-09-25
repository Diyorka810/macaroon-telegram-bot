using Macaroon_bot.Model;
using Macaroon_bot.Services;
using MacaroonBot.Model;
using MacaroonBot.Services;
using Microsoft.EntityFrameworkCore;
using Telegram.Bot;


var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// ���������� ��
builder.Services.AddDbContext<ApplicationDBContext>(options =>
        options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

// ����������� � �������
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ������������ ��������-����
var token = configuration["TelegramBot:Token"];
if (string.IsNullOrEmpty(token))
{
    throw new InvalidOperationException("� appsettings.json �� ������ TelegramBot:Token");
}
builder.Services.AddSingleton<ITelegramBotClient>(sp =>
    new TelegramBotClient(token));
builder.Services.AddSingleton<ITelegramBotService, TelegramBotService>();

// ������������ ������ �������
builder.Services.AddScoped<IParentService, ParentService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Lifetime.ApplicationStarted.Register(() =>
{
    using var scope = app.Services.CreateScope();
    var bot = scope.ServiceProvider.GetRequiredService<ITelegramBotService>();
    var cts = new CancellationTokenSource();
    _ = bot.StartAsync(cts.Token);
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
