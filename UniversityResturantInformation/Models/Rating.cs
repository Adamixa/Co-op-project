namespace UniversityResturantInformation.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public Item Item { get; set; }
        public int ItemId { get; set; }
        public int Rate { get; set; }
        public float total { get; set; }

    }
}
