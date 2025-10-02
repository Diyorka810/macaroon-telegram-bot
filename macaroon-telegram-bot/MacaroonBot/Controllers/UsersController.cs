using Macaroon_bot.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Telegram.Bot.Types;

namespace Macaroon_bot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public UsersController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("ok");
        }

        [HttpPost]
        public IActionResult Post([FromQuery] string phoneNumber, string? password, string code)
        {
            return Ok("ok");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] string telegramId)
        {
            var parent = await _context.Parents
                .Include(p => p.Children)
                .Include(p => p.Payments)
                .FirstOrDefaultAsync(p => p.TelegramId == telegramId);

            if (parent == null)
                return NotFound("ѕользователь с таким TelegramId не найден.");

            if (parent.Children.Any())
                _context.Children.RemoveRange(parent.Children);

            if (parent.Payments.Any())
                _context.Payments.RemoveRange(parent.Payments);

            _context.Parents.Remove(parent);

            await _context.SaveChangesAsync();

            return Ok("ѕользователь и все св€занные данные удалены.");
        }
    }
}
