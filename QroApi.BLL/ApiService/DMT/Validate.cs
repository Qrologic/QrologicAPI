using QroApi.DLL;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QroApi.BLL
{
    public class Validate
    {
        static  readonly ISQLHelper _sqlHelper;
        #region Constructor
        static Validate()
        {
            SQLHelper iSqlHelper = new SQLHelper();
            _sqlHelper = iSqlHelper;
        }
        #endregion

        #region Validate Member
        public static async Task<Tuple<bool,string,string>> ValidMember(int msrNo, string ipAddress)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "ValidateIPOrMember"));
            parameters.Add(new SqlParameter("@MsrNo", msrNo));
            parameters.Add(new SqlParameter("@IpAddress", ipAddress));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageIP", parameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                   return ds.Tables[0].AsEnumerable().Select(s => new Tuple<bool, string,string>(Convert.ToBoolean(s["Status"]), s.Field<string>("Message"), s.Field<string>("StatusCode"))).FirstOrDefault();
                }
            }
            return new Tuple<bool, string,string>(false,"Something Went Wrong","IPE");
        }

        #endregion

        public async Task<string> CallVerify_AccountApi()
        {
            var result = string.Empty;
            try
            {
                var client = new RestClient("https://api.instantpay.in/identity/verifyBankAccount");
                var request = new RestRequest(Method.POST);
                request.AddHeader("Accept", "application/json");
                request.AddHeader("X-Ipay-Auth-Code", "application/json");
                request.AddHeader("X-Ipay-Client-Id", "application/json");
                request.AddHeader("X-Ipay-Endpoint-Ip", "application/json");
                request.AddHeader("X-Ipay-Client-Secret", "application/json");
                IRestResponse response =  client.Execute(request);
                result = response.Content;
            }
            catch (Exception ex)
            {
                result = "0";
            }
            return result;
        }

    }
}
