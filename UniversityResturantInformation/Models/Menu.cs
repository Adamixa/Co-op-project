using System;

namespace UniversityResturantInformation.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public bool Status { get; set; }
    }
}
\\