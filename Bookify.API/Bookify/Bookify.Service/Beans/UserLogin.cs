﻿using System.ComponentModel.DataAnnotations;

namespace Bookify.Service.Interfaces
{
    public class UserLogin
    {
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
