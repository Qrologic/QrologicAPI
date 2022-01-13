using QroApi.BLL;
using QroApi.Core;
using QroApi.CustomAttributes;
using QroApi.MODEL;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QroApi.Areas.Admin.Controllers
{
    [Authorize(Role.Admin, Role.SuperAdmin, Role.SubAdmin)]
    [Area("Admin")]
    public class SettingsController : Controller
    {
        #region Properties
        private readonly ISettings _iSettings;
        private readonly ICommonClass _iCommonClass;
        private readonly IWebHostEnvironment _webHostEnvironment;
        #endregion

        #region Constuctor
        public SettingsController(ISettings iSettings, IWebHostEnvironment hostEnvironment, ICommonClass iCommonClass)
        {
            _iSettings = iSettings;
            _webHostEnvironment = hostEnvironment;
            _iCommonClass = iCommonClass;
        }
        #endregion

        #region MemberBank
        #region MyBank
        public IActionResult BankDetail()
        {
            return View();
        }
        #region Get MemberBank List
        [HttpPost]
        public async Task<IActionResult> GetMemberBankList()
        {
            int draw = Convert.ToInt32(HttpContext.Request.Form["draw"].FirstOrDefault());
            int StartIndex = Convert.ToInt32(Request.Form["start"].FirstOrDefault());
            int PageSize = Convert.ToInt32(Request.Form["length"].FirstOrDefault());
            string SortCol = Convert.ToString(Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault());
            string SortDir = Convert.ToString(Request.Form["order[0][dir]"].FirstOrDefault());
            string SearchField = Convert.ToString(Request.Form["search[value]"].FirstOrDefault());
            int msrNo = Convert.ToInt32(User.Identity.GetDetailOf("MsrNo"));
            ReportList result = await _iSettings.GetMemberBankList(SearchField, StartIndex, PageSize, SortCol, SortDir, msrNo);
            result.draw = draw;
            return Json(result);
        }

        #endregion
        #endregion
        #region Add MemberBank
        public async Task<IActionResult> AddMemberBank(int? id)
        {
            MemberBankModel model = new MemberBankModel();
            if (id != null)
            {
                model = await _iSettings.GetMemberBankById(Convert.ToInt32(id));
            }
            return PartialView("_AddMemberBank", model);
        }

        [HttpPost]
        public async Task<IActionResult> AddMemberBank(MemberBankModel model)
        {
            try
            {
                Result result = new Result();
                model.MsrNo = Convert.ToInt32(User.Identity.GetDetailOf("MsrNo"));
                if (ModelState.IsValid)
                {
                    result = await _iSettings.AddEditMemberBank(model);
                    result.RedirectUrl = "/Admin/Settings/GetMemberBankList";
                    result.isRedirect = false;
                    result.IsPost = true;
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
        #region Delete MemberBank
        public async Task<IActionResult> DeleteMemberBank(int? id)
        {
            try
            {
                Result model = new Result();
                model = await _iSettings.DeleteMemberBank(Convert.ToInt32(id));
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
        #region Active / Deactive MemberBank
        public async Task<IActionResult> ActiveMemberBank(int? id)
        {
            try
            {
                Result model = new Result();
                model = await _iSettings.ActiveMemberBank(Convert.ToInt32(id));
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

        #region Company
        public async Task<IActionResult> Company()
        {
            CompanyModel model = new CompanyModel();
            int msrNo = User.Identity.GetDetailOf("MsrNo") == "" ? 0 : Convert.ToInt32(User.Identity.GetDetailOf("MsrNo"));
            if (msrNo > 0)
            {
                model = await _iSettings.GetCompanyDetailById(msrNo);
            }
            return View(model);
        }
        public async Task<IActionResult> GetCompany()
        {
            CompanyModel model = new CompanyModel();
            int msrNo = User.Identity.GetDetailOf("MsrNo") == "" ? 0 : Convert.ToInt32(User.Identity.GetDetailOf("MsrNo"));
            if (msrNo > 0)
            {
                model = await _iSettings.GetCompanyDetailById(msrNo);
            }
            return PartialView("_Company", model);
        }
        public async Task<IActionResult> AddEditCompany([Bind("Id,CompanyName,CompanyOwner,Mobile,Email,WebsiteUrl,GstNo,CIN,PanNo,TanNo,Copyright,Address")] CompanyModel model)
        {
            try
            {

                Result result = new Result();
                int msrNo = User.Identity.GetDetailOf("MsrNo") == "" ? 0 : Convert.ToInt32(User.Identity.GetDetailOf("MsrNo"));
                model.MsrNo = msrNo;
                if (ModelState.IsValid)
                {
                    if (model.ImageFile != null)
                    {
                        model.CompanyLogo = await _iCommonClass.UploadImage(_webHostEnvironment.WebRootPath, model.ImageFile);
                    }
                    result = await _iSettings.AddEditCompanyDetail(model);
                    result.RedirectUrl = "/Admin/Settings/Company";
                    result.isRedirect = true;
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

        #region Update Logo
        public async Task<IActionResult> UpdateCompanyLogo([Bind("Id,ImageFile")] CompanyModel model)
        {
            try
            {
                Result result = new Result();
                if (model.ImageFile != null)
                {
                    model.CompanyLogo = await _iCommonClass.UploadImage(_webHostEnvironment.WebRootPath, model.ImageFile);
                }
                result = await _iSettings.UpdateCompanyLogo(model,"logo");
                result.RedirectUrl = "/Admin/Settings/Company";
                result.isRedirect = true;

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
        
        #region Update Fevicon 
        public async Task<IActionResult> UpdateCompanyFevicon([Bind("Id,ImageFile")] CompanyModel model)
        {
            try
            {
                Result result = new Result();
                if (model.ImageFile != null)
                {
                   model.CompanyLogo= model.FeviconIcon = await _iCommonClass.UploadFevicon(_webHostEnvironment.WebRootPath, model.ImageFile);
                }
                result = await _iSettings.UpdateCompanyLogo(model,"fevicon");
                result.RedirectUrl = "/Admin/Settings/Company";
                result.isRedirect = true;

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
