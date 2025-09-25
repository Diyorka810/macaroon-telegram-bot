using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacaroonBot.Model
{
    public class Attendance
    {
        public int Id { get; set; }

        public int? ChildId { get; set; }
        public Child? Child { get; set; }

        public int? StaffId { get; set; }
        public Staff? Staff { get; set; }

        public DateTime Date { get; set; }

        public string Status { get; set; } = "Present"; // Present, Absent, Excused

        public string? Comment { get; set; }
    }
}
