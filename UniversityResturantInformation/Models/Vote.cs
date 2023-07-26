using System;

namespace UniversityResturantInformation.Models
{
    public class Vote
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int UId { get; set; }
        public Menu Menu { get; set; }
        public int MId { get; set; }
        public DateTime Date { get; set; }
    }
}
