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

namespace QroApi.Areas.Member.Controllers
{
    [Authorize(Role.SuperDistributor, Role.MasterDistributor, Role.Distributor, Role.Retailer, Role.Customer, Role.ApiMember)]
    [Area("Member")]
    public class UtilityController : Controller
    {
        #region Properties
        private readonly IUtility _iUtility;
        private readonly IRecharge _iRecharge;
        private readonly IMember _iMember;
        private readonly ICommonClass _iCommonClass;
        private readonly IWebHostEnvironment _webHostEnvironment;
        #endregion

        #region Constuctor
        public UtilityController(IUtility iUtility, IRecharge iRecharge, IMember iMember, IWebHostEnvironment hostEnvironment, ICommonClass iCommonClass)
        {
            _iUtility = iUtility;
            _iRecharge = iRecharge;
            _iMember = iMember;
            _webHostEnvironment = hostEnvironment;
            _iCommonClass = iCommonClass;
        }
        #endregion

        #region Package
        #region ListPackage
        public IActionResult ListPackage()
        {
            return View();
        }

        [Produces("application/json")]
        public async Task<IActionResult> GetPackageList()
        {
            var msrNo = User.Identity.GetDetailOf("MsrNo");
            int draw = Convert.ToInt32(Request.Query["draw"]);
            int StartIndex = Convert.ToInt32(Request.Query["start"]);
            int PageSize = Convert.ToInt32(Request.Query["length"]);
            string SortCol = Convert.ToString(Request.Query["order[0][column]"]);
            string SortDir = Request.Query["order[0][dir]"];
            string SearchField = Request.Query["search[value]"].FirstOrDefault()?.Trim();
            ReportList result = await _iUtility.GetPackageList(SearchField, StartIndex, PageSize, SortCol, SortDir, Convert.ToInt32(msrNo));
            result.draw = draw;
            return Json(result);
        }
        #endregion

        #region Add Package
        public async Task<IActionResult> AddPackage(int? id)
        {
            PackageModel model = new PackageModel();
            if (id != null && id != 0)
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
                    var msrNo = Convert.ToInt32(User.Identity.GetDetailOf("MsrNo") == "" ? "0" : User.Identity.GetDetailOf("MsrNo"));
                    model.MsrNo = msrNo;
                    result = await _iUtility.AddEditPackage(model);
                    result.RedirectUrl = "/Member/Utility/GetPackageList";
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
        public async Task<IActionResult> GetPackage()
        {   
            try
            {
                var msrNo = User.Identity.GetDetailOf("MsrNo");
                Result model = new Result();
                model = await _iUtility.GetPackage(Convert.ToInt32(msrNo));
                return Json(new Result
                {
                    Status = model.Status,
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

        #region My Commission
        public async Task<IActionResult> MyCommission()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LoadMyCommission()
        {
            int msrNo = User.Identity.GetDetailOf("MsrNo") == "" ? 0 : Convert.ToInt32(User.Identity.GetDetailOf("MsrNo"));
            int packageId = await _iMember.GetPackageId(msrNo);
            int draw = Convert.ToInt32(HttpContext.Request.Form["draw"].FirstOrDefault());
            int StartIndex = Convert.ToInt32(Request.Form["start"].FirstOrDefault());
            int PageSize = Convert.ToInt32(Request.Form["length"].FirstOrDefault());
            string SortCol = Convert.ToString(Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault());
            string SortDir = Convert.ToString(Request.Form["order[0][dir]"].FirstOrDefault());
            string SearchField = Convert.ToString(Request.Form["search[value]"].FirstOrDefault());
            ReportList result = await _iRecharge.MyCommission(SearchField, StartIndex, PageSize, SortCol, SortDir, packageId, msrNo);
            result.draw = draw;
            return Json(result);
        }
        #endregion

        #region Manage Commission  
        public async Task<IActionResult> ManageCommission(int? packageId, int serviceId)
        {
            RechargeCommission model = new RechargeCommission();
            await Task.Delay(TimeSpan.FromMilliseconds(1));
            return PartialView("ManageCommission", model);
        }
        [HttpPost]
        public async Task<IActionResult> ManageCommission([FromBody] RechargeCommission[] modelArray, int packageId)
        {
            try
            {
                Result result = new Result();
                if (ModelState.IsValid)
                {
                    result = await _iRecharge.SaveCommission(modelArray, packageId);
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
        public async Task<IActionResult> LoadRechargeCommission(int? packageId, int? serviceId)
        {
            RechargeCommission model = new RechargeCommission();
            int msrNo = User.Identity.GetDetailOf("MsrNo") == "" ? 0 : Convert.ToInt32(User.Identity.GetDetailOf("MsrNo"));
            int myPackageId = await _iMember.GetPackageId(msrNo);
            model.list = await _iRecharge.GetCommission(Convert.ToInt32(packageId), myPackageId, Convert.ToInt32(serviceId), "others");
            return PartialView("_ManageCommission", model);
        }
        #endregion

        #region Get Service
        public async Task<IActionResult> GetService()
        {
            try
            {
                Result model = new Result();
                int msrNo = User.Identity.GetDetailOf("MsrNo") == "" ? 0 : Convert.ToInt32(User.Identity.GetDetailOf("MsrNo"));
                int packageId = await _iMember.GetPackageId(msrNo);
                model = await _iRecharge.GetRechargeServiceByPackageId(packageId);
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
        #region Role
        #region Get Role For Registration
        public async Task<IActionResult> GetRoleForRegistration(int? id)
        {
            try
            {
                Result model = new Result();
                int userId = Convert.ToInt32(User.Identity.GetDetailOf("UserId"));
                model = await _iUtility.GetRoleForRegistration(Convert.ToInt32(id), userId);
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
        #region Support
        #region GetSupportList
        public IActionResult Support()
        {
            return View();
        }

        [Produces("application/json")]
        public async Task<IActionResult> GetSupportList(CommonFilter model)
        {
            int msrNo = Convert.ToInt32(User.Identity.GetDetailOf("MsrNo"));
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
        public async Task<IActionResult> Chat(int? id)
        {
            SupportModel model = new SupportModel(); 
            try
            {
                if (id != null && id != 0)
                {
                    model = await _iUtility.GetSupportById(Convert.ToInt32(id));
                }
            }
            catch (Exception ex)
            { }
            return View(model);
        }
        #region Create Ticket
        public async Task<IActionResult> ChatMessage(int? id)
        {
            SupportModel model = new SupportModel(); 
            try
            {
                if (id != null && id != 0)
                {
                    model = await _iUtility.GetSupportById(Convert.ToInt32(id));
                }
            }
            catch (Exception ex) { }
            return PartialView("_ChatMessage", model);
        }

        [HttpPost]
        public async Task<IActionResult> SaveMessage(SupportModel model)
        {
            string message = "";
            try
            {
                var errors = ModelState.Select(x => x.Value.Errors).Where(y => y.Count > 0).ToList();
                var msrNo = Convert.ToInt32(User.Identity.GetDetailOf("MsrNo") == "" ? "0" : User.Identity.GetDetailOf("MsrNo"));
                model.MsrNo = msrNo;
                bool isSuccess = false;
                if (ModelState.IsValid)
                {
                    if (model.ImageFile != null)
                    {
                        model.Attachment = await _iCommonClass.UploadImage(_webHostEnvironment.WebRootPath, model.ImageFile);
                    }
                    var res = await _iUtility.CreateTicket(model);
                    if (res == null)
                    {
                        isSuccess = false;
                        message = "Enter valid input !";
                        ModelState.AddModelError(string.Empty, "Enter valid input !");
                    }
                    else if (!res.Status)
                    {
                        isSuccess = false;
                        message = res.Message;
                    }
                    else
                    {
                        message = res.Message;
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

        [HttpPost]
        public async Task<IActionResult> ChatMessage(SupportModel model)
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



        #region Create Ticket
        public async Task<IActionResult> CreateTicket(int? id)
        {
            SupportModel model = new SupportModel(); 
            try
            {
                if (id != null && id != 0)
                {
                    model = await _iUtility.GetSupportById(Convert.ToInt32(id));
                }
            }
            catch (Exception ex)
            { }
            return PartialView("_ChatMessage", model);
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
        #endregion
    }
}
