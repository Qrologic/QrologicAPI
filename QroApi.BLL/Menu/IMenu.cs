using QroApi.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QroApi.BLL
{
    public interface IMenu : IDisposable
    {
        Task<Result> GetFirstLevelMenu();
        Task<Result> AddEditAdminMenu(MenuModel model);
        Task<ReportList> GetAllAdminMenu(string search, int pageIndex, int pageSize, string sortCol, string sortDir);
        Task<Result> ActiveAdminMenu(int id);
        Task<Result> DeleteAdminMenu(int id);
        Task<MenuModel> GetMenuById(int id);
        Task<MenuModel> BindAdminMenu(string UserId);
        Task<List<MenuDisplay>> GetMenuTreeBind(int roleID);
        Task<Result> SaveCheckedTreeNodes(List<int> checkedIds, int RoleID, int CUserID, string IP);

        Task<Result> MemberFirstLevelMenu();
        Task<Result> AddEditMemberMenu(MenuModel model);
        Task<ReportList> GetAllMemberMenu(string search, int pageIndex, int pageSize, string sortCol, string sortDir);
        Task<Result> ActiveMemberMenu(int id);
        Task<Result> DeleteMemberMenu(int id);
        Task<MenuModel> GetMemberMenuById(int id);
        Task<MenuModel> BindMemberMenu(string UserId);
        Task<RoleResponse> GetRoleList(int MsrNo);
        Task<Result> ActiveRole(int id);
        Task<RoleModel> GetRoleById(int id);
        Task<Result> AddEditRole(RoleModel model);
    }
}
