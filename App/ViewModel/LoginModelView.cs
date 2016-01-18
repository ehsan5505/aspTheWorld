using System;
using System.ComponentModel.DataAnnotations;

namespace TheWorld.ModelView
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
