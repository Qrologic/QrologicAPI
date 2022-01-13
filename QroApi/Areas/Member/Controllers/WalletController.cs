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
    public class WalletController : Controller
    {
        #region Properties
        private readonly IWallet _iWallet;
        #endregion

        #region Constructor
        public WalletController(IWallet iWallet)
        {
            _iWallet = iWallet;
        }
        #endregion

        #region Add Edit Balance Request
        public async Task<IActionResult> AddEditBalanceRequest(int? id)
        {
            BalanceRequestModel model = new BalanceRequestModel();
            try
            {
                if (id != null || id != 0)
                {
                    model = await _iWallet.GetBalanceRequestById(Convert.ToInt32(id));
                }
            }
            catch (Exception ex) { }
            return PartialView("_BalanceRequest", model);
        }
        [HttpPost]
        public async Task<IActionResult> AddEditBalanceRequest(BalanceRequestModel model)
        {
            Result result = new Result();
            try
            {
                int msrNo = User.Identity.GetDetailOf("MsrNo") == "" ? 0 : Convert.ToInt32(User.Identity.GetDetailOf("MsrNo"));
                model.MsrNo = msrNo;
                model.Source = "Web";
                result = await _iWallet.AddEditBalanceRequest(model);
                result.isRedirect = false;
                result.IsPost = true;
                result.RedirectUrl = "/Member/Wallet/LoadBalanceRequest";
            }
            catch
            {
                result = new Result
                {
                    Status = false,
                    Message = "Something Went Wrong",
                    isRedirect = false,
                };
            }
            return Json(result);
        }
        #endregion

        #region List Balance Request
        public async Task<IActionResult> BalanceRequest()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LoadBalanceRequest()
        {
            int msrNo = Convert.ToInt32(User.Identity.GetDetailOf("MsrNo"));
            int draw = Convert.ToInt32(HttpContext.Request.Form["draw"].FirstOrDefault());
            int StartIndex = Convert.ToInt32(Request.Form["start"].FirstOrDefault());
            int PageSize = Convert.ToInt32(Request.Form["length"].FirstOrDefault());
            string SortCol = Convert.ToString(Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault());
            string SortDir = Convert.ToString(Request.Form["order[0][dir]"].FirstOrDefault());
            string SearchField = Convert.ToString(Request.Form["search[value]"].FirstOrDefault());
            ReportList result = await _iWallet.GetSelfRequest(SearchField, StartIndex, PageSize, SortCol, SortDir, msrNo);
            result.draw = draw;
            return Json(result);
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

        #region Get Bank For Request
        public async Task<IActionResult> GetBankForRequest()
        {
            try
            {

                Result model = new Result();
                model = await _iWallet.GetBankForRequest();
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

        #region Cancel Request By Self
        public async Task<IActionResult> CancelRequest(int? id)
        {
            try
            {
                Result model = new Result();
                model = await _iWallet.CancelRequest(Convert.ToInt32(id), "");
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
        public async Task<IActionResult> CancelRequestByParent(int? id, string remark)
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

        #region List Wallet
        public IActionResult ListWallet()
        {
            return View();
        }
        #region Get Wallet List

        [HttpPost]
        public async Task<IActionResult> GetWalletList(CommonFilter model)
        {
            int msrNo = User.Identity.GetDetailOf("MsrNo") == "" ? 0 : Convert.ToInt32(User.Identity.GetDetailOf("MsrNo"));
            int draw = Convert.ToInt32(HttpContext.Request.Form["draw"].FirstOrDefault());
            int StartIndex = Convert.ToInt32(Request.Form["start"].FirstOrDefault());
            int PageSize = Convert.ToInt32(Request.Form["length"].FirstOrDefault());
            string SortCol = Convert.ToString(Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault());
            string SortDir = Convert.ToString(Request.Form["order[0][dir]"].FirstOrDefault());
            string SearchField = Convert.ToString(Request.Form["search[value]"].FirstOrDefault());
            ReportList result = await _iWallet.GetWalletList(SearchField, StartIndex, PageSize, SortCol, SortDir, msrNo, model);
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

            int msrNo = User.Identity.GetDetailOf("MsrNo") == "" ? 0 : Convert.ToInt32(User.Identity.GetDetailOf("MsrNo"));
            int draw = Convert.ToInt32(HttpContext.Request.Form["draw"].FirstOrDefault());
            int StartIndex = Convert.ToInt32(Request.Form["start"].FirstOrDefault());
            int PageSize = Convert.ToInt32(Request.Form["length"].FirstOrDefault());
            string SortCol = Convert.ToString(Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault());
            string SortDir = Convert.ToString(Request.Form["order[0][dir]"].FirstOrDefault());
            string SearchField = Convert.ToString(Request.Form["search[value]"].FirstOrDefault());
            ReportList result = await _iWallet.GetAllWalletTransactionList(SearchField, StartIndex, PageSize, SortCol, SortDir, msrNo, model);
            result.draw = draw;
            return Json(result);

        }
        #endregion

        #region Top 10 Transaction
        public async Task<IActionResult> Top10Transaction()
        {
            Top10Transaction model = new Top10Transaction();
            try
            {
                int msrNo = User.Identity.GetDetailOf("MsrNo") == "" ? 0 : Convert.ToInt32(User.Identity.GetDetailOf("MsrNo"));
                model = await _iWallet.GetTop10Transaction(msrNo);
            }
            catch (Exception ex) { }
            return PartialView("_Top10Transaction", model);

        }
        #endregion

        #region Transaction Detail
        public async Task<IActionResult> TransactionDetail(int ? id)
        {
            TxnDetailModel model = new TxnDetailModel();
            try
            {
                int msrno = User.Identity.GetDetailOf("MsrNo") == "" ? 0 : Convert.ToInt32(User.Identity.GetDetailOf("MsrNo"));
                model = await _iWallet.GetTransactionDetail(Convert.ToInt32(id), msrno);
            }
            catch(Exception ex) { }
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
                int msrNo = User.Identity.GetDetailOf("MsrNo") == "" ? 0 : Convert.ToInt32(User.Identity.GetDetailOf("MsrNo"));
                Result result = new Result();
                model.Source = "Web";
                model.FromMsrNo = msrNo;
                model.IsReturn = true;
                if (ModelState.IsValid)
                {
                    result = await _iWallet.AddFund(model);
                    result.RedirectUrl = "/Member/Wallet/GetWalletList";
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

      
    }
}
