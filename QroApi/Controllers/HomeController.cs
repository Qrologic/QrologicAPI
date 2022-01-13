using QroApi.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QroApi.CustomAttributes;
using System.Diagnostics;
using QroApi.Models;
using QroApi.BLL;
using System.Threading.Tasks;
using Newtonsoft.Json;
using QroApi.MODEL;
using System;
using Newtonsoft.Json.Linq;
using System.Data;
using QroApi.DLL;
using System.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Extensions;

namespace QroApi.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMemberService _iMemberService;
        private readonly IDMT _iDMT;
        private readonly ISQLHelper _iSql;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public HomeController(ILogger<HomeController> logger, IMemberService iMemberService, IDMT iDMT, ISQLHelper iSql, IWebHostEnvironment hostEnvironment)
        {
            _logger = logger;
            _iMemberService = iMemberService;
            _iDMT = iDMT;
            _iSql = iSql;
            _webHostEnvironment = hostEnvironment;
        }

        public async Task<IActionResult> Index()
        {

            //var json = "{";
            //json += "\"mode\": \"online/offline\"";
            //json += "\"response_code\": 1,";
            //json += "\"message\": \"Remitter details fetch successfully.\",";
            //json += "\"data\": {";
            //json += "\"fname\": \"REMITTER FIRST NAME\",";
            //json += "\"lname\": \"REMITTER LAST NAME\",";
            //json += "\"mobile\": \"9990000000\",";
            //json += "\"status\": \"1\",";
            //json += "\"bank3_limit\": 25000,";
            //json += "\"bank2_limit\": 25000,";
            //json += "\"bank1_limit\": 25000}}";
            //json += "}";
            //string res = await _iDMT.CallPostAPI("",json);
            //JObject obj = JObject.Parse(res);
            //DataTable dt = (DataTable) JsonConvert.DeserializeObject(Convert.ToString(obj["data"]), (typeof(DataTable)));
            //DataView view = new DataView(dt);
            //view.RowFilter = "category='Insurance'";
            //// DataTable distinctValues = view.ToTable(true, "category");
            //foreach (DataRow s in view.ToTable().Rows)
            //{
            //    List<SqlParameter> list = new List<SqlParameter>();
            //    list.Add(new SqlParameter("@Name", Convert.ToString(s["name"])));
            //    list.Add(new SqlParameter("@FatchId", Convert.ToString(s["id"])));
            //    list.Add(new SqlParameter("@DisplayName", Convert.ToString(s["displayname"])));
            //    list.Add(new SqlParameter("@DisplayName2", Convert.ToString(s["ad1_d_name"])));
            //    list.Add(new SqlParameter("@REGX", Convert.ToString(s["regex"])));
            //    await _iSql.ExecuteProcedure("SP_TemOperator", list.ToArray());
            //}
            //ICICI._path = _webHostEnvironment.WebRootPath;
            //var res =await ICICI.CallICICI(Guid.NewGuid().ToString(), "1", "testing", "Israj Khan");
            //ViewBag.res = res;
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult CallBack()
        {
            Callback model = new Callback();
            model.status = "1";
            model.message = "Success";
            return Json(model);
        }
        [HttpPost]
        public IActionResult CallBack(Callback model)
        {
            
            model.status = "1";
            model.message = "Success";
            return Json(model);
        }
        public async Task<IActionResult> RechargeCallBack()
        {
            var _url = HttpContext.Request.GetDisplayUrl();
            var queryString = HttpContext.Request.Query;
            string query = "";
            foreach (var item in queryString)
            {
                query += item.Key + "=" + item.Value + "&";
            }
            query = await _iMemberService.ManageRechargeCallback(query);
            string url = "/Home/RechargeCallBackDefault?" + query;
            return Redirect(url);
        }
        public async Task<IActionResult> RechargeCallBackDefault(string status,string oprId,string txnId,string agentId)
        {
            var _url = HttpContext.Request.GetDisplayUrl();
            await _iMemberService.UpdateRechargeTransactionByCallback(status, oprId, txnId, agentId, _url);
            Callback model = new Callback();
            model.status = "1";
            model.message = "Success";
            return Json(model);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
