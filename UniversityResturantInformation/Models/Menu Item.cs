namespace UniversityResturantInformation.Models
{
    public class Menu_Item
    {
        public int Id { get; set; }
        public Item item { get; set; }
        public int IId { get; set; }
        public Menu menu { get; set; }
        public int MId { get; set; }
    }
}
