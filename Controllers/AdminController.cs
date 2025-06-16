using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Smart_Tire_app_Server.Additionals;
using Smart_Tire_app_Server.CustomExceptions;
using Smart_Tire_app_Server.Models;
using Smart_Tire_app_Server.Services;

namespace Smart_Tire_app_Server.Controllers
{
    [ApiController]
    [Route("admin")]
    public class AdminController : Controller
    {
        private readonly AdminService _adminService;

        public AdminController(AdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet("users")]
        public ActionResult<List<UserResponse>> getAllUsers()
        {
            return Ok(_adminService.getUsers());
        }

        [HttpGet("brackets")]
        public ActionResult<List<Bracket>> getAllBrackets()
        {
            return Ok(_adminService.GetBrackets());
        }

        [HttpGet("fines")]
        public ActionResult<List<Fine>> getAllFines()
        {
            return Ok(_adminService.GetFines());
        }

        [HttpGet("paidfines")]
        public ActionResult<List<PaidFine>> getPaidFines()
        {
            return Ok(_adminService.GetPaidFines());
        }


        [HttpPost("createuser")]
        public ActionResult<UserResponse> createUser([FromBody] CreateUserRequest createUserRequest)
        {
            try
            {
                if (!AuxiliaryMethods.isCreateUserRequestValid(createUserRequest))
                {
                    return BadRequest("Трябва да се попълнят всички полета!");
                }

                return Ok(_adminService.AddNewUser(createUserRequest));
            }
            catch (UsernameAlreadyInUseException) { return BadRequest("Потребителското име вече е заето!"); }
            catch (DuplicatedCitizenNumbersException) { return BadRequest("Въведенето ЕГН съвпада с друг!"); }
            catch (DuplicatedPhoneNumbersException) { return BadRequest("Въведеният телефонен номер съвпада с друг!"); }
        }

        [HttpPatch("updateuser")]
        public ActionResult<UserResponse> updateUserData([FromBody] UpdateUserRequest updateUser)
        {
            try
            {
                AuxiliaryMethods.validateUpdateUserRequest(updateUser);

                return _adminService.updateUser(updateUser);
            }
            catch (UsernameAlreadyInUseException) { return BadRequest("Потребителското име вече е заето!"); }
            catch (DuplicatedPhoneNumbersException) { return BadRequest("Въведеният телефонен номер съвпада с друг!"); }
            catch (UserNotFoundException) { return BadRequest("Грешен потербителски идентификатор!"); }
        }
    }
}
