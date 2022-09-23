using FirstRealApp.Models;
using FirstRealApp.Models.DTO_models;
using FirstRealApp.Models.DTO_models.AdminDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FirstRealApp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]

    public class AuthenticationController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IConfiguration _configuration;

        public AuthenticationController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            this.signInManager = signInManager;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public  IActionResult Login([FromBody] LoginDTO model)
        {
            if (!ModelState.IsValid)
            {
                return  BadRequest("Login parameters invalid.");
            }
            var user = _userManager.FindByNameAsync(model.Username).GetAwaiter().GetResult();
            if (user != null && _userManager.CheckPasswordAsync(user, model.Password).GetAwaiter().GetResult())
            {

                var userRoles = _userManager.GetRolesAsync(user).GetAwaiter().GetResult();

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                   
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),

                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }
                 

                var token = GetToken(authClaims);
             
                return Ok(new TokenDTO()
                {
                    
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Expiration = token.ValidTo,
                    Role = _userManager.GetRolesAsync(user).GetAwaiter().GetResult().FirstOrDefault().ToString()
                }) ;
            }
            return  Unauthorized("login failed");
        }


        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));


            var token = new JwtSecurityToken(

                  issuer: _configuration["Jwt:Issuer"],
                  audience: _configuration["Jwt:Audience"],
                  expires: DateTime.Now.AddMinutes(10),
                  claims: authClaims,
                  signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)

              );
            return token;
        }



        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        //registering normal user
        public IActionResult Register([FromBody] RegisterDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Registration parameters invalid.");
            }

            var userExists = _userManager.FindByNameAsync(model.Username).GetAwaiter().GetResult();
            if (userExists != null)
            {
                return BadRequest("User already exists");
            }

            ApplicationUser user = new ApplicationUser()
            {

                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username

            };

            var result = _userManager.CreateAsync(user, model.Password).GetAwaiter().GetResult();

            if (!_roleManager.RoleExistsAsync(UserRole.User).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(UserRole.User)).GetAwaiter().GetResult();
            }

            if (_roleManager.RoleExistsAsync(UserRole.User).GetAwaiter().GetResult())
            {
                _userManager.AddToRoleAsync(user, UserRole.User).GetAwaiter().GetResult();
            }

            if (!result.Succeeded)
            {
                return BadRequest("Validation failed! Please check user details and try again.");
            }
            return Ok(result);
        }




        [HttpPost]
        [Route("change-password")]
        //change password endpoint
        public IActionResult ChangePassword([FromBody] PasswordChangeDTO model)
        {


            var user = _userManager.FindByNameAsync(model.Username).GetAwaiter().GetResult();
            if (user == null)
            {
                return NotFound("user doesnt exist");
            }

            var currentPassword = _userManager.CheckPasswordAsync(user, model.CurrentPassword).GetAwaiter().GetResult();

            if (currentPassword == false || model.NewPassword == null)
            {
                return BadRequest("you must enter valid password");
            }

            if (string.Compare(model.NewPassword, model.ConfirmPassword) != 0 || model.NewPassword.Length < 7)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, "passwords cant be empty and must match each other");
            }

            var result = _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword).GetAwaiter().GetResult();

            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "error123");
            }

            return Ok(result);
        }
 
        //controller to sign out active user 
        [HttpGet]
        [Route("logout")]
        public IActionResult Logout()
        {
            signInManager.SignOutAsync().GetAwaiter().GetResult();
            return Ok();
        }

    




















    }
}
