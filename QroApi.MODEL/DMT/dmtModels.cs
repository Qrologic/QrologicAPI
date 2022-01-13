using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QroApi.MODEL
{
    public class dmtModels
    {
        public class FatchRemitter
        {
            public string mobile { get; set; }
            public string bank3_flag { get; set; }
        }
        public class RemitterRegistration
        {
            public string mobile { get; set; }
            public string firstname { get; set; }
            public string lastname { get; set; }
            public string address { get; set; }
            public string otp { get; set; }
            public string pincode { get; set; }
            public string stateresp { get; set; }
            public string bank3_flag { get; set; }
            public string dob { get; set; }
            public string gst_state { get; set; }
        }
        public class FetchBeneficiary
        {
            public string mobile { get; set; }
        }
        public class RegisterBeneficiary
        {
            public string mobile { get; set; }
            public string benename { get; set; }
            public string bankid { get; set; }
            public string accno { get; set; }
            public string ifsccode { get; set; }
            public string verified { get; set; }
            public string gst_state { get; set; }
            public string dob { get; set; }
            public string address { get; set; }
            public string pincode { get; set; }

        }
        public class DeleteBeneficiary
        {
            public string mobile { get; set; }
            public string bene_id { get; set; }
        }
        public class BeneficiaryVerify
        {
            public string mobile { get; set; }
            public string accno { get; set; }
            public string bankid { get; set; }
            public string benename { get; set; }
            public string referenceid { get; set; }
            public string pincode { get; set; }
            public string address { get; set; }
            public string dob { get; set; }
            public string gst_state { get; set; }
            public string bene_id { get; set; }
            public string remname { get; set; }
            public string bankname { get; set; }
            public string ifsccode { get; set; }
        }
        public class Transaction
        {
            public string mobile { get; set; }
            public string referenceid { get; set; }
            public string pipe { get; set; }
            public string txntype { get; set; }
            public string accno { get; set; }
            public int bankid { get; set; }
            public string benename { get; set; }
            public int pincode { get; set; }
            public string address { get; set; }
            public string dob { get; set; }
            public string gst_state { get; set; }
            public int bene_id { get; set; }
            public string ifsccode { get; set; }
            public string remname { get; set; }
            public string bankname { get; set; }
            public decimal amount { get; set; }
        }
        public class Response
        {
            public bool status { get; set; }
            public int response_code { get; set; }
            public string message { get; set; }
            public dynamic data { get; set; }
            public string utr { get; set; }
            public string ackno { get; set; }
            public int txn_status { get; set; }
            public string benename { get; set; }
            public string stateresp { get; set; }
            public string remitter_limit { get; set; }
        }

        public class TransactionResponse
        {
            public bool status { get; set; }
            public int response_code { get; set; }
            public string ackno { get; set; }
            public string utr { get; set; }
            public int txn_status { get; set; }
            public string benename { get; set; }
            public string remarks { get; set; }
            public string message { get; set; }
            public string customercharge { get; set; }
            public string gst { get; set; }
            public string tds { get; set; }
            public string netcommission { get; set; }
            public string remitter { get; set; }
            public string account_number { get; set; }
            public string paysprint_share { get; set; }
            public string txn_amount { get; set; }
            public double balance { get; set; }
        }
       
    }
    public class dmtApiBalance
    {
        public string Action { get; set; }
        public string Balance { get; set; }
        public string ApiName { get; set; }
        public int ApiId { get; set; }
        public int SrNo { get; set; }
        public List<dmtApiBalance> list { get; set; }
    }
    public class PendingDMT
    {
        public int SrNo { get; set; }
        public int Id { get; set; }
        public string Amount { get; set; }
        public string Account { get; set; }
        public string TxnId { get; set; }
        public string ApiTxnId { get; set; }
        public string Status { get; set; }
        public string Remitter { get; set; }
        public string Ifsc { get; set; }
        public string TxnDate { get; set; }
        public string MemberName { get; set; }
        public string BeneName { get; set; }
        public string  RefNo { get; set; }
        public int ApiId { get; set; }
        public List<PendingDMT> list { get; set; }
    }

    public class TransactionEnquiry
    {
        public int id { get; set; }
        public int apiId { get; set; }
        public string referenceId { get; set; }
        public string apitxnId { get; set; }
        public string otp { get; set; }
    }
    public class DMTSurcharge
    {
        public int SrNo { get; set; }
        public int Id { get; set; }
        [Required(ErrorMessage = "required")]
        [Display(Name = "Package")]
        public int PackageId { get; set; }
        [Required(ErrorMessage = "required")]
        [Display(Name = "From Amount")]
        public decimal FromAmount { get; set; }
        [Required(ErrorMessage = "required")]
        [Display(Name = "To Amount")]
        public decimal ToAmount { get; set; }
        [Required(ErrorMessage = "required")]
        public decimal Surcharge { get; set; }
        public bool IsFlat { get; set; }
        public string PackageName { get; set; }
        [Display(Name = "MD Commission")]
        [Required(ErrorMessage = "required")]
        public decimal mdComm { get; set; } = 0;
        [Display(Name = "IsFlat")]
        public bool mdIsFlat { get; set; }
        [Required(ErrorMessage = "required")]
        [Display(Name = "DT Commission")]
        public decimal dtComm { get; set; }
        [Display(Name = "IsFlat")]
        public bool dtIsFlat { get; set; }
        [Required(ErrorMessage = "required")]
        [Display(Name = "RT Commission")]
        public decimal rtComm { get; set; }
        [Display(Name = "IsFlat")]
        public bool rtIsFlat { get; set; }
        [Required(ErrorMessage = "required")]
        [Display(Name = "SD Commission")]
        public decimal sdComm { get; set; }
        [Display(Name = "IsFlat")]
        public bool sdIsFlat { get; set; }
        public int ApiId { get; set; }
        public string ApiName { get; set; }
        [Display(Name = "GST(%)")]
        public string gstRate { get; set; }
        [Display(Name = "TDS(%)")]
        public string tdsRate { get; set; } = "0";
        public List<DMTSurcharge> list { get; set; }
    }

    public class dmtApiCharge
    {
        public int SrNo { get; set; }
        public int Id { get; set; }


        [Required(ErrorMessage = "required")]
        [Display(Name = "Package")]
        public int PackageId { get; set; }

        [Required(ErrorMessage = "required")]
        [Display(Name = "Start Range")]
        public decimal FromAmount { get; set; }
        [Required(ErrorMessage = "required")]
        [Display(Name = "End Range")]
        public decimal ToAmount { get; set; }
        [Required(ErrorMessage = "required")]
        public decimal ApiCharge { get; set; }
        [Required(ErrorMessage = "required")]
        public decimal Surcharge { get; set; }
        [Display(Name = "IsFlat")]
        public bool IsFlat { get; set; }
        [Required(ErrorMessage = "required")]
        [Display(Name = "Select API")]
        public int ApiId { get; set; }
        public string ApiName { get; set; }
        [Display(Name = "GST(%)")]
        public string gstRate { get; set; }
        [Display(Name = "TDS(%)")]
        public string tdsRate { get; set; }
      
    }

    public class dmtApiChargeResponse
    {
        public int SrNo { get; set; }
        public int Id { get; set; }
        public string ApiName { get; set; }
        public string PackageName { get; set; }
        public decimal StartRange { get; set; }
        public decimal EndRange { get; set; }
        public string ApiCharge { get; set; }
        public string Surcharge { get; set; }
        public string GstRate { get; set; }       
        public string TdsRate { get; set; }
        public string Action { get; set; }
    }
    public class dmtApiList
    {
        public int SrNo { get; set; }
        public string ApiName { get; set; }
        public string Balance { get; set; }
        public string Action { get; set; }
    }
    public class dmtResult
    {

        public int Id { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; }
        public string isSuccess { get; set; }
        public dynamic Results { get; set; }

    }
    public class dmtReciept
    {
        public bool response_code { get; set; }
        public bool message { get; set; }
        public decimal Amount { get; set; }
        public string Account { get; set; }
        public string Status { get; set; }
        public string TxnId { get; set; }
        public string ApiTxnId { get; set; }
        public string TxnDate { get; set; }
        public string RefNo { get; set; }
        public string Ifsc { get; set; }
        public string SenderMobile { get; set; }
        public string Sender { get; set; }
        public string Bank { get; set; }
        public string Reciever { get; set; }
        public string PaymentMode { get; set; }
        public string Surcharge { get; set; }
        public string OrderId { get; set; }
        public CompanyModel company { get; set; }
    }

    public class dmtBulkReciept
    {
        public bool response_code { get; set; }
        public string message { get; set; }
        public string AgentName { get; set; }
        public string AgentMobile { get; set; }
        public string Sender { get; set; }
        public string SenderMobile { get; set; }
        public string Bank { get; set; }
        public string Reciever { get; set; }
        public string Account { get; set; }
        public string Ifsc { get; set; }
        public string PaymentMode { get; set; }
        public CompanyModel company { get; set; }
        public List<dmtBulkTransaction> listTxn { get; set; }
    }
    public class dmtBulkTransaction
    {
        public string Date { get; set; }
        public string Amount { get; set; }
        public string Status { get; set; }
        public string RefNo { get; set; }
        public string OrderId { get; set; }
    }

    public class dmtApiLogs
    {
        public int SrNo { get; set; }
        public string ApiName { get; set; }
        public string  Url { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
        public string Date { get; set; }
    }
    public class MonthlyDMTCommission
    {
        public int SrNo { get; set; }
        public int Id { get; set; }
        public string MemberId { get; set; }
        public string Name { get; set; }
        public string Commission { get; set; }
        public string Tds { get; set; }
        public string Month { get; set; }
        public string Action { get; set; }
    }

}
