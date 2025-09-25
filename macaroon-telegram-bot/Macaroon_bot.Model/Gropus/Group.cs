using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacaroonBot.Model
{
    public class Group
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Level { get; set; }

        public int? TeacherId { get; set; }
        public Staff? Teacher { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public ICollection<Child> Children { get; set; } = new List<Child>();
        public ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
    }
}
