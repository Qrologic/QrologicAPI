using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using QroApi.MODEL;
using QroApi.BLL;
using QroApi.Core;

namespace QroApi.Controllers
{
    public class BaseController : Controller
    {
        #region[START : FETCH CURRENT USER DETAILS]
        public int UserId
        {
            get
            {
                if (CurrentUser != null)
                {
                    return int.Parse(CurrentUser.Claims.Where(c => c.Type == "Id")
                    .Select(x => x.Value).FirstOrDefault());
                }
                return 0;
            }
        }
        public ClaimsPrincipal CurrentUser
        {
            get { return User as ClaimsPrincipal; }
        }
        #endregion

        #region[START : CREATE SESSION OF LOGIN USER USING JWT TOKEN]
        public async Task CreateAuthenticationTicket(Users user)
        {
            var key = Encoding.ASCII.GetBytes(SiteKeys.Token);
            var JWToken = new JwtSecurityToken(
            issuer: SiteKeys.Domain,
            audience: SiteKeys.ApiDomain,
            claims: GetUserClaims(user),
            notBefore: new DateTimeOffset(DateTime.Now).DateTime,
            expires: new DateTimeOffset(DateTime.Now.AddDays(1)).DateTime,
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        );
            var token = new JwtSecurityTokenHandler().WriteToken(JWToken);
            HttpContext.Session.SetString("JWToken", token);
        }
        #endregion

        public async Task<string> GetToken(Users user)
        {
            string key = SiteKeys.Token; //Secret key which will be used later during validation    
            var issuer = SiteKeys.Domain;  //normally this will be your site URL    

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //Create a List of Claims, Keep claims name short    
            var permClaims = new List<Claim>();
            permClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            permClaims.Add(new Claim("valid", "1"));
            permClaims.Add(new Claim("userid", user.UserId.ToString()));
            permClaims.Add(new Claim("name", user.UserName.ToString()));
            permClaims.Add(new Claim("msrno", user.MsrNo.ToString()));
            permClaims.Add(new Claim("mobile", user.Mobile.ToString()));
            //Create Security Token object by giving required parameters    
            var token = new JwtSecurityToken(issuer, //Issure    
                            issuer,  //Audience    
                            permClaims,
                            expires: DateTime.Now.AddDays(1),
                            signingCredentials: credentials);
            var jwt_token = new JwtSecurityTokenHandler().WriteToken(token);
            return  jwt_token ;
        }


        #region[START : CREATE CLAIMS]
        private IEnumerable<Claim> GetUserClaims(Users user)
        {
            List<Claim> claims = new List<Claim>();
            Claim _claim;

            _claim = new Claim(ClaimTypes.Name, user.UserName);
            claims.Add(_claim);
            _claim = new Claim(ClaimTypes.Role, user.UserRole.ToString());
            claims.Add(_claim);
            _claim = new Claim(ClaimTypes.Email, user.Email);
            claims.Add(_claim);
            _claim = new Claim(ClaimTypes.MobilePhone, user.Mobile);
            claims.Add(_claim);
            _claim = new Claim("UserId", user.UserId.ToString());
            claims.Add(_claim);
            _claim = new Claim("MsrNo", user.MsrNo);
            claims.Add(_claim);
            _claim = new Claim("Role", user.UserRole);
            claims.Add(_claim);
            _claim = new Claim("Mobile", user.Mobile);
            claims.Add(_claim);

            //_claim = new Claim(user.ACCESS_LEVEL, user.ACCESS_LEVEL);
            //claims.Add(_claim);
            _claim = new Claim("PHOTO", user.UserImage);
            claims.Add(_claim);
            return claims.AsEnumerable<Claim>();
        }
        #endregion

        #region "Notificatons"

        protected void ShowMessages(string title, string message, MessageType messageType, bool isCurrentView)
        {
            Notification model = new Notification
            {
                Heading = title,
                Message = message,
                Type = messageType
            };

            if (isCurrentView)
                this.ViewData.AddOrReplace("NotificationModel", model);
            else
            {
                this.TempData["NotificationModel"] = JsonConvert.SerializeObject(model);
                TempData.Keep("NotificationModel");
            }
        }

        protected void ShowErrorMessage(string title, string message, bool isCurrentView = true)
        {
            ShowMessages(title, message, MessageType.Danger, isCurrentView);
        }

        protected void ShowSuccessMessage(string title, string message, bool isCurrentView = true)
        {
            ShowMessages(title, message, MessageType.Success, isCurrentView);
        }

        protected void ShowWarningMessage(string title, string message, bool isCurrentView = true)
        {
            ShowMessages(title, message, MessageType.Warning, isCurrentView);
        }

        protected void ShowInfoMessage(string title, string message, bool isCurrentView = true)
        {
            ShowMessages(title, message, MessageType.Info, isCurrentView);
        }
        protected PartialViewResult MessagePartialView(string message, string title = "", MessageType messageType = MessageType.Danger)
        {
            ShowMessages(title, message, messageType, true);
            return PartialView("_Notification");
        }
        protected ViewResult CustomErrorView(string message, string title = "", MessageType messageType = MessageType.Danger)
        {
            ShowMessages(title, message, messageType, true);
            return View("CustomError");
        }
        #endregion


        #region[START : lOGOUT USER]
        public void RemoveAuthentication()
        {
            // HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Clear();
        }
        #endregion
    }
}
