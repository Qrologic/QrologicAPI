using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QroApi.BLL;
using QroApi.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace QroApi.Api
{

    [Produces("application/json")]
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class dmtController : ControllerBase
    {
        #region Properties
        private readonly IdmtApiService _idmtApiService;
        #endregion

        #region Constructor
        public dmtController(IdmtApiService idmtApiService)
        {
            _idmtApiService = idmtApiService;
        }
        #endregion

        #region Remitter Details
        [HttpPost("remitter_details")]
        public async Task<IActionResult> remitter_details([FromBody] dmtApi.RemitterDetails_Request model)
        {
            var identity = User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                string ipAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                IEnumerable<Claim> claims = identity.Claims;
                var msrno = claims.Where(p => p.Type == "msrno").FirstOrDefault()?.Value;
                var result = await _idmtApiService.RemitterDetail(model, Convert.ToInt32(msrno), ipAddress);
                return new JsonResult(result, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }
            else
            {
                return new JsonResult(new basicApi.apiResponse { statuscode = "IAT", status = "IAT Invalid Access Token" }, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }
        }
        #endregion

        #region Remitter Registration
        [HttpPost("remitter_registration")]
        public async Task<IActionResult> remitter_registration([FromBody] dmtApi.Request_RemitterRegistration model)
        {
            basicApi.apiResponse result = new basicApi.apiResponse();
            var identity = User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                string ipAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                IEnumerable<Claim> claims = identity.Claims;
                var msrno = claims.Where(p => p.Type == "msrno").FirstOrDefault()?.Value;
                result = await _idmtApiService.RemitterRegistration(model, Convert.ToInt32(msrno), ipAddress);
                return new JsonResult(result, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }
            else
            {
                return new JsonResult(result = new basicApi.apiResponse { statuscode = "IAT", status = "IAT Invalid Access Token" }, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }
        }
        #endregion

        #region Remitter Validate
        [HttpPost("remitter_validate")]
        public async Task<IActionResult> remitter_validate([FromBody] dmtApi.Request_RemitterValidate model)
        {
            basicApi.apiResponse result = new basicApi.apiResponse();
            var identity = User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                string ipAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                IEnumerable<Claim> claims = identity.Claims;
                var msrno = claims.Where(p => p.Type == "msrno").FirstOrDefault()?.Value;
                result = await _idmtApiService.RemitterValidate(model, Convert.ToInt32(msrno), ipAddress);
                return new JsonResult(result, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }
            else
            {
                return new JsonResult(result = new basicApi.apiResponse { statuscode = "IAT", status = "IAT Invalid Access Token" }, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }
        }
        #endregion

        #region Register Beneficiary
        [HttpPost("register_beneficiary")]
        public async Task<IActionResult> register_beneficiary([FromBody] dmtApi.Request_BeneficiaryRegistration model)
        {
            basicApi.apiResponse result = new basicApi.apiResponse();
            var identity = User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                string ipAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                IEnumerable<Claim> claims = identity.Claims;
                var msrno = claims.Where(p => p.Type == "msrno").FirstOrDefault()?.Value;
                result = await _idmtApiService.BeneficiaryRegistration(model, Convert.ToInt32(msrno), ipAddress);
                return new JsonResult(result, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }
            else
            {
                return new JsonResult(result = new basicApi.apiResponse { statuscode = "IAT", status = "IAT Invalid Access Token" }, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }
        }
        #endregion

        #region Remove Beneficiary
        [HttpPost("remove_beneficiary")]
        public async Task<IActionResult> remove_beneficiary([FromBody] dmtApi.Request_BeneficiaryRemove model)
        {
            basicApi.apiResponse result = new basicApi.apiResponse();
            var identity = User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                string ipAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                IEnumerable<Claim> claims = identity.Claims;
                var msrno = claims.Where(p => p.Type == "msrno").FirstOrDefault()?.Value;
                result = await _idmtApiService.BeneficiaryRemove(model, Convert.ToInt32(msrno), ipAddress);
                return new JsonResult(result, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }
            else
            {
                return new JsonResult(result = new basicApi.apiResponse { statuscode = "IAT", status = "IAT Invalid Access Token" }, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }
        }
        #endregion

        #region Remove Beneficiary Validate
        [HttpPost("remove_beneficiary_validate")]
        public async Task<IActionResult> remove_beneficiary_validate([FromBody] dmtApi.Request_BeneficiaryRemove_Validate model)
        {
            basicApi.apiResponse result = new basicApi.apiResponse();
            var identity = User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                string ipAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                IEnumerable<Claim> claims = identity.Claims;
                var msrno = claims.Where(p => p.Type == "msrno").FirstOrDefault()?.Value;
                result = await _idmtApiService.BeneficiaryRemove_Validate(model, Convert.ToInt32(msrno), ipAddress);
                return new JsonResult(result, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }
            else
            {
                return new JsonResult(result = new basicApi.apiResponse { statuscode = "IAT", status = "IAT Invalid Access Token" }, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }
        }
        #endregion

        #region Fund Transfer
        [HttpPost("fund_transfer")]
        public async Task<IActionResult> fund_transfer([FromBody] dmtApi.Request_FundTransfer model)
        {
            basicApi.apiResponse result = new basicApi.apiResponse();
            var identity = User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                string ipAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                IEnumerable<Claim> claims = identity.Claims;
                var msrno = claims.Where(p => p.Type == "msrno").FirstOrDefault()?.Value;
                result = await _idmtApiService.FundTransfer(model, Convert.ToInt32(msrno), ipAddress);
                return new JsonResult(result, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }
            else
            {
                return new JsonResult(result = new basicApi.apiResponse { statuscode = "IAT", status = "IAT Invalid Access Token" }, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }
        }
        #endregion

        #region Transaction Status
        [HttpPost("transaction_status")]
        public async Task<IActionResult> transaction_status([FromBody] dmtApi.TransactionStatus_Request model)
        {
            basicApi.apiResponse result = new basicApi.apiResponse();
            var identity = User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                string ipAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                IEnumerable<Claim> claims = identity.Claims;
                var msrno = claims.Where(p => p.Type == "msrno").FirstOrDefault()?.Value;
                result = await _idmtApiService.TransactionStatus(model, Convert.ToInt32(msrno), ipAddress);
                return new JsonResult(result, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }
            else
            {
                return new JsonResult(result = new basicApi.apiResponse { statuscode = "IAT", status = "IAT Invalid Access Token" }, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }
        }
        #endregion
    }
}
