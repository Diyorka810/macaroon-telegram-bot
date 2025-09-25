using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MacaroonBot.Model
{
    public class Child
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public DateTime DateOfBirth { get; set; }

        public int ParentId { get; set; }
        public Parent Parent { get; set; } = null!;

        public int? GroupId { get; set; }
        public Group? Group { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
        public ICollection<Schedule> IndividualSchedules { get; set; } = new List<Schedule>();
    }
}
