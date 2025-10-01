using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacaroonBot.Model
{
    public class Staff
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Role { get; set; } = null!; // Admin, Owner, Teacher

        public string Login { get; set; } = null!;

        public string PasswordHash { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public ICollection<Group> Groups { get; set; } = new List<Group>();
        public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
        public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
    }
}
