using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Polly_C.Horizon.Gateway.IdentityServer.WebAPI.Auth;
using System.Data;

namespace Polly_C.Horizon.Gateway.IdentityServer.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleManagementController: ControllerBase
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleManagementController(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }



        [HttpPost]
        [Route("register-user")]
        [Authorize(Roles = "HorizonAdmin")]
        public async Task<IActionResult> RegisterUser([FromBody] Credential userRegister)
        {
            var userExists = await _userManager.FindByNameAsync(userRegister.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status400BadRequest, new Response { Status = "Error", Message = "User already exists" });

            IdentityUser user = new()
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = userRegister.Username
            };
            var result = await _userManager.CreateAsync(user, userRegister.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status400BadRequest, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }

        [HttpPost]
        [Route("deregister-user")]
        [Authorize(Roles = "HorizonAdmin")]
        public async Task<IActionResult> DeregisterUser([FromBody] string username)
        {
            var userExists = await _userManager.FindByNameAsync(username);
            if (userExists == null)
                return StatusCode(StatusCodes.Status400BadRequest, new Response { Status = "Error", Message = "User does not exist!" });

            await _userManager.DeleteAsync(userExists);

            return Ok(new Response { Status = "Success", Message = "User deleted successfully!" });
        }

        [HttpPost]
        [Route("enroll-user")]
        [Authorize(Roles = "HorizonAdmin")]
        public async Task<IActionResult> EnrollUser([FromBody] ManageUser userEnroll)
        {
            var userExists = await _userManager.FindByNameAsync(userEnroll.Username);
            if (userExists == null)
                return StatusCode(StatusCodes.Status400BadRequest, new Response { Status = "Error", Message = "User does not exist!" });

            if (!await _roleManager.RoleExistsAsync(userEnroll.Role))
                return StatusCode(StatusCodes.Status400BadRequest, new Response { Status = "Error", Message = "Role does not exist!" });

            if (await _roleManager.RoleExistsAsync(userEnroll.Role))
            {
                await _userManager.AddToRoleAsync(userExists, userEnroll.Role);
            }
            return Ok(new Response { Status = "Success", Message = "User enrolled successfully!" });
        }

        [HttpPost]
        [Route("withdraw-user-from-role")]
        [Authorize(Roles = "HorizonAdmin")]
        public async Task<IActionResult> WithdrawUser([FromBody] ManageUser userWithdraw)
        {
            var userExists = await _userManager.FindByNameAsync(userWithdraw.Username);
            if (userExists == null)
                return StatusCode(StatusCodes.Status400BadRequest, new Response { Status = "Error", Message = "User does not exist!" });

            if (!await _roleManager.RoleExistsAsync(userWithdraw.Role))
                return StatusCode(StatusCodes.Status400BadRequest, new Response { Status = "Error", Message = "Role does not exist!" });

            if (await _roleManager.RoleExistsAsync(userWithdraw.Role))
            {
                await _userManager.RemoveFromRoleAsync(userExists, userWithdraw.Role);
            }
            return Ok(new Response { Status = "Success", Message = "User withdrawn successfully!" });
        }

        [HttpPost]
        [Route("create-role")]
        [Authorize(Roles = "HorizonAdmin")]
        public async Task<IActionResult> CreateRole([FromBody] string roleName)
        {          

            if (!await _roleManager.RoleExistsAsync(roleName))
                await _roleManager.CreateAsync(new IdentityRole(roleName));
            else
                return StatusCode(StatusCodes.Status400BadRequest, new Response { Status = "Error", Message = "Role already exists" });

            return Ok(new Response { Status = "Success", Message = "Role created successfully!" });
        }

        [HttpPost]
        [Route("remove-role")]
        [Authorize(Roles = "HorizonAdmin")]
        public async Task<IActionResult> RemoveRole([FromBody] string roleName)
        {

            if (await _roleManager.RoleExistsAsync(roleName))
                await _roleManager.DeleteAsync(new IdentityRole(roleName));
            else
                return StatusCode(StatusCodes.Status400BadRequest, new Response { Status = "Error", Message = "Role does not exist" });

            return Ok(new Response { Status = "Success", Message = "Role created successfully!" });
        }

        [HttpPost]
        [Route("enroll-admin")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> RegisterAdmin([FromBody] Credential userToRegister)
        {
            var userExists = await _userManager.FindByNameAsync(userToRegister.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status400BadRequest, new Response { Status = "Error", Message = "User already exists" });

            IdentityUser user = new()
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = userToRegister.Username
            };
            var result = await _userManager.CreateAsync(user, userToRegister.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status400BadRequest, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            if (!await _roleManager.RoleExistsAsync("HorizonAdmin"))
                await _roleManager.CreateAsync(new IdentityRole("HorizonAdmin"));

            if (await _roleManager.RoleExistsAsync("HorizonAdmin"))
            {
                await _userManager.AddToRoleAsync(user, "HorizonAdmin");
            }

            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }
    }
}
