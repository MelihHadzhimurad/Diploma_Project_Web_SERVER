using System.ComponentModel.DataAnnotations;
using Smart_Tire_app_Server.Additionals;

namespace Smart_Tire_app_Server.Models
{
    public class User
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public UserRolesEnum Role { get; set; }

        [Required]
        public string UserName { get; set; }
        
        [Required]
        public string Password { get; set; }

        [Required]
        public string CitizenNumber { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public User() { }
        public User(string id, string fullName, UserRolesEnum userRole, string userName, string password, string citizenNumber, string phoneNumber)
        {
            Id = id;
            FullName = fullName;
            Role = userRole;
            UserName = userName;
            Password = password;
            CitizenNumber = citizenNumber;
            PhoneNumber = phoneNumber;
        }
    }
}
