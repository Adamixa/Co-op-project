using System.ComponentModel.DataAnnotations;

namespace UniversityResturantInformation.Models
{
    public class Menu_Item
    {
        public int Id { get; set; }
        public Item Item { get; set; }
        [Required(ErrorMessage = "Item is required")]
        [Display(Name = "Item")]
        public int ItemId { get; set; }
        public Menu Menu { get; set; }
        [Required(ErrorMessage = "Menu is required")]
        public int MenuId { get; set; }
        public bool IsDeleted { get; set; }
    }
}