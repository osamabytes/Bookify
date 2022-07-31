using AutoMapper;
using Bookify.Data.Data;
using Bookify.Data.JwtBearer;
using Bookify.Data.Models;
using Bookify.Service.Interfaces;
using Bookify.Service.Interfaces.Response;
using Bookify.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bookify.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/users")]
    public class UserController : Controller
    {
        private readonly UserService _userService;

        public UserController(UserManager<User> userManager, BookifyDbContext bookifyDbContext, IMapper mapper, JwtHandler jwtHandler)
        {
            _userService = new UserService(userManager, bookifyDbContext, mapper, jwtHandler);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegister userRegisterDto)
        {
            if (userRegisterDto == null || !ModelState.IsValid)
                return BadRequest();

            var result = await _userService.SignUp(userRegisterDto);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                return BadRequest(new RegisterResponse { Errors = errors, IsSuccessfulRegister = false});
            }

            return Ok(new RegisterResponse { IsSuccessfulRegister = true });
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserLogin userLoginDto)
        {
            if (userLoginDto == null || !ModelState.IsValid)
                return BadRequest();

            var token = await _userService.SignIn(userLoginDto);

            // authorize user with email and password
            if (token == null)
                return Unauthorized(new AuthResponse { IsAuthSuccess = false, ErrorMessage = "Invalid Authentication User"});

            return Ok(new AuthResponse { IsAuthSuccess = true, Token = token });
        }

        [HttpGet("UserStatus")]
        public async Task<IActionResult> GetUserStatus()
        {
            var useremail = User.Claims.FirstOrDefault();

            if (useremail == null)
                return Unauthorized(new GeneralResponse { Status = false, Errors = new List<string> { "User Session Timeout." } });

            return Ok(new GeneralResponse { Status = true });
        }

    }
}
