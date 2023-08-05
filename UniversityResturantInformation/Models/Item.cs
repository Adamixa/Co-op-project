using Microsoft.EntityFrameworkCore.Query;

namespace UniversityResturantInformation.Models
{
    public class Item
    {
        public int Id { get; set; }
        public int ItemCode { get; set; }
        public string ItemName { get; set; }
        public int Cal { get; set; }
        
    }
}
