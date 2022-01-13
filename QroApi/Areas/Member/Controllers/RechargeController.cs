using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QroApi.BLL;
using QroApi.Core;
using QroApi.CustomAttributes;
using QroApi.MODEL;
using Microsoft.AspNetCore.Mvc;

namespace QroApi.Areas.Member.Controllers
{
    [Authorize(Role.SuperDistributor, Role.MasterDistributor, Role.Distributor, Role.Retailer, Role.Customer, Role.ApiMember)]
    [Area("Member")]
    public class RechargeController : Controller
    {
        #region Properties
        private readonly IRecharge _iRecharge;
        #endregion

        #region Constructor
        public RechargeController(IRecharge iRecharge)
        {
            _iRecharge = iRecharge;
        }
        #endregion

        public IActionResult Index()
        {
            return View();
        }
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
    }
}
