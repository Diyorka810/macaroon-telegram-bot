namespace MacaroonBot.Model
{
    public class ParentChild
    {
        public int ParentId { get; set; }
        public Parent Parent { get; set; } = null!;

        public int ChildId { get; set; }
        public Child Child { get; set; } = null!;

        public DateTime LinkedAt { get; set; } = DateTime.UtcNow;
    }
}
