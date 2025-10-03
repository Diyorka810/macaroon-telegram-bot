namespace MacaroonBot.Model
{
    public class Schedule
    {
        public int Id { get; set; }

        public int? GroupId { get; set; }
        public Group? Group { get; set; }

        public int? ChildId { get; set; } // для индивидуальных
        public Child? Child { get; set; }

        public string Type { get; set; } = "Regular";

        // Для регулярных занятий
        public DayOfWeek? DayOfWeek { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }

        // Для разовых мероприятий
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
