using QroApi.MODEL;
using System;
using System.Threading.Tasks;

namespace QroApi.BLL
{
    public interface IMember : IDisposable
    {

        Task<Result> ActiveMember(int MsrNo);
        Task<Result> AddEditMember(MemberRegisterModel model);
        Task<MemberRegisterModel> GetMemberByMsrNo(int MsrNo);
        Task<ReportList> GetMemberList(string search, int pageIndex, int pageSize, string sortCol, string sortDir,int msrNo, CommonFilter model);
        Task<MemberDetail> GetMemberDetail(int msrNo);
        Task<Result> ActiveEmployee(int Id);
        Task<Result> AddEditEmployee(EmployeeRegisterModel model);
        Task<EmployeeRegisterModel> GetEmployeeById(int Id);
        Task<ReportList> GetEmployeeList(string search, int pageIndex, int pageSize, string sortCol, string sortDir, int userId);
        Task<int> GetMsrNo(string memberId);
        Task<string> GetMemberId(int msrNo);
        Task<Result> SearchMember(string search,int msrNo);
        Task<int> GetPackageId(int msrNo);
        Task<Result> ChangeMemberPassword(ChangePassword model);
        Task<Result> ChangeMemberTPassword(ChangePassword model);
        Task<Result> ChangePassword(ChangePassword model);
        Task<EmployeeDetail> GetEmployeeDetail(int id);
        Task<Result> ChangeEmployeePassword(ChangePassword model);
        Task<Result> ChangeEmployeeTPassword(ChangePassword model);
    }
}