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
    public class Wallet : IWallet
    {
        #region [START : PROPERTIES]
        private readonly ISQLHelper _sqlHelper;
        private readonly ISettings _iSettings;
        #endregion

        #region[CONSTRUCTER]
        public Wallet(ISQLHelper sqlHelper, ISettings iSettings)
        {
            _sqlHelper = sqlHelper;
            _iSettings = iSettings;
        }
        #endregion

        #region Wallet
        #region Get Wallet List
        public async Task<ReportList> GetWalletList(string search, int pageIndex, int pageSize, string sortCol, string sortDir, int msrNo, CommonFilter model)
        {
            ReportList rpList = new ReportList();
            List<WalletResponse> list = new List<WalletResponse>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "GetAll"));
            parameters.Add(new SqlParameter("@MsrNo", msrNo));

            parameters.Add(new SqlParameter("@UserRole", model.option1 == null ? 0 : model.option1));
            parameters.Add(new SqlParameter("@MemberId", model.option3 == null ? "" : model.option3));
            parameters.Add(new SqlParameter("@Name", model.option4 == null ? "" : model.option4));
            parameters.Add(new SqlParameter("@Mobile", model.option5 == null ? "" : model.option5));
            parameters.Add(new SqlParameter("@Email", model.option6 == null ? "" : model.option6));


            parameters.Add(new SqlParameter("@PageIndex", pageIndex));
            parameters.Add(new SqlParameter("@PageSize", pageSize));
            parameters.Add(new SqlParameter("@Search", search));
            parameters.Add(new SqlParameter("@OrderColumn", sortCol));
            parameters.Add(new SqlParameter("@OrderDir", sortDir));
            int totalRecord = 0;
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageEWallet", parameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataView dv = new DataView(ds.Tables[0]);
                    dv.Sort = sortCol + " " + sortDir;
                    totalRecord = Convert.ToInt32(ds.Tables[0].Rows[0]["TotalRow"].ToString());
                    list = dv.ToTable().AsEnumerable().Select(s => new WalletResponse
                    {
                        SrNo = s["SrNo"] == DBNull.Value ? 0 : Convert.ToInt32(s["SrNo"]),
                        MemberId = s["MemberId"] == DBNull.Value ? "" : Convert.ToString(s["MemberId"]),
                        Name = s["Name"] == DBNull.Value ? "" : Convert.ToString(s["Name"]),
                        Debit = s["Debit"] == DBNull.Value ? "" : Convert.ToString(s["Debit"]),
                        Credit = s["Credit"] == DBNull.Value ? "" : Convert.ToString(s["Credit"]),
                        Balance = s["Balance"] == DBNull.Value ? "" : Convert.ToString(s["Balance"]),
                        Action = s["Action"] == DBNull.Value ? "" : Convert.ToString(s["Action"])
                    }).ToList();
                }
            }
            rpList.recordsFiltered = totalRecord;
            rpList.recordsTotal = totalRecord;
            rpList.data = list;
            return rpList;
        }
        #endregion

        #region Get Wallet Transaction List
        public async Task<ReportList> GetWalletTransactionList(string search, int pageIndex, int pageSize, string sortCol, string sortDir, int? MsrNo, CommonFilter model)
        {
            ReportList rpList = new ReportList();
            List<WalletTransactionResponse> list = new List<WalletTransactionResponse>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "OnlyWalletTransactionGetByMsrNo"));
            parameters.Add(new SqlParameter("@MsrNo", MsrNo));
            parameters.Add(new SqlParameter("@fromDate", model.fromDate == null ? "01/01/2015" : model.fromDate));
            parameters.Add(new SqlParameter("@todate", model.toDate == null ? "01/01/2100" : model.toDate));
            parameters.Add(new SqlParameter("@Status", model.status == null ? "" : model.status));
            parameters.Add(new SqlParameter("@TxnId", model.option2 == null ? "" : model.option2));
            parameters.Add(new SqlParameter("@MemberId", model.option3 == null ? "" : model.option3));
             parameters.Add(new SqlParameter("@Narration", ""));
            parameters.Add(new SqlParameter("@PageIndex", pageIndex));
            parameters.Add(new SqlParameter("@PageSize", pageSize));
            parameters.Add(new SqlParameter("@Search", search));
            int totalRecord = 0;
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageEWalletTransaction", parameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataView dv = new DataView(ds.Tables[0]);
                    dv.Sort = sortCol + " " + sortDir;
                    totalRecord = Convert.ToInt32(ds.Tables[0].Rows[0]["TotalRow"].ToString());
                    list = dv.ToTable().AsEnumerable().Select(s => new WalletTransactionResponse
                    {
                        SrNo = s["SrNo"] == DBNull.Value ? 0 : Convert.ToInt32(s["SrNo"]),
                        Member = s["MemberDetail"] == DBNull.Value ? "" : Convert.ToString(s["MemberDetail"]),
                        Amount = s["Amount"] == DBNull.Value ? "" : Convert.ToString(s["Amount"]),
                        Balance = s["Balance"] == DBNull.Value ? "" : Convert.ToString(s["Balance"]),
                        Status = s["Status"] == DBNull.Value ? "" : Convert.ToString(s["Status"]),
                        Remark = s["Remark"] == DBNull.Value ? "" : Convert.ToString(s["Remark"]),
                        Service = s["Service"] == DBNull.Value ? "" : Convert.ToString(s["Service"]),
                        Mobile = s["Mobile"] == DBNull.Value ? "" : Convert.ToString(s["Mobile"]),
                        TransId = s["TransId"] == DBNull.Value ? "" : Convert.ToString(s["TransId"]),
                        Date = s["AddedDate"] == DBNull.Value ? "" : Convert.ToString(s["AddedDate"]),
                        Receipt = s["Action"] == DBNull.Value ? "" : Convert.ToString(s["Action"])
                    }).ToList();
                }
            }
            rpList.recordsFiltered = totalRecord;
            rpList.recordsTotal = totalRecord;
            rpList.data = list;
            return rpList;
        }
        #endregion

        #region Get Wallet Transaction List
        public async Task<ReportList> GetAllWalletTransactionList(string search, int pageIndex, int pageSize, string sortCol, string sortDir, int? MsrNo, CommonFilter model)
        {
            ReportList rpList = new ReportList();
            List<WalletTransactionResponse> list = new List<WalletTransactionResponse>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "GetByMsrNo"));
            parameters.Add(new SqlParameter("@MsrNo", MsrNo));
            parameters.Add(new SqlParameter("@fromDate", model.fromDate == null ? "01/01/2015" : model.fromDate));
            parameters.Add(new SqlParameter("@todate", model.toDate == null ? "01/01/2100" : model.toDate));
            parameters.Add(new SqlParameter("@Status", model.status == null ? "" : model.status));
            parameters.Add(new SqlParameter("@ServiceId", model.option1 == null ? 0 : Convert.ToInt32(model.option1)));
            parameters.Add(new SqlParameter("@TxnId", model.option2 == null ? "" : model.option2));
            parameters.Add(new SqlParameter("@MemberId", model.option3 == null ? "" : model.option3));
            parameters.Add(new SqlParameter("@ApiTxnId", model.option4 == null ? "" : model.option4));
            parameters.Add(new SqlParameter("@RefNo", model.option5 == null ? "" : model.option5));
            parameters.Add(new SqlParameter("@Number", model.option6 == null ? "" : model.option6));
            parameters.Add(new SqlParameter("@OperatorId", model.option7 == null ? 0 : model.option7));
            parameters.Add(new SqlParameter("@Narration", ""));
            parameters.Add(new SqlParameter("@PageIndex", pageIndex));
            parameters.Add(new SqlParameter("@PageSize", pageSize));
            parameters.Add(new SqlParameter("@Search", search));
            int totalRecord = 0;
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageEWalletTransaction", parameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataView dv = new DataView(ds.Tables[0]);
                    dv.Sort = sortCol + " " + sortDir;
                    totalRecord = Convert.ToInt32(ds.Tables[0].Rows[0]["TotalRow"].ToString());
                    list = dv.ToTable().AsEnumerable().Select(s => new WalletTransactionResponse
                    {
                        SrNo = s["SrNo"] == DBNull.Value ? 0 : Convert.ToInt32(s["SrNo"]),
                        Member = s["MemberDetail"] == DBNull.Value ? "" : Convert.ToString(s["MemberDetail"]),
                        Amount = s["Amount"] == DBNull.Value ? "" : Convert.ToString(s["Amount"]),
                        Balance = s["Balance"] == DBNull.Value ? "" : Convert.ToString(s["Balance"]),
                        Status = s["Status"] == DBNull.Value ? "" : Convert.ToString(s["Status"]),
                        Remark = s["Remark"] == DBNull.Value ? "" : Convert.ToString(s["Remark"]),
                        Service = s["Service"] == DBNull.Value ? "" : Convert.ToString(s["Service"]),
                        Mobile = s["Mobile"] == DBNull.Value ? "" : Convert.ToString(s["Mobile"]),
                        TransId = s["TransId"] == DBNull.Value ? "" : Convert.ToString(s["TransId"]),
                        Date = s["AddedDate"] == DBNull.Value ? "" : Convert.ToString(s["AddedDate"]),
                        Receipt = s["Action"] == DBNull.Value ? "" : Convert.ToString(s["Action"])
                    }).ToList();
                }
            }
            rpList.recordsFiltered = totalRecord;
            rpList.recordsTotal = totalRecord;
            rpList.data = list;
            return rpList;
        }
        #endregion

        #region Get Wallet Top 10 Transaction 
        public async Task<Top10Transaction> GetTop10Transaction(int MsrNo)
        {
            Top10Transaction model = new Top10Transaction();

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "GetByMsrNoTop10"));
            parameters.Add(new SqlParameter("@MsrNo", MsrNo));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageEWalletTransaction", parameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    model.list = ds.Tables[0].AsEnumerable().Select(s => new Top10Transaction
                    {
                        SrNo = s["SrNo"] == DBNull.Value ? 0 : Convert.ToInt32(s["SrNo"]),
                        Status = s["Status"] == DBNull.Value ? "" : Convert.ToString(s["Status"]),
                        Amount = s["Amount"] == DBNull.Value ? "" : Convert.ToString(s["Amount"]),
                        Balance = s["Balance"] == DBNull.Value ? "" : Convert.ToString(s["Balance"]),
                        Remark = s["Remark"] == DBNull.Value ? "" : Convert.ToString(s["Remark"]),
                        Service = s["Service"] == DBNull.Value ? "" : Convert.ToString(s["Service"]),
                        Date = s["AddedDate"] == DBNull.Value ? "" : Convert.ToString(s["AddedDate"]),
                        Action = s["Action"] == DBNull.Value ? "" : Convert.ToString(s["Action"])
                    }).ToList();
                }
            }
            return model;
        }
        #endregion

        #region Get Transaction Detail
        public async Task<TxnDetailModel> GetTransactionDetail(int id, int msrNo)
        {

            TxnDetailModel model = new TxnDetailModel();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "GetByWalletId"));
            parameters.Add(new SqlParameter("@Id", id));
            parameters.Add(new SqlParameter("@MsrNo", msrNo));
            CompanyModel company = new CompanyModel();

            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageEWalletTransaction", parameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    model = ds.Tables[0].AsEnumerable().Select(s => new TxnDetailModel
                    {
                        ServiceId = s["ServiceId"] == DBNull.Value ? 0 : Convert.ToInt32(s["ServiceId"]),
                        Amount = s["TransactionAmount"] == DBNull.Value ? 0 : Convert.ToDecimal(s["TransactionAmount"]),
                        Factor = s["Factor"] == DBNull.Value ? "" : Convert.ToString(s["Factor"]),
                        Remark = s["Narration"] == DBNull.Value ? "" : Convert.ToString(s["Narration"]),
                        TxnId = s["TransId"] == DBNull.Value ? "" : Convert.ToString(s["TransId"]),
                        ApiTxnId = s["ApiTxnId"] == DBNull.Value ? "" : Convert.ToString(s["ApiTxnId"]),
                        TxnDate = s["Date"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(s["Date"]),
                        Status = s["Status"] == DBNull.Value ? "" : Convert.ToString(s["Status"]),
                        RefNo = s["RefNo"] == DBNull.Value ? "" : Convert.ToString(s["RefNo"]),
                        Number = s["Number"] == DBNull.Value ? "" : Convert.ToString(s["Number"]),
                        OperatorName = s["OperatorName"] == DBNull.Value ? "" : Convert.ToString(s["OperatorName"]),
                        ServiceCode = s["ServiceCode"] == DBNull.Value ? "" : Convert.ToString(s["ServiceCode"]),
                        Ifsc = s["IFSC"] == DBNull.Value ? "" : Convert.ToString(s["IFSC"]),
                        SenderMobile = s["SenderMobile"] == DBNull.Value ? "" : Convert.ToString(s["SenderMobile"]),
                        Sender = s["Sender"] == DBNull.Value ? "" : Convert.ToString(s["Sender"]),
                        Reciever = s["Reciever"] == DBNull.Value ? "" : Convert.ToString(s["Reciever"]),
                        Bank = s["Bank"] == DBNull.Value ? "" : Convert.ToString(s["Bank"]),
                        PaymentMode = s["PaymentMode"] == DBNull.Value ? "" : Convert.ToString(s["PaymentMode"]),
                        Surcharge = s["Surcharge"] == DBNull.Value ? "" : Convert.ToString(s["Surcharge"]),
                        OrderId = s["stxnId"] == DBNull.Value ? "" : Convert.ToString(s["stxnId"]),
                        AgentName = s["Name"] == DBNull.Value ? "" : Convert.ToString(s["Name"]),
                        AgentMobile = s["Mobile"] == DBNull.Value ? "" : Convert.ToString(s["Mobile"]),
                    }).FirstOrDefault();
                }
            }
            company = await _iSettings.GetCompanyDetailById(1);
            model.company = company;
            return model;
        }
        #endregion

        #region GetBalanceByMsrNo
        public async Task<AddDeductFundModel> GetBalanceByMsrNo(int MsrNo)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "GetByMsrNo"));
            parameters.Add(new SqlParameter("@MsrNo", MsrNo));
            AddDeductFundModel model = new AddDeductFundModel();
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageEWallet", parameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    model = ds.Tables[0].AsEnumerable().Select(s => new AddDeductFundModel
                    {
                        ToMsrNo = Convert.ToInt32(s["MsrNo"] == DBNull.Value ? 0 : s["MsrNo"]),
                        MemberId = s["MemberId"] == DBNull.Value ? "" : Convert.ToString(s["MemberId"]),
                        Balance = s["Balance"] == DBNull.Value ? 0 : Convert.ToDecimal(s["Balance"])
                    }).FirstOrDefault();
                }
            }
            return model;
        }
        #endregion

        #region Add Deduct Balance
        public async Task<Result> AddFund(AddDeductFundModel model)
        {
            DataSet ds = new DataSet();

            List<SqlParameter> parameters = new List<SqlParameter>();
            if (model.ToMsrNo == 1)
            {
                parameters.Add(new SqlParameter("@MsrNo", model.ToMsrNo));
                parameters.Add(new SqlParameter("@Amount", model.Amount));
                parameters.Add(new SqlParameter("@Factor", model.Factor));
                parameters.Add(new SqlParameter("@Narration", model.Narration));
                parameters.Add(new SqlParameter("@Source", model.Source));
                parameters.Add(new SqlParameter("@ServiceId", 0));
                parameters.Add(new SqlParameter("@IsReturn", model.IsReturn));
                ds = await _sqlHelper.ExecuteProcedure("SP_AddEditEWallet", parameters.ToArray());
            }
            else
            {
                parameters.Add(new SqlParameter("@Action", model.Factor == "Cr" ? "Add" : "Deduct"));
                parameters.Add(new SqlParameter("@FromMsrNo", model.FromMsrNo));
                parameters.Add(new SqlParameter("@ToMsrNo", model.ToMsrNo));
                parameters.Add(new SqlParameter("@Amount", model.Amount));
                parameters.Add(new SqlParameter("@Remark", model.Narration));
                parameters.Add(new SqlParameter("@Source", model.Source));
                ds = await _sqlHelper.ExecuteProcedure("SP_WalletToWalletTransfer", parameters.ToArray());
            }
            Result result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = Convert.ToBoolean(s["Status"]), Message = s.Field<string>("Message") }).First();
            return result;
        }
        #endregion

        #endregion

        #region Balance Request

        #region Add Edit Balance Request
        public async Task<Result> AddEditBalanceRequest(BalanceRequestModel model)
        {
            Result result = new Result();
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@Action", "Insert"));
                parameters.Add(new SqlParameter("@Id", model.Id));
                parameters.Add(new SqlParameter("@MsrNo", model.MsrNo));
                parameters.Add(new SqlParameter("@Amount", model.Amount));
                parameters.Add(new SqlParameter("@PaymentMode", model.PaymentMode));
                parameters.Add(new SqlParameter("@PaymentProof", model.@PaymentProof));
                parameters.Add(new SqlParameter("@ChequeNumber", model.@ChequeNumber));
                parameters.Add(new SqlParameter("@ChequeDate", model.ChequeDate));
                parameters.Add(new SqlParameter("@PayDate", model.PayDate));
                parameters.Add(new SqlParameter("@Remark", model.Remark));
                parameters.Add(new SqlParameter("@ToBank", model.ToBank));
                parameters.Add(new SqlParameter("@RefNo", model.RefNo));
                parameters.Add(new SqlParameter("@Source", model.Source));
                DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageBalanceRequest", parameters.ToArray());
                result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = Convert.ToBoolean(s["Status"]), Message = s.Field<string>("Message") }).First();
            }
            catch (Exception ex)
            {
                result = new Result { Status = false, Message = ex.Message.ToString() };
            }
            return result;
        }
        #endregion

        #region Get Balance Request By Id
        public async Task<BalanceRequestModel> GetBalanceRequestById(int id)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "GetById"));
            parameters.Add(new SqlParameter("@Id", id));
            BalanceRequestModel model = new BalanceRequestModel();
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageBalanceRequest", parameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    model = ds.Tables[0].AsEnumerable().Select(s => new BalanceRequestModel
                    {
                        Id = s["Id"] == DBNull.Value ? 0 : Convert.ToInt32(s["Id"]),
                        MsrNo = s["MsrNo"] == DBNull.Value ? 0 : Convert.ToInt32(s["MsrNo"]),
                        Amount = s["Amount"] == DBNull.Value ? 0 : Convert.ToDecimal(s["Amount"]),
                        PaymentMode = s["PaymentMode"] == DBNull.Value ? "" : Convert.ToString(s["PaymentMode"]),
                        PaymentProof = s["PaymentProof"] == DBNull.Value ? "" : Convert.ToString(s["PaymentProof"]),
                        ChequeNumber = s["ChequeNumber"] == DBNull.Value ? "" : Convert.ToString(s["ChequeNumber"]),
                        PayDate = s["PayDate"] == DBNull.Value ? "" : Convert.ToString(s["PayDate"]),
                        Remark = s["Remark"] == DBNull.Value ? "" : Convert.ToString(s["Remark"]),
                        ToBank = s["ToBank"] == DBNull.Value ? "" : Convert.ToString(s["ToBank"]),
                        RefNo = s["RefNo"] == DBNull.Value ? "" : Convert.ToString(s["RefNo"]),
                        Source = s["Source"] == DBNull.Value ? "" : Convert.ToString(s["Source"]),
                    }).FirstOrDefault();
                }
            }
            return model;
        }
        #endregion

        #region Get Bank For Request
        public async Task<Result> GetBankForRequest()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "GetDDL"));

            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageBank", parameters.ToArray());
            Result result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = true, Message = "Data Fatched" }).First();
            result.Results = ds.Tables[0].AsEnumerable().Select(s => new
            {
                Id = s.Field<string>("BankName"),
                Name = s.Field<string>("BankName")
            }).ToList();
            return result;
        }
        #endregion

        #region List Request
        public async Task<ReportList> GetSelfRequest(string search, int pageIndex, int pageSize, string sortCol, string sortDir, int msrNo)
        {
            ReportList rpList = new ReportList();
            List<BalanceRequestList> list = new List<BalanceRequestList>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "GetByMsrNo"));
            parameters.Add(new SqlParameter("@MsrNo", msrNo));
            parameters.Add(new SqlParameter("@PageIndex", pageIndex));
            parameters.Add(new SqlParameter("@PageSize", pageSize));
            parameters.Add(new SqlParameter("@Search", search));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageBalanceRequest", parameters.ToArray());
            rpList = await BindRequestData(ds, sortCol, sortDir);

            return rpList;
        }
        public async Task<ReportList> GetDownlineRequest(string search, int pageIndex, int pageSize, string sortCol, string sortDir, int msrNo)
        {
            ReportList rpList = new ReportList();
            List<BalanceRequestList> list = new List<BalanceRequestList>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "GetByParentMsrNo"));
            parameters.Add(new SqlParameter("@MsrNo", msrNo));
            parameters.Add(new SqlParameter("@PageIndex", pageIndex));
            parameters.Add(new SqlParameter("@PageSize", pageSize));
            parameters.Add(new SqlParameter("@Search", search));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageBalanceRequest", parameters.ToArray());
            rpList = await BindRequestData(ds, sortCol, sortDir);

            return rpList;
        }
        public async Task<ReportList> BindRequestData(DataSet ds, string sortCol, string sortDir)
        {
            int totalRecord = 0;
            ReportList rpList = new ReportList();
            List<BalanceRequestList> list = new List<BalanceRequestList>();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataView dv = new DataView(ds.Tables[0]);
                    dv.Sort = sortCol + " " + sortDir;
                    totalRecord = Convert.ToInt32(ds.Tables[0].Rows[0]["TotalRow"].ToString());
                    list = dv.ToTable().AsEnumerable().Select(s => new BalanceRequestList
                    {
                        SrNo = s["SrNo"] == DBNull.Value ? 0 : Convert.ToInt32(s["SrNo"]),
                        Status = s["Status"] == DBNull.Value ? "" : Convert.ToString(s["Status"]),
                        Amount = s["Amount"] == DBNull.Value ? "" : Convert.ToString(s["Amount"]),
                        PaymentMode = s["PaymentMode"] == DBNull.Value ? "" : Convert.ToString(s["PaymentMode"]),
                        Name = s["Name"] == DBNull.Value ? "" : Convert.ToString(s["Name"]),
                        RefNo = s["RefNo"] == DBNull.Value ? "" : Convert.ToString(s["RefNo"]),
                        PayDate = s["PayDate"] == DBNull.Value ? "" : Convert.ToString(s["PayDate"]),
                        Remark = s["Remark"] == DBNull.Value ? "" : Convert.ToString(s["Remark"]),
                        Date = s["Date"] == DBNull.Value ? "" : Convert.ToString(s["Date"]),
                        Action = s["Action"] == DBNull.Value ? "" : Convert.ToString(s["Action"])
                    }).ToList();
                }
            }
            rpList.recordsFiltered = totalRecord;
            rpList.recordsTotal = totalRecord;
            rpList.data = list;
            return rpList;
        }

        #endregion

        #region Cancel Request
        public async Task<Result> CancelRequest(int id, string remark)
        {
            Result result = new Result();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "Cancel"));
            parameters.Add(new SqlParameter("@Id", id));
            parameters.Add(new SqlParameter("@CancelReason", remark));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageBalanceRequest", parameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = Convert.ToBoolean(s["Status"]), Message = s.Field<string>("Message") }).First();
                }
            }
            return result;
        }
        #endregion

        #region Approve Request
        public async Task<Result> ApproveRequest(int id)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "Approve"));
            parameters.Add(new SqlParameter("@Id", id));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageBalanceRequest", parameters.ToArray());
            Result result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = Convert.ToBoolean(s["Status"]), Message = s.Field<string>("Message") }).First();
            return result;
        }
        #endregion

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
