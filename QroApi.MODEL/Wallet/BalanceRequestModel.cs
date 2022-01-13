using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QroApi.MODEL
{
    public class BalanceRequestModel
    {
        public int Id { get; set; }
        public int MsrNo { get; set; }

        [Display(Name="Amount")]
        [Range(1, 5000000) ]
        [Required]
        public decimal Amount { get; set; }
        public string BankName { get; set; }
        [Display(Name = "Payment Mode")]
        [Required]
        public string PaymentMode { get; set; }
        public string PaymentProof { get; set; }
        [Display(Name = "Cheque/DD Number")]
        [Required]
        public string ChequeNumber { get; set; }
        
        public string ChequeDate { get; set; }
        [Display(Name = "Transaction Date")]
        [Required]
        public string PayDate { get; set; }
        [Display(Name = "Remark")]
        [Required]
        public string Remark { get; set; }
        [Display(Name = "To Bank")]
        [Required]
        public string ToBank { get; set; }
        [Display(Name = "RRN")]
        [Required]
        public string RefNo { get; set; }
        public string Source { get; set; }
    }
    public class BalanceRequestList
    {
        public int SrNo { get; set; }
        public string Name { get; set; }
        public string PaymentMode { get; set; }
        public string Amount { get; set; }
        public string Status { get; set; }
        public string RefNo { get; set; }
        public string PayDate { get; set; }
        public string Remark { get; set; }
        public string Date { get; set; }
        public string Action { get; set; }
    }
}
