using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using QroApi.BLL;
using QroApi.MODEL;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace QroApi.Controllers.ApiService
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/[controller]")]
    public class basicController : ControllerBase
    {
        #region Properties
        private readonly IAccountService _accountService;
        #endregion

        #region Constructor
        public basicController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        #endregion

        #region  Get Token
        [HttpPost("gettoken")]
        public async Task<IActionResult> GetToken(LoginRequest model)
        {
            basicApi.apiResponse result = new basicApi.apiResponse();
            model.Type = "Member";
            var user = await _accountService.Login(model);
            if (user == null)
            {
               return  Ok(result = new basicApi.apiResponse { statuscode = "IUA", status = "Invalid User Account" });
            }
            else if (!user.Status)
            {
                return Ok(result = new basicApi.apiResponse { statuscode = "IUA", status = "Invalid User Account" });
            }
            if (user.Status)
            {
                var userDetails = user.Results;
                string key = SiteKeys.Token; //Secret key which will be used later during validation    
                var issuer = SiteKeys.Domain;  //normally this will be your site URL    

                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                //Create a List of Claims, Keep claims name short    
                var permClaims = new List<Claim>();
                permClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
                permClaims.Add(new Claim("valid", "1"));
                permClaims.Add(new Claim("userid", userDetails.UserId.ToString()));
                permClaims.Add(new Claim("name", userDetails.UserName.ToString()));
                permClaims.Add(new Claim("msrno", userDetails.MsrNo.ToString()));
                permClaims.Add(new Claim("mobile", userDetails.Mobile.ToString()));
                //Create Security Token object by giving required parameters    
                var token = new JwtSecurityToken(issuer, //Issure    
                                issuer,  //Audience    
                                permClaims,
                                expires: DateTime.Now.AddDays(3650),
                                signingCredentials: credentials);              
                var jwt_token = new JwtSecurityTokenHandler().WriteToken(token);
                return new JsonResult( new basicApi.apiResponse { status = "Token Successfully Generated", statuscode = "TXN", token = jwt_token  }, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }
            else
            {
                return new JsonResult(new basicApi.apiResponse { statuscode = "IUA", status = "Invalid User Account" }, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                }) ;
               
            }
                
        }
        #endregion
    }
}
