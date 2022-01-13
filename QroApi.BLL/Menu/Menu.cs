using QroApi.DLL;
using QroApi.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QroApi.BLL
{
    public class Menu : IMenu
    {
        #region [START : PROPERTIES]
        private readonly ISQLHelper _sqlHelper;
        #endregion

        #region[CONSTRUCTER]
        public Menu(ISQLHelper sqlHelper)
        {
            _sqlHelper = sqlHelper;
        }
        #endregion

        #region [Admin Menu]
        #region [Get First Level Menu For Admin]
        public async Task<Result> GetFirstLevelMenu()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "GetFirstLevel"));

            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageAdminMenu", parameters.ToArray());
            Result result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = true, Message = "Data Fatched" }).First();
            result.Results = ds.Tables[0].AsEnumerable().Select(s => new
            {
                Id = Convert.ToInt32(s["MenuId"]),
                MenuName = s.Field<string>("MenuName"),

            }).ToList();
            return result;
        }
        #endregion
        public async Task<Result> AddEditAdminMenu(MenuModel model)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "Insert"));
            parameters.Add(new SqlParameter("@Id", model.MenuId));
            parameters.Add(new SqlParameter("@EmpId", 0));
            parameters.Add(new SqlParameter("@MenuName", model.MenuName));
            parameters.Add(new SqlParameter("@Controller", model.ControllerName));
            parameters.Add(new SqlParameter("@ActionName", model.ActionName));
            parameters.Add(new SqlParameter("@MenuIcon", model.MenuIcon));
            parameters.Add(new SqlParameter("@Level", model.Level));
            parameters.Add(new SqlParameter("@Position", model.Position));
            parameters.Add(new SqlParameter("@ParentId", model.ParentId));
            parameters.Add(new SqlParameter("@MenuTitle", model.MenuTitle));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageAdminMenu", parameters.ToArray());
            Result result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = Convert.ToBoolean(s["Status"]), Message = s.Field<string>("Message") }).First();
            return result;
        }

        public async Task<ReportList> GetAllAdminMenu(string search, int pageIndex, int pageSize, string sortCol, string sortDir)
        {
            ReportList rpList = new ReportList();
            List<MenuResponse> menuList = new List<MenuResponse>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "GetAll"));
            parameters.Add(new SqlParameter("@PageIndex", pageIndex));
            parameters.Add(new SqlParameter("@PageSize", pageSize));
            parameters.Add(new SqlParameter("@Search", search));
            int totalRecord = 0;
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageAdminMenu", parameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataView dv = new DataView(ds.Tables[0]);
                    dv.Sort = sortCol + " " + sortDir;
                    totalRecord = Convert.ToInt32(ds.Tables[0].Rows[0]["TotalRow"].ToString());
                    menuList = dv.ToTable().AsEnumerable().Select(s => new MenuResponse
                    {
                        SrNo = Convert.ToInt32(s["SrNo"] == DBNull.Value ? 0 : s["SrNo"]),
                        MenuName = Convert.ToString(s["MenuName"] == DBNull.Value ? "" : s["MenuName"]),
                        ControllerName = Convert.ToString(s["ControllerName"] == DBNull.Value ? "" : s["ControllerName"]),
                        ActionName = Convert.ToString(s["ActionName"] == DBNull.Value ? "" : s["ActionName"]),
                        MenuTitle = Convert.ToString(s["MenuTitle"] == DBNull.Value ? "" : s["MenuTitle"]),
                        Action = Convert.ToString(s["Action"] == DBNull.Value ? "" : s["Action"])
                    }).ToList();
                }
            }
            rpList.recordsFiltered = totalRecord;
            rpList.recordsTotal = totalRecord;
            rpList.data = menuList;
            return rpList;
        }
        public async Task<MenuModel> GetMenuById(int id)
        {
            List<MenuResponse> menuList = new List<MenuResponse>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "GetById"));
            parameters.Add(new SqlParameter("@Id", id));
            MenuModel model = new MenuModel();
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageAdminMenu", parameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    model = ds.Tables[0].AsEnumerable().Select(s => new MenuModel
                    {
                        MenuId = Convert.ToInt32(s["MenuId"] == null ? 0 : s["MenuId"]),
                        MenuName = Convert.ToString(s["MenuName"] == null ? "" : s["MenuName"]),
                        ControllerName = Convert.ToString(s["ControllerName"] == null ? "" : s["ControllerName"]),
                        ActionName = Convert.ToString(s["ActionName"] == null ? "" : s["ActionName"]),
                        Level = Convert.ToInt32(s["Level"] == null ? 0 : s["Level"]),
                        Position = Convert.ToInt32(s["Position"] == null ? 0 : s["Position"]),
                        ParentId = Convert.ToInt32(s["ParentId"] == null ? 0 : s["ParentId"]),
                        MenuIcon = Convert.ToString(s["MenuIcon"] == null ? "" : s["MenuIcon"]),
                        MenuTitle = Convert.ToString(s["MenuIcon"] == null ? "" : s["MenuTitle"])
                    }).FirstOrDefault();
                }
            }
            return model;
        }
        public async Task<Result> DeleteAdminMenu(int id)
        {
            Result result = new Result();
            List<MenuResponse> menuList = new List<MenuResponse>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "Delete"));
            parameters.Add(new SqlParameter("@Id", id));
            MenuModel model = new MenuModel();
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageAdminMenu", parameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = Convert.ToBoolean(s["Status"]), Message = s.Field<string>("Message") }).First();

                }
            }
            return result;
        }
        public async Task<Result> ActiveAdminMenu(int id)
        {
            Result result = new Result();
            List<MenuResponse> menuList = new List<MenuResponse>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "IsActive"));
            parameters.Add(new SqlParameter("@Id", id));
            MenuModel model = new MenuModel();
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageAdminMenu", parameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = Convert.ToBoolean(s["Status"]), Message = s.Field<string>("Message") }).First();

                }
            }
            return result;
        }

        public async Task<MenuModel> BindAdminMenu(string UserId)
        {
            MenuModel model = new MenuModel();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "GetByAdminId"));
            parameters.Add(new SqlParameter("@EmpId", UserId));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageAdminMenu", parameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                DataTable dtMenu = ds.Tables[0];
                if (dtMenu.Rows.Count > 0)
                {
                    model.SidebarClass = Convert.ToString(ds.Tables[0].Rows[0]["SidebarClass"]);
                    model.listMenu = ds.Tables[0].AsEnumerable().Select(s => new MenuModel
                    {
                        MenuId = Convert.ToInt32(s["MenuId"] == null ? 0 : s["MenuId"]),
                        MenuName = Convert.ToString(s["MenuName"] == null ? "" : s["MenuName"]),
                        ControllerName = Convert.ToString(s["ControllerName"] == null ? "" : s["ControllerName"]),
                        ActionName = Convert.ToString(s["ActionName"] == null ? "" : s["ActionName"]),
                        Level = Convert.ToInt32(s["Level"] == null ? 0 : s["Level"]),
                        Position = Convert.ToInt32(s["Position"] == null ? 0 : s["Position"]),
                        ParentId = Convert.ToInt32(s["ParentId"] == null ? 0 : s["ParentId"]),
                        MenuIcon = Convert.ToString(s["MenuIcon"] == null ? "" : s["MenuIcon"]),
                        MenuTitle = Convert.ToString(s["MenuTitle"] == null ? "" : s["MenuTitle"])
                    }).ToList();
                }
            }
            return model;
        }
        #endregion

        #region [Member Menu]
        #region [Get First Level Menu For Member]
        public async Task<Result> MemberFirstLevelMenu()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "GetFirstLevel"));

            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageMemberMenu", parameters.ToArray());
            Result result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = true, Message = "Data Fatched" }).First();
            result.Results = ds.Tables[0].AsEnumerable().Select(s => new
            {
                Id = Convert.ToInt32(s["MenuId"]),
                MenuName = s.Field<string>("MenuName"),

            }).ToList();
            return result;
        }
        #endregion
        public async Task<Result> AddEditMemberMenu(MenuModel model)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "Insert"));
            parameters.Add(new SqlParameter("@Id", model.MenuId));
            parameters.Add(new SqlParameter("@UserId", 0));
            parameters.Add(new SqlParameter("@MenuName", model.MenuName));
            parameters.Add(new SqlParameter("@Controller", model.ControllerName));
            parameters.Add(new SqlParameter("@ActionName", model.ActionName));
            parameters.Add(new SqlParameter("@MenuIcon", model.MenuIcon));
            parameters.Add(new SqlParameter("@Level", model.Level));
            parameters.Add(new SqlParameter("@Position", model.Position));
            parameters.Add(new SqlParameter("@ParentId", model.ParentId));
            parameters.Add(new SqlParameter("@MenuTitle", model.MenuTitle));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageMemberMenu", parameters.ToArray());
            Result result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = Convert.ToBoolean(s["Status"]), Message = s.Field<string>("Message") }).First();
            return result;
        }

        public async Task<ReportList> GetAllMemberMenu(string search, int pageIndex, int pageSize, string sortCol, string sortDir)
        {
            ReportList rpList = new ReportList();
            List<MenuResponse> menuList = new List<MenuResponse>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "GetAll"));
            parameters.Add(new SqlParameter("@PageIndex", pageIndex));
            parameters.Add(new SqlParameter("@PageSize", pageSize));
            parameters.Add(new SqlParameter("@Search", search));
            int totalRecord = 0;
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageMemberMenu", parameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataView dv = new DataView(ds.Tables[0]);
                    dv.Sort = sortCol + " " + sortDir;
                    totalRecord = Convert.ToInt32(ds.Tables[0].Rows[0]["TotalRow"].ToString());
                    menuList = dv.ToTable().AsEnumerable().Select(s => new MenuResponse
                    {
                        SrNo = Convert.ToInt32(s["SrNo"] == null ? 0 : s["SrNo"]),
                        MenuName = Convert.ToString(s["MenuName"] == null ? "" : s["MenuName"]),
                        ControllerName = Convert.ToString(s["ControllerName"] == null ? "" : s["ControllerName"]),
                        ActionName = Convert.ToString(s["ActionName"] == null ? "" : s["ActionName"]),
                        MenuTitle = Convert.ToString(s["MenuTitle"] == DBNull.Value ? "" : s["MenuTitle"]),
                        Action = Convert.ToString(s["Action"] == null ? "" : s["Action"])
                    }).ToList();
                }
            }
            rpList.recordsFiltered = totalRecord;
            rpList.recordsTotal = totalRecord;
            rpList.data = menuList;
            return rpList;
        }
        public async Task<MenuModel> GetMemberMenuById(int id)
        {
            List<MenuResponse> menuList = new List<MenuResponse>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "GetById"));
            parameters.Add(new SqlParameter("@Id", id));
            MenuModel model = new MenuModel();
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageMemberMenu", parameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    model = ds.Tables[0].AsEnumerable().Select(s => new MenuModel
                    {
                        MenuId = Convert.ToInt32(s["MenuId"] == null ? 0 : s["MenuId"]),
                        MenuName = Convert.ToString(s["MenuName"] == null ? "" : s["MenuName"]),
                        ControllerName = Convert.ToString(s["ControllerName"] == null ? "" : s["ControllerName"]),
                        ActionName = Convert.ToString(s["ActionName"] == null ? "" : s["ActionName"]),
                        Level = Convert.ToInt32(s["Level"] == null ? 0 : s["Level"]),
                        Position = Convert.ToInt32(s["Position"] == null ? 0 : s["Position"]),
                        ParentId = Convert.ToInt32(s["ParentId"] == null ? 0 : s["ParentId"]),
                        MenuIcon = Convert.ToString(s["MenuIcon"] == null ? "" : s["MenuIcon"]),
                        MenuTitle = Convert.ToString(s["MenuTitle"] == DBNull.Value ? "" : s["MenuTitle"])
                    }).FirstOrDefault();
                }
            }
            return model;
        }
        public async Task<Result> DeleteMemberMenu(int id)
        {
            Result result = new Result();
            List<MenuResponse> menuList = new List<MenuResponse>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "Delete"));
            parameters.Add(new SqlParameter("@Id", id));
            MenuModel model = new MenuModel();
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageMemberMenu", parameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = Convert.ToBoolean(s["Status"]), Message = s.Field<string>("Message") }).First();
                }
            }
            return result;
        }
        public async Task<Result> ActiveMemberMenu(int id)
        {
            Result result = new Result();
            List<MenuResponse> menuList = new List<MenuResponse>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "IsActive"));
            parameters.Add(new SqlParameter("@Id", id));
            MenuModel model = new MenuModel();
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageMemberMenu", parameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = Convert.ToBoolean(s["Status"]), Message = s.Field<string>("Message") }).First();

                }
            }
            return result;
        }

        public async Task<MenuModel> BindMemberMenu(string UserId)
        {
            MenuModel model = new MenuModel();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "GetByRole"));
            parameters.Add(new SqlParameter("@UserId", UserId));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageMemberMenu", parameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                DataTable dtMenu = ds.Tables[0];
                if (dtMenu.Rows.Count > 0)
                {
                    model.listMenu = ds.Tables[0].AsEnumerable().Select(s => new MenuModel
                    {
                        MenuId = Convert.ToInt32(s["MenuId"] == null ? 0 : s["MenuId"]),
                        MenuName = Convert.ToString(s["MenuName"] == null ? "" : s["MenuName"]),
                        ControllerName = Convert.ToString(s["ControllerName"] == null ? "" : s["ControllerName"]),
                        ActionName = Convert.ToString(s["ActionName"] == null ? "" : s["ActionName"]),
                        Level = Convert.ToInt32(s["Level"] == null ? 0 : s["Level"]),
                        Position = Convert.ToInt32(s["Position"] == null ? 0 : s["Position"]),
                        ParentId = Convert.ToInt32(s["ParentId"] == null ? 0 : s["ParentId"]),
                        MenuIcon = Convert.ToString(s["MenuIcon"] == null ? "" : s["MenuIcon"]),
                        MenuTitle = Convert.ToString(s["MenuTitle"] == DBNull.Value ? "" : s["MenuTitle"])
                    }).ToList();
                }
            }
            return model;
        }
        #endregion

        #region[MenuTree]
        #region[GetMenuTreeBind]
        public async Task<List<MenuDisplay>> GetMenuTreeBind(int roleID)
        {
            List<MenuModel> menuList = new List<MenuModel>();
            List<MenuDisplay> menuDisplay = new List<MenuDisplay>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "GetMenuTreeBind"));
            parameters.Add(new SqlParameter("@Id", roleID));
            DataSet ds = new DataSet();
            if (roleID == 1 || roleID == 2 || roleID == 8)
            {
                ds = await _sqlHelper.ExecuteProcedure("SP_ManageAdminMenu", parameters.ToArray());
            }
            else
            {
                ds = await _sqlHelper.ExecuteProcedure("SP_ManageMemberMenu", parameters.ToArray());
            }
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    menuList = ds.Tables[0].AsEnumerable().Select(s => new MenuModel
                    {
                        MenuId = Convert.ToInt32(s["MenuId"] == null ? 0 : s["MenuId"]),
                        ParentId = Convert.ToInt32(s["ParentId"] == null ? 0 : s["ParentId"]),
                        Position = Convert.ToInt32(s["Position"] == null ? 0 : s["Position"]),
                        MenuName = Convert.ToString(s["MenuName"] == null ? "" : s["MenuName"]),
                        ControllerName = Convert.ToString(s["ControllerName"] == null ? "" : s["ControllerName"]),
                        ActionName = Convert.ToString(s["ActionName"] == null ? "" : s["ActionName"]),
                        IsChecked = Convert.ToBoolean(s["IsChecked"])
                    }).ToList();
                }
            }
            menuDisplay = menuList.Where(l => l.ParentId == 0).OrderBy(l => l.Position)
                .Select(l => new MenuDisplay
                {
                    id = l.MenuId,
                    text = l.MenuName,
                    @checked = l.IsChecked,
                    children = GetChildren(menuList, l.MenuId, roleID)
                }).ToList();

            return menuDisplay;
        }
        private List<MenuDisplay> GetChildren(List<MenuModel> locations, int parentId, int roleID)
        {
            return locations.Where(l => l.ParentId == parentId).OrderBy(l => l.Position)
                .Select(l => new MenuDisplay
                {
                    id = l.MenuId,
                    text = l.MenuName,
                    @checked = l.IsChecked,
                    children = GetChildren(locations, l.MenuId, roleID)
                }).ToList();
        }
        #endregion

        #region[SaveCheckedTreeNodes]
        public async Task<Result> SaveCheckedTreeNodes(List<int> checkedIds, int RoleID, int CUserID, string IP)
        {
            Result result = new Result();
            try
            {
                DataTable dtMenuLink = new DataTable();
                if (checkedIds != null)
                {
                    dtMenuLink.Columns.Add("MenuID", typeof(int));
                    dtMenuLink.Columns.Add("RoleID", typeof(int));
                    dtMenuLink.Columns.Add("IP", typeof(string));
                    dtMenuLink.Columns.Add("CUserID", typeof(int));
                    foreach (var k in checkedIds)
                    {
                        DataRow dr = dtMenuLink.NewRow();
                        dr["MenuID"] = k;
                        dr["RoleID"] = RoleID;
                        dr["IP"] = IP;
                        dr["CUserID"] = CUserID;
                        dtMenuLink.Rows.Add(dr);
                    }
                    if (dtMenuLink.Rows.Count > 0)
                    {
                        List<SqlParameter> parameters = new List<SqlParameter>();
                        parameters.Add(new SqlParameter("@Action", "Insert"));
                        parameters.Add(new SqlParameter("@RoleID", RoleID));
                        parameters.Add(new SqlParameter("@MenuRoleLinkType", dtMenuLink));
                        MenuModel model = new MenuModel();
                        DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageMenuRoleLnk", parameters.ToArray());
                        if (ds.Tables.Count > 0)
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = Convert.ToBoolean(s["Status"]), Message = s.Field<string>("Message") }).First();

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = ex.Message;
            }
            return result;
        }
        #endregion

        #region Get Role List
        public async Task<RoleResponse> GetRoleList(int UserId)
        {
            RoleResponse model = new RoleResponse();

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "GetAll"));
            parameters.Add(new SqlParameter("@UserId", UserId));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageRole", parameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    model.list = ds.Tables[0].AsEnumerable().Select(s => new RoleResponse
                    {
                        SrNo = s["SrNo"] == DBNull.Value ? 0 : Convert.ToInt32(s["SrNo"]),
                        Role = s["RoleName"] == DBNull.Value ? "" : Convert.ToString(s["RoleName"]),
                        Status = s["Status"] == DBNull.Value ? "" : Convert.ToString(s["Status"]),
                        Action = s["Action"] == DBNull.Value ? "" : Convert.ToString(s["Action"])
                    }).ToList();
                }
            }
            return model;
        }
        #endregion
        #region GetRoleById
        public async Task<RoleModel> GetRoleById(int id)
        {
            List<RoleResponse> list = new List<RoleResponse>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "GetById"));
            parameters.Add(new SqlParameter("@Id", id));
            RoleModel model = new RoleModel();
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageRole", parameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    model = ds.Tables[0].AsEnumerable().Select(s => new RoleModel
                    {
                        Id = s["Id"] == DBNull.Value ? 0 : Convert.ToInt32(s["Id"]),
                        UserRole = s["RoleName"] == DBNull.Value ? "" : Convert.ToString(s["RoleName"])
                    }).FirstOrDefault();
                }
            }
            return model;
        }
        #endregion
        #region Add Edit Role
        public async Task<Result> AddEditRole(RoleModel model)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "Insert"));
            parameters.Add(new SqlParameter("@ID", model.Id));
            parameters.Add(new SqlParameter("@RoleName", model.UserRole));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageRole", parameters.ToArray());
            Result result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = Convert.ToBoolean(s["Status"]), Message = s.Field<string>("Message") }).First();
            return result;
        }
        #endregion
        #region Active / Deactive Role
        public async Task<Result> ActiveRole(int id)
        {
            Result result = new Result();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "IsActive"));
            parameters.Add(new SqlParameter("@ID", id));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageRole", parameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = Convert.ToBoolean(s["Status"]), Message = s.Field<string>("Message") }).First();
                }
            }
            return result;
        }
        #endregion
        #endregion

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }
                disposedValue = true;
            }
        }

        void IDisposable.Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
