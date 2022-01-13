
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QroApi.MODEL
{
    public class LoginRequest
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }

        public string IP { get; set; }
        public string MAC { get; set; }
        public string Type { get; set; }
    }
    
}
