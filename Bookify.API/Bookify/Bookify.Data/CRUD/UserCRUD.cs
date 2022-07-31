using Bookify.Data.Data;
using Bookify.Data.JwtBearer;
using Bookify.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Data.CRUD
{
    public class UserCRUD
    {

        private readonly UserManager<User> _userManager;
        private readonly BookifyDbContext _bookifyDbContext;
        private readonly JwtHandler _jwtHandler;

        public UserCRUD(UserManager<User> userManager, BookifyDbContext bookifyDbContext, JwtHandler jwtHandler)
        {
            _userManager = userManager;
            _bookifyDbContext = bookifyDbContext;
            _jwtHandler = jwtHandler;
        }

        public async Task<IdentityResult> RegisterUser(User user, String Password)
        {
            var result = await _userManager.CreateAsync(user, Password);
            return result;
        }

        public async Task<String> CheckUserLogin(String email, String Password)
        {
            var result = await _userManager.FindByNameAsync(email);

            string token = null;

            if(result != null)
            {
                var isAuth = await _userManager.CheckPasswordAsync(result, Password);

                if (isAuth)
                {
                    var sigingCredentials = _jwtHandler.GetSigningCredentials();
                    var claims = _jwtHandler.GetClaims(result);
                    var tokenOpetions = _jwtHandler.GenerateTokenOptions(sigingCredentials, claims);
                    token = new JwtSecurityTokenHandler().WriteToken(tokenOpetions);
                }
            }

            return token;
        }
    }
}
