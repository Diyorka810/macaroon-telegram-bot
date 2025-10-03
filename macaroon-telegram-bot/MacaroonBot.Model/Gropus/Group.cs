namespace MacaroonBot.Model
{
    public class Group
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int ActivityId { get; set; }
        public Activity Activity { get; set; } = null!;

        public int? TeacherId { get; set; }
        public Staff? Teacher { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ICollection<Child> Children { get; set; } = new List<Child>();
        public ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
    }
}
