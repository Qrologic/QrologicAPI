using QroApi.BLL;
using QroApi.Core;
using QroApi.CustomAttributes;
using QroApi.MODEL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QroApi.Areas.Admin.Controllers
{
    [Authorize(Role.Admin, Role.SuperAdmin, Role.SubAdmin)]
    [Area("Admin")]
    public class MenuController : Controller
    {
        #region Properties
        private readonly IMenu _iMenu;
        private readonly ICookies _iCookies;
        private readonly IUtilityService _utilityService;
        #endregion

        #region Constuctor
        public MenuController(IMenu iMenu, IUtilityService utilityService, ICookies iCookies)
        {
            _iMenu = iMenu;
            _utilityService = utilityService;
            _iCookies = iCookies;
        }
        #endregion

        #region Admin Menu
        public async Task<IActionResult> AdminMenu(int? id)
        {
            MenuModel model = new MenuModel();
            if (id == null)
            {
                
                model.ControllerName = "#";
                model.ActionName = "#";
                model.Position = 0;
                model.Level = 0;
            }            
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AdminMenu(MenuModel model)
        {
            string message = "";
            try
            {
                var errors = ModelState.Select(x => x.Value.Errors)
                           .Where(y => y.Count > 0)
                           .ToList();
                bool isSuccess = false;
                if (ModelState.IsValid)
                {
                    var menu = await _iMenu.AddEditAdminMenu(model);
                    if (menu == null)
                    {
                        isSuccess = false;
                        message = "Enter valid input !";
                        ModelState.AddModelError(string.Empty, "Enter valid input !");
                    }
                    else if (!menu.Status)
                    {
                        isSuccess = false;
                        message = menu.Message;
                    }
                    else
                    {
                        message = menu.Message;
                        isSuccess = true;
                        model = null;
                    }
                }
               
                return Json(new Result
                {
                    Status = isSuccess,
                    Results = null,
                    Message = message
                });
            }
            catch (Exception ex)
            {
                return Json(new Result
                {
                    Status = false,
                    Results = null,
                    Message = "Something Went Wrong !"
                });
            }
        }

        public async Task<IActionResult> GetFirstLevelMenu()
        {
            try
            {
                Result model = new Result();
                model = await _iMenu.GetFirstLevelMenu();
                return Json(new Result
                {
                    Status = true,
                    Results = model.Results,
                    Message = "Success"
                });
            }
            catch (Exception ex)
            {
                return Json(new Result
                {
                    Status = false,
                    Results = null,
                    Message = ex.Message.ToString()
                });
            }
        }
        public async Task<IActionResult> CallMenuPartial(int? id, string type)
        {
            
            MenuModel model = new MenuModel();
            if (id == null)
            {
                model.ControllerName = "#";
                model.ActionName = "#";
                model.Position = 0;
                model.Level = 0;
            }
            else
            {
                model = await _iMenu.GetMenuById(Convert.ToInt32(id));
            }
           
            return PartialView("_AdminMenu", model);
        }

        [HttpPost]
        public async Task<IActionResult> GetMenuList()
        {
            int draw = Convert.ToInt32(HttpContext.Request.Form["draw"].FirstOrDefault());
            int StartIndex = Convert.ToInt32(Request.Form["start"].FirstOrDefault());
            int PageSize = Convert.ToInt32(Request.Form["length"].FirstOrDefault());
            string SortCol = Convert.ToString(Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault());
            string SortDir = Convert.ToString(Request.Form["order[0][dir]"].FirstOrDefault());
            string SearchField = Convert.ToString(Request.Form["search[value]"].FirstOrDefault());
            ReportList result = await _iMenu.GetAllAdminMenu(SearchField, StartIndex, PageSize, SortCol, SortDir);
            result.draw = draw;
            return Json(result);
        }

        public async Task<IActionResult> DeleteAdminMenu(int? id)
        {
            try
            {
                Result model = new Result();
                model = await _iMenu.DeleteAdminMenu(Convert.ToInt32(id));
                return Json(new Result
                {
                    Status = true,
                    Results = model.Results,
                    Message = "Menu Succesfully Deleted"
                });
            }
            catch (Exception ex)
            {
                return Json(new Result
                {
                    Status = false,
                    Results = null,
                    Message = ex.Message.ToString()
                });
            }
        }
        public async Task<IActionResult> ActiveAdminMenu(int? id)
        {
            try
            {
                Result model = new Result();
                model = await _iMenu.ActiveAdminMenu(Convert.ToInt32(id));
                return Json(new Result
                {
                    Status = true,
                    Results = model.Results,
                    Message = "Menu Succesfully Acivated or Deactivated"
                });
            }
            catch (Exception ex)
            {
                return Json(new Result
                {
                    Status = false,
                    Results = null,
                    Message = ex.Message.ToString()
                });
            }
        }

        #region[Bind Admin Menu ]
        public async Task<IActionResult> BindAdminMenu()
        {
            MenuModel model = new MenuModel();
            model = await _iMenu.BindAdminMenu(User.Identity.GetDetailOf("UserId"));
            return PartialView("_AdminBindMenu", model);
        }
        #endregion
        #endregion

        #region Member Menu
        public async Task<IActionResult> MemberMenu(int? id)
        {
            MenuModel model = new MenuModel();
            if (id == null)
            {

                model.ControllerName = "#";
                model.ActionName = "#";
                model.Position = 0;
                model.Level = 0;
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> MemberMenu(MenuModel model)
        {
            string message = "";
            try
            {               
                bool isSuccess = false;
                if (ModelState.IsValid)
                {
                    var menu = await _iMenu.AddEditMemberMenu(model);
                    if (menu == null)
                    {
                        isSuccess = false;
                        message = "Enter valid input !";
                        ModelState.AddModelError(string.Empty, "Enter valid input !");
                    }
                    else if (!menu.Status)
                    {
                        isSuccess = false;
                        message = menu.Message;
                    }
                    else
                    {
                        message = menu.Message;
                        isSuccess = true;
                        model = null;
                    }
                }

                return Json(new Result
                {
                    Status = isSuccess,
                    Results = null,
                    Message = message
                });
            }
            catch (Exception ex)
            {
                return Json(new Result
                {
                    Status = false,
                    Results = null,
                    Message = "Something Went Wrong !"
                });
            }
        }

        public async Task<IActionResult> MemberFirstLevelMenu()
        {
            try
            {
                Result model = new Result();
                model = await _iMenu.MemberFirstLevelMenu();
                return Json(new Result
                {
                    Status = true,
                    Results = model.Results,
                    Message = "Success"
                });
            }
            catch (Exception ex)
            {
                return Json(new Result
                {
                    Status = false,
                    Results = null,
                    Message = ex.Message.ToString()
                });
            }
        }
        public async Task<IActionResult> MemberMenuPartial(int? id, string type)
        {

            MenuModel model = new MenuModel();
            if (id == null)
            {
                model.ControllerName = "#";
                model.ActionName = "#";
                model.Position = 0;
                model.Level = 0;
            }
            else
            {
                model = await _iMenu.GetMemberMenuById(Convert.ToInt32(id));
            }

            return PartialView("_MemberMenu", model);
        }

        
        [HttpPost]
        public async Task<IActionResult> GetMemberMenuList()
        {
            int draw = Convert.ToInt32(HttpContext.Request.Form["draw"].FirstOrDefault());
            int StartIndex = Convert.ToInt32(Request.Form["start"].FirstOrDefault());
            int PageSize = Convert.ToInt32(Request.Form["length"].FirstOrDefault());
            string SortCol = Convert.ToString(Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault());
            string SortDir = Convert.ToString(Request.Form["order[0][dir]"].FirstOrDefault());
            string SearchField = Convert.ToString(Request.Form["search[value]"].FirstOrDefault());
            ReportList result = await _iMenu.GetAllMemberMenu(SearchField, StartIndex, PageSize, SortCol, SortDir);
            result.draw = draw;
            return Json(result);
        }
        public async Task<IActionResult> DeleteMemberMenu(int? id)
        {
            try
            {
                Result model = new Result();
                model = await _iMenu.DeleteMemberMenu(Convert.ToInt32(id));
                return Json(new Result
                {
                    Status = true,
                    Results = model.Results,
                    Message = "Menu Succesfully Deleted"
                });
            }
            catch (Exception ex)
            {
                return Json(new Result
                {
                    Status = false,
                    Results = null,
                    Message = ex.Message.ToString()
                });
            }
        }
        public async Task<IActionResult> ActiveMemberMenu(int? id)
        {
            try
            {
                Result model = new Result();
                model = await _iMenu.ActiveMemberMenu(Convert.ToInt32(id));
                return Json(new Result
                {
                    Status = true,
                    Results = model.Results,
                    Message = "Menu Succesfully Acivated or Deactivated"
                });
            }
            catch (Exception ex)
            {
                return Json(new Result
                {
                    Status = false,
                    Results = null,
                    Message = ex.Message.ToString()
                });
            }
        }

        #region[Bind Admin Menu ]
        public async Task<IActionResult> BindMemberMenu()
        {
            MenuModel model = new MenuModel();
            model = await _iMenu.BindMemberMenu(User.Identity.GetDetailOf("UserId"));
            return PartialView("_AdminBindMenu", model);
        }
        #endregion
        #endregion


        #region Menu Rights
        public IActionResult MenuRights()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> GetMenuTree(int roleID)
        {
            return Json(await _iMenu.GetMenuTreeBind(roleID));
        }

        [HttpPost]
        public async Task<JsonResult> SaveCheckedTreeNodes(List<int> checkedIds, int RoleID)
        {
            string IP = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            var result =await _iMenu.SaveCheckedTreeNodes(checkedIds, RoleID, Convert.ToInt32(User.Identity.GetDetailOf("UserId")), IP);
            return Json(new Result
            {
                Status = result.Status,
                Results = result.Results,
                Message = result.Message
            });

        }

        #endregion

        #region Set Active Menu In Cookie
        public IActionResult SetMenuInCookie(int? menuId)
        {           
            _iCookies.SetCookie("ActiveMenu", menuId.ToString(), 60.0);
            return Json(new Result
            {
                Status = true,
                Results = null,
                Message ="Success"
            });
        }
        #endregion

        #region Manage Role
        #region Bind Role Table
        public async Task<IActionResult> BindRoleTable()
        {
            RoleResponse model = new RoleResponse();
            try
            {
                int UserId = User.Identity.GetDetailOf("UserId") == "" ? 0 : Convert.ToInt32(User.Identity.GetDetailOf("UserId"));
               model = await _iMenu.GetRoleList(UserId);
            }
            catch (Exception ex) { }
            return PartialView("_RoleList", model);

        }
        #endregion
        #region Add Role
        public async Task<IActionResult> AddRole(int? id)
        {
            RoleModel model = new RoleModel();
            if (id != null)
            {
                model = await _iMenu.GetRoleById(Convert.ToInt32(id));
            }
            return PartialView("_AddRole", model);
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(RoleModel model)
        {
            try
            {
                Result result = new Result();
                if (ModelState.IsValid)
                {
                    result = await _iMenu.AddEditRole(model);
                    result.RedirectUrl = "/Admin/Menu/MenuRights";
                    result.isRedirect = true;
                }
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(new Result
                {
                    Status = false,
                    Results = null,
                    Message = ex.Message.ToString()
                });
            }
        }
        #endregion
        #region Active / Deactive Role
        public async Task<IActionResult> ActiveRole(int? id)
        {
            try
            {
                Result model = new Result();
                model = await _iMenu.ActiveRole(Convert.ToInt32(id));
                return Json(new Result
                {
                    Status = true,
                    Results = model.Results,
                    Message = model.Message
                });
            }
            catch (Exception ex)
            {
                return Json(new Result
                {
                    Status = false,
                    Results = null,
                    Message = ex.Message.ToString()
                });
            }
        }
        #endregion
        #endregion

    }
}
