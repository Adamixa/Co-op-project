using System;
using System.ComponentModel.DataAnnotations;

namespace UniversityResturantInformation.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }
        public Role Role { get; set; }
        public int RoleId { get; set; }
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public string Mobile { get; set; }
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$", ErrorMessage = "Password Doesn't meet Requirements")]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        //[RegularExpression(@"[\w]*@*[a-z]*\.*[\w]{3,}(\.)*(com)*(@*.kfu.edu.sa)", ErrorMessage = "Email Doesn't match with University domain")]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        public Guid Guid { get; set; }
        public bool IsDeleted { get; set; }
    }
}
