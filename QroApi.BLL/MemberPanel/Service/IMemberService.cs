using QroApi.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QroApi.BLL
{
    public interface IMemberService:IDisposable
    {
        Task<MemberServiceModel> GetServiceByPackageId(int msrNo);
        Task<Result> GetOpertorByServiceId(int serviceId);
        Task<Result> GetCircle();
        Task<RechargeResult> RechargeProcess(RechargePorcessModel model, string source, int msrNo);
        Task<string> ManageRechargeCallback(string queryString);
        Task<bool> UpdateRechargeTransactionByCallback(string status, string oprId, string txnId, string agentId, string callbackUrl);
        Task<Result> GetOpertorDetailById(int id);
        Task<string> BillFatch(BBPS.BillFatch model);
        Task<RechargeReciept> RechargeReciept(int id, int msrNo);
        Task<BBPS.Response> BillPay(BBPS.BillPayRequest model, string source, int msrNo);
    }
}
