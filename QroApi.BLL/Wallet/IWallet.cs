using QroApi.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QroApi.BLL
{
    public interface IWallet :IDisposable
    {
        Task<ReportList> GetWalletList(string search, int pageIndex, int pageSize, string sortCol, string sortDir, int msrNo, CommonFilter model = null);
        Task<ReportList> GetAllWalletTransactionList(string search, int pageIndex, int pageSize, string sortCol, string sortDir, int? MsrNo, CommonFilter model);
        Task<ReportList> GetWalletTransactionList(string search, int pageIndex, int pageSize, string sortCol, string sortDir, int? MsrNo, CommonFilter model);
        Task<AddDeductFundModel> GetBalanceByMsrNo(int MsrNo);
        Task<Result> AddFund(AddDeductFundModel model);
        Task<Result> AddEditBalanceRequest(BalanceRequestModel model);
        Task<BalanceRequestModel> GetBalanceRequestById(int id);
        Task<Result> GetBankForRequest();
        Task<ReportList> GetSelfRequest(string search, int pageIndex, int pageSize, string sortCol, string sortDir, int msrNo);
        Task<Result> CancelRequest(int id, string remark);
        Task<ReportList> GetDownlineRequest(string search, int pageIndex, int pageSize, string sortCol, string sortDir, int msrNo);
        Task<Result> ApproveRequest(int id);
        Task<TxnDetailModel> GetTransactionDetail(int id, int msrNo);
        Task<Top10Transaction> GetTop10Transaction(int MsrNo);
    }
}
