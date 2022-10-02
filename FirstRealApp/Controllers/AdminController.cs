using FirstRealApp.Models;
using FirstRealApp.Models.DTO_models;
using FirstRealApp.Models.DTO_models.AdminDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstRealApp.Controllers
{
    [Authorize(Roles ="Admin")]
    [ApiController]
    [Route("api/[controller]")]


    public class AdminController : ControllerBase
    {

        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;


        public AdminController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {


            _roleManager = roleManager;
            _userManager = userManager;
            _configuration = configuration;

        }

        [HttpPost]
        [Route("register-admin")]
        //endpoint for registering admin role only 
        public async Task<ActionResult> RegisterAdmin([FromBody] RegisterDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Registration parameters invalid.");
            }

            var userExists = await _userManager.FindByNameAsync(model.Username);

            if (userExists != null)
            {
                return BadRequest("User already exists");
            }

            ApplicationUser user = new()
            {

                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username,



            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return BadRequest("user creation failed");
            }

            if ( !_roleManager.RoleExistsAsync(UserRole.Admin).GetAwaiter().GetResult())
            {
                await _roleManager.CreateAsync(new IdentityRole(UserRole.Admin));

            }

            if (_roleManager.RoleExistsAsync(UserRole.Admin).GetAwaiter().GetResult())
            {
                await _userManager.AddToRoleAsync(user, UserRole.Admin);
            }

            return Ok(result);

        }


        [HttpPost]
        [Route("create-role")]
        //add new role to rolemanager
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityRole role = new IdentityRole
            {
                Name = model.RoleName
            };

            IdentityResult result = await _roleManager.CreateAsync(role);

            return Ok(result);

        }


        [HttpGet]
        [Route("list-users")]
        public async Task<ActionResult> ListAllUsers()
        {
            var users = await _userManager.GetUsersInRoleAsync(UserRole.User);

            return Ok(users);
        }

        [HttpGet]
        [Route("list-admins")]

        public async Task<ActionResult> ListAllAdmins()
        {
            var admins = await _userManager.GetUsersInRoleAsync(UserRole.Admin);

            return Ok(admins);
        }

        [HttpGet]
        [Route("/api/user/{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return BadRequest();
            }

            return Ok(user);
        }

        [HttpDelete]
        [Route("/api/user/{id}")]

        public async Task<ActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return BadRequest();
            }

            await _userManager.DeleteAsync(user);

            return NoContent();


        }

    }
}