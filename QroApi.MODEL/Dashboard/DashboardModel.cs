using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QroApi.MODEL
{
   public class DashboardModel
    {
        public string Members { get; set; }
        public string Sd { get; set; }
        public string Md { get; set; }
        public string Dt { get; set; }
        public string Rt { get; set; }
        public string Packages { get; set; }
        public string FundRequest { get; set; }
        public string KYCApproval { get; set; }
        public string PendingTickets { get; set; }
        public string SuccessAmount { get; set; }
        public string FailedAmount { get; set; }
        public string PendingAmount { get; set; }
        public string DMRSuccessAmount { get; set; }
        public string DMRFailedAmount { get; set; }
        public string DMRPendingAmount { get; set; }
        public string SDBalance { get; set; }
        public string MDBalance { get; set; }
        public string DTBalance { get; set; }
        public string RTBalance { get; set; }
        public string Balance { get; set; }
        public string RechargeEarning { get; set; }
        public bool IsElectricity { get; set; }
    }
}
