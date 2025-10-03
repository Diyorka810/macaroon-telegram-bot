namespace MacaroonBot.Model
{
    public class Payment
    {
        public int Id { get; set; }

        public int ParentId { get; set; }
        public Parent Parent { get; set; } = null!;

        public int ChildId { get; set; }
        public Child Child { get; set; } = null!;

        public int ActivityId { get; set; }
        public Activity Activity { get; set; } = null!;

        public decimal Amount { get; set; }

        public DateTime PaymentDate { get; set; }

        public string PaymentMethod { get; set; } = "Cash"; // Cash, Card, Transfer

        public string Status { get; set; } = "Paid"; // Paid, Pending, Overdue
    }

}
