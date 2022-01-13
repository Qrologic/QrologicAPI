using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QroApi.MODEL
{
    public class EmployeeRegisterModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Role")]
        public int UserRole { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string UserId { get; set; }
        [Required]
        [Display(Name = "Full Name")]
        public string UserName { get; set; }

        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [EmailAddress]
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [MaxLength(10)]
        [Display(Name = "Mobile")]
        public string Mobile { get; set; }
        public string Image { get; set; }


        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Transaction Password")]
        public string TPassword { get; set; }

        public string SecurityKey { get; set; }
        public string Address { get; set; }
        [Display(Name = "Country")]
        public int? CountryId { get; set; }

        [Display(Name = "State")]
        public int? StateId { get; set; }

        [Display(Name = "City")]
        public int? CityId { get; set; }

        [MaxLength(6)]
        [Display(Name = "Pin Code")]
        public string Zip { get; set; }
        [Required]
        [MaxLength(10)]
        [Display(Name = "PAN Number")]
        [RegularExpression("^([A-Za-z]){5}([0-9]){4}([A-Za-z]){1}$", ErrorMessage = "Invalid PAN Number")]
        public string PanNumber { get; set; }

        [MaxLength(12)]
        [Display(Name = "Aadhar Number")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Please enter valid Number")]
        public string AadhaarNumber { get; set; }
        public string Source { get; set; }
        public string IP { get; set; }
        public string MAC { get; set; }
    }
    public class EmployeeResponse
    {
        public int Id { get; set; }
        public int SrNo { get; set; }
        // public string Status { get; set; }
        public string Role { get; set; }
        public string LoginId { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        //public string Address { get; set; }
        //public string PanNumber { get; set; }

        public string Action { get; set; }
    }
    public class EmployeeDetail
    {
        public int Id { get; set; }
        public string Role { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
        public string TPassword { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string PanNumber { get; set; }
        public string AadharNumber { get; set; }
        public string Status { get; set; }
        public string DOJ { get; set; }
    }
}
