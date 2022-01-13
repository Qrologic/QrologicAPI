using QroApi.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QroApi.BLL
{
    public interface IDMT : IDisposable
    {
        Task<string> GetJWTToken();
        Task<string> CallPostAPI(string method, string requestJson);
        Task<Result> GetBank();
        Task<Result> GetIFSCByBankId(int id);
        Task<dmtModels.Response> RemitterDetail(dmtModels.FatchRemitter model);
        Task<dmtModels.Response> RemitterRegistration(dmtModels.RemitterRegistration model);
        Task<dmtModels.Response> FetchBeneficiary(dmtModels.FetchBeneficiary model);
        Task<dmtModels.Response> RegisterBeneficiary(dmtModels.RegisterBeneficiary model);
        Task<dmtModels.Response> DeleteBeneficiary(dmtModels.DeleteBeneficiary model);
        Task<Result> VerifyBeneficiary(dmtModels.BeneficiaryVerify model, int msrNo, string source);
        Task<dmtBulkReciept> ConfirmTransaction(dmtModels.Transaction model, int msrNo, string source);
        Task<PendingDMT> GetPendingTransaction();
        Task<Result> TransactionEnquiry(TransactionEnquiry model);
        Task<ReportList> GetApiList();
        Task<Result> SwitchApi(int id);
        Task<PendingDMT> FindTransaction(string txnId);
        Task<dmtModels.Response> RefundTransaction(TransactionEnquiry model);
        Task<dmtModels.Response> SendOTPForRefund(TransactionEnquiry model);

        Task<Result> AddEditApiSurcharge(dmtApiCharge model);
        Task<ReportList> GetApiChargeByApiId(string search, int pageIndex, int pageSize, string sortCol, string sortDir, CommonFilter filetr);
        Task<dmtApiCharge> GetApiChargeById(int id);
        Task<Result> GetAPI();
        Task<Result> ForceUpdateTransaction(int id, int type);
        Task<ReportList> ApiBalance();
        Task<dmtReciept> dmtReciept(int id);
       
        Task<ReportList> ApiLogs(string search, int pageIndex, int pageSize, string sortCol, string sortDir, int msrNo, CommonFilter model);
      
    }
}
