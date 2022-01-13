using QroApi.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QroApi.BLL
{
    public interface IRecharge : IDisposable
    {
        Task<Result> AddEditRechargeAPI(RechargeApiModel model);
        Task<RechargeApiModel> GetAPIById(int id);
        Task<ReportList> GetAllAPIList(string search, int pageIndex, int pageSize, string sortCol, string sortDir);
        Task<Result> DeleteAPI(int id);
        Task<Result> ActiveAPI(int id);
        Task<Result> GetAPI();
        Task<Result> AddEditOperator(Operator model);
        Task<Operator> GetOperatorById(int id);
        Task<ReportList> GetAllOperator(string search, int pageIndex, int pageSize, string sortCol, string sortDir);
        Task<Result> DeleteOperator(int id);
        Task<Result> ActiveOperator(int id);
        Task<Result> GetService();
        Task<Result> GetServiceForFilter();
        Task<Result> AddEditService(ServiceModel model);
        Task<ServiceModel> GetServiceById(int id);
        Task<ReportList> GetAllService(string search, int pageIndex, int pageSize, string sortCol, string sortDir);
        Task<Result> DeleteService(int id);
        Task<Result> ActiveService(int id);
        Task<Result> AddEditCircle(CircleModel model);
        Task<CircleModel> GetCircleById(int id);
        Task<ReportList> GetAllCircle(string search, int pageIndex, int pageSize, string sortCol, string sortDir);
        Task<Result> DeleteCircle(int id);
        Task<Result> ActiveCircle(int id);
        Task<List<OperatorCodeModel>> GetOperatorForAPI(int serviceId, int apiId);
        Task<Result> SaveOperatorCode(OperatorCodeModel[] modelArray, int apiId);
        Task<List<CircleCodeModel>> GetCircleForAPI(int apiId);
        Task<Result> SaveCircleCode(CircleCodeModel[] modelArray, int apiId);
        Task<List<RechargeCommission>> GetCommission(int packageId, int myPackageId, int serviceId, string action);
        Task<Result> SaveCommission(RechargeCommission[] modelArray, int packageId);
        Task<ApiList> GetAPIWithBalance();
        Task<Result> SwitchApi(int apiId);
        Task<Result> SwitchPackageWiseApi(int apiId, int packageId);
        Task<OperatorWiseApi> GetOperatorByServiceId(int serviceId);
        Task<Result> GetOperatorByServiceIdForFilter(int serviceId);
        Task<Result> SwitchOperatorWiseApi(OperatorWiseApi[] modelArray);
        Task<string> CallApi(string url, int apiId);
        Task<ReportList> MyCommission(string search, int pageIndex, int pageSize, string sortCol, string sortDir, int myPackageId, int msrNo);
        Task<Result> GetRechargeServiceByPackageId(int packageId);
        Task<List<TxnRecharge>> GetPendingRecharge();
        Task<Result> CheckStatus(TxnRecharge[] txnArray);
        Task<Result> ForceFailed(TxnRecharge[] txnArray);
        Task<Result> ForceSuccess(TxnRecharge[] txnArray);
        
       
    }

}
