using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacaroonBot.Model
{
    public class Notification
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Message { get; set; } = null!;

        public string Audience { get; set; } = "AllClients"; // AllClients, SpecificGroup, SpecificChild

        public DateTime? SentAt { get; set; }

        public int CreatedById { get; set; }
        public Staff CreatedBy { get; set; } = null!;
    }
}
