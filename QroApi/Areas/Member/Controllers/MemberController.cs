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
    public class MemberController : Controller
    {
        #region Properties
        private readonly IMember _iMember;
        #endregion
        #region Constuctor
        public MemberController(IMember iMember)
        {
            _iMember = iMember;
        }
        #endregion

        #region Member
        #region List Member
        public IActionResult ListMember()
        {
            return View();
        }
        #region Get Member List

        [HttpPost]
        public async Task<IActionResult> GetMemberList(CommonFilter model)
        {
            int msrNo = Convert.ToInt32(User.Identity.GetDetailOf("MsrNo"));
            int draw = Convert.ToInt32(HttpContext.Request.Form["draw"].FirstOrDefault());
            int StartIndex = Convert.ToInt32(Request.Form["start"].FirstOrDefault());
            int PageSize = Convert.ToInt32(Request.Form["length"].FirstOrDefault());
            string SortCol = Convert.ToString(Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault());
            string SortDir = Convert.ToString(Request.Form["order[0][dir]"].FirstOrDefault());
            string SearchField = Convert.ToString(Request.Form["search[value]"].FirstOrDefault());
            ReportList result = await _iMember.GetMemberList(SearchField, StartIndex, PageSize, SortCol, SortDir,msrNo,model);
            result.draw = draw;
            return Json(result);

        }
        #endregion
        #endregion
        #region Member Detail
        public async Task<IActionResult> MemberDetail(int? id)
        {
            MemberDetail model = new MemberDetail();
            try
            {
                model = await _iMember.GetMemberDetail(Convert.ToInt32(id));
            }
            catch (Exception ex) { }
            return PartialView("_MemberDetail", model);
        }
        #endregion
        #region Add Member
        public async Task<IActionResult> AddMember(int? id)
        {
            MemberRegisterModel model = new MemberRegisterModel();
            try
            {
                if (id != null)
                {
                    model = await _iMember.GetMemberByMsrNo(Convert.ToInt32(id));
                }
            }
            catch (Exception aa)
            {
            }
            return PartialView("_AddMember", model);
        }

        [HttpPost]
        public async Task<IActionResult> AddMember(MemberRegisterModel model)
        {
            try
            {
                model.PackageId = 1;
                var messageArray = this.ViewData.ModelState.Values.SelectMany(modelState => modelState.Errors, (modelState, error) => error.ErrorMessage).ToArray();

                var errors = ModelState.Select(x => x.Value.Errors)
                             .Where(y => y.Count > 0)
                             .ToList();
               
                Result result = new Result();
                if (ModelState.IsValid)
                {
                    model.IP = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                    model.MAC = Network.GetMACAddress();
                    model.ParentMsrNo = Convert.ToInt32(User.Identity.GetDetailOf("MsrNo"));
                    model.Source = "Web";
                    result = await _iMember.AddEditMember(model);
                    if (result.Status)
                    {
                        var v = result.Results;
                        result.Message = v.GetType().GetProperty("Message").GetValue(v, null);
                        result.RedirectUrl = "/Member/Member/GetMemberList";
                        result.isRedirect = false;
                        result.IsPost = true;
                        model = null;
                    }
                }
                else
                {
                    result.Status = false;
                    result.Message = "Enter valid field";
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
        #region Active / Deactive Member
        public async Task<IActionResult> ActiveMember(int? id)
        {
            try
            {
                Result model = new Result();
                model = await _iMember.ActiveMember(Convert.ToInt32(id));
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

        [HttpPost]
        public async Task<IActionResult> SearchMember(string prefix)
        {
            Result model = new Result();
            try
            {
                int msrNo = User.Identity.GetDetailOf("MsrNo") == "" ? 0 : Convert.ToInt32(User.Identity.GetDetailOf("MsrNo"));
                model = await _iMember.SearchMember(prefix, msrNo);
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

        #region Change  Password
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePassword model)
        {
            try
            {
                model.Type = "Member";
                Result result = new Result();
                int msrNo = User.Identity.GetDetailOf("MsrNo") == "" ? 0 : Convert.ToInt32(User.Identity.GetDetailOf("MsrNo"));
                model.MsrNo = msrNo;
                result = await _iMember.ChangePassword(model);
                result.isRedirect = false;
               
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
