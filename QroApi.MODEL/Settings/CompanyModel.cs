using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QroApi.MODEL
{
    public class CompanyModel
    {
        public int Id { get; set; }
        public int MsrNo { get; set; }
        [Required]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }       
        public string  CompanyLogo { get; set; }
        [Required]
        [Display(Name = "Company Owner")]
        public string  CompanyOwner { get; set; }
        [Required]
        public string  Mobile { get; set; }
        [Required]
        [EmailAddress]
        public string  Email { get; set; }
        [Display(Name = "Website Url")]
        [Required]
        public string  WebsiteUrl { get; set; }
        [Display(Name = "GST Number")]
        public string  GstNo { get; set; }
        public string  CIN { get; set; }
        [Display(Name = "PAN Number")]
        public string  PanNo { get; set; }
        [Display(Name = "TAN Number")]
        public string  TanNo { get; set; }
        [Required]
        public string  Copyright { get; set; }
        [Required]
        public string Address { get; set; }
        public string Fevicon { get; set; }
        public string FeviconIcon { get; set; }
        [Display(Name = "Company Logo")]
        public IFormFile ImageFile { get; set; }


    }
}
