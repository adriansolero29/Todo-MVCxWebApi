namespace Todo.API.Models
{
    public class MemberDTO
    {
        public long Id { get; set; }
        public required string First { get; set; }
        public required string Last { get; set; }
    }
}
