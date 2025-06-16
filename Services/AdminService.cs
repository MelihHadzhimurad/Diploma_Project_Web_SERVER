using Smart_Tire_app_Server.Additionals;
using Smart_Tire_app_Server.CustomExceptions;
using Smart_Tire_app_Server.DataBaseContext;
using Smart_Tire_app_Server.Models;
using Smart_Tire_app_Server.Security;

namespace Smart_Tire_app_Server.Services
{
    public class AdminService
    {
        private readonly ApplicationDbContext _context;

        private readonly PasswordHasher _passwordHasher;

        public AdminService(ApplicationDbContext context, PasswordHasher passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public UserResponse AddNewUser(CreateUserRequest userRequest)
        {
            foreach (User user in _context.Users)
            {
                AuxiliaryMethods.isSensitivDataDuplicated(user, userRequest);
            }

            User newUser = new User(Guid.NewGuid().ToString(), userRequest.FullName,
                                    userRequest.Role != null ? userRequest.Role : UserRolesEnum.INSPECTOR,
                                    userRequest.UserName, _passwordHasher.Hash(userRequest.Password),
                                    userRequest.CitizenNumber, userRequest.PhoneNumber);

            _context.Users.Add(newUser);
            _context.SaveChanges();

            return new UserResponse(newUser);
        }

        public UserResponse updateUser(UpdateUserRequest request)
        {
            User old = _context.Users.Find(request.UserId);

            if (old == null) { throw new UserNotFoundException(); }

            switch (request.FieldDesiredToChange)
            {
                case "fullname":
                    old.FullName = request.NewValue;
                    break;

                case "phonenumber":
                    old.PhoneNumber = request.NewValue;
                    break;

                case "username":
                    old.UserName = request.NewValue;
                    break;

                default:
                    break;
            }

            foreach (User user in _context.Users)
            {
                AuxiliaryMethods.isSensitivDataDuplicated(user, old);
            }

            _context.Users.Add(old);
            _context.SaveChanges();

            return new UserResponse(old);
        }

        public List<UserResponse> getUsers()
        {
            List<UserResponse> users = new List<UserResponse>();

            foreach (User user in _context.Users)
            {
                users.Add(new UserResponse(user));
            }

            return users;
        }

        public List<Bracket> GetBrackets()
        {
            return _context.Brackets.ToList();
        }

        public List<Fine> GetFines()
        {
            return _context.Fines.ToList();
        }

        public List<PaidFine> GetPaidFines()
        {
            return _context.PaidFines.ToList();
        }
    }
}
