using QroApi.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QroApi.BLL
{
    public interface IUtility : IDisposable
    {
        Task<ReportList> GetStateList(string search, int pageIndex, int pageSize, string sortCol, string sortDir);
        Task<StateModel> GetStateById(int id);
        Task<Result> GetCountry();
        Task<Result> GetState(int countryId);
        Task<Result> AddEditState(StateModel model);
        Task<Result> DeleteState(int id);
        Task<Result> ActiveState(int id);

        Task<ReportList> GetCityList(string search, int pageIndex, int pageSize, string sortCol, string sortDir);
        Task<CityModel> GetCityById(int id);
        Task<Result> GetCity(int stateId);
        Task<Result> AddEditCity(CityModel model);
        Task<Result> DeleteCity(int id);
        Task<Result> ActiveCity(int id);
        Task<ReportList> GetPackageList(string search, int pageIndex, int pageSize, string sortCol, string sortDir, int msrNo);
        Task<PackageModel> GetPackageById(int id);
        Task<Result> GetPackage(int msrNo);
        Task<Result> AddEditPackage(PackageModel model);
        Task<Result> DeletePackage(int id);
        Task<Result> ActivePackage(int id);

        Task<Result> GetRoleForRegistration(int? id, int userId);
        Task<Result> GetRoleForEmployee(int? id, int userId);
        Task<Result> GetRoleForRights(int userId);
        Task<Result> AssigneServiceOnPackage(AssignedService[] modelArray, int packageId);
        Task<AssignedService> GetServiceByPackageId(int packageId);
        Task<Result> GetBank();

        Task<AssignedService> GetServiceByMsrNo(int MsrNo);
        Task<Result> AssigneServiceOnMsrNo(AssignedService[] modelArray, int MsrNo);
        Task<ReportList> GetSupportList(string search, int pageIndex, int pageSize, string sortCol, string sortDir, int msrNo, CommonFilter model);
        Task<SupportModel> GetSupportById(int id);
        Task<Result> GetPriority();
        Task<Result> GetDepartment();
        Task<Result> CreateTicket(SupportModel model);
        Task<Result> CloseTicket(int id);
        Task<Result> GetServiceForFilter();
    }
}
