using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QroApi.MODEL
{
    public class ProfileModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [Display(Name = "Role")]
        public string RoleName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        [Display(Name ="Address")]
        public string FullAddress { get; set; }
        public string PanNumber { get; set; }
        public string AadhaarNumber { get; set; }
        public string Status { get; set; }
        public string DOJ { get; set; }
        public string Balance { get; set; }
        public string Image { get; set; }
        [Display(Name = "Profile Photo")]
        public IFormFile ImageFile { get; set; }

    }
}
