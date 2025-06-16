using Smart_Tire_app_Server.CustomExceptions;
using Smart_Tire_app_Server.Models;

namespace Smart_Tire_app_Server.Additionals
{
    public static class AuxiliaryMethods
    {
        public static bool isCreateUserRequestValid(CreateUserRequest request)
        {
            if (request == null) { return false; }
            if (string.IsNullOrEmpty(request.UserName) || string.IsNullOrWhiteSpace(request.UserName)) { return false; }
            if (string.IsNullOrEmpty(request.Password) || string.IsNullOrWhiteSpace(request.Password)) { return false; }
            if (string.IsNullOrEmpty(request.PhoneNumber) || string.IsNullOrWhiteSpace(request.PhoneNumber)) { return false; }
            if (string.IsNullOrEmpty(request.CitizenNumber) || string.IsNullOrWhiteSpace(request.CitizenNumber)) { return false; }
            if (string.IsNullOrEmpty(request.FullName) || string.IsNullOrWhiteSpace(request.FullName)) { return false; }
            
            return true;
        }

        public static void isSensitivDataDuplicated(User existing, CreateUserRequest newUser)
        {
            if(existing.UserName.Equals(newUser.UserName)) { throw new UsernameAlreadyInUseException(); }
            if(existing.CitizenNumber.Equals(newUser.CitizenNumber)) { throw new DuplicatedCitizenNumbersException(); }
            if (existing.PhoneNumber.Equals(newUser.PhoneNumber)) { throw new DuplicatedPhoneNumbersException(); }
        }

        public static void isSensitivDataDuplicated(User existing, User newUser)
        {
            if (existing.UserName.Equals(newUser.UserName)) { throw new UsernameAlreadyInUseException(); }
            if (existing.CitizenNumber.Equals(newUser.CitizenNumber)) { throw new DuplicatedCitizenNumbersException(); }
            if (existing.PhoneNumber.Equals(newUser.PhoneNumber)) { throw new DuplicatedPhoneNumbersException(); }
        }

        public static void validateUpdateUserRequest(UpdateUserRequest request)
        {
            if (string.IsNullOrEmpty(request.UserId) || string.IsNullOrWhiteSpace(request.UserId)) { throw new UserNotSpecifiedException(); }
            if (string.IsNullOrEmpty(request.FieldDesiredToChange) || string.IsNullOrWhiteSpace(request.FieldDesiredToChange))
            {
                throw new FieldNotSpecifiedException();
            }

            if (string.IsNullOrEmpty(request.NewValue) || string.IsNullOrWhiteSpace(request.NewValue))
            {
                throw new CustomExceptions.InvalidDataException();
            }
        }
    }
}
