using QroApi.BLL;
using QroApi.MODEL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QroApi.Core;
using Microsoft.AspNetCore.Hosting;
using QroApi.CustomAttributes;

namespace QroApi.Areas.Admin.Controllers
{
    [Authorize(Role.Admin, Role.SuperAdmin, Role.SubAdmin, Role.SuperDistributor, Role.MasterDistributor, Role.Distributor, Role.Retailer, Role.Customer)]
    [Area("Admin")]
    public class UtilityController : Controller
    {
        #region Properties
        private readonly IUtility _iUtility;
        private readonly ICommonClass _iCommonClass;
        private readonly IWebHostEnvironment _webHostEnvironment;
        #endregion

        #region Constuctor
        public UtilityController(IUtility iUtility, IWebHostEnvironment hostEnvironment, ICommonClass iCommonClass)
        {
            _iUtility = iUtility;
            _iCommonClass = iCommonClass;
            _webHostEnvironment = hostEnvironment;
        }
        #endregion

        #region State
        #region ListState
        public IActionResult ListState()
        {
            return View();
        }
        #region Get State List
        [HttpPost]
        [Produces("application/json")]
        public async Task<IActionResult> GetStateList()
        {
            int draw = Convert.ToInt32(HttpContext.Request.Form["draw"].FirstOrDefault());
            int StartIndex = Convert.ToInt32(Request.Form["start"].FirstOrDefault());
            int PageSize = Convert.ToInt32(Request.Form["length"].FirstOrDefault());
            string SortCol = Convert.ToString(Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault());
            string SortDir = Convert.ToString(Request.Form["order[0][dir]"].FirstOrDefault());
            string SearchField = Convert.ToString(Request.Form["search[value]"].FirstOrDefault());
            ReportList result = await _iUtility.GetStateList(SearchField, StartIndex, PageSize, SortCol, SortDir);
            result.draw = draw;
            return Json(result);
        }
        #endregion
        #endregion
        #region Add State
        public async Task<IActionResult> AddState(int? id)
        {
            StateModel model = new StateModel();
            if (id != null)
            {
                model = await _iUtility.GetStateById(Convert.ToInt32(id));
            }
            return PartialView("_AddState", model);
        }

        [HttpPost]
        public async Task<IActionResult> AddState(StateModel model)
        {
            try
            {
                Result result = new Result();
                if (ModelState.IsValid)
                {
                    result = await _iUtility.AddEditState(model);
                    result.RedirectUrl = "/Admin/Utility/GetStateList";
                    result.isRedirect = false;
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
        #region Delete State
        public async Task<IActionResult> DeleteState(int? id)
        {
            try
            {
                Result model = new Result();
                model = await _iUtility.DeleteState(Convert.ToInt32(id));
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
        #region Active / Deactive State
        public async Task<IActionResult> ActiveState(int? id)
        {
            try
            {
                Result model = new Result();
                model = await _iUtility.ActiveState(Convert.ToInt32(id));
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
        #region Get Country
        public async Task<IActionResult> GetCountry()
        {
            try
            {
                Result model = new Result();
                model = await _iUtility.GetCountry();
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
        #endregion
        #region Get State      
        public async Task<IActionResult> GetState(int countryId)
        {
            try
            {
                Result model = new Result();
                model = await _iUtility.GetState(countryId);
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
        #endregion
        #endregion

        #region City
        #region ListCity
        public IActionResult ListCity()
        {
            return View();
        }
        #region Get City List
        [HttpPost]
        [Produces("application/json")]
        public async Task<IActionResult> GetCityList(dynamic data)
        {
            int draw = Convert.ToInt32(HttpContext.Request.Form["draw"].FirstOrDefault());
            int StartIndex = Convert.ToInt32(Request.Form["start"].FirstOrDefault());
            int PageSize = Convert.ToInt32(Request.Form["length"].FirstOrDefault());
            string SortCol = Convert.ToString(Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault());
            string SortDir = Convert.ToString(Request.Form["order[0][dir]"].FirstOrDefault());
            string SearchField = Convert.ToString(Request.Form["search[value]"].FirstOrDefault());
            ReportList result = await _iUtility.GetCityList(SearchField, StartIndex, PageSize, SortCol, SortDir);
            result.draw = draw;
            return Json(result);
        }
        #endregion
        #endregion
        #region Add City
        public async Task<IActionResult> AddCity(int? id)
        {
            CityModel model = new CityModel();
            if (id != null)
            {
                model = await _iUtility.GetCityById(Convert.ToInt32(id));
            }
            return PartialView("_AddCity", model);
        }

        [HttpPost]
        public async Task<IActionResult> AddCity(CityModel model)
        {
            try
            {
                Result result = new Result();
                if (ModelState.IsValid)
                {
                    result = await _iUtility.AddEditCity(model);
                    result.RedirectUrl = "/Admin/Utility/GetCityList";
                    result.isRedirect = false;
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
        #region Delete City
        public async Task<IActionResult> DeleteCity(int? id)
        {
            try
            {
                Result model = new Result();
                model = await _iUtility.DeleteCity(Convert.ToInt32(id));
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
        #region Active / Deactive City
        public async Task<IActionResult> ActiveCity(int? id)
        {
            try
            {
                Result model = new Result();
                model = await _iUtility.ActiveCity(Convert.ToInt32(id));
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
        #region Get City
        [HttpPost]
        public async Task<IActionResult> GetCity(int stateId)
        {
            try
            {
                Result model = new Result();
                model = await _iUtility.GetCity(stateId);
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
        #endregion
        #endregion

        #region Package
        #region ListPackage
        public IActionResult ListPackage()
        {
            return View();
        }
       [HttpPost]
        [Produces("application/json")]
        public async Task<IActionResult> GetPackageList()
        {
            var msrNo = User.Identity.GetDetailOf("MsrNo");
            int draw = Convert.ToInt32(HttpContext.Request.Form["draw"].FirstOrDefault());
            int StartIndex = Convert.ToInt32(Request.Form["start"].FirstOrDefault());
            int PageSize = Convert.ToInt32(Request.Form["length"].FirstOrDefault());
            string SortCol = Convert.ToString(Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault());
            string SortDir = Convert.ToString(Request.Form["order[0][dir]"].FirstOrDefault());
            string SearchField = Convert.ToString(Request.Form["search[value]"].FirstOrDefault());
            ReportList result = await _iUtility.GetPackageList(SearchField, StartIndex, PageSize, SortCol, SortDir,Convert.ToInt32(msrNo));
            result.draw = draw;
            return Json(result);
        } 
        #endregion

        #region Add Package
        public async Task<IActionResult> AddPackage(int? id)
        {
            PackageModel model = new PackageModel();
            if (id != null && id!=0)
            {
                model = await _iUtility.GetPackageById(Convert.ToInt32(id));
            }
            return PartialView("_Package", model);
        }

        [HttpPost]
        public async Task<IActionResult> AddPackage(PackageModel model)
        {
            try
            {
                Result result = new Result();
                if (ModelState.IsValid)
                {
                    model.MsrNo = model.MsrNo>1 ? model.MsrNo: 1;
                    result = await _iUtility.AddEditPackage(model);
                    result.RedirectUrl = "/Admin/Utility/GetPackageList";
                    result.isRedirect = false;
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

        #region Delete Package
        public async Task<IActionResult> DeletePackage(int? id)
        {
            try
            {
                Result model = new Result();
                model = await _iUtility.DeletePackage(Convert.ToInt32(id));
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

        #region Active / Deactive Package
        public async Task<IActionResult> ActivePackage(int? id)
        {
            try
            {
                Result model = new Result();
                model = await _iUtility.ActivePackage(Convert.ToInt32(id));
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

        #region Get Package

        #region Get Package       

        public async Task<IActionResult> GetPackage()
        {
            try
            {
                var msrNo = User.Identity.GetDetailOf("MsrNo");
                Result model = new Result();
                model = await _iUtility.GetPackage(Convert.ToInt32(msrNo));
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
        #endregion
        #endregion
        #endregion

        #region Assign Service
        #region GetServiceForFilter
        public async Task<IActionResult> GetServiceForFilter()
        {
            try
            {
                Result model = new Result();
                model = await _iUtility.GetServiceForFilter();
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
        #endregion
        public async Task<IActionResult> GetServiceByPackage(int ?packageId)
        {
            AssignedService model = new AssignedService();
            try
            {
                model = await _iUtility.GetServiceByPackageId(Convert.ToInt32(packageId));
            }
            catch (Exception ex) { }
            return PartialView("_AssignService", model);
        }
        public async Task<IActionResult> AssignService([FromBody] AssignedService[] modelArray, int packageId)
        {
            try
            {
                Result result = new Result();
                if (ModelState.IsValid)
                {
                    result = await _iUtility.AssigneServiceOnPackage(modelArray, packageId);
                }
                else
                {
                    return Json(new Result
                    {
                        Status = false,
                        Results = null,
                        Message = "Fill All Required Field"
                    });
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

        public async Task<IActionResult> GetServiceByMsrNo(int? MsrNo)
        {
            AssignedService model = new AssignedService();
            try
            {
                if (MsrNo==null)
                {
                    MsrNo = 0;
                }
                model = await _iUtility.GetServiceByMsrNo(Convert.ToInt32(MsrNo));
            }
            catch (Exception ex) { }
            return PartialView("_AssignServiceByMsrNo", model);
        }
        public async Task<IActionResult> AssignServiceByMsrNo([FromBody] AssignedService[] modelArray, int MsrNo)
        {
            try
            {
                Result result = new Result();
                if (ModelState.IsValid)
                {
                    result = await _iUtility.AssigneServiceOnMsrNo(modelArray, MsrNo);
                }
                else
                {
                    return Json(new Result
                    {
                        Status = false,
                        Results = null,
                        Message = "Fill All Required Field"
                    });
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

        #region Role
        #region Get Role For Registration
        public async Task<IActionResult> GetRoleForRegistration(int? id)
        {
            try
            {
                Result model = new Result();
                int userId = Convert.ToInt32(User.Identity.GetDetailOf("UserId"));
                model = await _iUtility.GetRoleForRegistration(Convert.ToInt32(id),userId);
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
        #endregion
        #region GetRoleForEmployee
        public async Task<IActionResult> GetRoleForEmployee(int? id)
        {
            try
            {
                Result model = new Result();
                int userId = Convert.ToInt32(User.Identity.GetDetailOf("UserId"));
                model = await _iUtility.GetRoleForEmployee(Convert.ToInt32(id),userId);
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
        #endregion
        #region GetRoleForRights
        public async Task<IActionResult> GetRoleForRights()
        {
            try
            {
                Result model = new Result();
                int userId = Convert.ToInt32(User.Identity.GetDetailOf("UserId"));
                model = await _iUtility.GetRoleForRights(userId);
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
        #endregion
        #endregion

        #region Bank
        #region Get Bank For Request
        public async Task<IActionResult> GetBank()
        {
            try
            {
                Result model = new Result();
                model = await _iUtility.GetBank();
                return Json(model);
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

        #region Support
        #region GetSupportList
        public IActionResult Support()
        {
            return View();
        }

        [Produces("application/json")]
        public async Task<IActionResult> GetSupportList(CommonFilter model)
        {
            int msrNo = 0;// Convert.ToInt32(User.Identity.GetDetailOf("MsrNo"));
            int draw = Convert.ToInt32(HttpContext.Request.Form["draw"].FirstOrDefault());
            int StartIndex = Convert.ToInt32(Request.Form["start"].FirstOrDefault());
            int PageSize = Convert.ToInt32(Request.Form["length"].FirstOrDefault());
            string SortCol = Convert.ToString(Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault());
            string SortDir = Convert.ToString(Request.Form["order[0][dir]"].FirstOrDefault());
            string SearchField = Convert.ToString(Request.Form["search[value]"].FirstOrDefault());
            ReportList result = await _iUtility.GetSupportList(SearchField, StartIndex, PageSize, SortCol, SortDir, Convert.ToInt32(msrNo), model);
            result.draw = draw;
            return Json(result);
        }
        #endregion

        #region Create Ticket
        public async Task<IActionResult> CreateTicket(int? id)
        {
            SupportModel model = new SupportModel(); try
            {
                if (id != null && id != 0)
                {
                    model = await _iUtility.GetSupportById(Convert.ToInt32(id));
                }
            }
            catch (Exception ex)
            { }
            return PartialView("_CreateTicket", model);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTicket(SupportModel model)
        {
            try
            {
                Result result = new Result();
                if (ModelState.IsValid)
                {
                    var msrNo = Convert.ToInt32(User.Identity.GetDetailOf("MsrNo") == "" ? "0" : User.Identity.GetDetailOf("MsrNo"));
                    model.MsrNo = msrNo;
                    if (model.ImageFile != null)
                    {
                        model.Attachment = await _iCommonClass.UploadImage(_webHostEnvironment.WebRootPath, model.ImageFile);
                    }
                    result = await _iUtility.CreateTicket(model);
                    result.RedirectUrl = "/Member/Utility/GetSupportList";
                    result.IsPost = true;
                    result.isRedirect = false;
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
        #region GetPriority
        public async Task<IActionResult> GetPriority()
        {
            try
            {
                Result model = new Result();
                model = await _iUtility.GetPriority();
                return Json(model);
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
        #region GetDepartment
        public async Task<IActionResult> GetDepartment()
        {
            try
            {
                Result model = new Result();
                model = await _iUtility.GetDepartment();
                return Json(model);
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
        #region Close Ticket
        public async Task<IActionResult> CloseTicket(int? id)
        {
            try
            {
                Result model = new Result();
                model = await _iUtility.CloseTicket(Convert.ToInt32(id));
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
