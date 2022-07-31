using AutoMapper;
using Bookify.Data.Data;
using Bookify.Data.JwtBearer;
using Bookify.Data.Models;
using Bookify.Service.Interfaces;
using Bookify.Service.Interfaces.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace Bookify.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/users")]
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly BookifyDbContext _bookifyDbContext;
        private readonly IMapper _mapper;
        private readonly JwtHandler _jwtHandler;

        public UserController(UserManager<User> userManager, BookifyDbContext bookifyDbContext, IMapper mapper, JwtHandler jwtHandler)
        {
            _userManager = userManager;
            _bookifyDbContext = bookifyDbContext;
            _mapper = mapper;
            _jwtHandler = jwtHandler;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegister userRegisterDto)
        {
            if (userRegisterDto == null || !ModelState.IsValid)
                return BadRequest();

            userRegisterDto.Id = Guid.NewGuid();

            var user = _mapper.Map<User>(userRegisterDto);
            var result = await _userManager.CreateAsync(user, userRegisterDto.Password);

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

            // check if the user exists in the system 
            var user = await _userManager.FindByNameAsync(userLoginDto.Email);
            
            if(user == null)
                return Unauthorized(new AuthResponse { IsAuthSuccess = false, ErrorMessage = "Invalid User SignIn"});

            // authorize user with email and password
            var authUser = await _userManager.CheckPasswordAsync(user, userLoginDto.Password);
            if (!authUser)
                return Unauthorized(new AuthResponse { IsAuthSuccess = false, ErrorMessage = "Invalid Authentication User"});

            var sigingCredentials = _jwtHandler.GetSigningCredentials();
            var claims = _jwtHandler.GetClaims(user);
            var tokenOpetions = _jwtHandler.GenerateTokenOptions(sigingCredentials, claims);
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOpetions);

            return Ok(new AuthResponse { IsAuthSuccess = true, Token = token });
        }


    }
}
