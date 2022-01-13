
using QroApi.DLL;
using QroApi.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QroApi.BLL
{
    public class Dashboard: IDashboard
    {
        #region [START : PROPERTIES]
        private readonly ISQLHelper _sqlHelper;
        #endregion

        #region[CONSTRUCTER]
        public Dashboard(ISQLHelper sqlHelper)
        {
            _sqlHelper = sqlHelper;
        }
        #endregion

        #region Get Admin Dashboard Data
        public async Task<DashboardModel> GetAdminDashboardByMsrNo(int msrno)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "Admin"));
            parameters.Add(new SqlParameter("@MsrNo", msrno));
            DashboardModel model = new DashboardModel();
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_Dashboard", parameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    model = ds.Tables[0].AsEnumerable().Select(s => new DashboardModel
                    {
                        Members = Convert.ToString(s["Members"] == DBNull.Value ? "" : s["Members"]),
                        Sd = Convert.ToString(s["Sd"] == DBNull.Value ? "" : s["Sd"]),
                        Md = Convert.ToString(s["Md"] == DBNull.Value ? "" : s["Md"]),
                        Dt = Convert.ToString(s["Dt"] == DBNull.Value ? "" : s["Dt"]),
                        Rt = Convert.ToString(s["Rt"] == DBNull.Value ? "" : s["Rt"]),
                        Packages = Convert.ToString(s["Packages"] == DBNull.Value ? "" : s["Packages"]),
                        FundRequest = Convert.ToString(s["FundRequest"] == DBNull.Value ? "" : s["FundRequest"]),
                        KYCApproval = Convert.ToString(s["KYCApproval"] == DBNull.Value ? "" : s["KYCApproval"]),
                        PendingTickets = Convert.ToString(s["PendingTickets"] == DBNull.Value ? "" : s["PendingTickets"]),
                        SuccessAmount = Convert.ToString(s["SuccessAmount"] == DBNull.Value ? "" : s["SuccessAmount"]),
                        FailedAmount = Convert.ToString(s["FailedAmount"] == DBNull.Value ? "" : s["FailedAmount"]),
                        PendingAmount = Convert.ToString(s["PendingAmount"] == DBNull.Value ? "" : s["PendingAmount"]),
                        DMRSuccessAmount = Convert.ToString(s["DMRSuccessAmount"] == DBNull.Value ? "" : s["DMRSuccessAmount"]),
                        DMRFailedAmount = Convert.ToString(s["DMRFailedAmount"] == DBNull.Value ? "" : s["DMRFailedAmount"]),
                        DMRPendingAmount = Convert.ToString(s["DMRPendingAmount"] == DBNull.Value ? "" : s["DMRPendingAmount"]),
                        SDBalance = Convert.ToString(s["SDBalance"] == DBNull.Value ? "" : s["SDBalance"]),
                        MDBalance = Convert.ToString(s["MDBalance"] == DBNull.Value ? "" : s["MDBalance"]),
                        DTBalance = Convert.ToString(s["DTBalance"] == DBNull.Value ? "" : s["DTBalance"]),
                        RTBalance = Convert.ToString(s["RTBalance"] == DBNull.Value ? "" : s["RTBalance"]),
                        Balance = Convert.ToString(s["Balance"] == DBNull.Value ? "" : s["Balance"]),
                        IsElectricity = Convert.ToBoolean(s["IsElectricity"] == DBNull.Value ? 0 : s["IsElectricity"])
                    }).FirstOrDefault();
                }
            }
            return model;
        }
        #endregion

        #region Get Member Dashboard Data
        public async Task<DashboardModel> GetMemberDashboardByMsrNo(int msrno)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "Member"));
            parameters.Add(new SqlParameter("@MsrNo", msrno));
            DashboardModel model = new DashboardModel();
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_Dashboard", parameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    model = ds.Tables[0].AsEnumerable().Select(s => new DashboardModel
                    {                        
                        SuccessAmount = Convert.ToString(s["SuccessAmount"] == DBNull.Value ? "" : s["SuccessAmount"]),
                        FailedAmount = Convert.ToString(s["FailedAmount"] == DBNull.Value ? "" : s["FailedAmount"]),
                        PendingAmount = Convert.ToString(s["PendingAmount"] == DBNull.Value ? "" : s["PendingAmount"]),                      
                        RechargeEarning = Convert.ToString(s["RechargeEarning"] == DBNull.Value ? "" : s["RechargeEarning"])
                    }).FirstOrDefault();
                }
            }
            return model;
        }
        #endregion

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }
                disposedValue = true;
            }
        }
        void IDisposable.Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
