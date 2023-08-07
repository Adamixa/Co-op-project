namespace UniversityResturantInformation.Models
{
    public class Menu_Item
    {
        public int Id { get; set; }
        public Item Item { get; set; }
        public int ItemId { get; set; }
        public Menu Menu { get; set; }
        public int MenuId { get; set; }
    }
}
