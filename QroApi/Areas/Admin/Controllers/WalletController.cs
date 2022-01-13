using QroApi.BLL;
using QroApi.Core;
using QroApi.CustomAttributes;
using QroApi.MODEL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QroApi.Areas.Admin.Controllers
{
    [Authorize(Role.Admin, Role.SuperAdmin, Role.SubAdmin)]
    [Area("Admin")]
    public class WalletController : Controller
    {
        #region Properties
        private readonly IWallet _iWallet;
        #endregion

        #region Constuctor
        public WalletController(IWallet iWallet)
        {
            _iWallet = iWallet;
        }
        #endregion

        #region List Wallet
        public IActionResult ListWallet()
        {
            return View();
        }
        #region Get Wallet List

        [HttpPost]
        public async Task<IActionResult> GetWalletList(CommonFilter model)
        {
            int draw = Convert.ToInt32(HttpContext.Request.Form["draw"].FirstOrDefault());
            int StartIndex = Convert.ToInt32(Request.Form["start"].FirstOrDefault());
            int PageSize = Convert.ToInt32(Request.Form["length"].FirstOrDefault());
            string SortCol = Convert.ToString(Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault());
            string SortDir = Convert.ToString(Request.Form["order[0][dir]"].FirstOrDefault());
            string SearchField = Convert.ToString(Request.Form["search[value]"].FirstOrDefault());
            ReportList result = await _iWallet.GetWalletList(SearchField, StartIndex, PageSize, SortCol, SortDir,0, model);
            result.draw = draw;
            return Json(result);

        }
        #endregion

        #region Get Wallet Transaction List
        public IActionResult ListWalletTransaction()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GetWalletTransactionList(int? id, CommonFilter model)
        {
            int draw = Convert.ToInt32(HttpContext.Request.Form["draw"].FirstOrDefault());
            int StartIndex = Convert.ToInt32(Request.Form["start"].FirstOrDefault());
            int PageSize = Convert.ToInt32(Request.Form["length"].FirstOrDefault());
            string SortCol = Convert.ToString(Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault());
            string SortDir = Convert.ToString(Request.Form["order[0][dir]"].FirstOrDefault());
            string SearchField = Convert.ToString(Request.Form["search[value]"].FirstOrDefault());
            ReportList result = await _iWallet.GetWalletTransactionList(SearchField, StartIndex, PageSize, SortCol, SortDir, id, model);
            result.draw = draw;
            return Json(result);

        }
        #endregion

        #region Get All Wallet Transaction List
        public IActionResult Transaction()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LoadTransaction(CommonFilter model)
        {
            int draw = Convert.ToInt32(HttpContext.Request.Form["draw"].FirstOrDefault());
            int StartIndex = Convert.ToInt32(Request.Form["start"].FirstOrDefault());
            int PageSize = Convert.ToInt32(Request.Form["length"].FirstOrDefault());
            string SortCol = Convert.ToString(Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault());
            string SortDir = Convert.ToString(Request.Form["order[0][dir]"].FirstOrDefault());
            string SearchField = Convert.ToString(Request.Form["search[value]"].FirstOrDefault());
            ReportList result = await _iWallet.GetAllWalletTransactionList(SearchField, StartIndex, PageSize, SortCol, SortDir, 0, model);
            result.draw = draw;
            return Json(result);

        }
        #endregion

        #region Transaction Detail
        public async Task<IActionResult> TransactionDetail(int? id)
        {
            TxnDetailModel model = new TxnDetailModel();
            try
            {
                int msrno = User.Identity.GetDetailOf("MsrNo") == "" ? 0 : Convert.ToInt32(User.Identity.GetDetailOf("MsrNo"));
                model = await _iWallet.GetTransactionDetail(Convert.ToInt32(id), msrno);
            }
            catch (Exception ex) { }
            return PartialView("_Reciept", model);
        }
        #endregion


        #region Get Balance By MsrNo
        public async Task<IActionResult> GetBalance(int? id)
        {
            AddDeductFundModel model = new AddDeductFundModel();
            if (id != null)
            {
                if (id == 0)
                {
                    id = User.Identity.GetDetailOf("MsrNo") == "" ? 0 : Convert.ToInt32(User.Identity.GetDetailOf("MsrNo"));
                }              
                if (id != 0)
                {
                    model = await _iWallet.GetBalanceByMsrNo(Convert.ToInt32(id));
                }
            }
            return Json(model);
        }
        #endregion

        #region Add Fund
        public async Task<IActionResult> AddDeductBalance(string fector)
        {
            AddDeductFundModel model = new AddDeductFundModel();
            model.Factor = fector;
            return PartialView("_AddFund", model);
        }

        [HttpPost]
        public async Task<IActionResult> AddDeductBalance(AddDeductFundModel model)
        {
            try
            {
                int msrNo = User.Identity.GetDetailOf("MsrNo")==""?0:Convert.ToInt32(User.Identity.GetDetailOf("MsrNo"));
                Result result = new Result();                
                model.Source = "Web";
                model.FromMsrNo = msrNo;
                model.IsReturn = true;
                if (ModelState.IsValid)
                {
                    result = await _iWallet.AddFund(model);
                    result.RedirectUrl = "/Admin/Wallet/GetWalletList";
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

        #endregion
        
        #region Balance Request
        public async Task<IActionResult> BalanceRequest()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LoadDownlineBalanceRequest()
        {
            int msrNo = Convert.ToInt32(User.Identity.GetDetailOf("MsrNo"));
            int draw = Convert.ToInt32(HttpContext.Request.Form["draw"].FirstOrDefault());
            int StartIndex = Convert.ToInt32(Request.Form["start"].FirstOrDefault());
            int PageSize = Convert.ToInt32(Request.Form["length"].FirstOrDefault());
            string SortCol = Convert.ToString(Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault());
            string SortDir = Convert.ToString(Request.Form["order[0][dir]"].FirstOrDefault());
            string SearchField = Convert.ToString(Request.Form["search[value]"].FirstOrDefault());
            ReportList result = await _iWallet.GetDownlineRequest(SearchField, StartIndex, PageSize, SortCol, SortDir, msrNo);
            result.draw = draw;
            return Json(result);
        }
        #endregion

        #region Approve Request
        public async Task<IActionResult> ApproveRequest(int? id)
        {
            try
            {
                Result result = new Result();
                result = await _iWallet.ApproveRequest(Convert.ToInt32(id));
                return Json(new Result
                {
                    Status = true,
                    Results = result.Results,
                    Message = result.Message
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

        #region Cancel Request By Parent
        public async Task<IActionResult> CancelRequestByParent(int? id,string remark)
        {
            try
            {
                Result model = new Result();
                model = await _iWallet.CancelRequest(Convert.ToInt32(id), remark);
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
    }
}
