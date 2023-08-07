using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;

namespace UniversityResturantInformation.Models
{
    public class Compliant
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Category { get; set; }
        public DateTime Date { get; set; }
    }
}
