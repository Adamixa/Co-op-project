namespace UniversityResturantInformation.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public int Cal { get; set; }
        public Menu Menu { get; set; }
        public int MId { get; set; }
    }
}
