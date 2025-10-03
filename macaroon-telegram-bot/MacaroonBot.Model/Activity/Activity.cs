namespace MacaroonBot.Model
{
    public class Activity
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!; // "Поурочно 2+", "Абонемент 4+", "Танцы", "Английский язык"

        public string? Description { get; set; }

        public decimal Price { get; set; } // 400000 сум, 500000 сум и т.д.

        public TimeSpan Duration { get; set; } // 00:45:00 или 01:30:00

        public bool IsSubscription { get; set; } // Поурочно или Абонемент

        public ICollection<Group> Groups { get; set; } = new List<Group>();
        public ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
    }
}
