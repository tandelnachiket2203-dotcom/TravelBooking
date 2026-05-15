using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using TravelBooking.Models.DTO;
using TravelBooking.Repository;

namespace TravelBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> UserManager;

        public ITokenRepositry TokenRepositry { get; }

        public AuthController(UserManager<IdentityUser> userManager,ITokenRepositry tokenRepositry)
        {
            UserManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            TokenRepositry = tokenRepositry;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDTO requestDTO)
        {
            // Implementation goes here
            var identityUser = new IdentityUser
            {
                UserName = requestDTO.UserName,
                Email = requestDTO.UserName
            };
            var IdentityUserResult = await UserManager.CreateAsync(identityUser, requestDTO.Password);
                if(!IdentityUserResult.Succeeded)
            {
                return BadRequest(IdentityUserResult.Errors.Select(e => e.Description));
            }
            if(IdentityUserResult.Succeeded)
            {
                //Add Roll to This User
                if(requestDTO.Roles !=null && requestDTO.Roles.Any())
                {
                    IdentityUserResult= await UserManager.AddToRolesAsync(identityUser, requestDTO.Roles);
                    if(IdentityUserResult.Succeeded)
                    {
                        return Ok("User registered successfully, Please Login");
                    }
                }
            }
            
            return BadRequest("Something Went Wrong");
        }

        //POST:/api/auth/loging

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody]LoginRequestDTO loginRequestDTO)
        {
            var user = await UserManager.FindByEmailAsync(loginRequestDTO.UserName);
            if ((user != null))
            {
                var isPasswordValid = await UserManager.CheckPasswordAsync(user, loginRequestDTO.Password);
                if ((isPasswordValid))
                {
                    //Get User Roles
                    var roles = await UserManager.GetRolesAsync(user);
                    //create token
                    if (roles != null)
                    {
                      var jwtToken=  TokenRepositry.CreateJWTToken(user, roles.ToList());
                        var response = new LoginResponseDTO
                        {
                            JwtToken = jwtToken
                        };
                        return Ok(response);
                    }

                   
                }
            }
            return BadRequest("Invalid UserName or Password");

        }
    }
}
