using QroApi.MODEL;
using System;
using System.Threading.Tasks;

namespace QroApi.BLL
{
    public interface ISettings:IDisposable
    {
        Task<CompanyModel> GetCompanyDetailById(int id);
        Task<Result> AddEditCompanyDetail(CompanyModel model);
        Task<Result> ActiveMemberBank(int id);
        Task<Result> AddEditMemberBank(MemberBankModel model);
        Task<Result> DeleteMemberBank(int id);
        Task<MemberBankModel> GetMemberBankById(int id);
        Task<ReportList> GetMemberBankList(string search, int pageIndex, int pageSize, string sortCol, string sortDir, int msrNo);
        
        Task<Result> UpdateCompanyLogo(CompanyModel model, string type);
    }
}