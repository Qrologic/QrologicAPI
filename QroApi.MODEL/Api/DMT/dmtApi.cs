using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QroApi.MODEL
{
    public class dmtApi
    {

        /// <summary>
        /// Remitter Details
        /// </summary>
        public class RemitterDetails_Request
        {
            public string mobile { get; set; }
            //public string outletid { get; set; }
        }


        /// <summary>
        /// Remitter Registration
        /// </summary>
        public class Request_RemitterRegistration
        {
            public string mobile { get; set; }
            public string name { get; set; }
            public string surname { get; set; }
            public string pincode { get; set; }
            //public int outletid { get; set; }
        }

        /// <summary>
        /// Remitter Validate
        /// </summary>
        /// 

        public class Request_RemitterValidate
        {
            public string remitterid { get; set; }
            public string mobile { get; set; }
            public string otp { get; set; }
            //public int outletid { get; set; }
        }

        /// <summary>
        /// Beneficiary Registration
        /// </summary>
        public class Request_BeneficiaryRegistration
        {
            public string remitterid { get; set; }
            public string name { get; set; }
            public string mobile { get; set; }
            public string ifsc { get; set; }
            public string account { get; set; }
            //public string outletid { get; set; }
        }

        /// <summary>
        /// Beneficiary Remove
        /// </summary>
      
        public class Request_BeneficiaryRemove
        {
            public string beneficiaryid { get; set; }
            public string remitterid { get; set; }
            //public int outletid { get; set; }
        }

        /// <summary>
        /// Beneficiary Remove Validate
        /// </summary>
        
        public class Request_BeneficiaryRemove_Validate
        {
            public string beneficiaryid { get; set; }
            public string remitterid { get; set; }
            public string otp { get; set; }
            //public int outletid { get; set; }
        }
        /// <summary>
        /// Fund Transfer
        /// </summary>
        
        public class Request_FundTransfer
        {
            public string remittermobile { get; set; }
            public string beneficiaryid { get; set; }
            public string agentid { get; set; }
            public string amount { get; set; }
            public string account { get; set; }
            public string ifsc { get; set; }
            public string mode { get; set; }
            public string beneficiary_name { get; set; }
            public string bank_id { get; set; }
            //public string outletid { get; set; }
        }

        public class FundTransfer_Data
        {
            public string ipay_id { get; set; }
            public string ref_no { get; set; }
            public string opr_id { get; set; }
            public string name { get; set; }
            public string opening_bal { get; set; }
            public decimal amount { get; set; }
            public string charged_amt { get; set; }
            public decimal locked_amt { get; set; }
            public decimal ccf_bank { get; set; }
            public string bank_alias { get; set; }
        }

        public class Root_ResponseFundTransfer
        {
            public string statuscode { get; set; }
            public string status { get; set; }
            public FundTransfer_Data data { get; set; }
            public string timestamp { get; set; }
            public string ipay_uuid { get; set; }
            public string orderid { get; set; }
            public string environment { get; set; }
        }

        /// <summary>
        /// Transaction Status
        /// </summary>
        public class TransactionStatus_Request
        {
            public string agentid { get; set; }           
        }
        public class Root_ApiRequest
        {
            public string token { get; set; }
            public dynamic request { get; set; }
        }
    }
}
