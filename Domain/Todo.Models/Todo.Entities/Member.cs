namespace Todo.Entities
{
    public class Member : BaseEntity
    {
        public Member(string first, string last)
        {
            this.First = first;
            this.Last = last;
        }

        public string First { get; set; }
        public string Last { get; set; }
    }
}
