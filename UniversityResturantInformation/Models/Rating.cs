namespace UniversityResturantInformation.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int UId { get; set; }
        public Item Item { get; set; }
        public int IId { get; set; }
        public int Rate { get; set; }

    }
}
