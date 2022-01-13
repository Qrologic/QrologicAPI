using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QroApi.MODEL
{
    public class TxnDetailModel
    {
        public int ServiceId { get; set; }
        public decimal Amount { get; set; }
        public string Factor { get; set; }
        public string Remark { get; set; }
        public string Number { get; set; }
        public string Status { get; set; }
        public string TxnId { get; set; }
        public string ApiTxnId { get; set; }
        public DateTime TxnDate { get; set; }
        public string RefNo { get; set; }
        public string OperatorName { get; set; }
        public string ServiceCode { get; set; }
        public string Ifsc { get; set; }
        public string SenderMobile { get; set; }
        public string Sender { get; set; }
        public string Bank { get; set; }
        public string Reciever { get; set; }
        public string PaymentMode { get; set; }
        public string Surcharge { get; set; }
        public string OrderId { get; set; }
        public CompanyModel company { get; set; }
        public string AgentName { get; set; }
        public string AgentMobile { get; set; }
    }

  
}
