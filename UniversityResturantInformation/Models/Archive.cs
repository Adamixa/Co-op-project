using System;
using System.Reflection.Metadata.Ecma335;

namespace UniversityResturantInformation.Models
{
    public class Archive
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int MenuCode { get; set; }
        public int Record { get; set; }
    }
}
