using QroApi.DLL;
using QroApi.MODEL;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace QroApi.BLL
{
    public class DMT : IDMT
    {
        #region Properties
        private readonly ISQLHelper _sqlHelper;
        private readonly ISettings _iSettings;
        private readonly IWallet _iWallet;
        public static string _token = "UFMwMDcxNDE3NDMyNjU1ZGJhMmRkNDE5N2I3NTYyN2U5ZjliNmQ2";
        public static string apiUrl = "https://api.paysprint.in/api/v1/service/";//"https://paysprint.in/service-api/api/v1/service/";
        #endregion

        #region Constructor
        public DMT(ISQLHelper sqlHelper, ISettings iSettings, IWallet iWallet)
        {
            _sqlHelper = sqlHelper;
            _iSettings = iSettings;
            _iWallet = iWallet;
        }
        #endregion

        #region Get JWT Token
        public async Task<string> GetJWTToken()
        {
            Random random = new Random();
            int ReqID = random.Next(0, 99999999);
            string key = "UFMwMDcxNDE3NDMyNjU1ZGJhMmRkNDE5N2I3NTYyN2U5ZjliNmQ2";
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var permClaims = new List<Claim>();
            permClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            permClaims.Add(new Claim("timestamp", DateTime.Now.AddDays(1).ToString("yyyyMMddHHmmssffff")));
            permClaims.Add(new Claim("partnerId", "PS00714"));
            permClaims.Add(new Claim("reqid", ReqID.ToString()));
            var token = new JwtSecurityToken("", "",
                          permClaims,
                          signingCredentials: credentials);
            var jwt_token = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt_token;
        }
        #endregion 

        #region Call API
        public async Task<string> CallPostAPI(string method, string requestJson)
        {
            string _token = await GetJWTToken();// "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJ0aW1lc3RhbXAiOjE2MzgxODY5NTcsInBhcnRuZXJJZCI6IlBTMDAzMjEiLCJyZXFpZCI6IjU2MzQ1NDU0MyJ9.2IOPyqx17hOw84avv0gFGdUfWkudaLHcZ0jRrE4XF2E";
            string key = "UFMwMDcxNDE3NDMyNjU1ZGJhMmRkNDE5N2I3NTYyN2U5ZjliNmQ2"; //"YjEwYjg2Yjg0ZGZjZjUyYWU2OTM1ODBjY2U1OWEzMjY="; 
            string response = string.Empty;
            try
            {
                var url = apiUrl + method;
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);

                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("Token", _token);
                //request.AddHeader("Authorisedkey", key);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Accept", "application/json");
                request.AddParameter("application/json", requestJson, ParameterType.RequestBody);
                IRestResponse content = client.Execute(request);
                response = content.Content;

            }
            catch (Exception ex)
            {
                response = "0";
            }
            return response;
        }
        #endregion

        #region Get Bank
        public async Task<Result> GetBank()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "GetBank"));

            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_DMTProcess", parameters.ToArray());
            Result result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = true, Message = "Data Fatched" }).First();
            result.Results = ds.Tables[0].AsEnumerable().Select(s => new
            {
                Id = s.Field<int>("BankId"),
                Name = s.Field<string>("BankName")
            }).ToList();
            return result;
        }
        #endregion

        #region Get API Balance        
        public async Task<ReportList> ApiBalance()
        {

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "APIList"));
            var totalRecord = 0;
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageDMT", parameters.ToArray());
            List<dmtApiBalance> list = new List<dmtApiBalance>();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    totalRecord = Convert.ToInt32(ds.Tables[0].Rows[0]["TotalRow"].ToString());
                    list = ds.Tables[0].AsEnumerable().Select(s => new dmtApiBalance
                    {
                        SrNo = s["SrNo"] != DBNull.Value ? Convert.ToInt32(s["SrNo"]) : 0,
                        ApiId = s["Id"] != DBNull.Value ? Convert.ToInt32(s["Id"]) : 0,
                        ApiName = s["ApiName"] != DBNull.Value ? Convert.ToString(s["ApiName"]) : "",
                        Action = s["Action"] != DBNull.Value ? Convert.ToString(s["Action"]) : "",
                        Balance = "0"
                    }).ToList();
                }
            }
            ReportList model = new ReportList();
            var _request = "";
            var response = await CallPostAPI("balance/balance/cashbalance", _request);
            if (response != "0" && response != "")
            {
                JObject _obj = JObject.Parse(response);
                if (Convert.ToBoolean(_obj["status"]) == true && Convert.ToInt32(_obj["response_code"]) == 1)
                {
                    list.Where(w => w.ApiId == 2).ToList().ForEach(i => i.Balance = Convert.ToString(_obj["cdwallet"]));
                }
            }
            await ICICI.ErrorLog("", "balance/balance/cashbalance", _request, response, 2);
            response = await ICICI.BalanceEnquiry();
            JObject _objD = JObject.Parse(response);
            if (_objD["RESPONSE"] != null)
            {
                var _apiResponse = _objD["RESPONSE"] != null ? Convert.ToString(_objD["RESPONSE"]) : "FAILURE";
                if (_apiResponse.ToLower() == "success")
                {
                    list.Where(w => w.ApiId == 1).ToList().ForEach(i => i.Balance = Convert.ToString(Convert.ToString(_objD["EFFECTIVEBAL"])));
                }
            }
            model.recordsFiltered = totalRecord;
            model.recordsTotal = totalRecord;
            model.data = list;
            model.draw = 1;
            return model;
        }
        #endregion

        #region Remitter Detail
        public async Task<dmtModels.Response> RemitterDetail(dmtModels.FatchRemitter model)
        {
            dmtModels.Response result = new dmtModels.Response();
            var _request = JsonConvert.SerializeObject(model);
            var response = await CallPostAPI("dmt/remitter/queryremitter", _request);
            if (response == "0")
            {
                result.response_code = 406;
                result.status = false;
                result.message = "Something Went Wrong !";
                return result;
            }
            result = JsonConvert.DeserializeObject<dmtModels.Response>(response);

            var limit = 0M;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "RemitterLimit"));
            parameters.Add(new SqlParameter("@RemitterMobile", model.mobile));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageDMT", parameters.ToArray());

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    limit = Convert.ToDecimal(ds.Tables[0].Rows[0]["MonthlyLimit"]);
                }
            }
            result.remitter_limit = limit.ToString();
            return result;
        }
        #endregion

        #region Remitter Registration
        public async Task<dmtModels.Response> RemitterRegistration(dmtModels.RemitterRegistration model)
        {
            dmtModels.Response result = new dmtModels.Response();
            var _request = JsonConvert.SerializeObject(model);
            var response = await CallPostAPI("dmt/remitter/registerremitter", _request);
            if (response == "0")
            {
                result.response_code = 406;
                result.status = false;
                result.message = "Something Went Wrong !";
                return result;
            }
            result = JsonConvert.DeserializeObject<dmtModels.Response>(response);
            return result;
        }
        #endregion

        #region Fetch Beneficiary
        public async Task<dmtModels.Response> FetchBeneficiary(dmtModels.FetchBeneficiary model)
        {
            dmtModels.Response result = new dmtModels.Response();
            var _request = JsonConvert.SerializeObject(model);
            var response = await CallPostAPI("dmt/beneficiary/registerbeneficiary/fetchbeneficiary", _request);
            if (response == "0")
            {
                result.response_code = 406;
                result.status = false;
                result.message = "Something Went Wrong !";
                return result;
            }
            result = JsonConvert.DeserializeObject<dmtModels.Response>(response);
            return result;
        }
        #endregion

        #region Register Beneficiary
        public async Task<dmtModels.Response> RegisterBeneficiary(dmtModels.RegisterBeneficiary model)
        {
            dmtModels.Response result = new dmtModels.Response();
            var _request = JsonConvert.SerializeObject(model);
            var response = await CallPostAPI("dmt/beneficiary/registerbeneficiary", _request);
            if (response == "0")
            {
                result.response_code = 406;
                result.status = false;
                result.message = "Something Went Wrong !";
                return result;
            }
            result = JsonConvert.DeserializeObject<dmtModels.Response>(response);
            return result;
        }
        #endregion

        #region Delete Beneficiary
        public async Task<dmtModels.Response> DeleteBeneficiary(dmtModels.DeleteBeneficiary model)
        {
            dmtModels.Response result = new dmtModels.Response();
            var _request = JsonConvert.SerializeObject(model);
            var response = await CallPostAPI("dmt/beneficiary/registerbeneficiary/deletebeneficiary", _request);
            if (response == "0")
            {
                result.response_code = 406;
                result.status = false;
                result.message = "Something Went Wrong !";
                return result;
            }
            result = JsonConvert.DeserializeObject<dmtModels.Response>(response);
            return result;
        }
        #endregion

        #region Verify Beneficiary
        public async Task<Result> VerifyBeneficiary(dmtModels.BeneficiaryVerify model, int msrNo, string source)
        {
            Result result = new Result();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "Insert"));
            parameters.Add(new SqlParameter("@MsrNo", msrNo));
            parameters.Add(new SqlParameter("@Status", "Pending"));
            parameters.Add(new SqlParameter("@Account", model.accno));
            parameters.Add(new SqlParameter("@Ifsc", model.ifsccode));
            parameters.Add(new SqlParameter("@RemitterMobile", model.mobile));
            parameters.Add(new SqlParameter("@Remitter", model.remname));
            parameters.Add(new SqlParameter("@BankName", model.bankname));
            parameters.Add(new SqlParameter("@Type", 0));
            parameters.Add(new SqlParameter("@Source", source));
            parameters.Add(new SqlParameter("@BeneName", model.benename));
            DataSet ds = new DataSet();
            ds = await _sqlHelper.ExecuteProcedure("SP_DMTProcess", parameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToBoolean(ds.Tables[0].Rows[0]["Status"]))
                    {
                        int id = Convert.ToInt32(ds.Tables[0].Rows[0]["Id"]);
                        string txnId = Convert.ToString(ds.Tables[0].Rows[0]["TxnId"]);
                        model.referenceid = txnId;
                        var _request = JsonConvert.SerializeObject(model);
                        var response = await CallPostAPI("dmt/beneficiary/registerbeneficiary/benenameverify", _request);
                        if (response != "0" && response != "")
                        {
                            dmtModels.Response _response = JsonConvert.DeserializeObject<dmtModels.Response>(response);
                            if (_response.status = true && _response.response_code == 1)
                            {
                                ds = new DataSet();
                                string status = _response.txn_status == 1 ? "Success" : _response.txn_status == 0 ? "Failed" : "Pending";
                                parameters = new List<SqlParameter>();
                                parameters.Add(new SqlParameter("@Action", "Update"));
                                parameters.Add(new SqlParameter("@Id", id));
                                parameters.Add(new SqlParameter("@Status", status));
                                parameters.Add(new SqlParameter("@ApiTxnId", _response.ackno));
                                parameters.Add(new SqlParameter("@BankUtr", _response.utr));
                                parameters.Add(new SqlParameter("@Response", response));
                                ds = await _sqlHelper.ExecuteProcedure("SP_DMTProcess", parameters.ToArray());
                                if (ds.Tables.Count > 0)
                                {
                                    if (ds.Tables[0].Rows.Count > 0)
                                    {
                                        result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = Convert.ToBoolean(s["Status"]), Message = s.Field<string>("Message") }).First();
                                        result.Results = new dmtModels.BeneficiaryVerify { benename = _response.benename };
                                    }
                                }
                            }
                            else
                            {
                                parameters = new List<SqlParameter>();
                                parameters.Add(new SqlParameter("@Action", "Update"));
                                parameters.Add(new SqlParameter("@Id", id));
                                parameters.Add(new SqlParameter("@Status", "Failed"));
                                parameters.Add(new SqlParameter("@ApiTxnId", _response.ackno));
                                parameters.Add(new SqlParameter("@BankUtr", _response.utr));
                                parameters.Add(new SqlParameter("@Response", response));
                                ds = await _sqlHelper.ExecuteProcedure("SP_DMTProcess", parameters.ToArray());
                                if (ds.Tables.Count > 0)
                                {
                                    if (ds.Tables[0].Rows.Count > 0)
                                    {
                                        result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = Convert.ToBoolean(s["Status"]), Message = s.Field<string>("Message") }).First();
                                    }
                                }
                            }
                        }
                        else
                        {
                            parameters = new List<SqlParameter>();
                            parameters.Add(new SqlParameter("@Action", "Update"));
                            parameters.Add(new SqlParameter("@Id", id));
                            parameters.Add(new SqlParameter("@Status", "Failed"));
                            parameters.Add(new SqlParameter("@ApiTxnId", ""));
                            parameters.Add(new SqlParameter("@BankUtr", ""));
                            parameters.Add(new SqlParameter("@Response", response));
                            ds = await _sqlHelper.ExecuteProcedure("SP_DMTProcess", parameters.ToArray());
                            if (ds.Tables.Count > 0)
                            {
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = Convert.ToBoolean(s["Status"]), Message = s.Field<string>("Message") }).First();
                                }
                            }
                            // result = new Result { Status = false, Message = "Something Went Wrong !" };
                        }
                    }
                    else
                    {
                        result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = Convert.ToBoolean(s["Status"]), Message = s.Field<string>("Message") }).First();
                    }
                }
            }

            return result;
        }
        #endregion

        #region Calculate Surcharge
        public async Task<decimal> CalculateSurcharge(int msrNo, decimal amount)
        {
            var totalAmount = 0M;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "CalculateSurcharge"));
            parameters.Add(new SqlParameter("@MsrNo", msrNo));
            parameters.Add(new SqlParameter("@Amount", amount));           
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_DMTProcess", parameters.ToArray());
           
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    totalAmount = Convert.ToDecimal(ds.Tables[0].Rows[0]["NetAmount"].ToString());                    
                }
            }
            return totalAmount;
        }
        #endregion

        #region Confirm Transaction
        public async Task<dmtBulkReciept> ConfirmTransaction(dmtModels.Transaction model, int msrNo, string source)
        {
            dmtBulkReciept _bulk = new dmtBulkReciept();
            _bulk.response_code = true;
            if (model.amount > 25000)
            {
                _bulk.response_code = false;
                _bulk.message = "Invalid Amount !";
                return _bulk;
            }
            var wallet = await _iWallet.GetBalanceByMsrNo(msrNo);
            decimal totalAmount = await CalculateSurcharge(msrNo,model.amount);            
            if (wallet.Balance < totalAmount)
            {
                _bulk.response_code = false;
                _bulk.message = "Insufficient Balance !";
                return _bulk;
            }
            int total_amount = Convert.ToInt32(model.amount);
            int factor_amount = 5000;
            int remaining_amount = total_amount % factor_amount;
            int loop = total_amount / factor_amount;
            _bulk.Sender = model.remname;
            _bulk.SenderMobile = model.mobile;
            _bulk.Bank = model.bankname;
            _bulk.Reciever = model.benename;
            _bulk.Account = model.accno;
            _bulk.Ifsc = model.ifsccode;
            _bulk.PaymentMode = model.txntype;
            List<dmtBulkTransaction> listAll = new List<dmtBulkTransaction>();
            for (int i = 1; i <= loop; i++)
            {
                dmtBulkTransaction _bulktxn = new dmtBulkTransaction();
                _bulktxn = await BulkTransaction(model, msrNo, source, factor_amount.ToString());
                listAll.Add(_bulktxn);
            }
            if (remaining_amount > 0)
            {
                dmtBulkTransaction _bulktxn = new dmtBulkTransaction();
                _bulktxn = await BulkTransaction(model, msrNo, source, remaining_amount.ToString());
                listAll.Add(_bulktxn);
            }
            CompanyModel company = new CompanyModel();
            company = await _iSettings.GetCompanyDetailById(1);
            _bulk.company = company;
            _bulk.listTxn = listAll;
            return _bulk;
        }

        public async Task<dmtBulkTransaction> BulkTransaction(dmtModels.Transaction model, int msrNo, string source, string amount)
        {
            dmtBulkTransaction _bulkTxn = new dmtBulkTransaction();
            try
            {
                model.amount = Convert.ToDecimal(amount);
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@Action", "Insert"));
                parameters.Add(new SqlParameter("@MsrNo", msrNo));
                parameters.Add(new SqlParameter("@Status", "Pending"));
                parameters.Add(new SqlParameter("@Account", model.accno));
                parameters.Add(new SqlParameter("@Ifsc", model.ifsccode));
                parameters.Add(new SqlParameter("@RemitterMobile", model.mobile));
                parameters.Add(new SqlParameter("@Remitter", model.remname));
                parameters.Add(new SqlParameter("@BankName", model.bankname));
                parameters.Add(new SqlParameter("@Type", 1));
                parameters.Add(new SqlParameter("@Source", source));
                parameters.Add(new SqlParameter("@Amount", amount));
                parameters.Add(new SqlParameter("@TxnType", model.txntype == "TPA" ? "IMPS" : model.txntype));
                parameters.Add(new SqlParameter("@BeneName", model.benename));
                DataSet ds = new DataSet();
                _bulkTxn.Amount = amount;
                _bulkTxn.Date = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");
                ds = await _sqlHelper.ExecuteProcedure("SP_DMTProcess", parameters.ToArray());
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (Convert.ToBoolean(ds.Tables[0].Rows[0]["Status"]))
                        {
                            int id = Convert.ToInt32(ds.Tables[0].Rows[0]["Id"]);
                            string txnId = Convert.ToString(ds.Tables[0].Rows[0]["TxnId"]);
                            model.referenceid = txnId;
                            _bulkTxn.OrderId = txnId;
                            var response = "";
                            int activeApi = Convert.ToInt32(ds.Tables[0].Rows[0]["ActiveAPI"]);
                            parameters = new List<SqlParameter>();
                            if (activeApi == 1)
                            {
                                string _apiResponse = "", _apiMessage = "", _apiTxnId = "", _utrNo = "", _apiStatus = "";
                                var txnMode = model.txntype.ToLower() == "imps" ? "IFS" : model.txntype.ToLower() == "neft" ? "RGS" : "TPA";

                                response = await ICICI.TransactionRequest(txnId, model.amount, "Send Amount to " + model.accno, model.benename, model.accno, model.ifsccode, txnMode);


                                JObject _obj = JObject.Parse(response);
                                if (_obj["RESPONSE"] != null)
                                {
                                    _apiResponse = _obj["RESPONSE"] != null ? Convert.ToString(_obj["RESPONSE"]) : "FAILURE";
                                    _apiMessage = _obj["MESSAGE"] != null ? Convert.ToString(_obj["MESSAGE"]) : "Something Went Wrong !";
                                    _apiTxnId = _obj["REQID"] != null ? Convert.ToString(_obj["REQID"]) : "";
                                    _utrNo = _obj["UTRNUMBER"] != null ? Convert.ToString(_obj["UTRNUMBER"]) : "0";
                                    _apiStatus = _obj["STATUS"] != null ? Convert.ToString(_obj["STATUS"]) : "Pending";
                                    _bulkTxn.Status = _apiStatus;
                                    _bulkTxn.RefNo = _utrNo;
                                    if (_apiResponse.ToLower() == "success")
                                    {
                                        if (_apiStatus.ToLower() == "success")
                                        {
                                            parameters.Add(new SqlParameter("@Status", _apiStatus));
                                        }
                                        else if (_apiStatus.ToLower() == "pending" || _apiStatus.ToLower() == "pending for processing")
                                        {
                                            _apiStatus = _apiStatus.ToLower() == "pending for processing" ? "Pending" : _apiStatus;
                                            parameters.Add(new SqlParameter("@Status", _apiStatus));

                                        }
                                        else if (_apiStatus.ToLower() == "failure" || _apiStatus.ToLower() == "failed" || _apiStatus.ToLower() == "duplicate")
                                        {
                                            _apiStatus = _apiStatus.ToLower() == "duplicate" ? "Pending" : _apiStatus;
                                            parameters.Add(new SqlParameter("@Status", _apiStatus));

                                        }
                                        else
                                        {
                                            parameters.Add(new SqlParameter("@Status", _apiStatus));

                                        }
                                    }
                                    else if (_apiResponse.ToLower() == "failure")
                                    {
                                        parameters.Add(new SqlParameter("@Status", "Failure"));
                                        _bulkTxn.Status = "Failed";
                                    }
                                }
                                else
                                {
                                    parameters.Add(new SqlParameter("@Status", "Failure"));
                                    _bulkTxn.Status = "Failed";
                                }
                                parameters.Add(new SqlParameter("@Action", "Update"));
                                parameters.Add(new SqlParameter("@Id", id));
                                parameters.Add(new SqlParameter("@ApiTxnId", _apiTxnId));
                                parameters.Add(new SqlParameter("@BankUtr", _utrNo));
                                parameters.Add(new SqlParameter("@Response", response));
                                ds = await _sqlHelper.ExecuteProcedure("SP_DMTProcess", parameters.ToArray());
                                //if (ds.Tables.Count > 0)
                                //{
                                //    if (ds.Tables[0].Rows.Count > 0)
                                //    {
                                //        result = ds.Tables[0].AsEnumerable().Select(s => new dmtResult { Status = Convert.ToBoolean(s["Status"]), Message = s.Field<string>("Message"), Id = id }).First();
                                //    }
                                //}
                                //result.Results = response;
                            }
                            else if (activeApi == 2)
                            {
                                var _request = JsonConvert.SerializeObject(model);
                                response = await CallPostAPI("dmt/transact/transact", _request);
                                await ICICI.ErrorLog(txnId, "dmt/transact/transact", _request, response, 2);
                                if (response != "0" && response != "")
                                {
                                    dmtModels.TransactionResponse _response = JsonConvert.DeserializeObject<dmtModels.TransactionResponse>(response);
                                    if (_response.status = true && _response.response_code == 1)
                                    {
                                        ds = new DataSet();
                                        string status = _response.txn_status == 1 ? "Success" : _response.txn_status == 0 ? "Failed" : _response.txn_status == 5 ? "Failed" : "Pending";
                                        parameters = new List<SqlParameter>();
                                        parameters.Add(new SqlParameter("@Action", "Update"));
                                        parameters.Add(new SqlParameter("@Id", id));
                                        parameters.Add(new SqlParameter("@Status", status));
                                        parameters.Add(new SqlParameter("@ApiTxnId", _response.ackno));
                                        parameters.Add(new SqlParameter("@BankUtr", _response.utr));
                                        parameters.Add(new SqlParameter("@ApiCharge", _response.customercharge));
                                        parameters.Add(new SqlParameter("@Response", response));
                                        ds = await _sqlHelper.ExecuteProcedure("SP_DMTProcess", parameters.ToArray());
                                        _bulkTxn.Status = status;
                                        _bulkTxn.RefNo = _response.utr;
                                        //if (ds.Tables.Count > 0)
                                        //{
                                        //    if (ds.Tables[0].Rows.Count > 0)
                                        //    {
                                        //        result = ds.Tables[0].AsEnumerable().Select(s => new dmtResult { Status = Convert.ToBoolean(s["Status"]), Message = s.Field<string>("Message"), Id = id }).First();
                                        //        result.Results = response;
                                        //    }
                                        //}

                                    }
                                    else
                                    {
                                        parameters = new List<SqlParameter>();
                                        parameters.Add(new SqlParameter("@Action", "Update"));
                                        parameters.Add(new SqlParameter("@Id", id));
                                        parameters.Add(new SqlParameter("@Status", "Failed"));
                                        parameters.Add(new SqlParameter("@ApiTxnId", _response.ackno));
                                        parameters.Add(new SqlParameter("@BankUtr", _response.utr));
                                        parameters.Add(new SqlParameter("@Response", response));
                                        ds = await _sqlHelper.ExecuteProcedure("SP_DMTProcess", parameters.ToArray());
                                        _bulkTxn.Status = "Failed";
                                        //if (ds.Tables.Count > 0)
                                        //{
                                        //    if (ds.Tables[0].Rows.Count > 0)
                                        //    {
                                        //        result = ds.Tables[0].AsEnumerable().Select(s => new dmtResult { Status = Convert.ToBoolean(s["Status"]), Message = s.Field<string>("Message"), Id = id }).FirstOrDefault();
                                        //    }
                                        //}
                                    }
                                }
                                else
                                {
                                    parameters = new List<SqlParameter>();
                                    parameters.Add(new SqlParameter("@Action", "Update"));
                                    parameters.Add(new SqlParameter("@Id", id));
                                    parameters.Add(new SqlParameter("@Status", "Failed"));
                                    parameters.Add(new SqlParameter("@ApiTxnId", ""));
                                    parameters.Add(new SqlParameter("@BankUtr", ""));
                                    parameters.Add(new SqlParameter("@Response", response));
                                    ds = await _sqlHelper.ExecuteProcedure("SP_DMTProcess", parameters.ToArray());
                                    _bulkTxn.Status = "Failed";
                                    //if (ds.Tables.Count > 0)
                                    //{
                                    //    if (ds.Tables[0].Rows.Count > 0)
                                    //    {
                                    //        result = ds.Tables[0].AsEnumerable().Select(s => new dmtResult { Status = Convert.ToBoolean(s["Status"]), Message = s.Field<string>("Message"), Id = id }).First();
                                    //    }
                                    //}

                                }
                            }
                        }
                        else
                        {
                            _bulkTxn.Status = "Failed";

                            //result = ds.Tables[0].AsEnumerable().Select(s => new dmtResult { Status = Convert.ToBoolean(s["Status"]), Message = s.Field<string>("Message") }).First();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _bulkTxn.Status = "Failed";
                //result = new dmtResult { Status = false, Message = "Something Went Wrong !" };
            }
            return _bulkTxn;
        }
        #endregion

        #region Transaction Enquiry
        public async Task<Result> TransactionEnquiry(TransactionEnquiry model)
        {
            Result result = new Result();
            var response = "";
            DataSet ds = new DataSet();
            List<SqlParameter> parameters = new List<SqlParameter>();
            if (model.apiId == 1)
            {
                string _apiResponse = "", _apiMessage = "", _apiTxnId = "", _utrNo = "", _apiStatus = "";

                response = await ICICI.TransactionStatusRequest(model.referenceId);
                JObject _obj = JObject.Parse(response);
                if (_obj["RESPONSE"] != null)
                {
                    _apiResponse = _obj["RESPONSE"] != null ? Convert.ToString(_obj["RESPONSE"]) : "FAILURE";
                    _apiMessage = _obj["MESSAGE"] != null ? Convert.ToString(_obj["MESSAGE"]) : "Something Went Wrong !";
                    _apiTxnId = _obj["REQID"] != null ? Convert.ToString(_obj["REQID"]) : "";
                    _utrNo = _obj["UTRNUMBER"] != null ? Convert.ToString(_obj["UTRNUMBER"]) : "";
                    _apiStatus = _obj["STATUS"] != null ? Convert.ToString(_obj["STATUS"]) : "";
                    if (_apiResponse.ToLower() == "success")
                    {
                        if (_apiStatus.ToLower() == "success")
                        {
                            parameters.Add(new SqlParameter("@Status", _apiStatus));
                        }
                        else if (_apiStatus.ToLower() == "pending" || _apiStatus.ToLower() == "pending for processing")
                        {
                            _apiStatus = _apiStatus.ToLower() == "pending for processing" ? "Pending" : _apiStatus;
                            parameters.Add(new SqlParameter("@Status", _apiStatus));
                        }
                        else if (_apiStatus.ToLower() == "failure" || _apiStatus.ToLower() == "failed" || _apiStatus.ToLower() == "duplicate")
                        {
                            _apiStatus = _apiStatus.ToLower() == "duplicate" ? "Pending" : _apiStatus;
                            parameters.Add(new SqlParameter("@Status", _apiStatus));
                        }
                        else
                        {
                            parameters.Add(new SqlParameter("@Status", _apiStatus));
                        }
                    }
                    else if (_apiResponse.ToLower() == "failure")
                    {
                        parameters.Add(new SqlParameter("@Status", "Failure"));
                    }
                    parameters.Add(new SqlParameter("@Action", "Update"));
                    parameters.Add(new SqlParameter("@Id", model.id));
                    parameters.Add(new SqlParameter("@ApiTxnId", _apiTxnId));
                    parameters.Add(new SqlParameter("@BankUtr", _utrNo));
                    parameters.Add(new SqlParameter("@Response", response));
                    ds = await _sqlHelper.ExecuteProcedure("SP_DMTProcess", parameters.ToArray());
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = Convert.ToBoolean(s["Status"]), Message = s.Field<string>("Message") }).First();
                        }
                    }
                    result.Results = response;
                }
            }
            else if (model.apiId == 2)
            {
                var _parameterList = new Dictionary<string, object>();
                _parameterList.Add("referenceid", model.referenceId);
                var _request = JsonConvert.SerializeObject(_parameterList);
                response = await CallPostAPI("dmt/transact/transact/querytransact", _request);
                if (response != "0" && response != "")
                {
                    dmtModels.TransactionResponse _response = JsonConvert.DeserializeObject<dmtModels.TransactionResponse>(response);
                    if (_response.status = true && _response.response_code == 1)
                    {
                        ds = new DataSet();
                        string status = _response.txn_status == 1 ? "Success" : _response.txn_status == 0 ? "Failed" : _response.txn_status == 5 ? "Failed" : "Pending";
                        parameters = new List<SqlParameter>();
                        parameters.Add(new SqlParameter("@Action", "Update"));
                        parameters.Add(new SqlParameter("@Id", model.id));
                        parameters.Add(new SqlParameter("@Status", status));
                        parameters.Add(new SqlParameter("@ApiTxnId", _response.ackno));
                        parameters.Add(new SqlParameter("@BankUtr", _response.utr));
                        parameters.Add(new SqlParameter("@ApiCharge", _response.customercharge));
                        parameters.Add(new SqlParameter("@Response", response));
                        ds = await _sqlHelper.ExecuteProcedure("SP_DMTProcess", parameters.ToArray());
                        if (ds.Tables.Count > 0)
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = Convert.ToBoolean(s["Status"]), Message = s.Field<string>("Message") }).First();
                                result.Results = response;
                            }
                        }
                    }
                }
                else
                {
                    result = new Result { Status = false, Message = "Something Went Wrong !" };
                }
            }
            return result;
        }
        #endregion

        #region Send OTP For Refund
        public async Task<dmtModels.Response> SendOTPForRefund(TransactionEnquiry model)
        {
            dmtModels.Response result = new dmtModels.Response();
            var _parameterList = new Dictionary<string, object>();
            _parameterList.Add("referenceid", model.referenceId);
            _parameterList.Add("ackno", model.apitxnId);
            var _request = JsonConvert.SerializeObject(_parameterList);
            var response = await CallPostAPI("dmt/refund/refund/resendotp", _request);
            if (response == "0" && response == "")
            {
                result.response_code = 406;
                result.status = false;
                result.message = "Something Went Wrong !";
                return result;
            }

            result = JsonConvert.DeserializeObject<dmtModels.Response>(response);
            return result;
        }
        #endregion

        #region Refund Transaction
        public async Task<dmtModels.Response> RefundTransaction(TransactionEnquiry model)
        {
            dmtModels.Response result = new dmtModels.Response();
            var _parameterList = new Dictionary<string, object>();
            _parameterList.Add("referenceid", model.referenceId);
            _parameterList.Add("ackno", model.apitxnId);
            _parameterList.Add("otp", model.otp);
            var _request = JsonConvert.SerializeObject(_parameterList);
            var response = await CallPostAPI("dmt/refund/refund", _request);
            if (response == "0" && response == "")
            {
                result.response_code = 406;
                result.status = false;
                result.message = "Something Went Wrong !";
                return result;
            }
            if (result.status == true && result.response_code == 1)
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@Status", "Failed"));
                parameters.Add(new SqlParameter("@Action", "Update"));
                parameters.Add(new SqlParameter("@Id", model.id));
                parameters.Add(new SqlParameter("@ApiTxnId", model.apitxnId));

                parameters.Add(new SqlParameter("@Response", response));
                DataSet ds = await _sqlHelper.ExecuteProcedure("SP_DMTProcess", parameters.ToArray());
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        result = ds.Tables[0].AsEnumerable().Select(s => new dmtModels.Response { status = Convert.ToBoolean(s["Status"]), message = s.Field<string>("Message"), response_code = 1 }).First();
                    }
                }
            }
            result = JsonConvert.DeserializeObject<dmtModels.Response>(response);
            return result;
        }
        #endregion

        #region Force Update Transaction
        public async Task<Result> ForceUpdateTransaction(int id, int type)
        {
            Result result = new Result();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Status", type == 0 ? "Failed" : "Success"));
            parameters.Add(new SqlParameter("@Action", "Update"));
            parameters.Add(new SqlParameter("@Id", id));
            //parameters.Add(new SqlParameter("@ApiTxnId",""));

            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_DMTProcess", parameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = Convert.ToBoolean(s["Status"]), Message = s.Field<string>("Message") }).FirstOrDefault();
                }
            }
            return result;
        }
        #endregion

        #region Get Pending Transaction
        public async Task<PendingDMT> GetPendingTransaction()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "GetPending"));
            PendingDMT model = new PendingDMT();
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageDMT", parameters.ToArray());
            Result result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = true, Message = "Data Fatched" }).FirstOrDefault();
            List<PendingDMT> list = new List<PendingDMT>();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {

                    list = ds.Tables[0].AsEnumerable().Select(s => new PendingDMT
                    {
                        SrNo = s["SrNo"] != DBNull.Value ? Convert.ToInt32(s["SrNo"]) : 0,
                        Id = s["Id"] != DBNull.Value ? Convert.ToInt32(s["Id"]) : 0,
                        ApiId = s["ApiId"] != DBNull.Value ? Convert.ToInt32(s["ApiId"]) : 0,
                        Amount = s["Amount"] != DBNull.Value ? Convert.ToString(s["Amount"]) : "",
                        MemberName = s["Member"] != DBNull.Value ? Convert.ToString(s["Member"]) : "",
                        Account = s["Account"] != DBNull.Value ? Convert.ToString(s["Account"]) : "",
                        TxnId = s["TxnId"] != DBNull.Value ? Convert.ToString(s["TxnId"]) : "",
                        ApiTxnId = s["ApiTxnId"] != DBNull.Value ? Convert.ToString(s["ApiTxnId"]) : "",
                        Status = s["Status"] != DBNull.Value ? Convert.ToString(s["Status"]) : "",
                        Ifsc = s["Ifsc"] != DBNull.Value ? Convert.ToString(s["Ifsc"]) : "",
                        Remitter = s["Remitter"] != DBNull.Value ? Convert.ToString(s["Remitter"]) : "",
                        TxnDate = s["TxnDate"] != DBNull.Value ? Convert.ToString(s["TxnDate"]) : "",
                        BeneName = s["BeneName"] != DBNull.Value ? Convert.ToString(s["BeneName"]) : "",
                        RefNo = s["RefNo"] != DBNull.Value ? Convert.ToString(s["RefNo"]) : ""
                    }).ToList();
                }

            }
            model.list = list;
            return model;
        }
        #endregion

        #region Get Find Transaction
        public async Task<PendingDMT> FindTransaction(string txnId)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "FindByTxnId"));
            parameters.Add(new SqlParameter("@TxnId", txnId));
            PendingDMT model = new PendingDMT();
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageDMT", parameters.ToArray());
            Result result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = true, Message = "Data Fatched" }).First();
            List<PendingDMT> list = new List<PendingDMT>();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {

                    list = ds.Tables[0].AsEnumerable().Select(s => new PendingDMT
                    {
                        SrNo = s["SrNo"] != DBNull.Value ? Convert.ToInt32(s["SrNo"]) : 0,
                        Id = s["Id"] != DBNull.Value ? Convert.ToInt32(s["Id"]) : 0,
                        ApiId = s["ApiId"] != DBNull.Value ? Convert.ToInt32(s["ApiId"]) : 0,
                        Amount = s["Amount"] != DBNull.Value ? Convert.ToString(s["Amount"]) : "",
                        MemberName = s["Member"] != DBNull.Value ? Convert.ToString(s["Member"]) : "",
                        Account = s["Account"] != DBNull.Value ? Convert.ToString(s["Account"]) : "",
                        TxnId = s["TxnId"] != DBNull.Value ? Convert.ToString(s["TxnId"]) : "",
                        ApiTxnId = s["ApiTxnId"] != DBNull.Value ? Convert.ToString(s["ApiTxnId"]) : "",
                        Status = s["Status"] != DBNull.Value ? Convert.ToString(s["Status"]) : "",
                        Ifsc = s["Ifsc"] != DBNull.Value ? Convert.ToString(s["Ifsc"]) : "",
                        Remitter = s["Remitter"] != DBNull.Value ? Convert.ToString(s["Remitter"]) : "",
                        TxnDate = s["TxnDate"] != DBNull.Value ? Convert.ToString(s["TxnDate"]) : "",
                        BeneName = s["BeneName"] != DBNull.Value ? Convert.ToString(s["BeneName"]) : ""
                    }).ToList();
                }

            }
            model.list = list;
            return model;
        }
        #endregion

        #region Get IFSC By Bank Id
        public async Task<Result> GetIFSCByBankId(int id)
        {
            Result result = new Result();

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "GetIFSCByBankId"));
            parameters.Add(new SqlParameter("@BankId", id));

            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_DMTProcess", parameters.ToArray());
            result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = true, Message = "Data Fatched" }).First();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    result.Results = ds.Tables[0].AsEnumerable().Select(s => new
                    {
                        Id = s.Field<int>("BankId"),
                        Name = s.Field<string>("BankName"),
                        Ifsc = s.Field<string>("IFSC")
                    }).FirstOrDefault();
                }
            }
            return result;
        }
        #endregion

        #region Api List
        public async Task<ReportList> GetApiList()
        {
            ReportList result = new ReportList();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "APIList"));
            var totalRecord = 0;
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageDMT", parameters.ToArray());
            List<dmtApiList> list = new List<dmtApiList>();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    totalRecord = Convert.ToInt32(ds.Tables[0].Rows[0]["TotalRow"].ToString());
                    list = ds.Tables[0].AsEnumerable().Select(s => new dmtApiList
                    {
                        SrNo = s["SrNo"] != DBNull.Value ? Convert.ToInt32(s["SrNo"]) : 0,
                        ApiName = s["ApiName"] != DBNull.Value ? Convert.ToString(s["ApiName"]) : "",
                        Action = s["Action"] != DBNull.Value ? Convert.ToString(s["Action"]) : ""
                    }).ToList();
                }
            }
            result.recordsFiltered = totalRecord;
            result.recordsTotal = totalRecord;
            result.data = list;
            result.draw = 1;
            return result;
        }
        #endregion

        #region Get API For DDL
        public async Task<Result> GetAPI()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "GetApi"));

            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageDMTSurcharge", parameters.ToArray());
            Result result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = true, Message = "Data Fatched" }).First();
            result.Results = ds.Tables[0].AsEnumerable().Select(s => new
            {
                Id = Convert.ToInt32(s["Id"]),
                Name = s.Field<string>("ApiName")
            }).ToList();
            return result;
        }
        #endregion

        #region Switch Api
        public async Task<Result> SwitchApi(int id)
        {
            Result result = new Result();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "IsActiveApi"));
            parameters.Add(new SqlParameter("@Id", id));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageDMT", parameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = Convert.ToBoolean(s["Status"]), Message = s.Field<string>("Message") }).First();
                }
            }
            return result;
        }
        #endregion

        #region API Surcharge

        #region Add Edit API Surcharge
        public async Task<Result> AddEditApiSurcharge(dmtApiCharge model)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", model.Id == 0 ? "InsertApiCharge" : model.Id == null ? "InsertApiCharge" : "UpdateApiCharge"));
            parameters.Add(new SqlParameter("@Id", model.Id));
            parameters.Add(new SqlParameter("@ApiId", model.ApiId));
            parameters.Add(new SqlParameter("@PackageId", model.PackageId));
            parameters.Add(new SqlParameter("@FromAmount", model.FromAmount));
            parameters.Add(new SqlParameter("@ToAmount", model.ToAmount));
            parameters.Add(new SqlParameter("@ApiCharge", model.ApiCharge));
            parameters.Add(new SqlParameter("@Surcharge", model.Surcharge));
            parameters.Add(new SqlParameter("@IsFlat", model.IsFlat));
            parameters.Add(new SqlParameter("@gstRate", model.gstRate));
            parameters.Add(new SqlParameter("@tdsRate", model.tdsRate));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageDMTSurcharge", parameters.ToArray());
            Result result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = Convert.ToBoolean(s["Status"]), Message = s.Field<string>("Message") }).FirstOrDefault();
            return result;

        }
        #endregion

        #region GetApi Charge By Id
        public async Task<dmtApiCharge> GetApiChargeById(int id)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "GetApiChargeById"));
            parameters.Add(new SqlParameter("@Id", id));
            dmtApiCharge model = new dmtApiCharge();
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageDMTSurcharge", parameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    model = ds.Tables[0].AsEnumerable().Select(s => new dmtApiCharge
                    {
                        Id = Convert.ToInt32(s["Id"] == DBNull.Value ? 0 : s["Id"]),
                        ApiId = Convert.ToInt32(s["ApiId"] == DBNull.Value ? 0 : s["ApiId"]),
                        PackageId = Convert.ToInt32(s["PackageId"] == DBNull.Value ? 0 : s["PackageId"]),
                        FromAmount = Convert.ToDecimal(s["FromAmount"] == DBNull.Value ? 0 : s["FromAmount"]),
                        ToAmount = Convert.ToDecimal(s["ToAmount"] == DBNull.Value ? 0 : s["ToAmount"]),
                        ApiCharge = Convert.ToDecimal(s["ApiCharge"] == DBNull.Value ? "" : s["ApiCharge"]),
                        Surcharge = Convert.ToDecimal(s["Surcharge"] == DBNull.Value ? "" : s["Surcharge"]),
                        IsFlat = Convert.ToBoolean(s["IsFlat"] == DBNull.Value ? "" : s["IsFlat"]),
                        gstRate = Convert.ToString(s["gstRate"] == DBNull.Value ? "" : s["gstRate"]),
                        tdsRate = Convert.ToString(s["tdsRate"] == DBNull.Value ? "" : s["tdsRate"])
                    }).FirstOrDefault();
                }
            }
            return model;
        }
        #endregion

        #region Get Api Charge By Api Id
        public async Task<ReportList> GetApiChargeByApiId(string search, int pageIndex, int pageSize, string sortCol, string sortDir,  CommonFilter filetr)
        {
          
            ReportList rpList = new ReportList();
            List<dmtApiChargeResponse> list = new List<dmtApiChargeResponse>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "GetByApiId"));
            parameters.Add(new SqlParameter("@ApiId", filetr.option1));
            parameters.Add(new SqlParameter("@PackageId", filetr.option2));
            parameters.Add(new SqlParameter("@PageIndex", pageIndex));
            parameters.Add(new SqlParameter("@PageSize", pageSize));
            parameters.Add(new SqlParameter("@Search", search));
            int totalRecord = 0;
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageDMTSurcharge", parameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataView dv = new DataView(ds.Tables[0]);
                    dv.Sort = sortCol + " " + sortDir;
                    totalRecord = Convert.ToInt32(ds.Tables[0].Rows[0]["TotalRow"].ToString());
                    list = dv.ToTable().AsEnumerable().Select(s => new dmtApiChargeResponse
                    {
                        SrNo = Convert.ToInt32(s["SrNo"] == DBNull.Value ? 0 : s["SrNo"]),
                        Id = Convert.ToInt32(s["Id"] == DBNull.Value ? 0 : s["Id"]),
                        PackageName = Convert.ToString(s["PackageName"] == DBNull.Value ? 0 : s["PackageName"]),
                        ApiName = Convert.ToString(s["APIName"] == DBNull.Value ? 0 : s["APIName"]),
                        StartRange = Convert.ToDecimal(s["FromAmount"] == DBNull.Value ? 0 : s["FromAmount"]),
                        EndRange = Convert.ToDecimal(s["ToAmount"] == DBNull.Value ? 0 : s["ToAmount"]),
                        ApiCharge = Convert.ToString(s["ApiCharge"] == DBNull.Value ? "0" : s["ApiCharge"]),
                        Surcharge = Convert.ToString(s["Surcharge"] == DBNull.Value ? "0" : s["Surcharge"]),                       
                        GstRate = Convert.ToString(s["gstRate"] == DBNull.Value ? "0" : s["gstRate"]),
                        TdsRate = Convert.ToString(s["tdsRate"] == DBNull.Value ? "0" : s["tdsRate"]),
                        Action = s["Action"] == DBNull.Value ? "" : Convert.ToString(s["Action"])
                    }).ToList();
                }
            }
            rpList.recordsFiltered = totalRecord;
            rpList.recordsTotal = totalRecord;
            rpList.data = list;
            return rpList;
            
        }
        #endregion

        #endregion

        

        #region Get DMT Reciept
        public async Task<dmtReciept> dmtReciept(int id)
        {

            dmtReciept model = new dmtReciept();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "GetReciept"));
            parameters.Add(new SqlParameter("@Id", id));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageDMT", parameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    model = ds.Tables[0].AsEnumerable().Select(s => new dmtReciept
                    {
                        Amount = s["TransactionAmount"] == DBNull.Value ? 0 : Convert.ToDecimal(s["TransactionAmount"]),
                        TxnId = s["TxnId"] == DBNull.Value ? "" : Convert.ToString(s["TxnId"]),
                        ApiTxnId = s["ApiTxnId"] == DBNull.Value ? "" : Convert.ToString(s["ApiTxnId"]),
                        TxnDate = s["TxnDate"] == DBNull.Value ? "" : Convert.ToString(s["TxnDate"]),
                        Status = s["Status"] == DBNull.Value ? "" : Convert.ToString(s["Status"]),
                        RefNo = s["RefNo"] == DBNull.Value ? "" : Convert.ToString(s["RefNo"]),
                        Account = s["Account"] == DBNull.Value ? "" : Convert.ToString(s["Account"]),
                        Ifsc = s["Ifsc"] == DBNull.Value ? "" : Convert.ToString(s["Ifsc"]),
                        SenderMobile = s["SenderMobile"] == DBNull.Value ? "" : Convert.ToString(s["SenderMobile"]),
                        Sender = s["Sender"] == DBNull.Value ? "" : Convert.ToString(s["Sender"]),
                        Reciever = s["Reciever"] == DBNull.Value ? "" : Convert.ToString(s["Reciever"]),
                        Bank = s["Bank"] == DBNull.Value ? "" : Convert.ToString(s["Bank"]),
                        PaymentMode = s["PaymentMode"] == DBNull.Value ? "" : Convert.ToString(s["PaymentMode"]),
                        Surcharge = s["Surcharge"] == DBNull.Value ? "" : Convert.ToString(s["Surcharge"]),

                    }).FirstOrDefault();
                }
            }
            CompanyModel company = new CompanyModel();
            company = await _iSettings.GetCompanyDetailById(1);
            model.company = company;
            return model;
        }
        #endregion

        #region Get Api Logs
        public async Task<ReportList> ApiLogs(string search, int pageIndex, int pageSize, string sortCol, string sortDir, int msrNo, CommonFilter model)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "ApiLogs"));
            parameters.Add(new SqlParameter("@Id", model.option1 == null ? 0 : model.option1));
            parameters.Add(new SqlParameter("@fromDate", model.fromDate == null ? "01/01/2015" : model.fromDate));
            parameters.Add(new SqlParameter("@todate", model.toDate == null ? "01/01/2100" : model.toDate));
            parameters.Add(new SqlParameter("@PageIndex", pageIndex));
            parameters.Add(new SqlParameter("@PageSize", pageSize));
            parameters.Add(new SqlParameter("@Search", search));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageDMT", parameters.ToArray());
            Result result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = true, Message = "Data Fatched" }).FirstOrDefault();
            List<dmtApiLogs> list = new List<dmtApiLogs>();
            ReportList rpList = new ReportList();
            int totalRecord = 0;
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataView dv = new DataView(ds.Tables[0]);
                    dv.Sort = sortCol + " " + sortDir;
                    totalRecord = Convert.ToInt32(ds.Tables[0].Rows[0]["TotalRow"].ToString());
                    list = dv.ToTable().AsEnumerable().Select(s => new dmtApiLogs
                    {
                        SrNo = s["SrNo"] != DBNull.Value ? Convert.ToInt32(s["SrNo"]) : 0,
                        ApiName = s["ApiName"] != DBNull.Value ? Convert.ToString(s["ApiName"]) : "",
                        Url = s["Url"] != DBNull.Value ? Convert.ToString(s["Url"]) : "",
                        Response = s["Response"] != DBNull.Value ? Convert.ToString(s["Response"]) : "",
                        Request = s["Request"] != DBNull.Value ? Convert.ToString(s["Request"]) : "",
                        Date = s["CreateDate"] != DBNull.Value ? Convert.ToString(s["CreateDate"]) : "",
                    }).ToList();
                }
            }
            rpList.recordsFiltered = totalRecord;
            rpList.recordsTotal = totalRecord;
            rpList.data = list;
            return rpList;
        }
        #endregion

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }
                disposedValue = true;
            }
        }
        void IDisposable.Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
