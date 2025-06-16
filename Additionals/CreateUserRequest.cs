namespace Smart_Tire_app_Server.Additionals
{
    public class CreateUserRequest
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public UserRolesEnum Role { get; set; }
        public string CitizenNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}
