namespace MacaroonBot.Model
{
    public class Child
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string SurName { get; set; } = null!;
        public DateOnly DateOfBirth { get; set; }

        public int? GroupId { get; set; }
        public Group? Group { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ICollection<Parent> Parents { get; set; } = new List<Parent>();

        public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
        public ICollection<Schedule> IndividualSchedules { get; set; } = new List<Schedule>();
        public ICollection<ParentChild> ParentsLink { get; set; } = new List<ParentChild>();
    }
}
