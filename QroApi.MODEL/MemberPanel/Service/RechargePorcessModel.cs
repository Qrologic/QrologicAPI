using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QroApi.MODEL
{
    public class RechargePorcessModel
    {
        public int ServiceId { get; set; }
        public int OperatorId { get; set; }
        public int CircleId { get; set; }
        public string Number { get; set; }
        public string CANumber { get; set; }
        public decimal Amount { get; set; }
    }

    public class RechargeResult
    {
        public int id { get; set; }
        public bool status { get; set; }
        public string message { get; set; }
        public string isSuccess { get; set; }
    }
    public class RechargeReciept
    {
        public int ServiceId { get; set; }
        public string  RecieptNo { get; set; }
        public string Amount { get; set; }
        public string Number { get; set; }
        public string Status { get; set; }
        public string TxnId { get; set; }
        public string OperatorName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string MemberId { get; set; }
        public string OprId { get; set; }
        public CompanyModel company { get; set; }
    }
}
