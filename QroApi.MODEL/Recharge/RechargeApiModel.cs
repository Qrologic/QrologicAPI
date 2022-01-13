using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QroApi.MODEL
{
    public class RechargeApiModel
    {
        public int APIID { get; set; }
        [Required]
        [Display(Name = "API Name")]
        public string APIName { get; set; }
        [Required]
        [Display(Name = "Recharge Url")]
        public string URL { get; set; }
        [Required]
        [Display(Name = "Balance Url")]
        public string BalanceURL { get; set; }
        [Required]
        [Display(Name = "Status Url")]
        public string StatusURL { get; set; }
        public string IsDelete { get; set; }
        public string IsActive { get; set; }
        public string CreateDate { get; set; }
        public string ModifyUpdate { get; set; }
        public bool DynamicAPI { get; set; }
        [Display(Name = "Response Format")]
        [Required]
        public string ResponseType { get; set; }
        public string CallbackUrl { get; set; }
        [Display(Name = "Status")]
        [Required]
        public string CallbackStatus { get; set; }
        [Display(Name = "OprId")]
        [Required]
        public string CallbackOperatorId { get; set; }
        [Display(Name = "ApiTxnId")]
        [Required]
        public string CallbackApiId { get; set; }
        [Display(Name = "TxnId")]
        [Required]
        public string CallbackTxnId { get; set; }
        [Display(Name = "Error Code")]
        public string CallbackErrorCode { get; set; }
        public string CallbackBalance { get; set; }
        [Required]
        [Display(Name = "Status")]
        public string paramStatus { get; set; }
        [Required]
        [Display(Name = "TxnId")]
        public string paramTxnId { get; set; }
        [Display(Name = "ApiTxnId")]
        [Required]
        public string paramApiTxnId { get; set; }
        [Required]
        [Display(Name = "OprId")]
        public string paramOprId { get; set; }
        [Display(Name = "Error Code")]
        public string paramErrCode { get; set; }
        [Display(Name = "Error Message")]
        public string paramErrMsg { get; set; }

        [Display(Name = "Failed Status")]
        [Required]
        public string cFailedStatus { get; set; }
        [Display(Name = "Success Status")]
        [Required]
        public string cSuccessStatus { get; set; }
        [Display(Name = "Pending Status")]
        [Required]
        public string cPendingStatus { get; set; }


        [Display(Name = "Failed Status")]
        [Required]
        public string FailedStatus { get; set; }
        [Display(Name = "Success Status")]
        [Required]
        public string SuccessStatus { get; set; }
        [Display(Name = "Pending Status")]
        [Required]
        public string PendingStatus { get; set; }

        [Display (Name ="Status")]
        [Required]
        public string sprmStatus { get; set; }
        [Display(Name = "ApiTxnId")]
        [Required]
        public string sprmApiTxnId { get; set; }
        [Required]
        [Display(Name = "OprId")]
        public string sprmOprId { get; set; }
        [Required]
        [Display(Name = "TxnId")]
        public string sprmTxnId { get; set; }
        [Display(Name = "Failed Status")]
        [Required]
        public string sFailedStatus { get; set; }
        [Display(Name = "Success Status")]
        [Required]
        public string sSuccessStatus { get; set; }
        [Display(Name = "Pending Status")]
        [Required]
        public string sPendingStatus { get; set; }
        [Required]
        [Display(Name = "Balance Parameter Name")]
        public string bparm { get; set; }  
        public bool IsData { get; set; }
    }
    public class RechargeAPIList
    {
        public int SrNo { get; set; }
        public string ApiName { get; set; }
        public string Url { get; set; }
        public string Action { get; set; }
    }
}
