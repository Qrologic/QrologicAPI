using QroApi.BLL;
using QroApi.Core;
using QroApi.CustomAttributes;
using QroApi.MODEL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QroApi.Areas.Member.Controllers
{
    [Authorize(Role.SuperDistributor,Role.MasterDistributor,Role.Distributor,Role.Retailer,Role.Customer,Role.ApiMember)]
    [Area("Member")]
    public class HomeController : Controller
    {
        #region Properties
        private readonly IMemberService _iMemberService;
        private readonly ISettings _iSettings;
        private readonly IDashboard _iDashboard;
        #endregion

        #region Constructor
        public HomeController(IMemberService iMemberService,ISettings iSettings, IDashboard iDashboard)
        {
            _iMemberService = iMemberService;
            _iSettings = iSettings;
            _iDashboard=iDashboard;
        }
        #endregion

        #region Dashboard
        public async Task<IActionResult> Dashboard()
        {
            DashboardModel model = new DashboardModel();
            int msrNo = User.Identity.GetDetailOf("MsrNo") == "" ? 0 : Convert.ToInt32(User.Identity.GetDetailOf("MsrNo"));
            if (msrNo > 0)
            {
                model = await _iDashboard.GetMemberDashboardByMsrNo(msrNo);
            }
            return View(model);
        }
        #endregion

        #region Dashboard2
        public async Task<IActionResult> Dashboard2()
        {
            return View();
        }
        #endregion

        #region Profile
        public IActionResult Profile()
        {
            return View();
        }
        #endregion

        #region Company Detail
        public async Task<IActionResult> GetCompanyLogo()
        {
            try
            {
                Result result = new Result();
                CompanyModel model = new CompanyModel();                
                model = await _iSettings.GetCompanyDetailById(1);
                model.CompanyLogo = "../../images/UploadImages/" + model.CompanyLogo;
                result.Results = model;
                result.Status = true;
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

        #region Get Operator
        public async Task<IActionResult> GetOperator(int? serviceId)
        {
            var model = await _iMemberService.GetOpertorByServiceId(Convert.ToInt32(serviceId));
            return Json(model);
        }

        #endregion

        #region Get Operator Detail
        public async Task<IActionResult> GetOperatorDetail(int ? id)
        {
            var model = await _iMemberService.GetOpertorDetailById(Convert.ToInt32(id));
            return Json(model);
        }

        #endregion

        #region Get Circle
        public async Task<IActionResult> GetCircle()
        {
            var model = await _iMemberService.GetCircle();
            return Json(model);
        }
        #endregion

        #region Recharge Process
        [HttpPost]
        public async Task<IActionResult> RechargeProcess(RechargePorcessModel model)
        {
            RechargeResult result = new RechargeResult();
            try
            {
                int msrNo = Convert.ToInt32(User.Identity.GetDetailOf("MsrNo")=="" ?"0":User.Identity.GetDetailOf("MsrNo"));                
                result = await _iMemberService.RechargeProcess(model, "Web", msrNo);
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(new RechargeResult
                {
                    isSuccess = "Pending",
                    status = true,
                    message = "Recharge Pending on " + model.Number
                });
            }
        }

        #endregion

        #region Bill Fatch
        [HttpPost]
        public async Task<IActionResult> BillFatch(BBPS.BillFatch model)
        {            
            var response = await _iMemberService.BillFatch(model);
            return Json(response);
        }
        #endregion

        #region Bill Pay
        [HttpPost]
        public async Task<IActionResult> BillPay(BBPS.BillPayRequest model)
        {
            BBPS.Response result = new BBPS.Response();
            try
            {
                int msrNo = Convert.ToInt32(User.Identity.GetDetailOf("MsrNo") == "" ? "0" : User.Identity.GetDetailOf("MsrNo"));
                result = await _iMemberService.BillPay(model, "Web", msrNo);
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(new BBPS.Response
                {                   
                    status = true,
                    response_code = 0,
                    message = "Billing Pending on " + model.canumber
                });
            }
        }

        #endregion
       

        #region Recharge Reciept        
        public async Task<IActionResult> RechargeReciept(int ? id)
        {
            int msrNo = Convert.ToInt32(User.Identity.GetDetailOf("MsrNo") == "" ? "0" : User.Identity.GetDetailOf("MsrNo"));
            var response = await _iMemberService.RechargeReciept(Convert.ToInt32(id),msrNo);
            return View(response);
        }
        #endregion
    }
}
