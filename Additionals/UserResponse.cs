using Smart_Tire_app_Server.Models;

namespace Smart_Tire_app_Server.Additionals
{
    public class UserResponse
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public UserRolesEnum Role { get; set; }
        public string CitizenNumber { get; set; }
        public string PhoneNumber { get; set; }

        public UserResponse(User user)
        {
            Id = user.Id;
            FullName = user.FullName;
            UserName = user.UserName;
            Role = user.Role;
            CitizenNumber = user.CitizenNumber;
            PhoneNumber = user.PhoneNumber;
        }
    }
}
