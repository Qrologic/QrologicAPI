using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QroApi.MODEL
{
    public class TxnRecharge
    {
        public int Id { get; set; }
        public int SrNo { get; set; }
        public string MemberId { get; set; }
        public string Name { get; set; }
        public string ServiceName { get; set; }
        public string OperatorName { get; set; }
        public string Number { get; set; }
        public string Amount { get; set; }
        public string Status { get; set; }
        public string TxnId { get; set; }
        public string ApiTxnId { get; set; }
        public string OprId { get; set; }
        public string Date { get; set; }     
        public List<TxnRecharge> list { get; set; }
    }
    public class TxnRechargeResponse
    {
        public int Id { get; set; }
        public int SrNo { get; set; }
        public string MemberId { get; set; }
        public string Name { get; set; }
        public string Service { get; set; }
        public string Operator { get; set; }
        public string Number { get; set; }
        public string Amount { get; set; }
        public string Status { get; set; }
        public string TxnId { get; set; }       
        public string TransactionDate { get; set; }
        public string SettlementDate { get; set; }
    }
    public class MonthlyRechargeCommission
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
