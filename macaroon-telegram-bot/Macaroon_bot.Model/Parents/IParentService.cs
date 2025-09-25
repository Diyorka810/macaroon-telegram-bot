using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacaroonBot.Model
{
    public interface IParentService
    {
        Task<Parent> RegisterParentAsync(string firstName, string lastName, string phoneNumber, string telegramId);
        Task<Parent?> GetByTelegramIdAsync(string telegramId);
    }
}
