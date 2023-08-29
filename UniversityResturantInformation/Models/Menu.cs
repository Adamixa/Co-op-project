using System;

namespace UniversityResturantInformation.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public int Meal { get; set; }//1 for breakfast, 2 for lunch, 3 for dinner
        public bool IsVoteable { get; set; }
    }
}
