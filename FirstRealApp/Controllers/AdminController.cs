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
        public IActionResult RegisterAdmin([FromBody] RegisterDTO model)
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

            ApplicationUser user = new()
            {

                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username,



            };

            var result = _userManager.CreateAsync(user, model.Password).GetAwaiter().GetResult();

            if (!result.Succeeded)
            {
                return BadRequest("user creation failed");
            }

            if (!_roleManager.RoleExistsAsync(UserRole.Admin).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(UserRole.Admin)).GetAwaiter().GetResult();

            }

            if (_roleManager.RoleExistsAsync(UserRole.Admin).GetAwaiter().GetResult())
            {
                _userManager.AddToRoleAsync(user, UserRole.Admin).GetAwaiter().GetResult();
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
        [Route("allroles")]
        public IActionResult ListRoles()
        {
            var roles = _roleManager.Roles;
            return Ok(roles);
        }

        [HttpGet]
        [Route("list-users")]
        public IActionResult ListAllUsers()
        {
            var users = _userManager.GetUsersInRoleAsync(UserRole.User).GetAwaiter().GetResult();

            return Ok(users);
        }

        [HttpGet]
        [Route("list-admins")]

        public IActionResult ListAllAdmins()
        {
            var admins = _userManager.GetUsersInRoleAsync(UserRole.Admin).GetAwaiter().GetResult();

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

        public IActionResult DeleteUser(string id)
        {
            var user = _userManager.FindByIdAsync(id).GetAwaiter().GetResult();
            if (user == null)
            {
                return BadRequest();
            }

            _userManager.DeleteAsync(user).GetAwaiter().GetResult();

            return NoContent();


        }

    }
}