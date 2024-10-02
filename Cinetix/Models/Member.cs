namespace Cinetix.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}
