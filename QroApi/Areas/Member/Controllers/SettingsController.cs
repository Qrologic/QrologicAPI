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
    [Authorize(Role.SuperDistributor, Role.MasterDistributor, Role.Distributor, Role.Retailer, Role.Customer, Role.ApiMember)]
    [Area("Member")]
    public class SettingsController : Controller
    {
        #region Properties
        private readonly ISettings _iSettings;
        private readonly IMember _iMember;
        #endregion

        #region Constuctor
        public SettingsController(ISettings iSettings, IMember iMember)
        {
            _iSettings = iSettings;
            _iMember = iMember;
        }
        #endregion

        #region  Profile
        public async Task<IActionResult> Profile()
        {
            MemberDetail model = new MemberDetail();
            try
            {
                int msrNo = User.Identity.GetDetailOf("MsrNo")==""?0:Convert.ToInt32(User.Identity.GetDetailOf("MsrNo"));
                model = await _iMember.GetMemberDetail(Convert.ToInt32(msrNo));
            }
            catch (Exception ex) { }
            return View(model);
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
                    result.RedirectUrl = "/Member/Settings/GetMemberBankList";
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

        public IActionResult apiAccount()
        {
            return View();
        }

        
        
    }
}
