using Macaroon_bot.Model;
using Microsoft.AspNetCore.Mvc;

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
    }
}
