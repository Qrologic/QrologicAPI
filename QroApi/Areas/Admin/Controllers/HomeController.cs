using QroApi.BLL;
using QroApi.Core;
using QroApi.CustomAttributes;
using QroApi.MODEL;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace QroApi.Areas.Admin.Controllers
{
    [Authorize(Role.Admin,Role.SuperAdmin,Role.SubAdmin)]
    [Area("Admin")]
    public class HomeController : Controller
    {

        #region[START : PROPERTIES]
        private readonly ICommonClass _iCommonClass;
        private readonly IUtilityService _utilityService;
        private readonly ISettings _iSettings;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IDashboard _iDashboard;
        private readonly IProfile _iProfile;
        #endregion

        #region Constuctor
        public HomeController(IUtilityService utilityService, ICommonClass iCommonClass, IWebHostEnvironment webHostEnvironment, ISettings iSettings, IDashboard iDashboard, IProfile iProfile)
        {
            _iCommonClass = iCommonClass;
            _utilityService = utilityService;
            _webHostEnvironment = webHostEnvironment;
            _iSettings = iSettings;
            _iDashboard = iDashboard;
            _iProfile = iProfile;
        }
        #endregion

        public async Task<IActionResult> Dashboard()
        {
            DashboardModel model = new DashboardModel();
            int msrNo = User.Identity.GetDetailOf("MsrNo") == "" ? 0 : Convert.ToInt32(User.Identity.GetDetailOf("MsrNo"));
            if (msrNo > 0)
            {
                model = await _iDashboard.GetAdminDashboardByMsrNo(msrNo);
            }
            return View(model);
        }


        public async Task<IActionResult> Dashboard2()
        {
            
            return View();
        }

        public async Task<ActionResult> Profile()
        {
            ProfileModel model = new ProfileModel();
            int userId = User.Identity.GetDetailOf("UserId") == "" ? 0 : Convert.ToInt32(User.Identity.GetDetailOf("UserId"));
            if (userId > 0)
            {
                model= await _iProfile.getAdmiProfile(userId);
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddEditLayout(LayoutModel model)
        {
            try
            {
                Result result = new Result();
                int msrNo = User.Identity.GetDetailOf("MsrNo") == "" ? 0 : Convert.ToInt32(User.Identity.GetDetailOf("MsrNo"));
                model.MsrNo = msrNo;
                result = await _iCommonClass.AddEditLayout(model);
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
        public async Task<IActionResult> GetLayout()
        {
            try
            {
                Result result = new Result();
                int msrNo = User.Identity.GetDetailOf("MsrNo") == "" ? 0 : Convert.ToInt32(User.Identity.GetDetailOf("MsrNo"));
                result = await _iCommonClass.GetLayout(msrNo);
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
        public async Task<IActionResult> GetCompanyLogo()
        {
            try
            {
                Result result = new Result();
                CompanyModel model = new CompanyModel();
                int msrNo = User.Identity.GetDetailOf("MsrNo") == "" ? 0 : Convert.ToInt32(User.Identity.GetDetailOf("MsrNo"));
                model = await _iSettings.GetCompanyDetailById(msrNo);
                model.CompanyLogo = "../../images/UploadImages/"+model.CompanyLogo;
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
        public IActionResult DMT()
        {
            return View();
        }



    }


}
