using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QroApi.Core;
using QroApi.MODEL;
using System.Security.Claims;
using QroApi.BLL;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace QroApi.Controllers
{
    public class AccountController : BaseController
    {
        #region[START : PROPERTIES]
        private readonly IAccountService _accountService;
        private readonly IUserService _userService;
        private readonly IUtilityService _utilityService;
        private readonly ICookies _iCookies;
        private readonly ISettings _iSettings;
        #endregion

        #region[START : CONSTRUCTOR]
        public AccountController(IAccountService accountService, IUserService userService, IUtilityService utilityService, ICookies iCookies, ISettings iSettings)
        {
            _accountService = accountService;
            _utilityService = utilityService;
            _userService = userService;
            _iCookies = iCookies;
            _iSettings = iSettings;
        }
        #endregion

        #region Get Company Detail
        public async Task<IActionResult> GetCompanyLogo()
        {
            try
            {
                Result result = new Result();
                CompanyModel model = new CompanyModel();
                int msrNo = User.Identity.GetDetailOf("MsrNo") == "" ? 0 : Convert.ToInt32(User.Identity.GetDetailOf("MsrNo"));
                model = await _iSettings.GetCompanyDetailById(msrNo);
                model.CompanyLogo = "../images/UploadImages/" + model.CompanyLogo;
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

        #region[START :LOGIN GET POST]
        [HttpGet, AllowAnonymous]
        public IActionResult Login(string returnUrl = null)
        {
            //_accountService.InitialUser();
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Login(LoginRequest model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                try
                {
                    model.IP = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                    model.MAC = Network.GetMACAddress();
                    model.Type = "Member";
                    var user = await _accountService.Login(model);
                    if (user == null)
                    {
                        ModelState.AddModelError(string.Empty, "Not a valid account !");
                        return View(model);
                    }
                    else if (!user.Status)
                    {
                        ShowErrorMessage("Error!", "An error occured.", true);
                        ModelState.AddModelError(string.Empty, user.Message);
                        return View(model);
                    }
                    var LogInUser = (Users)user.Results;

                    //User nuser = new User
                    //{
                    //    NAME = "durgesh",
                    //    USERID = "d10001",
                    //    EMAILID = "",
                    //    PHONE = "",
                    //    ACCESS_LEVEL = "User",
                    //    PHOTO = "/img/Noimg.png",
                    //};
                    _ = CreateAuthenticationTicket(LogInUser);
                    return RedirectToLocal(returnUrl,"Member","Dashboard","Home");
                }
                catch (Exception ex)
                {
                    ShowErrorMessage("Error!", "Internal server error", true);
                }
            }
            else
            {
                //  return FormResult.CreateErrorResult("An error occured.");
                ShowErrorMessage("Error!", "An error occured.", true);
            }
            return View(model);
        }
        #endregion

        #region[START : LOGOUT]
        [HttpGet]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult LogOff(string id)
        {
            _iCookies.RemoveCookie("ActiveMenu");
            RemoveAuthentication();
            //if (id == "Admin")
            //{
                return Redirect("/User/Login");
            //}
            //return RedirectToAction(nameof(AccountController.Login), "Account");
        }
        #endregion

        #region[START : REDIRECTION]
        private IActionResult RedirectToLocal(string returnUrl ,string area,string action,string controller)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                //return RedirectToAction(nameof(HomeController.Index), "Home");
                return RedirectToAction(action, controller, new { area = area });
            }
        }
        #endregion

        #region Admin Login
        [Route("User/Login")]
        [HttpGet, AllowAnonymous]
        public IActionResult AdminLogin(string returnUrl = null)
        {
            _iCookies.RemoveCookie("ActiveMenu");
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        [Route("User/Login")]
        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> AdminLogin(LoginRequest model, string returnUrl = null)
        {
            Result result = new Result();
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                try
                {
                    model.IP = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                    model.MAC = Network.GetMACAddress();
                    model.Type = "Admin";
                    var user = await _accountService.Login(model);
                    if (user == null)
                    {
                        result = new Result {Status=false,Message= "Not a valid account !" };
                    }
                    else if (!user.Status)
                    {
                        //ShowErrorMessage("Error!", "An error occured.", true);
                        //ModelState.AddModelError(string.Empty, user.Message);
                        //return View(model);
                        result = new Result { Status = false, Message = user.Message };
                    }
                    var LogInUser = (Users)user.Results;
                    if (user.Status)
                    {
                        _ = CreateAuthenticationTicket(LogInUser);
                        if (LogInUser.UserRole == "Admin" || LogInUser.UserRole == "Super Admin" || LogInUser.UserRole == "Sub Admin")
                        {
                            result.Status = true;
                            result.RedirectUrl = "/Admin/Home/Dashboard";
                           // return RedirectToLocal(returnUrl, "Admin", "Dashboard", "Home");

                        }
                        if (LogInUser.UserRole == "Super Distributor" || LogInUser.UserRole == "Master Distributor" || LogInUser.UserRole == "Distributor" || LogInUser.UserRole == "Retailer" || LogInUser.UserRole == "API Member")
                        {
                            result.Status = true;
                            result.RedirectUrl = "/Member/Home/Dashboard";
                            //return RedirectToLocal(returnUrl, "Member", "Dashboard", "Home");
                        }
                    }
                  
                    
                }
                catch (Exception ex)
                {
                    result = new Result { Status = false, Message = ex.Message.ToString() };
                }
            }
            else
            {      
                result = new Result { Status = false, Message = "An error occured" };
            }
            return Json(result);
        }
        #endregion

        #region Forget Password
        [Route("User/Forget")]
        [HttpGet, AllowAnonymous]
        public IActionResult ForgetPassword(string returnUrl = null)
        {
            return View();
        }

        #endregion

        #region Admin Registration
        public IActionResult AdminRegistration(int? id)
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AdminRegistration(UserRegistration model)
        {
            bool isSuccess = false;
            if (ModelState.IsValid)
            {
                model.Type = "Admin";
                model.IP = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                model.MAC = Network.GetMACAddress();
                var msrNo = User.Identity.GetDetailOf("MsrNo");

                var user = await _userService.User_Register(model);
                if (user == null)
                {
                   
                    ModelState.AddModelError(string.Empty, "Enter valid input !");
                    return View(model);
                }
                else if (!user.Status)
                {
                  
                    ShowInfoMessage("error", user.Message);
                    return View(model);
                }
                else
                {
                    isSuccess = true;
                    ShowSuccessMessage("success", user.Message, isSuccess);
                    model = null;
                    return RedirectToAction();
                    //return View(model);
                }
            }
           
            return View(model);
        }
        #endregion

        #region Member Registration
        public IActionResult MemberRegistration(int? id)
        {
            var i = User.Identity.GetDetailOf("MsrNo");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> MemberRegistration(UserRegistration model)
        {
            string message = "";
            try
            {
                bool isSuccess = false;
                if (ModelState.IsValid)
                {
                    model.Type = "Member";
                    model.IP = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                    model.MAC = Network.GetMACAddress();
                    var msrNo = User.Identity.GetDetailOf("MsrNo");
                    model.Source = "Web";
                    model.ParentMsrNo = Convert.ToInt32(msrNo);
                    var user =await _userService.User_Register(model);
                    if (user == null)
                    {
                        isSuccess = false;
                        message = "Enter valid input !";
                        ModelState.AddModelError(string.Empty, "Enter valid input !");                        
                    }
                    else if (!user.Status)
                    {
                        isSuccess = false;
                        message = user.Message;                       
                    }
                    else
                    {
                        message = user.Message;
                        isSuccess = true;                     
                        model = null;                        
                    }
                }

                return Json(new Result
                {
                    Status = isSuccess,
                    Results = null,
                    Message = message
                }) ;
            }
            catch(Exception ex){
                return Json(new Result
                {
                    Status = false,
                    Results = null,
                    Message = "Something Went Wrong !"
                }) ;
            }
        }
        #endregion

        #region Get Role
        public async Task<IActionResult> GetRole()
        {
            try
            {
                int userId = Convert.ToInt32(User.Identity.GetDetailOf("UserId"));
                Result model = new Result();
                model = await _utilityService.GetRole(userId);
                return Json(new Result
                {
                    Status = true,
                    Results = model.Results,
                    Message ="Success"
                });
            }
            catch(Exception ex) {
                return Json(new Result
                {
                    Status = false,
                    Results = null,
                    Message =ex.Message.ToString()
                });
            }
        }
        #endregion

        #region Get Package
        public async Task<IActionResult> GetPackage()
        {
            try
            {
                int MsrNo = Convert.ToInt32(User.Identity.GetDetailOf("MsrNo"));
                Result model = new Result();
                model = await _utilityService.GetPackage(MsrNo);
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

        #region Get Country
        public async Task<IActionResult> GetCountry()
        {
            try
            {                
                Result model = new Result();
                model = await _utilityService.GetCountry();
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

        #region Get State
        [HttpPost]
        public async Task<IActionResult> GetState(int  countryId)
        {
            try
            {
                Result model = new Result();
                model =await _utilityService.GetState(countryId);
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

        #region Get City
        [HttpPost]
        public async Task<IActionResult> GetCity(int stateId)
        {
            try
            {
                Result model = new Result();
                model = await _utilityService.GetCity(stateId);
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
