using System;
using System.ComponentModel.DataAnnotations;

namespace CommanLayer
{
    public class UserAuthoCL
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public int UserType { get; set; }
    }
    
}
