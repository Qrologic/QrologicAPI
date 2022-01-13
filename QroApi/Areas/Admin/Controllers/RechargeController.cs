using QroApi.BLL;
using QroApi.MODEL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using System.IO;
using QroApi.Core;
using Newtonsoft.Json;
using QroApi.CustomAttributes;
using Microsoft.AspNetCore.Hosting;

namespace QroApi.Areas.Admin.Controllers
{
    [Authorize(Role.Admin, Role.SuperAdmin, Role.SubAdmin)]
    [Area("Admin")]
    public class RechargeController : Controller
    {
        #region Properties

        private readonly IRecharge _iRecharge;
        private readonly ICommonClass _iCommonClass;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IDMT _iDMT;
        #endregion

        #region Constuctor
        public RechargeController(IRecharge iRecharge, IWebHostEnvironment hostEnvironment, ICommonClass iCommonClass, IDMT iDMT)
        {
            _iRecharge = iRecharge;
            _webHostEnvironment = hostEnvironment;
            _iCommonClass = iCommonClass;
            _iDMT = iDMT;
        }
        #endregion        

        #region Add API / ListAPI
        #region Add API
        public async Task<IActionResult> AddAPI(int? id)
        {
            RechargeApiModel model = new RechargeApiModel();
            if (id != null)
            {
                model = await _iRecharge.GetAPIById(Convert.ToInt32(id));
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddAPI(RechargeApiModel model)
        {
            try
            {
                Result result = new Result();
                if (ModelState.IsValid)
                {
                    result = await _iRecharge.AddEditRechargeAPI(model);
                    result.RedirectUrl = "/Admin/Recharge/ListAPI";
                    result.isRedirect = true;
                    result.IsPost = false;
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

        #region List API
        public async Task<IActionResult> ListAPI()
        {

            return View();
        }
        [Produces("application/json")]
        public async Task<IActionResult> LoadListAPI()
        {
            int draw = 0;
            ReportList result = new ReportList();
            try
            {
                draw = Convert.ToInt32(Request.Query["draw"]);
                int StartIndex = Convert.ToInt32(Request.Query["start"]);
                int PageSize = Convert.ToInt32(Request.Query["length"]);
                string SortCol = Convert.ToString(Request.Query["order[0][column]"]);
                string SortDir = Request.Query["order[0][dir]"];
                string SearchField = Request.Query["search[value]"].FirstOrDefault()?.Trim();
                result = await _iRecharge.GetAllAPIList(SearchField, StartIndex, PageSize, SortCol, SortDir);
                result.draw = draw;
            }
            catch (Exception ex)
            {
                result.draw = draw;
            }
            return Json(result);

        }
        #endregion

        #region Delete API
        public async Task<IActionResult> DeleteAPI(int? id)
        {
            try
            {
                Result model = new Result();
                model = await _iRecharge.DeleteAPI(Convert.ToInt32(id));
                return Json(new Result
                {
                    Status = true,
                    Results = model.Results,
                    Message = "API Succesfully Deleted"
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

        #region Active / Deactive API
        public async Task<IActionResult> ActiveAPI(int? id)
        {
            try
            {
                Result model = new Result();
                model = await _iRecharge.ActiveAPI(Convert.ToInt32(id));
                return Json(new Result
                {
                    Status = true,
                    Results = model.Results,
                    Message = "API Succesfully Acivated or Deactivated"
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

        #region Get API
        public async Task<IActionResult> GetAPI()
        {
            try
            {
                Result model = new Result();
                model = await _iRecharge.GetAPI();
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

        #region Service
        #region Get Service
        public async Task<IActionResult> GetService()
        {
            try
            {
                Result model = new Result();
                model = await _iRecharge.GetService();
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

        #region List Service
        public async Task<IActionResult> ListService()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LoadServiceList()
        {
            int draw = 0;
            ReportList result = new ReportList();
            try
            {
                draw = Convert.ToInt32(HttpContext.Request.Form["draw"].FirstOrDefault());
                int StartIndex = Convert.ToInt32(Request.Form["start"].FirstOrDefault());
                int PageSize = Convert.ToInt32(Request.Form["length"].FirstOrDefault());
                string SortCol = Convert.ToString(Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault());
                string SortDir = Convert.ToString(Request.Form["order[0][dir]"].FirstOrDefault());
                string SearchField = Convert.ToString(Request.Form["search[value]"].FirstOrDefault());
                result = await _iRecharge.GetAllService(SearchField, StartIndex, PageSize, SortCol, SortDir);
                result.draw = draw;
            }
            catch (Exception ex)
            {
                result.draw = draw;
            }
            return Json(result);

        }
        #endregion

        #region AddEdit Service
        public async Task<IActionResult> AddService(int? id)
        {
            ServiceModel model = new ServiceModel();
            if (id != null && id != 0)
            {
                model = await _iRecharge.GetServiceById(Convert.ToInt32(id));
            }
            return PartialView("_Service", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddService(ServiceModel model)
        {
            try
            {
                Result result = new Result();
                if (ModelState.IsValid)
                {
                    result = await _iRecharge.AddEditService(model);
                    result.RedirectUrl = "/Admin/Recharge/LoadServiceList";
                    result.isRedirect = false;
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

        #region Delete Service
        public async Task<IActionResult> DeleteService(int? id)
        {
            try
            {
                Result model = new Result();
                model = await _iRecharge.DeleteService(Convert.ToInt32(id));
                return Json(new Result
                {
                    Status = true,
                    Results = model.Results,
                    Message = "Service Succesfully Deleted"
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

        #region Active / Deactive Service
        public async Task<IActionResult> ActiveService(int? id)
        {
            try
            {
                Result model = new Result();
                model = await _iRecharge.ActiveService(Convert.ToInt32(id));
                return Json(new Result
                {
                    Status = true,
                    Results = model.Results,
                    Message = "Service Succesfully Acivated or Deactivated"
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
        #region GetServiceForFilter
        public async Task<IActionResult> GetServiceForFilter()
        {
            try
            {
                Result model = new Result();
                model = await _iRecharge.GetServiceForFilter();
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

        #region Operator
        #region List Operator
        public async Task<IActionResult> ListOperator()
        {

            return View();
        }
        [Produces("application/json")]
        public async Task<IActionResult> LoadOperatorList()
        {
            int draw = 0;
            ReportList result = new ReportList();
            try
            {
                draw = Convert.ToInt32(Request.Query["draw"]);
                int StartIndex = Convert.ToInt32(Request.Query["start"]);
                int PageSize = Convert.ToInt32(Request.Query["length"]);
                string SortCol = Convert.ToString(Request.Query["order[0][column]"]);
                string SortDir = Request.Query["order[0][dir]"];
                string SearchField = Request.Query["search[value]"].FirstOrDefault()?.Trim();
                result = await _iRecharge.GetAllOperator(SearchField, StartIndex, PageSize, SortCol, SortDir);
                result.draw = draw;
            }
            catch (Exception ex)
            {
                result.draw = draw;
            }
            return Json(result);

        }
        #endregion

        #region AddEdit Operator
        public async Task<IActionResult> AddOperator(int? id)
        {
            Operator model = new Operator();
            if (id != null && id != 0)
            {
                model = await _iRecharge.GetOperatorById(Convert.ToInt32(id));
            }
            return PartialView("_Operator", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOperator([Bind("ServiceId,OperatorId,OperatorName,OperatorCode,OperatorImage,ImageFile")] Operator model)
        {
            try
            {
                Result result = new Result();
                if (ModelState.IsValid)
                {
                    if (model.ImageFile != null)
                    {
                        model.OperatorImage =await _iCommonClass.UploadImage(_webHostEnvironment.WebRootPath, model.ImageFile);
                    }
                    result = await _iRecharge.AddEditOperator(model);
                    result.RedirectUrl = "/Admin/Recharge/LoadOperatorList";
                    result.isRedirect = false;
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

        #region Delete Operator
        public async Task<IActionResult> DeleteOperator(int? id)
        {
            try
            {
                Result model = new Result();
                model = await _iRecharge.DeleteOperator(Convert.ToInt32(id));
                return Json(new Result
                {
                    Status = true,
                    Results = model.Results,
                    Message = "Operator Succesfully Deleted"
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

        #region Active / Deactive Operator
        public async Task<IActionResult> ActiveOperator(int? id)
        {
            try
            {
                Result model = new Result();
                model = await _iRecharge.ActiveOperator(Convert.ToInt32(id));
                return Json(new Result
                {
                    Status = true,
                    Results = model.Results,
                    Message = "Operator Succesfully Acivated or Deactivated"
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

        #region Circle
        #region List Circle
        public async Task<IActionResult> ListCircle()
        {

            return View();
        }
        [Produces("application/json")]
        public async Task<IActionResult> LoadCircleList()
        {
            int draw = 0;
            ReportList result = new ReportList();
            try
            {
                draw = Convert.ToInt32(Request.Query["draw"]);
                int StartIndex = Convert.ToInt32(Request.Query["start"]);
                int PageSize = Convert.ToInt32(Request.Query["length"]);
                string SortCol = Convert.ToString(Request.Query["order[0][column]"]);
                string SortDir = Request.Query["order[0][dir]"];
                string SearchField = Request.Query["search[value]"].FirstOrDefault()?.Trim();
                result = await _iRecharge.GetAllCircle(SearchField, StartIndex, PageSize, SortCol, SortDir);
                result.draw = draw;
            }
            catch (Exception ex)
            {
                result.draw = draw;
            }
            return Json(result);

        }
        #endregion

        #region AddEdit Circle
        public async Task<IActionResult> AddCircle(int? id)
        {
            CircleModel model = new CircleModel();
            if (id != null && id != 0)
            {
                model = await _iRecharge.GetCircleById(Convert.ToInt32(id));
            }
            return PartialView("_Circle", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCircle(CircleModel model)
        {
            try
            {
                Result result = new Result();
                if (ModelState.IsValid)
                {
                    result = await _iRecharge.AddEditCircle(model);
                    result.RedirectUrl = "/Admin/Recharge/LoadCircleList";
                    result.isRedirect = false;
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

        #region Delete Circle
        public async Task<IActionResult> DeleteCircle(int? id)
        {
            try
            {
                Result model = new Result();
                model = await _iRecharge.DeleteCircle(Convert.ToInt32(id));
                return Json(new Result
                {
                    Status = true,
                    Results = model.Results,
                    Message = "Circle Succesfully Deleted"
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

        #region Active / Deactive Circle
        public async Task<IActionResult> ActiveCircle(int? id)
        {
            try
            {
                Result model = new Result();
                model = await _iRecharge.ActiveCircle(Convert.ToInt32(id));
                return Json(new Result
                {
                    Status = true,
                    Results = model.Results,
                    Message = "Circle Succesfully Acivated or Deactivated"
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

        #region API Operator Code & Commission
        public async Task<IActionResult> OperatorCode(int? serviceId, int? apiId)
        {
            OperatorCodeModel model = new OperatorCodeModel();
            try
            {
                model.list = await _iRecharge.GetOperatorForAPI(Convert.ToInt32(serviceId), Convert.ToInt32(apiId));
            }
            catch (Exception ex) { }
            return PartialView("OperatorCode", model);
        }
        [HttpPost]
        public async Task<IActionResult> OperatorCode([FromBody] OperatorCodeModel[] modelArray, int apiId)
        {
            try
            {
                Result result = new Result();
                if (ModelState.IsValid)
                {
                    result = await _iRecharge.SaveOperatorCode(modelArray, apiId);
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
        public async Task<IActionResult> LoadOperatorCode(int? serviceId, int? apiId)
        {
            OperatorCodeModel model = new OperatorCodeModel();
            model.list = await _iRecharge.GetOperatorForAPI(Convert.ToInt32(serviceId), Convert.ToInt32(apiId));
            return PartialView("_OperatorCode", model);
        }
        #endregion

        #region API Circle Code 
        public async Task<IActionResult> CircleCode(int? apiId)
        {
            CircleCodeModel model = new CircleCodeModel();
            try
            {

                //model.list = await _iRecharge.GetCircleForAPI(Convert.ToInt32(apiId));
            }
            catch (Exception ex) { }
            return PartialView("CircleCode", model);
        }
        [HttpPost]
        public async Task<IActionResult> CircleCode([FromBody] CircleCodeModel[] modelArray, int apiId)
        {
            try
            {
                Result result = new Result();
                if (ModelState.IsValid)
                {
                    result = await _iRecharge.SaveCircleCode(modelArray, apiId);
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
        public async Task<IActionResult> LoadCircleCode(int? apiId)
        {
            CircleCodeModel model = new CircleCodeModel();
            model.list = await _iRecharge.GetCircleForAPI(Convert.ToInt32(apiId));
            return PartialView("_CircleCode", model);
        }
        #endregion

        #region API Settings
        public async Task<IActionResult> ApiSettings()
        {
            ICICI._path = _webHostEnvironment.WebRootPath;
            ApiList model = new ApiList();
            try
            {
                model = await _iRecharge.GetAPIWithBalance();               
            }
            catch (Exception ex) { }
            return View(model);
        }
        public async Task<IActionResult> LoadApiList()
        {
            ICICI._path = _webHostEnvironment.WebRootPath;
            ApiList model = new ApiList();
            try
            {
                model = await _iRecharge.GetAPIWithBalance();
            }
            catch (Exception ex) { }
            return PartialView("_ApiList", model);
        }
        public async Task<IActionResult> SwitchApi(int? apiId)
        {
            try
            {
                Result model = new Result();
                model = await _iRecharge.SwitchApi(Convert.ToInt32(apiId));
                return Json(new Result
                {
                    Status = true,
                    Results = model.Results,
                    Message = "API Succesfully Switched"
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

        public async Task<IActionResult> SwitchPackageWise()
        {
            PackageWiseApi model = new PackageWiseApi();
            return PartialView("_PackageWiseSwitchApi", model);
        }
        [HttpPost]
        public async Task<IActionResult> SwitchPackageWise(PackageWiseApi model)
        {
            try
            {
                Result result = new Result();
                result = await _iRecharge.SwitchPackageWiseApi(model.apiId, model.packageId);
                return Json(new Result
                {
                    isRedirect = false,
                    Status = true,
                    Results = result.Results,
                    Message = "API Succesfully Switched"
                });
            }
            catch (Exception ex)
            {
                return Json(new Result
                {
                    isRedirect = false,
                    Status = false,
                    Results = null,
                    Message = ex.Message.ToString()
                });
            }
        }
        public async Task<IActionResult> SwitchApiOperatorWise()
        {
            OperatorWiseApi model = new OperatorWiseApi();
            await Task.Delay(0);
            return PartialView("OperatorWiseSwitchApi", model);
        }
        [HttpPost]
        public async Task<IActionResult> SwitchApiOperatorWise([FromBody] OperatorWiseApi[] modelArray)
        {
            try
            {
                Result result = new Result();
                if (ModelState.IsValid)
                {
                    result = await _iRecharge.SwitchOperatorWiseApi(modelArray);
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
        public async Task<IActionResult> GetOperatorByServiceId(int? serviceId)
        {
            OperatorWiseApi model = new OperatorWiseApi();
            model = await _iRecharge.GetOperatorByServiceId(Convert.ToInt32(serviceId));
            return PartialView("_OperatorWiseSwitchApi", model);
        }

        #region GetOperatorByServiceIdForFilter
        public async Task<IActionResult> GetOperatorByServiceIdForFilter(int? serviceId)
        {
            try
            {
                Result model = new Result();
                model = await _iRecharge.GetOperatorByServiceIdForFilter(Convert.ToInt32(serviceId));
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
            model.list = await _iRecharge.GetCommission(Convert.ToInt32(packageId), 0, Convert.ToInt32(serviceId), "Admin");
            return PartialView("_ManageCommission", model);
        }
        #endregion

        #region Pending Recharge
        public async Task<IActionResult> PendingRecharge()
        {
            return View();
        }
        public async Task<IActionResult> LoadPendingRecharge()
        {
            TxnRecharge model = new TxnRecharge();
            model.list = await _iRecharge.GetPendingRecharge();
            return PartialView("_PendingRecharge", model);
        }
        #endregion

        #region Check Status
        [HttpPost]
        public async Task<IActionResult> CheckStatus([FromBody] TxnRecharge[] modelArray)
        {
            Result result = new Result();
            try
            {
                result = await _iRecharge.CheckStatus(modelArray);
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

        #region Force Success
        [HttpPost]
        public async Task<IActionResult> ForceSuccess([FromBody] TxnRecharge[] modelArray)
        {
            Result result = new Result();
            try
            {
                result = await _iRecharge.ForceSuccess(modelArray);
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

        #region Force Failed
        [HttpPost]
        public async Task<IActionResult> ForceFailed([FromBody] TxnRecharge[] modelArray)
        {
            Result result = new Result();
            try
            {
                result = await _iRecharge.ForceFailed(modelArray);
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

    

    }

}
