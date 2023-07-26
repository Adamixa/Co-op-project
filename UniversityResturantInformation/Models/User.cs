namespace UniversityResturantInformation.Models
{
    public class User
    {
        public int Id { get; set; }
        public int UniId { get; set; }
        public Role Role { get; set; }
        public int RId { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
