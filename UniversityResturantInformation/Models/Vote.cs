using System;

namespace UniversityResturantInformation.Models
{
    public class Vote
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public List_Menu List_Menu { get; set; }
        public int List_MenuId { get; set; }
        public DateTime Date { get; set; }
        public bool IsFinished { get; set; }
    }
}
