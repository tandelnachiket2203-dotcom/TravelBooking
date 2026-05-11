using Microsoft.AspNetCore.Mvc;
using TravelBooking.Models.DTO;
using TravelBooking.Repository;

namespace TravelBooking.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        public AuthController(IAuthRepository authRepository)
        {
            AuthRepository = authRepository;
        }

        public IAuthRepository AuthRepository { get; }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody]UserRegisterDTO userRegisterDTO)
        {
            // Implement user registration logic here
           var userExists=await AuthRepository.UserExistsAsync(userRegisterDTO.Email);
           if(userExists)
            {
                return BadRequest(new { Message = "User with this email already exists" });
            }
            var registeredUser=await AuthRepository.RegisterUserAsync(userRegisterDTO);

            return Ok(registeredUser);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult>Login([FromBody]UserLoginDTO userLoginDTO)
        {
            // Implement user login logic here
            bool userExists=await AuthRepository.UserExistsAsync(userLoginDTO.Email);
            if(!userExists)            
            {
                return BadRequest(new { Message = "Invalid email or password" });
            }
            var loggedInUser=await AuthRepository.LoginUserAsync(userLoginDTO);
            return Ok(new { Message = "Login successful" });
        }

    }
}