namespace Smart_Tire_app_Server.Additionals
{
    public class UpdateUserRequest
    {
        public string UserId { get; set; }
        public string FieldDesiredToChange { get; set; }
        public string NewValue { get; set; }
    }
}
