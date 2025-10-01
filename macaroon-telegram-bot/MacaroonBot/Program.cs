using Macaroon_bot.Model;
using MacaroonBot.Model;
using Microsoft.EntityFrameworkCore;
using Telegram.Bot;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var token = configuration["TelegramBot:Token"];
if (string.IsNullOrEmpty(token))
{
    throw new InvalidOperationException("В appsettings.json не найден TelegramBot:Token");
}
builder.Services.AddSingleton<ITelegramBotClient>(sp =>
    new TelegramBotClient(token));

builder.Services.AddScoped<IParentService, ParentService>();
builder.Services.AddSingleton<RegistrationStateStore>();
builder.Services.AddScoped<IRegistrationService, RegistrationService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
