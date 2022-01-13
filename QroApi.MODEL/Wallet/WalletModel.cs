using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QroApi.MODEL
{
    public class WalletModel
    {
    }
    public class WalletResponse
    {
        public int Id { get; set; }
        public int SrNo { get; set; }
        public string MemberId { get; set; }
        public string Name { get; set; }
        public string Debit { get; set; }
        public string Credit { get; set; }
        public string Balance { get; set; }
        public string Action { get; set; }
    }

    public class AddDeductFundModel
    {
        public int FromMsrNo { get; set; }
        public int ToMsrNo { get; set; }
        [Required]
        public string MemberId { get; set; }
        [Display(Name ="Current Balance")]
        public decimal Balance { get; set; } = 0;
        [Required]
        public decimal Amount { get; set; }
        
        public string Factor { get; set; }
        [Display(Name ="Remark")]
        [Required]
        public string Narration { get; set; }
       
        public string Source { get; set; }
        public bool IsReturn { get; set; } = false;
        public string Service { get; set; }
        public bool IsVerify { get; set; }

    }
    public class WalletTransactionResponse
    {
       
        public int Id { get; set; }
        public int SrNo { get; set; }
        public string Receipt { get; set; }
        public string Member { get; set; }
        
        public string Mobile { get; set; }
        public string Service { get; set; }
        public string Amount { get; set; }       
        public string Balance { get; set; }
        public string Status { get; set; }
        public string TransId { get; set; }       
        //public string RefId { get; set; }
        public string Date { get; set; }
        public string Remark { get; set; }
        
        
    }

    public class Top10Transaction
    {

        public int Id { get; set; }
        public int SrNo { get; set; }
        public string Action { get; set; }   
        public string Service { get; set; }
        public string Status { get; set; }
        public string Amount { get; set; }
        public string Balance { get; set; }       
        public string Date { get; set; }
        public string Remark { get; set; }
        public List<Top10Transaction> list { get; set; }
    }
}
