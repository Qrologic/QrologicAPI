using QroApi.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QroApi.BLL
{
    public interface IUtilityService : IDisposable
    {
        public Task<Result> GetState(int countryId);
        public Task<Result> GetCity(int StateID);
        public Task<Result> GetRole(int userId);
        public Task<Result> GetPackage(int MsrNo);
        public Task<Result> GetCountry();

    }
}
