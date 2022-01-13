using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using QroApi.DLL;
using QroApi.MODEL;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace QroApi.BLL
{
    public class MemberService : IMemberService
    {
        #region [START : PROPERTIES]
        private readonly ISQLHelper _sqlHelper;
        private readonly IMember _iMember;
        private readonly IRecharge _iRecharge;
        private readonly ISettings _iSettings;
        private readonly IDMT _iDMT;
        #endregion

        #region Constructor
        public MemberService(ISQLHelper sqlHelper, IMember iMember, IRecharge iRecharge, IDMT iDMT, ISettings iSettings)
        {
            _sqlHelper = sqlHelper;
            _iMember = iMember;
            _iRecharge = iRecharge;
            _iDMT = iDMT;
            _iSettings = iSettings;
        }
        #endregion



        #region Get Service By Package Id
        public async Task<MemberServiceModel> GetServiceByPackageId(int msrNo)
        {
            MemberServiceModel model = new MemberServiceModel();
            int packageId = await _iMember.GetPackageId(msrNo);
            List<MemberServiceModel> listService = new List<MemberServiceModel>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "GetMemberService"));
            parameters.Add(new SqlParameter("@ID", msrNo));
            parameters.Add(new SqlParameter("@PackageId", packageId));


            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageService", parameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    listService = ds.Tables[0].AsEnumerable().Select(s => new MemberServiceModel
                    {
                        ServiceId = Convert.ToInt32(s["ServiceId"] == DBNull.Value ? 0 : s["ServiceId"]),
                        ServiceName = s["ServiceName"] == DBNull.Value ? "" : Convert.ToString(s["ServiceName"]),
                        ClassName = s["CssClass"] == DBNull.Value ? "" : Convert.ToString(s["CssClass"]),
                        ServiceIcon = s["Icon"] == DBNull.Value ? "" : Convert.ToString(s["Icon"]),
                        ServiceCode = s["ServiceCode"] == DBNull.Value ? "" : Convert.ToString(s["ServiceCode"])
                    }).ToList();
                }
            }
            model.list = listService;
            return model;

        }
        #endregion

        #region  Get Opertor By ServiceId
        public async Task<Result> GetOpertorByServiceId(int serviceId)
        {

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "GetByServiceId"));
            parameters.Add(new SqlParameter("@ServiceId", serviceId));

            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageOperator", parameters.ToArray());
            Result result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = true, Message = "Data Fatched" }).First();
            result.Results = ds.Tables[0].AsEnumerable().Select(s => new
            {
                Id = Convert.ToInt32(s["OperatorId"]),
                Name = s.Field<string>("OperatorName"),

            }).ToList();
            return result;

        }
        #endregion

        #region  Get Opertor Detail By Id
        public async Task<Result> GetOpertorDetailById(int id)
        {

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "GetDetail"));
            parameters.Add(new SqlParameter("@ID", id));

            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageOperator", parameters.ToArray());
            Result result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = true, Message = "Data Fatched" }).First();
            result.Results = ds.Tables[0].AsEnumerable().Select(s => new
            {

                DisplayName = s.Field<string>("DisplayName"),
                DisplayName2 = s.Field<string>("DisplayName2"),
                Regx = s.Field<string>("Regx"),
                FatchId = s.Field<string>("FatchId"),

            }).FirstOrDefault();
            return result;

        }
        #endregion

        #region Get Circle
        public async Task<Result> GetCircle()
        {

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "Get"));

            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageCircle", parameters.ToArray());
            Result result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = true, Message = "Data Fatched" }).First();
            result.Results = ds.Tables[0].AsEnumerable().Select(s => new
            {
                Id = Convert.ToInt32(s["CircleId"]),
                Name = s.Field<string>("CircleName"),

            }).ToList();
            return result;

        }
        #endregion

        #region Recharge Process
        public async Task<RechargeResult> RechargeProcess(RechargePorcessModel model, string source, int msrNo)
        {
            RechargeResult result = new RechargeResult();
            string pendingStatus = "Pending";
            string successStatus = "Success";
            string failedStatus = "Failed";

            if (msrNo > 0)
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@MsrNo", msrNo));
                parameters.Add(new SqlParameter("@Number", model.Number));
                parameters.Add(new SqlParameter("@CANumber", model.CANumber));
                parameters.Add(new SqlParameter("@OperatorId", model.OperatorId));
                parameters.Add(new SqlParameter("@CircleId", model.CircleId));
                parameters.Add(new SqlParameter("@ServiceId", model.ServiceId));
                parameters.Add(new SqlParameter("@Amount", model.Amount));
                parameters.Add(new SqlParameter("@Status", "Pending"));
                parameters.Add(new SqlParameter("@Source", source));
                DataSet ds = await _sqlHelper.ExecuteProcedure("SP_RechargeProcess", parameters.ToArray());
                if (ds.Tables.Count > 0)
                {
                    if (Convert.ToBoolean(ds.Tables[0].Rows[0]["Status"]))
                    {
                        string status = "Pending";
                        string txnId = "";
                        string apiTxnId = "";
                        string oprId = "";
                        string errorCode = "";
                        string errorMessage = "";
                        int rechargeId = Convert.ToInt32(ds.Tables[0].Rows[0]["RCTxnId"]);
                        if (model.ServiceId != 7)
                        {
                            int apiId  = Convert.ToInt32(ds.Tables[0].Rows[0]["ApiId"]);
                            string rechargeUrl = Convert.ToString(ds.Tables[0].Rows[0]["RechargeUrl"]);
                            pendingStatus = Convert.ToString(ds.Tables[0].Rows[0]["PendingStatus"]);
                            successStatus = Convert.ToString(ds.Tables[0].Rows[0]["SuccessStatus"]);
                            failedStatus = Convert.ToString(ds.Tables[0].Rows[0]["FailedStatus"]);
                            string rechargeResult = await _iRecharge.CallApi(rechargeUrl, apiId);
                            if (rechargeResult != "0")
                            {
                                if (Convert.ToString(ds.Tables[0].Rows[0]["ResponseType"]).ToLower() == "json")
                                {
                                    try
                                    {
                                        JObject _object = JObject.Parse(rechargeResult);
                                        if (_object["Data"] != null)
                                        {
                                            _object = JObject.Parse(Convert.ToString(_object["Data"]));
                                        }
                                        if (_object["data"] != null)
                                        {
                                            _object = JObject.Parse(Convert.ToString(_object["data"]));
                                        }
                                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["paramStatus"])))
                                        {
                                            status = _object[Convert.ToString(ds.Tables[0].Rows[0]["paramStatus"])] == null ? "Pending" : Convert.ToString(_object[Convert.ToString(ds.Tables[0].Rows[0]["paramStatus"])]).ToLower();
                                        }
                                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["paramTxnId"])))
                                        {
                                            txnId = _object[Convert.ToString(ds.Tables[0].Rows[0]["paramTxnId"])] == null ? "" : Convert.ToString(_object[Convert.ToString(ds.Tables[0].Rows[0]["paramTxnId"])]);
                                        }
                                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["paramApiTxnId"])))
                                        {
                                            apiTxnId = _object[Convert.ToString(ds.Tables[0].Rows[0]["paramApiTxnId"])] == null ? "" : Convert.ToString(_object[Convert.ToString(ds.Tables[0].Rows[0]["paramApiTxnId"])]);
                                        }
                                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["paramOprId"])))
                                        {
                                            oprId = _object[Convert.ToString(ds.Tables[0].Rows[0]["paramOprId"])] == null ? "" : Convert.ToString(_object[Convert.ToString(ds.Tables[0].Rows[0]["paramOprId"])]);
                                        }
                                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["paramErrCode"])))
                                        {
                                            errorCode = _object[Convert.ToString(ds.Tables[0].Rows[0]["paramErrCode"])] == null ? "" : Convert.ToString(_object[Convert.ToString(ds.Tables[0].Rows[0]["paramErrCode"])]);
                                        }
                                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["paramErrMsg"])))
                                        {
                                            errorMessage = _object[Convert.ToString(ds.Tables[0].Rows[0]["paramErrMsg"])] == null ? "" : Convert.ToString(_object[Convert.ToString(ds.Tables[0].Rows[0]["paramErrMsg"])]);
                                        }

                                        parameters = new List<SqlParameter>();
                                        parameters.Add(new SqlParameter("@RcId", rechargeId));

                                        if (status.ToLower() == successStatus.ToLower())
                                        {
                                            parameters.Add(new SqlParameter("@Status", "Success"));
                                            result = new RechargeResult
                                            {
                                                id = rechargeId,
                                                isSuccess = "Success",
                                                status = false,
                                                message = "Recharge Successfull on " + model.Number
                                            };
                                        }
                                        else if (status.ToLower() == failedStatus.ToLower())
                                        {
                                            parameters.Add(new SqlParameter("@Status", "Failed"));
                                            result = new RechargeResult
                                            {
                                                id = rechargeId,
                                                isSuccess = "Failed",
                                                status = false,
                                                message = "Recharge Failed on " + model.Number
                                            };
                                        }
                                        else
                                        {
                                            parameters.Add(new SqlParameter("@Status", "Pending"));
                                            result = new RechargeResult
                                            {
                                                id = rechargeId,
                                                isSuccess = "Success",
                                                status = true,
                                                message = "Recharge Request Accepted on " + model.Number
                                            };
                                        }
                                        parameters.Add(new SqlParameter("@TxnId", txnId));
                                        parameters.Add(new SqlParameter("@ApiTxnId", apiTxnId));
                                        parameters.Add(new SqlParameter("@OprId", oprId));
                                        parameters.Add(new SqlParameter("@ErrMsg", errorMessage));
                                        await _sqlHelper.ExecuteProcedure("SP_UpdateRecharge", parameters.ToArray());
                                    }
                                    catch (Exception ex)
                                    {
                                        parameters = new List<SqlParameter>();
                                        parameters.Add(new SqlParameter("@RcId", rechargeId));
                                        parameters.Add(new SqlParameter("@Status", "Failed"));
                                        parameters.Add(new SqlParameter("@TxnId", txnId));
                                        parameters.Add(new SqlParameter("@ApiTxnId", apiTxnId));
                                        parameters.Add(new SqlParameter("@OprId", oprId));
                                        parameters.Add(new SqlParameter("@ErrMsg", errorMessage));
                                        await _sqlHelper.ExecuteProcedure("SP_UpdateRecharge", parameters.ToArray());
                                        result = new RechargeResult
                                        {
                                            id = rechargeId,
                                            isSuccess = "Failed",
                                            status = false,
                                            message = "Recharge Failed on " + model.Number
                                        };
                                    }
                                }
                                else
                                {
                                    result = new RechargeResult
                                    {
                                        id = rechargeId,
                                        isSuccess = "Pending",
                                        status = true,
                                        message = "Recharge Pending on " + model.Number
                                    };
                                }
                            }
                            else
                            {
                                parameters = new List<SqlParameter>();
                                parameters.Add(new SqlParameter("@RcId", rechargeId));
                                parameters.Add(new SqlParameter("@Status", "Failed"));
                                parameters.Add(new SqlParameter("@TxnId", txnId));
                                parameters.Add(new SqlParameter("@ApiTxnId", apiTxnId));
                                parameters.Add(new SqlParameter("@OprId", oprId));
                                parameters.Add(new SqlParameter("@ErrMsg", errorMessage));
                                await _sqlHelper.ExecuteProcedure("SP_UpdateRecharge", parameters.ToArray());
                                result = new RechargeResult
                                {
                                    id = rechargeId,
                                    isSuccess = "Failed",
                                    status = false,
                                    message = "Recharge Failed on " + model.Number
                                };
                            }
                        }
                        else
                        {
                            result = new RechargeResult
                            {
                                id = rechargeId,
                                isSuccess = "Pending",
                                status = true,
                                message = "Billing Request Accepted on " + model.Number
                            };
                        }
                    }
                    else
                    {
                        result = new RechargeResult
                        {
                            id = 0,
                            isSuccess = "Failed",
                            status = false,
                            message = Convert.ToString(ds.Tables[0].Rows[0]["Message"])
                        };
                    }
                }
                else
                {
                    result = new RechargeResult
                    {
                        id = 0,
                        isSuccess = "Failed",
                        status = false,
                        message = "Something Went Wrong"
                    };
                }
            }
            else
            {
                result = new RechargeResult
                {
                    id = 0,
                    isSuccess = "Failed",
                    status = false,
                    message = "Something Went Wrong"
                };
            }
            return result;
        }
        #endregion

        #region Manage Recharge Callback
        public async Task<string> ManageRechargeCallback(string queryString)
        {

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "GetCallbackParam"));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_RechargeManageAPI", parameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                DataTable dtApi = ds.Tables[0];
                for (int i = 0; i < dtApi.Rows.Count; i++)
                {
                    if (dtApi.Rows[i]["CallbackStatus"].ToString() != "")
                    {
                        if (queryString.Contains(dtApi.Rows[i]["CallbackStatus"].ToString()))
                        {
                            queryString = queryString.Replace(dtApi.Rows[i]["CallbackStatus"].ToString(), "status");
                        }
                    }
                    if (dtApi.Rows[i]["CallbackOperatorId"].ToString() != "")
                    {
                        if (queryString.Contains(dtApi.Rows[i]["CallbackOperatorId"].ToString()))
                        {
                            queryString = queryString.Replace(dtApi.Rows[i]["CallbackOperatorId"].ToString(), "oprId");
                        }
                    }
                    if (dtApi.Rows[i]["CallbackApiId"].ToString() != "")
                    {
                        if (queryString.Contains(dtApi.Rows[i]["CallbackApiId"].ToString()))
                        {
                            queryString = queryString.Replace(dtApi.Rows[i]["CallbackApiId"].ToString(), "txnId");
                        }
                    }
                    if (dtApi.Rows[i]["CallbackTxnId"].ToString() != "")
                    {
                        if (queryString.Contains(dtApi.Rows[i]["CallbackTxnId"].ToString()))
                        {
                            queryString = queryString.Replace(dtApi.Rows[i]["CallbackTxnId"].ToString(), "agentId");
                        }
                    }
                }
            }
            return queryString;
        }
        #endregion

        #region Update Recharge Transaction By Callback
        public async Task<bool> UpdateRechargeTransactionByCallback(string status, string oprId, string txnId, string agentId,string callbackUrl)
        {
            bool iSaved = true;

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "GetByTxnId"));
            parameters.Add(new SqlParameter("@TxnId", agentId));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_RechargeReport", parameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    string ourStatus = "Pending";
                    string pendingStatus = Convert.ToString(ds.Tables[0].Rows[0]["cPendingStatus"]);
                    string successStatus = Convert.ToString(ds.Tables[0].Rows[0]["cSuccessStatus"]);
                    string failedStatus = Convert.ToString(ds.Tables[0].Rows[0]["cFailedStatus"]);
                    if (pendingStatus.ToLower() == status.ToLower())
                    {
                        ourStatus = "Pending";
                    }
                    if (successStatus.ToLower() == status.ToLower())
                    {
                        ourStatus = "Success";
                    }
                    if (failedStatus.ToLower() == status.ToLower())
                    {
                        ourStatus = "Failed";
                    }
                    parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@RcId", Convert.ToInt32(dt.Rows[0]["Id"])));
                    parameters.Add(new SqlParameter("@Status", ourStatus));
                    parameters.Add(new SqlParameter("@TxnId", agentId));
                    parameters.Add(new SqlParameter("@ApiTxnId", txnId));
                    parameters.Add(new SqlParameter("@OprId", oprId));
                    parameters.Add(new SqlParameter("@Callback", callbackUrl));
                    await _sqlHelper.ExecuteProcedure("SP_UpdateRecharge", parameters.ToArray());
                }
            }
            return iSaved;
        }
        #endregion

        #region Recharge Reciept
        public async Task<RechargeReciept> RechargeReciept(int id, int msrNo)
        {
            RechargeReciept model = new RechargeReciept();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "GetRechargeReciept"));
            parameters.Add(new SqlParameter("@Id", id));
            parameters.Add(new SqlParameter("@MsrNo", msrNo));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_RechargeReport", parameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                model = ds.Tables[0].AsEnumerable().Select(s => new RechargeReciept
                {
                    ServiceId = s["ServiceId"] == DBNull.Value ? 0 : Convert.ToInt32(s["ServiceId"]),
                    RecieptNo = s["RecieptNo"] == DBNull.Value ? "" : Convert.ToString(s["RecieptNo"]),
                    Number = s["Number"] == DBNull.Value ? "" : Convert.ToString(s["Number"]),
                    Amount = s["Amount"] == DBNull.Value ? "" : Convert.ToString(s["Amount"]),
                    Status = s["Status"] == DBNull.Value ? "" : Convert.ToString(s["Status"]),
                    TxnId = s["TxnId"] == DBNull.Value ? "" : Convert.ToString(s["TxnId"]),
                    OprId = s["OprId"] == DBNull.Value ? "" : Convert.ToString(s["OprId"]),
                    OperatorName = s["OperatorName"] == DBNull.Value ? "" : Convert.ToString(s["OperatorName"]),
                    MemberId = s["MemberId"] == DBNull.Value ? "" : Convert.ToString(s["MemberId"]),
                    Name = s["Name"] == DBNull.Value ? "" : Convert.ToString(s["Name"]),
                    Mobile = s["Mobile"] == DBNull.Value ? "" : Convert.ToString(s["Mobile"]),
                    Email = s["Email"] == DBNull.Value ? "" : Convert.ToString(s["Email"]),
                }).FirstOrDefault();
            }
            model.company = await _iSettings.GetCompanyDetailById(1);
            return model;
        }
        #endregion

        #region Bill Fatch
        public async Task<string> BillFatch(BBPS.BillFatch model)
        {
            BBPS.Response result = new BBPS.Response();
            var _request = JsonConvert.SerializeObject(model);
            var response = await _iDMT.CallPostAPI("bill-payment/bill/fetchbill", _request);
            if (response == "0" || response == "")
            {
                result.response_code = 406;
                result.status = false;
                result.message = "Something Went Wrong !";
                return JsonConvert.SerializeObject(result);
            }
            // result = JsonConvert.DeserializeObject<dmtModels.Response>(response);
            return response;
        }
        #endregion

        #region Bill Pay
        public async Task<BBPS.Response> BillPay(BBPS.BillPayRequest model, string source, int msrNo)
        {
            BBPS.Response result = new BBPS.Response();
            if (msrNo > 0)
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@Action", "CheckElectricity"));                
                int isDueOn = await _sqlHelper.ExecuteScalerInt("SP_ManageService", parameters.ToArray());
                if (isDueOn == 1)
                {
                    var todayDate = DateTime.Now.ToString("yyyy-MM-dd");
                    var dueDate = Convert.ToDateTime(model.bill_fetch.dueDate).ToString("yyyy-MM-dd");
                    if (todayDate == dueDate)
                    {
                        if (DateTime.Now.ToShortTimeString() == "6:00 PM")
                        {
                            return result = new BBPS.Response
                            {
                                id = 0,
                                status = false,
                                response_code = 0,
                                message = "Failed. Billing period has expired"
                            };
                        }
                    }
                }
                parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@MsrNo", msrNo));
                parameters.Add(new SqlParameter("@Number", model.canumber));
                parameters.Add(new SqlParameter("@CANumber", model.canumber));
                parameters.Add(new SqlParameter("@OperatorId", model.operatorId));
                parameters.Add(new SqlParameter("@CircleId", 19));
                parameters.Add(new SqlParameter("@ServiceId", model.serviceId));
                parameters.Add(new SqlParameter("@Amount", model.amount));
                parameters.Add(new SqlParameter("@Status", "Pending"));
                parameters.Add(new SqlParameter("@Source", source));
                parameters.Add(new SqlParameter("@CustomerMobile", model.mobile));
                DataSet ds = await _sqlHelper.ExecuteProcedure("SP_RechargeProcess", parameters.ToArray());
                if (ds.Tables.Count > 0)
                {
                    if (Convert.ToBoolean(ds.Tables[0].Rows[0]["Status"]))
                    {
                        int rechargeId = Convert.ToInt32(ds.Tables[0].Rows[0]["RCTxnId"]);
                        return result = new BBPS.Response
                        {
                            id = rechargeId,
                            status = true,
                            response_code = 1,
                            message = "Bill Payment Successfull"
                        };

                        string status = "Pending";                      
                        string apiTxnId = "";
                        string oprId = "";                       
                        string errorMessage = "";
                       
                        string txnId = Convert.ToString(ds.Tables[0].Rows[0]["TxnId"]);
                        string billerId = Convert.ToString(ds.Tables[0].Rows[0]["BillerId"]);
                        model.referenceid = txnId;
                        model._operator = billerId;
                        var _request = JsonConvert.SerializeObject(model);
                        var apiResult = await _iDMT.CallPostAPI("bill-payment/bill/paybill", _request);
                        if (apiResult == "0" || apiResult == "")
                        {
                            result = new BBPS.Response
                            {
                                id = 0,
                                status = false,
                                message = "Something Went Wrong !",
                                response_code = 406
                            };
                        }
                        else
                        {
                            result = JsonConvert.DeserializeObject<BBPS.Response>(apiResult);
                            if (result.status == true && result.response_code == 1)
                            {
                                 apiTxnId = result.ackno.ToString();
                                 oprId = result.operatorid;
                                status = "Success";
                            }
                            else if (result.status == true && result.response_code == 0)
                            {
                                apiTxnId = result.ackno.ToString();
                                oprId = result.operatorid;
                                status = "Success";
                            }
                            else
                            {
                                apiTxnId = Convert.ToString(result.ackno);
                                oprId = result.operatorid;
                                status = "Failed";
                            }
                        }
                        parameters = new List<SqlParameter>();
                        parameters.Add(new SqlParameter("@RcId", rechargeId));
                        parameters.Add(new SqlParameter("@Status",status));
                        parameters.Add(new SqlParameter("@TxnId", txnId));                        
                        parameters.Add(new SqlParameter("@ApiTxnId", apiTxnId));
                        parameters.Add(new SqlParameter("@OprId", oprId));
                        parameters.Add(new SqlParameter("@ErrMsg", errorMessage));
                        await _sqlHelper.ExecuteProcedure("SP_UpdateRecharge", parameters.ToArray());
                    }
                    else
                    {
                        result = new BBPS.Response
                        {
                            id = 0,
                            status = false,
                            response_code = 0,
                            message = Convert.ToString(ds.Tables[0].Rows[0]["Message"])

                        };
                    }
                }
                else
                {
                    result = new BBPS.Response
                    {
                        id = 0,
                        status = false,
                        response_code = 0,
                        message = "Something Went Wrong"
                    };
                }
            }
            else
            {
                result = new BBPS.Response
                {
                    id = 0,
                    status = false,
                    response_code = 0,
                    message = "Something Went Wrong"
                };
            }
           
            return result;
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
