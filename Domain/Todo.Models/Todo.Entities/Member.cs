namespace Todo.Entities
{
    public class Member : BaseEntity
    {
        public Member(string first, string last)
        {
            this.First = first;
            this.Last = last;
        }

        public required string First { get; set; }
        public required string Last { get; set; }
    }
}
