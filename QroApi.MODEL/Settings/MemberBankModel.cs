using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QroApi.MODEL
{
    public class MemberBankModel
    {
        public int Id { get; set; }
        [Required]
        public int MsrNo { get; set; }
        [Display(Name = "Bank")]
        public int BankId { get; set; }
       
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [Display(Name = "Branch")]
        public string Branch { get; set; }
        [MaxLength(16)]
        [Required]
        [Display(Name = "AccountNumber")]
        public string AccountNumber { get; set; }
        [MaxLength(15)]
        [Required]
        [Display(Name = "IFSC")]
        public string IFSC { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [Display(Name = "AccountHolder")]
        public string AccountHolder { get; set; }
    }

    public class MemberBankResponse
    {
        public int Id { get; set; }
        public int SrNo { get; set; }
        public string BankName { get; set; }
        public string Branch { get; set; }
        public string AccountNumber { get; set; }
        public string Ifsc { get; set; }
        public string AccountHolder { get; set; }
        public string Action { get; set; }
    }
}
