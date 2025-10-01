namespace MacaroonBot.Model
{
    public class Parent
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string SurName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? TelegramId { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ICollection<Child> Children { get; set; } = new List<Child>();
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
        public ICollection<ParentChild> ChildrenLink { get; set; } = new List<ParentChild>();
    }
}
