using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QroApi.MODEL
{
    public class RechargeCommission
    {
        public int Id { get; set; }
        public int OperatorId { get; set; }
        public int ActiveApi { get; set; }
        public int PackageId { get; set; }
        public string ServiceName { get; set; }
        public string OperatorName { get; set; }
        public string MyCommission { get; set; }
        public decimal Commission { get; set; }
        public bool IsFlat { get; set; }

        public decimal sdComm { get; set; }
        public bool sdIsFlat { get; set; }
        public decimal mdComm { get; set; }
        public bool mdIsFlat { get; set; }
        public decimal dtComm { get; set; }
        public bool dtIsFlat { get; set; }
        public decimal rtComm { get; set; }
        public bool rtIsFlat { get; set; }
        public decimal gstRate { get; set; } = 0;
        public decimal tdsRate { get; set; } = 0;
        public List<RechargeCommission> list { get; set; }
    }

    public class MyCommissionModel
    {
        public int SrNo { get; set; }
        public string ServiceName { get; set; }
        public string OperatorName { get; set; }
        public string MyCommission { get; set; }
       
    }
}
