using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QroApi.MODEL
{
    public class UserRegistration
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string UserId { get; set; }
        [Required]
        [Display(Name = "Full Name")]
        public string UserName { get; set; }

        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        // [EmailAddress]
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [MaxLength(10)]
        [Display(Name = "Mobile")]
        public string Mobile { get; set; }
        public string UserImage { get; set; }
        public string SecurityKey { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Role")]
        public int UserRole { get; set; }

        [Display(Name = "Transaction Password")]
        public string TPassword { get; set; }
        public int ParentMsrNo { get; set; }
        [Required]
        [Display(Name = "Package")]
        public int PackageId { get; set; }
        public string Address { get; set; }
        [Display(Name = "Country")]
        public int? CountryId { get; set; }
        //[Range(1, Int32.MaxValue, ErrorMessage = "The State field is required.")]
        [Display(Name = "State")]
        public int? StateId { get; set; }

        [Display(Name = "City")]
        public int? CityId { get; set; }

        [MaxLength(6)]
        [Display(Name = "Pincode")]
        public string Zip { get; set; }
        public string Source { get; set; }
        public string LastLoginIP { get; set; }
        [Required]
        [MaxLength(10)]
        [Display(Name = "PAN Number")]
        public string PanNumber { get; set; }

        [MaxLength(12)]
        [Display(Name = "Aadhar Number")]
        public string AadharNumber { get; set; }
        public string IP { get; set; }
        public string MAC { get; set; }
    }
}
