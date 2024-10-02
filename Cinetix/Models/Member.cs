namespace Cinetix.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }

        // Foreign Key
        public int GroupId { get; set; }

        // Navigation Property
        public Group Group { get; set; }
    }
}
