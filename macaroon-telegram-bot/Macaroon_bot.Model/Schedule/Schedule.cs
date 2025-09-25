using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacaroonBot.Model
{
    public class Schedule
    {
        public int Id { get; set; }

        public int? GroupId { get; set; }
        public Group? Group { get; set; }

        public int? ChildId { get; set; } // для индивидуальных занятий
        public Child? Child { get; set; }

        public string ActivityType { get; set; } = null!; // Lesson, Dance, English, Logoped, Custom

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string Recurring { get; set; } = "None"; // None, Daily, Weekly, Monthly

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
