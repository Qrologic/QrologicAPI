using QroApi.MODEL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace QroApi.Controllers
{
    public class CallbackController : Controller
    {

        [HttpPost]
        [Route("api/content")]
        public async Task<IActionResult> dmtCallback([FromBody] dynamic content)
        {
            string s = JsonConvert.SerializeObject(content);

            return Json(s);
           
        }
        public async Task<IActionResult> depositRechargeCommission()
        {           
            return Ok();
        }
        public async Task<IActionResult> depositDMTCommission()
        {
            return Ok();
        }
    }
}
