using System;

namespace UniversityResturantInformation.Models
{
    public class Vote
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int UId { get; set; }
        public List_Menu list_Menu { get; set; }
        public int LMId { get; set; }
        public DateTime Date { get; set; }
        public bool IsFinished { get; set; }
    }
}
