using QroApi.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QroApi.BLL
{
    public interface IdmtApiService:IDisposable
    {
        Task<bool> IsAnyNullOrEmpty(object myObject);
        Task<basicApi.apiResponse> RemitterDetail(dmtApi.RemitterDetails_Request model, int msrNo, string ipAddress = "");
        Task<basicApi.apiResponse> RemitterRegistration(dmtApi.Request_RemitterRegistration model, int msrNo, string ipAddress = "");
        Task<basicApi.apiResponse> RemitterValidate(dmtApi.Request_RemitterValidate model, int msrNo, string ipAddress = "");
        Task<basicApi.apiResponse> BeneficiaryRegistration(dmtApi.Request_BeneficiaryRegistration model, int msrNo, string ipAddress = "");
        Task<basicApi.apiResponse> BeneficiaryRemove(dmtApi.Request_BeneficiaryRemove model, int msrNo, string ipAddress = "");
        Task<basicApi.apiResponse> BeneficiaryRemove_Validate(dmtApi.Request_BeneficiaryRemove_Validate model, int msrNo, string ipAddress = "");
        Task<basicApi.apiResponse> FundTransfer(dmtApi.Request_FundTransfer model, int msrNo, string ipAddress = "");
        Task<basicApi.apiResponse> TransactionStatus(dmtApi.TransactionStatus_Request model, int msrNo, string ipAddress = "");


    }
}
