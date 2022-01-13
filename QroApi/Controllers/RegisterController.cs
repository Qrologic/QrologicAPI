using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using QroApi.BLL;
using QroApi.Core;
using QroApi.DLL;
using QroApi.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;


namespace QroApi.Controllers
{
    public class RegisterController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IAccountService _accountService;
        private readonly IUtilityService _utilityService;
        
        public RegisterController(IUserService userService, IAccountService accountService, IUtilityService utilityService)
        {
            _utilityService = utilityService;
            _userService = userService;
            _accountService = accountService;
           
           
        }
        #region[START :UserRegister GET POST]
        [HttpGet]
        public IActionResult UserRegistration()
        {
            string referer = Request.Headers["Referer"].ToString();
            UserRegistration model = new UserRegistration();
            //BindViewBag();
           
            return  PartialView("_UserRegistration", model) ;
        }

        [HttpPost]
        public async Task<IActionResult> UserRegistration(UserRegistration model)
        {
            bool isSuccess = false;
            if (ModelState.IsValid)
            {
                model.IP = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                model.MAC = Network.GetMACAddress();
                var msrNo =  User.Identity.GetDetailOf("MsrNo");

                var user = await _userService.User_Register(model);
                if (user == null)
                {
                    BindViewBag();
                    ModelState.AddModelError(string.Empty, "Enter valid input !");
                    return View(model);
                }
                else if (!user.Status)
                {
                    BindViewBag();
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
            BindViewBag();
            return View(model);
        }
        #endregion

        public async Task<JsonResult> GetSponserDetails(string id)
        {
            var data =await _userService.GetSponserDetails(id);
            var sponsor = JsonConvert.SerializeObject(data.Results);
            return Json(sponsor);
            // return Ok(sponsor.Results==null?"":sponsor.Results);
        }
        public async Task<JsonResult> GetCity(int stateId)
        {
            var data =await _utilityService.GetCity(stateId);
            var sponsor = JsonConvert.SerializeObject(data.Results);
            return Json(sponsor);
            // return Ok(sponsor.Results==null?"":sponsor.Results);
        }

        public void BindViewBag()
        {
            //var Package = _utilityService.GetPackage(1);
            //ViewBag.PackageId = new SelectList(Package.Results, "Value", "Text", 0);

            //var State = _utilityService.GetState(0);
            //ViewBag.StateId = new SelectList(State.Results, "Value", "Text", 0);
            //var City = _utilityService.GetCity(0);
            //ViewBag.CityId = new SelectList(City.Results, "Value", "Text", 0);
        }
       
    }
}
