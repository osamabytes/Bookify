using AutoMapper;
using Bookify.Data.CRUD;
using Bookify.Data.Data;
using Bookify.Data.JwtBearer;
using Bookify.Data.Models;
using Bookify.Service.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Service.Services
{
    public class UserService
    {
        private readonly UserManager<User> _userManager;
        private readonly BookifyDbContext _bookifyDbContext;
        private readonly IMapper _mapper;
        private readonly JwtHandler _jwtHandler;

        private readonly UserCRUD _userCRUD;

        public UserService(UserManager<User> userManager, BookifyDbContext bookifyDbContext, 
            IMapper mapper, JwtHandler jwtHandler)
        {
            _userManager = userManager;
            _bookifyDbContext = bookifyDbContext;
            _mapper = mapper;
            _jwtHandler = jwtHandler;

            _userCRUD = new UserCRUD(_userManager, _bookifyDbContext, _jwtHandler);
        }

        public async Task<IdentityResult> SignUp(UserRegister userRegisterDto)
        {
            userRegisterDto.Id = Guid.NewGuid();

            var user = _mapper.Map<User>(userRegisterDto);
            return await _userCRUD.RegisterUser(user, userRegisterDto.Password);
        }

        public async Task<String> SignIn(UserLogin userLoginDto)
        {
            return await _userCRUD.CheckUserLogin(userLoginDto.Email, userLoginDto.Password);
        }
    }
}
