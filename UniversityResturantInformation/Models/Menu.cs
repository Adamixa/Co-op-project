using System;
using System.ComponentModel.DataAnnotations;

namespace UniversityResturantInformation.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        [Required(ErrorMessage = "Meal type is required, 1 for Breakfast, 2 for Lunch, 3 for Dinner")]
        public int Meal { get; set; }//1 for breakfast, 2 for lunch, 3 for dinner
        public bool IsVoteable { get; set; }
    }
}
