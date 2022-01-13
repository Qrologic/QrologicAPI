using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QroApi.DLL;
using QroApi.MODEL;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QroApi.BLL
{
    public class dmtApiService : IdmtApiService
    {
        #region Properties
        public static string apiUrl = "https://www.instantpay.in/";
        public static string apiToken = "0606ee197acefb083170db3ca52bb398";
        public readonly ISQLHelper _sqlHelper;
        #endregion

        #region Constructor
        public dmtApiService(ISQLHelper iSqlHelper)
        {
            _sqlHelper = iSqlHelper;
        }
        #endregion

        #region Check Property IsAnyNullOrEmpty
        public async Task<bool> IsAnyNullOrEmpty(object myObject)
        {
            foreach (PropertyInfo pi in myObject.GetType().GetProperties())
            {
                if (pi.PropertyType == typeof(string))
                {
                    string value = (string)pi.GetValue(myObject);
                    if (string.IsNullOrEmpty(value))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        #endregion

        #region Call API
        public async Task<string> CallPostAPI(string method, string requestJson, bool isTrack, int apiId, string txnId = "")
        {
            var url = apiUrl + method;
            string response = string.Empty;
            try
            {

                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Accept", "application/json");
                request.AddParameter("application/json", requestJson, ParameterType.RequestBody);
                IRestResponse content = client.Execute(request);
                response = content.Content;
                if (isTrack)
                {
                    await ApiLog(txnId, url, requestJson, response, apiId);
                }
            }
            catch (Exception ex)
            {
                await ApiLog(txnId, url, requestJson, ex.Message.ToString(), apiId);
                response = "0";
            }
            return response;
        }
        #endregion

        #region Remitter Details
        public async Task<basicApi.apiResponse> RemitterDetail(dmtApi.RemitterDetails_Request model, int msrNo, string ipAddress = "")
        {

            if (await IsAnyNullOrEmpty(model))
            {
                return new basicApi.apiResponse
                {
                    statuscode = "RPI",
                    status = "Request Parameters are Invalid or Incomplete"
                };
            }
            var validUser = await Validate.ValidMember(msrNo, ipAddress);
            if (!validUser.Item1)
            {
                return new basicApi.apiResponse
                {
                    statuscode = validUser.Item3,
                    status = validUser.Item2
                };
            }
            var _apiRequest = new dmtApi.Root_ApiRequest
            {
                token = apiToken,
                request = model
            };
            var _request = JsonConvert.SerializeObject(_apiRequest);
            var response = await CallPostAPI("ws/dmi/remitter_details", _request, false, 1);
            if (response == "0" || response == "")
            {
                return new basicApi.apiResponse
                {
                    statuscode = "IPE",
                    status = "Internal Processing Error, Try Later"
                };
            }
            var result = JsonConvert.DeserializeObject<basicApi.apiResponse>(response);

            return result;
        }
        #endregion

        #region Remitter Registration
        public async Task<basicApi.apiResponse> RemitterRegistration(dmtApi.Request_RemitterRegistration model, int msrNo, string ipAddress = "")
        {
            basicApi.apiResponse result = new basicApi.apiResponse();
            if (await IsAnyNullOrEmpty(model))
            {
                return result = new basicApi.apiResponse
                {
                    statuscode = "RPI",
                    status = "Request Parameters are Invalid or Incomplete"
                };
            }
            var validUser = await Validate.ValidMember(msrNo, ipAddress);
            if (!validUser.Item1)
            {
                return new basicApi.apiResponse
                {
                    statuscode = validUser.Item3,
                    status = validUser.Item2
                };
            }
            var _apiRequest = new dmtApi.Root_ApiRequest
            {
                token = apiToken,
                request = model
            };
            var _request = JsonConvert.SerializeObject(_apiRequest);
            var response = await CallPostAPI("ws/dmi/remitter", _request, false, 1);
            if (response == "0" || response == "")
            {
                result.statuscode = "IPE";
                result.status = "Internal Processing Error, Try Later";
                return result;
            }
            result = JsonConvert.DeserializeObject<basicApi.apiResponse>(response);

            return result;
        }
        #endregion

        #region Remitter Validate
        public async Task<basicApi.apiResponse> RemitterValidate(dmtApi.Request_RemitterValidate model, int msrNo, string ipAddress = "")
        {
            basicApi.apiResponse result = new basicApi.apiResponse();
            if (await IsAnyNullOrEmpty(model))
            {
                return result = new basicApi.apiResponse
                {
                    statuscode = "RPI",
                    status = "Request Parameters are Invalid or Incomplete"
                };
            }
            var validUser = await Validate.ValidMember(msrNo, ipAddress);
            if (!validUser.Item1)
            {
                return new basicApi.apiResponse
                {
                    statuscode = validUser.Item3,
                    status = validUser.Item2
                };
            }
            var _apiRequest = new dmtApi.Root_ApiRequest
            {
                token = apiToken,
                request = model
            };
            var _request = JsonConvert.SerializeObject(_apiRequest);
            var response = await CallPostAPI("ws/dmi/remitter_validate", _request, false, 1);
            if (response == "0" || response == "")
            {
                result.statuscode = "IPE";
                result.status = "Internal Processing Error, Try Later";
                return result;
            }
            result = JsonConvert.DeserializeObject<basicApi.apiResponse>(response);

            return result;
        }
        #endregion

        #region Beneficiary Registration
        public async Task<basicApi.apiResponse> BeneficiaryRegistration(dmtApi.Request_BeneficiaryRegistration model, int msrNo, string ipAddress = "")
        {
            basicApi.apiResponse result = new basicApi.apiResponse();
            if (await IsAnyNullOrEmpty(model))
            {
                return result = new basicApi.apiResponse
                {
                    statuscode = "RPI",
                    status = "Request Parameters are Invalid or Incomplete"
                };
            }
            var validUser = await Validate.ValidMember(msrNo, ipAddress);
            if (!validUser.Item1)
            {
                return new basicApi.apiResponse
                {
                    statuscode = validUser.Item3,
                    status = validUser.Item2
                };
            }
            var _apiRequest = new dmtApi.Root_ApiRequest
            {
                token = apiToken,
                request = model
            };
            var _request = JsonConvert.SerializeObject(_apiRequest);
            var response = await CallPostAPI("ws/dmi/beneficiary_register", _request, false, 1);
            if (response == "0" || response == "")
            {
                result.statuscode = "IPE";
                result.status = "Internal Processing Error, Try Later";
                return result;
            }
            result = JsonConvert.DeserializeObject<basicApi.apiResponse>(response);

            return result;
        }
        #endregion

        #region Beneficiary Remove
        public async Task<basicApi.apiResponse> BeneficiaryRemove(dmtApi.Request_BeneficiaryRemove model, int msrNo, string ipAddress = "")
        {
            basicApi.apiResponse result = new basicApi.apiResponse();
            if (await IsAnyNullOrEmpty(model))
            {
                return result = new basicApi.apiResponse
                {
                    statuscode = "RPI",
                    status = "Request Parameters are Invalid or Incomplete"
                };
            }
            var validUser = await Validate.ValidMember(msrNo, ipAddress);
            if (!validUser.Item1)
            {
                return new basicApi.apiResponse
                {
                    statuscode = validUser.Item3,
                    status = validUser.Item2
                };
            }
            var _apiRequest = new dmtApi.Root_ApiRequest
            {
                token = apiToken,
                request = model
            };
            var _request = JsonConvert.SerializeObject(_apiRequest);
            var response = await CallPostAPI("ws/dmi/beneficiary_remove", _request, false, 1);
            if (response == "0" || response == "")
            {
                result.statuscode = "IPE";
                result.status = "Internal Processing Error, Try Later";
                return result;
            }
            result = JsonConvert.DeserializeObject<basicApi.apiResponse>(response);

            return result;
        }
        #endregion

        #region Beneficiary Remove Validate
        public async Task<basicApi.apiResponse> BeneficiaryRemove_Validate(dmtApi.Request_BeneficiaryRemove_Validate model, int msrNo, string ipAddress = "")
        {
            basicApi.apiResponse result = new basicApi.apiResponse();
            if (await IsAnyNullOrEmpty(model))
            {
                return result = new basicApi.apiResponse
                {
                    statuscode = "RPI",
                    status = "Request Parameters are Invalid or Incomplete"
                };
            }
            var validUser = await Validate.ValidMember(msrNo, ipAddress);
            if (!validUser.Item1)
            {
                return new basicApi.apiResponse
                {
                    statuscode = validUser.Item3,
                    status = validUser.Item2
                };
            }
            var _apiRequest = new dmtApi.Root_ApiRequest
            {
                token = apiToken,
                request = model
            };
            var _request = JsonConvert.SerializeObject(_apiRequest);
            var response = await CallPostAPI("ws/dmi/beneficiary_remove_validate", _request, false, 1);
            if (response == "0" || response == "")
            {
                result.statuscode = "IPE";
                result.status = "Internal Processing Error, Try Later";
                return result;
            }
            result = JsonConvert.DeserializeObject<basicApi.apiResponse>(response);

            return result;
        }
        #endregion

        #region Fund Transfer
        public async Task<basicApi.apiResponse> FundTransfer(dmtApi.Request_FundTransfer model, int msrNo, string ipAddress = "")
        {
            basicApi.apiResponse result = new basicApi.apiResponse();
            if (await IsAnyNullOrEmpty(model))
            {
                return result = new basicApi.apiResponse
                {
                    statuscode = "RPI",
                    status = "Request Parameters are Invalid or Incomplete"
                };
            }
            var validUser = await Validate.ValidMember(msrNo, ipAddress);
            if (!validUser.Item1)
            {
                return new basicApi.apiResponse
                {
                    statuscode = validUser.Item3,
                    status = validUser.Item2
                };
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "Insert"));
            parameters.Add(new SqlParameter("@BankId", model.bank_id));
            parameters.Add(new SqlParameter("@MsrNo", msrNo));
            parameters.Add(new SqlParameter("@Status", "Pending"));
            parameters.Add(new SqlParameter("@Account", model.account));
            parameters.Add(new SqlParameter("@Ifsc", model.ifsc));
            parameters.Add(new SqlParameter("@RemitterMobile", model.remittermobile));
            parameters.Add(new SqlParameter("@Type", 1));
            parameters.Add(new SqlParameter("@Source", "API"));
            parameters.Add(new SqlParameter("@Amount", model.amount));
            parameters.Add(new SqlParameter("@TxnType", model.mode));
            parameters.Add(new SqlParameter("@AgentId", model.agentid));
            parameters.Add(new SqlParameter("@BeneName", model.beneficiary_name));
            DataSet ds = new DataSet();
            ds = await _sqlHelper.ExecuteProcedure("SP_DMTProcess", parameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (!Convert.ToBoolean(ds.Tables[0].Rows[0]["Status"]))
                    {
                        return result = ds.Tables[0].AsEnumerable().Select(s => new basicApi.apiResponse
                        {
                            statuscode = Convert.ToString(s["StatusCode"]),
                            status = s.Field<string>("Message")
                        }).FirstOrDefault();
                    }
                    int activeApi = Convert.ToInt32(ds.Tables[0].Rows[0]["ActiveAPI"]);
                    var qr_id = Convert.ToString(ds.Tables[0].Rows[0]["TxnId"]);
                    int id = Convert.ToInt32(ds.Tables[0].Rows[0]["Id"]);
                    var agent_id = model.agentid;
                    model.agentid = qr_id;
                    var _apiRequest = new dmtApi.Root_ApiRequest
                    {
                        token = apiToken,
                        request = model
                    };
                    var _request = JsonConvert.SerializeObject(_apiRequest);
                    var response = await CallPostAPI("ws/dmi/transfer", _request, true, 1, qr_id);
                    if (response == "0" || response == "")
                    {
                        result.statuscode = "IPE";
                        result.status = "Internal Processing Error, Try Later";
                        return result;
                    }
                    dmtApi.Root_ResponseFundTransfer _apiResponse = JsonConvert.DeserializeObject<dmtApi.Root_ResponseFundTransfer>(response);
                    string status = _apiResponse.statuscode == "TXN" ? "Success" : _apiResponse.statuscode == "TUP" ? "Pending" : "Failed";
                    string statuscode = _apiResponse.statuscode;
                    parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@Action", "Update"));
                    parameters.Add(new SqlParameter("@Id", id));
                    parameters.Add(new SqlParameter("@Status", status));
                    parameters.Add(new SqlParameter("@StatusCode", statuscode));
                    if (_apiResponse.data != null)
                    {
                        parameters.Add(new SqlParameter("@ApiTxnId", _apiResponse.data.ipay_id));
                        parameters.Add(new SqlParameter("@BankUtr", _apiResponse.data.ref_no));
                        parameters.Add(new SqlParameter("@locked_amt", _apiResponse.data.locked_amt));
                        parameters.Add(new SqlParameter("@ccf_bank", _apiResponse.data.ccf_bank));
                        parameters.Add(new SqlParameter("@charged_amt", _apiResponse.data.charged_amt));
                        parameters.Add(new SqlParameter("@opening_bal", _apiResponse.data.opening_bal));
                    }
                    parameters.Add(new SqlParameter("@timestamp", _apiResponse.timestamp));
                    parameters.Add(new SqlParameter("@ipay_uuid", _apiResponse.ipay_uuid));
                    parameters.Add(new SqlParameter("@orderid", _apiResponse.orderid));
                    parameters.Add(new SqlParameter("@message", _apiResponse.status));
                    ds = new DataSet();
                    ds = await _sqlHelper.ExecuteProcedure("SP_DMTProcess", parameters.ToArray());
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            if (Convert.ToBoolean(ds.Tables[0].Rows[0]["Status"]))
                            {
                                var qr_response = Convert.ToString(ds.Tables[0].Rows[0]["Response"]);
                                result = JsonConvert.DeserializeObject<basicApi.apiResponse>(qr_response);
                                return result;
                            }
                            else
                            {
                                result = ds.Tables[0].AsEnumerable().Select(s => new basicApi.apiResponse
                                {
                                    statuscode = Convert.ToString(s["StatusCode"]),
                                    status = s.Field<string>("Message")
                                }).FirstOrDefault();

                                return result;
                            }
                        }
                    }
                    return result;
                }
            }

            return result = new basicApi.apiResponse
            {
                statuscode = "IPE",
                status = "Internal Processing Error, Try Later"
            };

        }
        #endregion

        #region Transaction Status

        public async Task<basicApi.apiResponse> TransactionStatus(dmtApi.TransactionStatus_Request model, int msrNo, string ipAddress = "")
        {
            basicApi.apiResponse result = new basicApi.apiResponse();
            if (await IsAnyNullOrEmpty(model))
            {
                return result = new basicApi.apiResponse
                {
                    statuscode = "RPI",
                    status = "Request Parameters are Invalid or Incomplete"
                };
            }
            var validUser = await Validate.ValidMember(msrNo, ipAddress);
            if (!validUser.Item1)
            {
                return new basicApi.apiResponse
                {
                    statuscode = validUser.Item3,
                    status = validUser.Item2
                };
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "TransactionStatus"));
            parameters.Add(new SqlParameter("@AgentId", model.agentid));
            DataSet ds = new DataSet();
            ds = await _sqlHelper.ExecuteProcedure("SP_DMTProcess", parameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToBoolean(ds.Tables[0].Rows[0]["Status"]))
                    {
                        var qr_response = Convert.ToString(ds.Tables[0].Rows[0]["Response"]);
                        result = JsonConvert.DeserializeObject<basicApi.apiResponse>(qr_response);
                        return result;
                    }
                    else
                    {
                        result = ds.Tables[0].AsEnumerable().Select(s => new basicApi.apiResponse
                        {
                            statuscode = Convert.ToString(s["StatusCode"]),
                            status = s.Field<string>("Message")
                        }).FirstOrDefault();

                        return result;
                    }
                }
            }
            return result = new basicApi.apiResponse
            {
                statuscode = "ITI",
                status = "Invalid Transaction ID"
            };
        }

        #endregion

        #region Api Log
        public async Task<string> ApiLog(string txnId, string url, string request, string response, int apiId)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Url", url));
            parameters.Add(new SqlParameter("@Request", request));
            parameters.Add(new SqlParameter("@Response", response));
            parameters.Add(new SqlParameter("@TxnId", txnId));
            parameters.Add(new SqlParameter("@apiId", apiId));
            await _sqlHelper.ExecuteProcedure("SP_dmtApiLogs", parameters.ToArray());
            return "";
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
