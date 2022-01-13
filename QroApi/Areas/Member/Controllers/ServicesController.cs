using QroApi.BLL;
using QroApi.Core;
using QroApi.CustomAttributes;
using QroApi.MODEL;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QroApi.Areas.Member.Controllers
{
    [Authorize(Role.SuperDistributor, Role.MasterDistributor, Role.Distributor, Role.Retailer, Role.Customer, Role.ApiMember)]
    [Area("Member")]
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

        #region DMT

        #region DMT V1
        public IActionResult DMT()
        {
            return View();
        }
        #endregion

        #region Get Bank
        public async Task<IActionResult> GetBank()
        {
            var response = await _iDMT.GetBank();
            return Json(response);
        }
        #endregion

        #region Remitter Detail
        [HttpPost]
        public async Task<IActionResult> RemitterDetail(dmtModels.FatchRemitter model)
        {
            model.bank3_flag = "No";
            var response = await _iDMT.RemitterDetail(model);
            return Json(response);
        }
        #endregion

        #region Remitter Registration
        [HttpPost]
        public async Task<IActionResult> RemitterRegistration(dmtModels.RemitterRegistration model)
        {
            model.bank3_flag = "No";
            model.gst_state = "07";
            model.dob = Convert.ToDateTime(model.dob).ToString("yyyy-MM-dd");
            var response = await _iDMT.RemitterRegistration(model);
            return Json(response);
        }
        #endregion

        #region Fetch Beneficiary
        [HttpPost]
        public async Task<IActionResult> FetchBeneficiary(dmtModels.FetchBeneficiary model)
        {
            var response = await _iDMT.FetchBeneficiary(model);
            return Json(response);
        }
        #endregion

        #region Beneficiary Registration
        [HttpPost]
        public async Task<IActionResult> BeneficiaryRegistration(dmtModels.RegisterBeneficiary model)
        {
            model.verified = "0";
            model.gst_state = "07";
            var response = await _iDMT.RegisterBeneficiary(model);
            return Json(response);
        }
        #endregion

        #region Beneficiary Verify
        [HttpPost]
        public async Task<IActionResult> BeneficiaryVerify(dmtModels.BeneficiaryVerify model)
        {
            int msrNo = User.Identity.GetDetailOf("MsrNo") == "" ? 0 : Convert.ToInt32(User.Identity.GetDetailOf("MsrNo"));
            model.gst_state = "07";
            var response = await _iDMT.VerifyBeneficiary(model, msrNo, "Web");
            return Json(response);
        }
        #endregion

        #region Beneficiary Delete
        [HttpPost]
        public async Task<IActionResult> BeneficiaryDelete(dmtModels.DeleteBeneficiary model)
        {
            var response = await _iDMT.DeleteBeneficiary(model);
            return Json(response);
        }
        #endregion

        #region Confirm Transaction
        [HttpPost]
        public async Task<IActionResult> ConfirmTransaction(dmtModels.Transaction model)
        {
            dmtBulkReciept response = new dmtBulkReciept();
            try
            {
                int msrNo = User.Identity.GetDetailOf("MsrNo") == "" ? 0 : Convert.ToInt32(User.Identity.GetDetailOf("MsrNo"));
                model.gst_state = "07";
                model.pipe = "bank1";
                ICICI._path = _webHostEnvironment.WebRootPath;
                response = await _iDMT.ConfirmTransaction(model, msrNo, "Web");
                response.AgentMobile = User.Identity.GetDetailOf("Mobile");
                response.AgentName = User.Identity.Name;
                TempData["DMTTxnList"] = JsonConvert.SerializeObject(response);
                return Json(response);
            }
            catch (Exception ex)
            {
                return Json(response = new dmtBulkReciept
                {
                    response_code = false,
                    message = ex.Message.ToString()
                }) ; 
            }
            //return RedirectToAction("dmtReciept", "Services", new { area = "Member" });

        }
        #endregion

        #region Get IFSC
        public async Task<IActionResult> GetIFSC(int? id)
        {
            var response = await _iDMT.GetIFSCByBankId(Convert.ToInt32(id));
            return Json(response);
        }
        #endregion

        #region DMT  V2
        [Route("member/v2/dmt")]
        public IActionResult DMTSecond()
        {
            return View();
        }
        #endregion

        #region dmt Reciept
        public async Task<IActionResult> dmtReciept()
        {
            dmtBulkReciept model = new dmtBulkReciept();
            model = JsonConvert.DeserializeObject<dmtBulkReciept>(Convert.ToString(TempData["DMTTxnList"]));
            return View(model);
        }
        #endregion

        #endregion
    }
}
