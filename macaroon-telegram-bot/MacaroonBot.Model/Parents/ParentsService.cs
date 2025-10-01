using Macaroon_bot.Model;
using Microsoft.EntityFrameworkCore;

namespace MacaroonBot.Model
{
    public class ParentService : IParentService
    {
        private readonly ApplicationDBContext _context;

        public ParentService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Parent> RegisterParentAsync(string firstName, string lastName, string surName, string phoneNumber, string telegramId)
        {
            var existing = await _context.Parents
                .FirstOrDefaultAsync(p => p.TelegramId == telegramId);

            if (existing != null)
                return existing;

            var parent = new Parent
            {
                FirstName = firstName,
                LastName = lastName,
                SurName = surName,
                PhoneNumber = phoneNumber,
                TelegramId = telegramId
            };

            _context.Parents.Add(parent);
            await _context.SaveChangesAsync();
            return parent;
        }

        public async Task<Parent?> GetByTelegramIdAsync(string telegramId)
        {
            return await _context.Parents
                .Include(p => p.Children)
                .FirstOrDefaultAsync(p => p.TelegramId == telegramId);
        }
    }
}
