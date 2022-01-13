using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QroApi.BLL;
using QroApi.MODEL;

namespace QroApi.Controllers.ApiService
{

    [Produces("application/json")]
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class IdentityController : ControllerBase
    {
        [HttpPost("verify_account")]
        public async Task<IActionResult> verify_account()
        {
            basicApi.apiResponse result = new basicApi.apiResponse();

            return new JsonResult(result);
        }
    }
}
