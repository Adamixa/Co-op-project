using System;

namespace UniversityResturantInformation.Models
{
    public class Vote
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public  Menu Menu { get; set; }
        public int MenuId { get; set; }
        public DateTime Date { get; set; }
        public bool IsFinished { get; set; }
    }
}
