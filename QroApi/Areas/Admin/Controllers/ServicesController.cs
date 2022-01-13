using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QroApi.BLL;
using QroApi.Core;
using QroApi.CustomAttributes;
using QroApi.MODEL;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace QroApi.Areas.Admin.Controllers
{
    [Authorize(Role.Admin, Role.SuperAdmin, Role.SubAdmin)]
    [Area("Admin")]
    public class ServicesController : Controller
    {
        #region Properties
        private readonly IDMT _iDMT;
        private readonly IWebHostEnvironment _webHostEnvironment;
        #endregion

        #region Constructor
        public ServicesController(IDMT iDMT, IWebHostEnvironment webHostEnvironment)
        {
            _iDMT = iDMT;
            _webHostEnvironment = webHostEnvironment;
        }
        #endregion

        #region DMT Api Balance
        public async Task<IActionResult> dmtApiBalance()
        {
            dmtApiBalance model = new dmtApiBalance();
            try
            {               
               // model = await _iDMT.ApiBalance();
            }
            catch (Exception ex)
            {
                //model = new dmtApiBalance { icici_status = false, icici_bal = "0", rnfi_bal = "0", rnfi_status = false };
            }
            return Json(model);
        }
        #endregion

        #region Pending DMT Transaction
        public IActionResult dmtPending()
        {
            return View();
        }
        public async Task<IActionResult> loaddmtPending()
        {
            PendingDMT model = new PendingDMT();
            model = await _iDMT.GetPendingTransaction();
            return PartialView("_dmtPending", model);
        }
        #endregion

        #region DMT Transaction Enquiry
        [HttpPost]
        public async Task<IActionResult> TransactionEnquiry(TransactionEnquiry model)
        {
            Result result = new Result();
            result = await _iDMT.TransactionEnquiry(model);
            return Json(result);
        }
        #endregion

        #region DMT Api List

        public IActionResult dmtApiList()
        {
            return View();
        }

        public async Task<IActionResult> loaddmtApiList()
        {
            ReportList result = new ReportList();
            ICICI._path = _webHostEnvironment.WebRootPath;
            result = await _iDMT.ApiBalance();
            return Json(result);
        }
        #endregion

        #region Refund DMT

        public IActionResult dmtRefund()
        {
            return View();
        }
        public async Task<IActionResult> loaddmtRefund(string id)
        {
            PendingDMT model = new PendingDMT();
            model = await _iDMT.FindTransaction(id);
            return PartialView("_dmtRefund", model);
        }
        #region Send OTP For Refund
        [HttpPost]
        public async Task<IActionResult> SendOTPForRefund(TransactionEnquiry model)
        {
            var result = await _iDMT.SendOTPForRefund(model);
            return Json(result);
        }
        #endregion
        #region Refund Transaction
        [HttpPost]
        public async Task<IActionResult> RefundTransaction(TransactionEnquiry model)
        {
            var result = await _iDMT.RefundTransaction(model);
            return Json(result);
        }
        #endregion
        #endregion

        #region DMT Force Update Transaction 
        public async Task<IActionResult> dmtForceUpdate(int ? id,int ?type)
        {
            Result result = new Result();
            try
            {
                result = await _iDMT.ForceUpdateTransaction(Convert.ToInt32(id), Convert.ToInt32(type));
            }
            catch (Exception ex)
            {
                result = new Result { Status = false, Message = ex.Message.ToString() };
            }
            return Json(result);
        }
        #endregion

        #region DMT API Charge
        public IActionResult dmtApiCharge()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GetDMTApiChargeByApiId(CommonFilter filetr)
        {
            int draw = Convert.ToInt32(HttpContext.Request.Form["draw"].FirstOrDefault());
            int StartIndex = Convert.ToInt32(Request.Form["start"].FirstOrDefault());
            int PageSize = Convert.ToInt32(Request.Form["length"].FirstOrDefault());
            string SortCol = Convert.ToString(Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault());
            string SortDir = Convert.ToString(Request.Form["order[0][dir]"].FirstOrDefault());
            string SearchField = Convert.ToString(Request.Form["search[value]"].FirstOrDefault());
            ReportList result = await _iDMT.GetApiChargeByApiId(SearchField, StartIndex, PageSize, SortCol, SortDir, filetr);
            result.draw = draw;
            return Json(result);
        }
        public async Task<IActionResult> GetApiChargeById(int? id)
        {
            dmtApiCharge model = new dmtApiCharge();
            if (id != null)
            {
                model = await _iDMT.GetApiChargeById(Convert.ToInt32(id));
            }
            return Json(model);
        }

     
        public async Task<IActionResult> AddEditApiSurcharge(int? id)
        {
            dmtApiCharge model = new dmtApiCharge();
            try
            {
                if (id != null )
                {
                    if (id > 0)
                    {
                        model = await _iDMT.GetApiChargeById(Convert.ToInt32(id));
                    }
                }
            }
            catch (Exception ex) { }
            return PartialView("_dmtCharge", model);
        }
        [HttpPost]
        public async Task<IActionResult> AddEditApiSurcharge(dmtApiCharge model)
        {
            Result result = new Result();
            try
            {
                result = await _iDMT.AddEditApiSurcharge(model);
                result.RedirectUrl = "/Admin/Services/GetDMTApiChargeByApiId";
                result.isRedirect = false;
                result.IsPost = true;
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
            return Json(result);
        }
        #endregion

        #region Get API For DDL
        public async Task<IActionResult> GetAPI()
        {
            try
            {
                Result model = new Result();
                model = await _iDMT.GetAPI();
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

        #region Switch DMT API
        public async Task<IActionResult> SwitchApi(int? id)
        {
            try
            {
                Result model = new Result();
                model = await _iDMT.SwitchApi(Convert.ToInt32(id));
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

        #region DMT Api List

        public IActionResult dmtApiLogs()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> loaddmtApiLogs(CommonFilter filter)
        {
            ReportList result = new ReportList();
            int draw = Convert.ToInt32(HttpContext.Request.Form["draw"].FirstOrDefault());
            int StartIndex = Convert.ToInt32(Request.Form["start"].FirstOrDefault());
            int PageSize = Convert.ToInt32(Request.Form["length"].FirstOrDefault());
            string SortCol = Convert.ToString(Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault());
            string SortDir = Convert.ToString(Request.Form["order[0][dir]"].FirstOrDefault());
            string SearchField = Convert.ToString(Request.Form["search[value]"].FirstOrDefault());        
            result = await _iDMT.ApiLogs(SearchField, StartIndex, PageSize, SortCol, SortDir,0, filter);
            result.draw = draw;
            return Json(result);
        }
        #endregion




    }
}
