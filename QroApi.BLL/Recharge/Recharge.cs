using QroApi.DLL;
using QroApi.MODEL;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace QroApi.BLL
{
    public class Recharge : IRecharge
    {
        #region [START : PROPERTIES]
        private readonly ISQLHelper _sqlHelper;
        private readonly IDMT _iDMT;
        #endregion

        #region[CONSTRUCTER]
        public Recharge(ISQLHelper sqlHelper, IDMT iDMT)
        {
            _sqlHelper = sqlHelper;
            _iDMT = iDMT;
        }
        #endregion

        #region API

        #region Add Edit Recharge Api
        public async Task<Result> AddEditRechargeAPI(RechargeApiModel model)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@APIID", model.APIID));
            parameters.Add(new SqlParameter("@APIName", model.APIName));
            parameters.Add(new SqlParameter("@URL", model.URL));
            parameters.Add(new SqlParameter("@BalanceURL", model.BalanceURL));
            parameters.Add(new SqlParameter("@StatusURL", model.StatusURL));
            parameters.Add(new SqlParameter("@ResponseType", model.ResponseType));
            parameters.Add(new SqlParameter("@CallbackStatus", model.CallbackStatus));
            parameters.Add(new SqlParameter("@CallbackOperatorId", model.CallbackOperatorId));
            parameters.Add(new SqlParameter("@CallbackApiId", model.CallbackApiId));
            parameters.Add(new SqlParameter("@CallbackTxnId", model.CallbackTxnId));
            parameters.Add(new SqlParameter("@CallbackErrorCode", model.CallbackErrorCode));
            parameters.Add(new SqlParameter("@CallbackBalance", model.CallbackBalance));
            parameters.Add(new SqlParameter("@paramStatus", model.paramStatus));
            parameters.Add(new SqlParameter("@paramTxnId", model.paramTxnId));
            parameters.Add(new SqlParameter("@paramApiTxnId", model.paramApiTxnId));
            parameters.Add(new SqlParameter("@paramOprId", model.paramOprId));
            parameters.Add(new SqlParameter("@paramErrCode", model.paramErrCode));
            parameters.Add(new SqlParameter("@paramErrMsg", model.paramErrMsg));
            parameters.Add(new SqlParameter("@sprmStatus", model.sprmStatus));
            parameters.Add(new SqlParameter("@sprmTxnId", model.sprmTxnId));
            parameters.Add(new SqlParameter("@sprmApiTxnId", model.sprmApiTxnId));
            parameters.Add(new SqlParameter("@sprmOprId", model.sprmOprId));
            parameters.Add(new SqlParameter("@bparm", model.@bparm));
            parameters.Add(new SqlParameter("@FailedStatus", model.FailedStatus));
            parameters.Add(new SqlParameter("@SuccessStatus", model.SuccessStatus));
            parameters.Add(new SqlParameter("@PendingStatus", model.PendingStatus));
            parameters.Add(new SqlParameter("@sFailedStatus", model.sFailedStatus));
            parameters.Add(new SqlParameter("@sSuccessStatus", model.sSuccessStatus));
            parameters.Add(new SqlParameter("@sPendingStatus", model.sPendingStatus));
            parameters.Add(new SqlParameter("@cFailedStatus", model.cFailedStatus));
            parameters.Add(new SqlParameter("@cSuccessStatus", model.cSuccessStatus));
            parameters.Add(new SqlParameter("@cPendingStatus", model.cPendingStatus));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_AddEditRechargeAPI", parameters.ToArray());
            Result result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = Convert.ToBoolean(s["Status"]), Message = s.Field<string>("Message") }).First();
            return result;
        }
        #endregion

        #region Get API By Id
        public async Task<RechargeApiModel> GetAPIById(int id)
        {
            RechargeApiModel model = new RechargeApiModel();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "Get"));
            parameters.Add(new SqlParameter("@Id", id));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_RechargeManageAPI", parameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    model = ds.Tables[0].AsEnumerable().Select(s => new RechargeApiModel
                    {
                        APIID = Convert.ToInt32(s["APIID"] == null ? 0 : s["APIID"]),
                        APIName = Convert.ToString(s["APIName"] == null ? "" : s["APIName"]),
                        URL = Convert.ToString(s["URL"] == null ? "" : s["URL"]),
                        BalanceURL = Convert.ToString(s["BalanceURL"] == null ? "" : s["BalanceURL"]),
                        StatusURL = Convert.ToString(s["StatusURL"] == null ? 0 : s["StatusURL"]),
                        ResponseType = Convert.ToString(s["ResponseType"] == null ? 0 : s["ResponseType"]),
                        CallbackApiId = Convert.ToString(s["CallbackApiId"] == null ? 0 : s["CallbackApiId"]),
                        CallbackTxnId = Convert.ToString(s["CallbackTxnId"] == null ? "" : s["CallbackTxnId"]),
                        CallbackBalance = Convert.ToString(s["CallbackBalance"] == null ? 0 : s["CallbackBalance"]),
                        CallbackOperatorId = Convert.ToString(s["CallbackOperatorId"] == null ? "" : s["CallbackOperatorId"]),
                        CallbackErrorCode = Convert.ToString(s["CallbackErrorCode"] == null ? "" : s["CallbackErrorCode"]),
                        CallbackStatus = Convert.ToString(s["CallbackStatus"] == null ? "" : s["CallbackStatus"]),
                        paramApiTxnId = Convert.ToString(s["paramApiTxnId"] == null ? 0 : s["paramApiTxnId"]),
                        paramTxnId = Convert.ToString(s["paramTxnId"] == null ? 0 : s["paramTxnId"]),
                        paramStatus = Convert.ToString(s["paramStatus"] == null ? 0 : s["paramStatus"]),
                        paramOprId = Convert.ToString(s["paramOprId"] == null ? "" : s["paramOprId"]),
                        paramErrCode = Convert.ToString(s["paramErrCode"] == null ? 0 : s["paramErrCode"]),
                        paramErrMsg = Convert.ToString(s["paramErrMsg"] == null ? "" : s["paramErrMsg"]),

                        cFailedStatus = Convert.ToString(s["cFailedStatus"] == null ? "" : s["cFailedStatus"]),
                        cSuccessStatus = Convert.ToString(s["cSuccessStatus"] == null ? "" : s["cSuccessStatus"]),
                        cPendingStatus = Convert.ToString(s["cPendingStatus"] == null ? "" : s["cPendingStatus"]),
                        sFailedStatus = Convert.ToString(s["sFailedStatus"] == null ? "" : s["sFailedStatus"]),
                        sSuccessStatus = Convert.ToString(s["sSuccessStatus"] == null ? "" : s["sSuccessStatus"]),
                        sPendingStatus = Convert.ToString(s["sPendingStatus"] == null ? "" : s["sPendingStatus"]),
                        FailedStatus = Convert.ToString(s["FailedStatus"] == null ? "" : s["FailedStatus"]),
                        SuccessStatus = Convert.ToString(s["SuccessStatus"] == null ? "" : s["SuccessStatus"]),
                        PendingStatus = Convert.ToString(s["PendingStatus"] == null ? "" : s["PendingStatus"]),
                        sprmApiTxnId = Convert.ToString(s["sprmApiTxnId"] == null ? 0 : s["sprmApiTxnId"]),
                        sprmTxnId = Convert.ToString(s["sprmTxnId"] == null ? 0 : s["sprmTxnId"]),
                        sprmStatus = Convert.ToString(s["sprmStatus"] == null ? 0 : s["sprmStatus"]),
                        sprmOprId = Convert.ToString(s["sprmOprId"] == null ? "" : s["sprmOprId"]),
                        bparm = Convert.ToString(s["bparm"] == null ? "" : s["bparm"]),


                    }).FirstOrDefault();
                }
            }
            return model;
        }
        #endregion

        #region List Recharge 
        public async Task<ReportList> GetAllAPIList(string search, int pageIndex, int pageSize, string sortCol, string sortDir)
        {
            ReportList rpList = new ReportList();
            List<RechargeAPIList> apiList = new List<RechargeAPIList>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "GetAll"));
            parameters.Add(new SqlParameter("@PageIndex", pageIndex));
            parameters.Add(new SqlParameter("@PageSize", pageSize));
            parameters.Add(new SqlParameter("@Search", search));
            parameters.Add(new SqlParameter("@OrderColumn", sortCol));
            parameters.Add(new SqlParameter("@OrderDir", sortDir));
            int totalRecord = 0;
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_RechargeManageAPI", parameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    totalRecord = Convert.ToInt32(ds.Tables[0].Rows[0]["TotalRow"].ToString());
                    apiList = ds.Tables[0].AsEnumerable().Select(s => new RechargeAPIList
                    {
                        SrNo = Convert.ToInt32(s["SrNo"] == null ? 0 : s["SrNo"]),
                        ApiName = Convert.ToString(s["APIName"] == null ? "" : s["APIName"]),
                        Url = Convert.ToString(s["URL"] == null ? "" : s["URL"]),
                        Action = Convert.ToString(s["Action"] == null ? "" : s["Action"])

                    }).ToList();
                }
            }
            rpList.recordsFiltered = totalRecord;
            rpList.recordsTotal = totalRecord;
            rpList.data = apiList;
            return rpList;
        }
        #endregion

        #region Delete API
        public async Task<Result> DeleteAPI(int id)
        {
            Result result = new Result();
            List<MenuResponse> menuList = new List<MenuResponse>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "Delete"));
            parameters.Add(new SqlParameter("@Id", id));

            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_RechargeManageAPI", parameters.ToArray());
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

        #region Active/Deactive API
        public async Task<Result> ActiveAPI(int id)
        {
            Result result = new Result();
            List<MenuResponse> menuList = new List<MenuResponse>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "IsActive"));
            parameters.Add(new SqlParameter("@Id", id));

            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_RechargeManageAPI", parameters.ToArray());
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

        #region Get API
        public async Task<Result> GetAPI()
        {
            Result result = new Result();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "Get"));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_RechargeManageAPI", parameters.ToArray());
            if (ds.Tables[0].Rows.Count > 0)
            {
                result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = true, Message = "Data Fatched" }).First();
                result.Results = ds.Tables[0].AsEnumerable().Select(s => new
                {
                    Id = Convert.ToInt32(s["APIID"]),
                    Name = s.Field<string>("APIName"),

                }).ToList();
            }
            return result;
        }
        #endregion
        #endregion

        #region Service

        #region Get Service
        public async Task<Result> GetService()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "Get"));

            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageService", parameters.ToArray());
            Result result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = true, Message = "Data Fatched" }).First();
            result.Results = ds.Tables[0].AsEnumerable().Select(s => new
            {
                Id = Convert.ToInt32(s["ServiceId"]),
                Name = s.Field<string>("ServiceName"),

            }).ToList();
            return result;
        }
        #endregion

        #region Get Service
        public async Task<Result> GetServiceForFilter()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "GetForFilter"));

            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageService", parameters.ToArray());
            Result result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = true, Message = "Data Fatched" }).First();
            result.Results = ds.Tables[0].AsEnumerable().Select(s => new
            {
                Id = Convert.ToInt32(s["ServiceId"]),
                Name = s.Field<string>("ServiceName"),

            }).ToList();
            return result;
        }
        #endregion

        #region Get Recharge Service By PackageId
        public async Task<Result> GetRechargeServiceByPackageId(int packageId)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "GetForCommission"));
            parameters.Add(new SqlParameter("@PackageId", packageId));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageService", parameters.ToArray());
            Result result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = true, Message = "Data Fatched" }).First();
            result.Results = ds.Tables[0].AsEnumerable().Select(s => new
            {
                Id = Convert.ToInt32(s["ServiceId"]),
                Name = s.Field<string>("ServiceName"),

            }).ToList();
            return result;
        }
        #endregion

        #region Get Service By Id
        public async Task<ServiceModel> GetServiceById(int id)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "Get"));
            parameters.Add(new SqlParameter("@ID", id));
            ServiceModel model = new ServiceModel();
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageService", parameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    model = ds.Tables[0].AsEnumerable().Select(s => new ServiceModel
                    {
                        ServiceId = Convert.ToInt32(s["ServiceId"] == null ? 0 : s["ServiceId"]),
                        ServiceName = Convert.ToString(s["ServiceName"] == null ? "" : s["ServiceName"])
                    }).FirstOrDefault();
                }
            }
            return model;
        }
        #endregion

        #region Add Edit Service
        public async Task<Result> AddEditService(ServiceModel model)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "Insert"));
            parameters.Add(new SqlParameter("@ID", model.ServiceId));
            parameters.Add(new SqlParameter("@ServiceName", model.ServiceName));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageService", parameters.ToArray());
            Result result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = Convert.ToBoolean(s["Status"]), Message = s.Field<string>("Message") }).First();
            return result;
        }
        #endregion

        #region Get All Service
        public async Task<ReportList> GetAllService(string search, int pageIndex, int pageSize, string sortCol, string sortDir)
        {
            ReportList rpList = new ReportList();
            List<ServiceList> serviceList = new List<ServiceList>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "GetAll"));
            parameters.Add(new SqlParameter("@PageIndex", pageIndex));
            parameters.Add(new SqlParameter("@PageSize", pageSize));
            parameters.Add(new SqlParameter("@Search", search));
            int totalRecord = 0;
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageService", parameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataView dv = new DataView(ds.Tables[0]);
                    dv.Sort = sortCol + " " + sortDir;
                    totalRecord = Convert.ToInt32(ds.Tables[0].Rows[0]["TotalRow"].ToString());
                    serviceList = ds.Tables[0].AsEnumerable().Select(s => new ServiceList
                    {
                        SrNo = Convert.ToInt32(s["SrNo"] == null ? 0 : s["SrNo"]),
                        ServiceName = Convert.ToString(s["ServiceName"] == null ? "" : s["ServiceName"]),
                        Action = Convert.ToString(s["Action"] == null ? "" : s["Action"])
                    }).ToList();
                }
            }
            rpList.recordsFiltered = totalRecord;
            rpList.recordsTotal = totalRecord;
            rpList.data = serviceList;
            return rpList;
        }
        #endregion

        #region Delete Service
        public async Task<Result> DeleteService(int id)
        {
            Result result = new Result();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "Delete"));
            parameters.Add(new SqlParameter("@ID", id));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageService", parameters.ToArray());
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

        #region Active / Deactive Service
        public async Task<Result> ActiveService(int id)
        {
            Result result = new Result();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "IsActive"));
            parameters.Add(new SqlParameter("@ID", id));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageService", parameters.ToArray());
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

        
        #endregion

        #region Operator

        #region Get Operator By Id
        public async Task<Operator> GetOperatorById(int id)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "GetById"));
            parameters.Add(new SqlParameter("@ID", id));
            Operator model = new Operator();
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageOperator", parameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    model = ds.Tables[0].AsEnumerable().Select(s => new Operator
                    {
                        OperatorId = Convert.ToInt32(s["OperatorId"] == null ? 0 : s["OperatorId"]),
                        ServiceId = Convert.ToInt32(s["ServiceId"] == null ? "" : s["ServiceId"]),
                        OperatorName = Convert.ToString(s["OperatorName"] == null ? "" : s["OperatorName"]),
                        OperatorCode = Convert.ToString(s["OperatorCode"] == null ? "" : s["OperatorCode"]),
                        OperatorImage = Convert.ToString(s["OperatorImage"] == null ? "" : s["OperatorImage"]),
                    }).FirstOrDefault();
                }
            }
            return model;
        }
        #endregion

        #region Add Edit Operator
        public async Task<Result> AddEditOperator(Operator model)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "Insert"));
            parameters.Add(new SqlParameter("@ID", model.OperatorId));
            parameters.Add(new SqlParameter("@ServiceId", model.ServiceId));
            parameters.Add(new SqlParameter("@OperatorName", model.OperatorName));
            parameters.Add(new SqlParameter("@OperatorCode", model.OperatorCode));
            parameters.Add(new SqlParameter("@OperatorImage", model.OperatorImage));

            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageOperator", parameters.ToArray());
            Result result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = Convert.ToBoolean(s["Status"]), Message = s.Field<string>("Message") }).First();
            return result;
        }
        #endregion

        #region Get All Operator
        public async Task<ReportList> GetAllOperator(string search, int pageIndex, int pageSize, string sortCol, string sortDir)
        {
            ReportList rpList = new ReportList();
            List<OperatorList> operatorList = new List<OperatorList>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "GetAll"));
            parameters.Add(new SqlParameter("@PageIndex", pageIndex));
            parameters.Add(new SqlParameter("@PageSize", pageSize));
            parameters.Add(new SqlParameter("@Search", search));
            parameters.Add(new SqlParameter("@OrderColumn", sortCol));
            parameters.Add(new SqlParameter("@OrderDir", sortDir));
            int totalRecord = 0;
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageOperator", parameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    totalRecord = Convert.ToInt32(ds.Tables[0].Rows[0]["TotalRow"].ToString());
                    operatorList = ds.Tables[0].AsEnumerable().Select(s => new OperatorList
                    {
                        SrNo = Convert.ToInt32(s["SrNo"] == null ? 0 : s["SrNo"]),
                        ServiceName = Convert.ToString(s["ServiceName"] == null ? "" : s["ServiceName"]),
                        OperatorName = Convert.ToString(s["OperatorName"] == null ? "" : s["OperatorName"]),
                        OperatorCode = Convert.ToString(s["OperatorCode"] == null ? "" : s["OperatorCode"]),
                        Action = Convert.ToString(s["Action"] == null ? "" : s["Action"])
                    }).ToList();
                }
            }
            rpList.recordsFiltered = totalRecord;
            rpList.recordsTotal = totalRecord;
            rpList.data = operatorList;
            return rpList;
        }
        #endregion

        #region Delete Operator
        public async Task<Result> DeleteOperator(int id)
        {
            Result result = new Result();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "Delete"));
            parameters.Add(new SqlParameter("@ID", id));

            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageOperator", parameters.ToArray());
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

        #region Active / Deactive Operator
        public async Task<Result> ActiveOperator(int id)
        {
            Result result = new Result();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "IsActive"));
            parameters.Add(new SqlParameter("@ID", id));

            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageOperator", parameters.ToArray());
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

        #region Get Operator By Service Id
        public async Task<OperatorWiseApi> GetOperatorByServiceId(int serviceId)
        {
            OperatorWiseApi model = new OperatorWiseApi();
            List<OperatorWiseApi> operatorList = new List<OperatorWiseApi>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "GetByServiceId"));
            parameters.Add(new SqlParameter("@ServiceId", serviceId));

            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageOperator", parameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    operatorList = ds.Tables[0].AsEnumerable().Select(s => new OperatorWiseApi
                    {
                        OperatorName = Convert.ToString(s["OperatorName"] == null ? "" : s["OperatorName"]),
                        OperatorId = Convert.ToInt32(s["OperatorId"] == null ? "" : s["OperatorId"]),

                    }).ToList();
                }
            }
            model.list = operatorList;
            return model;
        }
        #endregion

        #region GetOperatorByServiceIdForFilter
        public async Task<Result> GetOperatorByServiceIdForFilter(int serviceId)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "GetByServiceId"));
            parameters.Add(new SqlParameter("@ServiceId", serviceId));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageOperator", parameters.ToArray());
            Result result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = true, Message = "Data Fatched" }).First();
            result.Results = ds.Tables[0].AsEnumerable().Select(s => new
            {
                Id = Convert.ToInt32(s["OperatorId"]),
                Name = s.Field<string>("OperatorName")
            }).ToList();
            return result;
        }
        #endregion
        #endregion

        #region Circle

        #region Get Circle By Id
        public async Task<CircleModel> GetCircleById(int id)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "Get"));
            parameters.Add(new SqlParameter("@ID", id));
            CircleModel model = new CircleModel();
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageCircle", parameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    model = ds.Tables[0].AsEnumerable().Select(s => new CircleModel
                    {
                        CircleId = Convert.ToInt32(s["CircleId"] == null ? 0 : s["CircleId"]),
                        CircleName = Convert.ToString(s["CircleName"] == null ? "" : s["CircleName"]),
                        CircleCode = Convert.ToString(s["CircleCode"] == null ? "" : s["CircleCode"]),

                    }).FirstOrDefault();
                }
            }
            return model;
        }
        #endregion

        #region Add Edit Circle
        public async Task<Result> AddEditCircle(CircleModel model)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "Insert"));
            parameters.Add(new SqlParameter("@ID", model.CircleId));
            parameters.Add(new SqlParameter("@CircleName", model.CircleName));
            parameters.Add(new SqlParameter("@CircleCode", model.CircleCode));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageCircle", parameters.ToArray());
            Result result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = Convert.ToBoolean(s["Status"]), Message = s.Field<string>("Message") }).First();
            return result;
        }
        #endregion

        #region Get All Circle
        public async Task<ReportList> GetAllCircle(string search, int pageIndex, int pageSize, string sortCol, string sortDir)
        {
            ReportList rpList = new ReportList();
            List<CircleList> circleList = new List<CircleList>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "GetAll"));
            parameters.Add(new SqlParameter("@PageIndex", pageIndex));
            parameters.Add(new SqlParameter("@PageSize", pageSize));
            parameters.Add(new SqlParameter("@Search", search));
            parameters.Add(new SqlParameter("@OrderColumn", sortCol));
            parameters.Add(new SqlParameter("@OrderDir", sortDir));
            int totalRecord = 0;
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageCircle", parameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    totalRecord = Convert.ToInt32(ds.Tables[0].Rows[0]["TotalRow"].ToString());
                    circleList = ds.Tables[0].AsEnumerable().Select(s => new CircleList
                    {
                        SrNo = Convert.ToInt32(s["SrNo"] == null ? 0 : s["SrNo"]),
                        CircleName = Convert.ToString(s["CircleName"] == null ? "" : s["CircleName"]),
                        CircleCode = Convert.ToString(s["CircleCode"] == null ? "" : s["CircleCode"]),
                        Action = Convert.ToString(s["Action"] == null ? "" : s["Action"])
                    }).ToList();
                }
            }
            rpList.recordsFiltered = totalRecord;
            rpList.recordsTotal = totalRecord;
            rpList.data = circleList;
            return rpList;
        }
        #endregion

        #region Delete Circle
        public async Task<Result> DeleteCircle(int id)
        {
            Result result = new Result();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "Delete"));
            parameters.Add(new SqlParameter("@ID", id));

            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageCircle", parameters.ToArray());
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

        #region Active / Deactive Circle
        public async Task<Result> ActiveCircle(int id)
        {
            Result result = new Result();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "IsActive"));
            parameters.Add(new SqlParameter("@ID", id));

            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageCircle", parameters.ToArray());
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

        #endregion

        #region Get API Operator Code & Commission
        public async Task<List<OperatorCodeModel>> GetOperatorForAPI(int serviceId, int apiId)
        {
            List<OperatorCodeModel> list = new List<OperatorCodeModel>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "GetByAPIID"));
            parameters.Add(new SqlParameter("@ServiceId", serviceId));
            parameters.Add(new SqlParameter("@APIID", apiId));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageOperatorCode", parameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    list = ds.Tables[0].AsEnumerable().Select(s => new OperatorCodeModel
                    {
                        OperatorId = s["OperatorId"] != DBNull.Value ? Convert.ToInt32(s["OperatorId"]) : 0,
                        OperatorName = s["OperatorName"] != DBNull.Value ? Convert.ToString(s["OperatorName"]) : "",
                        OperatorCode = s["OPCode"] != DBNull.Value ? Convert.ToString(s["OPCode"]) : Convert.ToString(s["OperatorCode"]),
                        Commission = s["Commission"] != DBNull.Value ? Convert.ToDecimal(s["Commission"]) : 0,
                        CommissionIsFlat = s["CommissionIsFlat"] != DBNull.Value ? Convert.ToBoolean(s["CommissionIsFlat"]) : false,
                        Surcharge = s["Surcharge"] != DBNull.Value ? Convert.ToDecimal(s["Surcharge"]) : 0,
                        SurchargeIsFlat = s["SurchargeIsFlat"] != DBNull.Value ? Convert.ToBoolean(s["SurchargeIsFlat"]) : false
                    }).ToList();
                }
            }
            return list;
        }
        #endregion

        #region Save Operator Code & Commission
        public async Task<Result> SaveOperatorCode(OperatorCodeModel[] modelArray, int apiId)
        {
            string jsonArray = "{\"data\":" + JsonConvert.SerializeObject(modelArray) + "}";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "Insert"));
            parameters.Add(new SqlParameter("@APIID", apiId));
            parameters.Add(new SqlParameter("@data", jsonArray));

            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageOperatorCode", parameters.ToArray());
            Result result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = Convert.ToBoolean(s["Status"]), Message = s.Field<string>("Message") }).First();
            return result;

        }
        #endregion

        #region Get API Circle Code 
        public async Task<List<CircleCodeModel>> GetCircleForAPI(int apiId)
        {
            List<CircleCodeModel> list = new List<CircleCodeModel>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "GetByAPIID"));
            parameters.Add(new SqlParameter("@APIID", apiId));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageCircleCode", parameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    list = ds.Tables[0].AsEnumerable().Select(s => new CircleCodeModel
                    {
                        CircleId = s["CircleId"] != DBNull.Value ? Convert.ToInt32(s["CircleId"]) : 0,
                        CircleName = s["CircleName"] != DBNull.Value ? Convert.ToString(s["CircleName"]) : "",
                        CircleCode = s["CirCode"] != DBNull.Value ? Convert.ToString(s["CirCode"]) : Convert.ToString(s["CircleCode"])
                    }).ToList();
                }
            }
            return list;
        }
        #endregion

        #region Save API Circle Code
        public async Task<Result> SaveCircleCode(CircleCodeModel[] modelArray, int apiId)
        {
            string jsonArray = "{\"data\":" + JsonConvert.SerializeObject(modelArray) + "}";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "Insert"));
            parameters.Add(new SqlParameter("@APIID", apiId));
            parameters.Add(new SqlParameter("@data", jsonArray));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageCircleCode", parameters.ToArray());
            Result result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = Convert.ToBoolean(s["Status"]), Message = s.Field<string>("Message") }).First();
            return result;

        }
        #endregion

        #region Get Commission
        public async Task<List<RechargeCommission>> GetCommission(int packageId, int myPackageId, int serviceId, string action)
        {
            List<RechargeCommission> list = new List<RechargeCommission>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", action));
            parameters.Add(new SqlParameter("@MyPackage", myPackageId));
            parameters.Add(new SqlParameter("@CurrentPackage", packageId));
            parameters.Add(new SqlParameter("@ServiceId", serviceId));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageRechargeCommission", parameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    list = ds.Tables[0].AsEnumerable().Select(s => new RechargeCommission
                    {
                        OperatorId = s["OperatorId"] != DBNull.Value ? Convert.ToInt32(s["OperatorId"]) : 0,
                        ServiceName = s["ServiceName"] != DBNull.Value ? Convert.ToString(s["ServiceName"]) : "",
                        OperatorName = s["OperatorName"] != DBNull.Value ? Convert.ToString(s["OperatorName"]) : "",
                        MyCommission = s["MyCommission"] != DBNull.Value ? Convert.ToString(s["MyCommission"]) : "",
                        sdComm = s["sdComm"] != DBNull.Value ? Convert.ToDecimal(s["sdComm"]) : 0,
                        sdIsFlat = s["sdIsFlat"] != DBNull.Value ? Convert.ToBoolean(s["sdIsFlat"]) : false,
                        mdComm = s["mdComm"] != DBNull.Value ? Convert.ToDecimal(s["mdComm"]) : 0,
                        mdIsFlat = s["mdIsFlat"] != DBNull.Value ? Convert.ToBoolean(s["mdIsFlat"]) : false,
                        dtComm = s["dtComm"] != DBNull.Value ? Convert.ToDecimal(s["dtComm"]) : 0,
                        dtIsFlat = s["dtIsFlat"] != DBNull.Value ? Convert.ToBoolean(s["dtIsFlat"]) : false,
                        rtComm = s["rtComm"] != DBNull.Value ? Convert.ToDecimal(s["rtComm"]) : 0,
                        rtIsFlat = s["rtIsFlat"] != DBNull.Value ? Convert.ToBoolean(s["rtIsFlat"]) : false,
                        gstRate = s["gstRate"] != DBNull.Value ? Convert.ToDecimal(s["gstRate"]) : 0,
                        tdsRate = s["tdsRate"] != DBNull.Value ? Convert.ToDecimal(s["tdsRate"]) : 0,
                        ActiveApi = s["ActiveApi"] != DBNull.Value ? Convert.ToInt32(s["ActiveApi"]) : 0
                    }).ToList();
                }
            }
            return list;
        }

        #region My Commission
        public async Task<ReportList> MyCommission(string search, int pageIndex, int pageSize, string sortCol, string sortDir, int myPackageId,int msrNo)
        {
            ReportList rpList = new ReportList();
            List<MyCommissionModel> list = new List<MyCommissionModel>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "MyCommission"));
            parameters.Add(new SqlParameter("@MyPackage", myPackageId));
            parameters.Add(new SqlParameter("@PageIndex", pageIndex));
            parameters.Add(new SqlParameter("@PageSize", pageSize));
            parameters.Add(new SqlParameter("@Search", search));
            parameters.Add(new SqlParameter("@MsrNo", msrNo));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageRechargeCommission", parameters.ToArray());
            int totalRecord = 0;
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataView dv = new DataView(ds.Tables[0]);
                    dv.Sort = sortCol + " " + sortDir;
                    totalRecord = Convert.ToInt32(ds.Tables[0].Rows[0]["TotalRow"].ToString());
                    list = dv.ToTable().AsEnumerable().Select(s => new MyCommissionModel
                    {
                        SrNo = s["SrNo"] != DBNull.Value ? Convert.ToInt32(s["SrNo"]) : 0,
                        ServiceName = s["ServiceName"] != DBNull.Value ? Convert.ToString(s["ServiceName"]) : "",
                        OperatorName = s["OperatorName"] != DBNull.Value ? Convert.ToString(s["OperatorName"]) : "",
                        MyCommission = s["MyCommission"] != DBNull.Value ? Convert.ToString(s["MyCommission"]) : ""
                    }).ToList();
                }
            }
            rpList.recordsFiltered = totalRecord;
            rpList.recordsTotal = totalRecord;
            rpList.data = list;
            return rpList;
        }
        #endregion

        #region Save Commission
        public async Task<Result> SaveCommission(RechargeCommission[] modelArray, int packageId)
        {
            string jsonArray = "{\"data\":" + JsonConvert.SerializeObject(modelArray) + "}";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "Insert"));
            parameters.Add(new SqlParameter("@CurrentPackage", packageId));
            parameters.Add(new SqlParameter("@data", jsonArray));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageRechargeCommission", parameters.ToArray());
            Result result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = Convert.ToBoolean(s["Status"]), Message = s.Field<string>("Message") }).First();
            return result;

        }
        #endregion
        #endregion

        #region Get API & Balance
        public async Task<ApiList> GetAPIWithBalance()
        {
            ApiList model = new ApiList();
            List<ApiList> list = new List<ApiList>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "GetList"));

            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_RechargeManageAPI", parameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    list = ds.Tables[0].AsEnumerable().Select(s => new ApiList
                    {
                        ApiId = Convert.ToInt32(s["APIID"] == null ? 0 : s["APIID"]),
                        ApiName = Convert.ToString(s["APIName"] == null ? "" : s["APIName"]),
                        Status = Convert.ToString(s["Status"] == null ? "" : s["Status"]),
                        BalanceUrl = Convert.ToString(s["BalanceUrl"] == null ? "" : s["BalanceUrl"]),
                        BalanceParam = Convert.ToString(s["BalanceParam"] == null ? "" : s["BalanceParam"]),
                    }).ToList();

                    foreach (var item in list)
                    {
                        try
                        {
                            string response = await CallApi(item.BalanceUrl,item.ApiId);
                            if (response != "0")
                            {
                                JObject _obj = JObject.Parse(response);
                                string bal = "0";
                                if (_obj["Data"] != null)
                                {
                                    bal = Convert.ToString(_obj["Data"][item.BalanceParam]);
                                }
                                else if (_obj["data"] != null)
                                {
                                    bal = Convert.ToString(_obj["data"][item.BalanceParam]);
                                }
                                else
                                {
                                    if (_obj[item.BalanceParam] != null)
                                    {
                                        bal = Convert.ToString(_obj[item.BalanceParam]);
                                    }
                                }
                                list.Where(w => w.ApiId == item.ApiId).ToList().ForEach(i => i.Balance = bal);
                            }
                        }
                        catch { }
                    }
                }
            }
            model.listApi = list;            
            return model;
        }
        #region Switch API
        public async Task<Result> SwitchApi(int apiId)
        {
            Result result = new Result();
            List<MenuResponse> menuList = new List<MenuResponse>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "ActiveAPI"));
            parameters.Add(new SqlParameter("@Id", apiId));

            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_RechargeManageAPI", parameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = Convert.ToBoolean(s["Status"]), Message = s.Field<string>("Message") }).First();

                }
            }
            return result;
        }

        public async Task<Result> SwitchPackageWiseApi(int apiId, int packageId)
        {
            Result result = new Result();
            List<MenuResponse> menuList = new List<MenuResponse>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "SwitchPackageWise"));
            parameters.Add(new SqlParameter("@ApiId", apiId));
            parameters.Add(new SqlParameter("@PackageId", packageId));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_RechargeManageAPI", parameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = Convert.ToBoolean(s["Status"]), Message = s.Field<string>("Message") }).First();

                }
            }
            return result;
        }
        public async Task<Result> SwitchOperatorWiseApi(OperatorWiseApi[] modelArray)
        {
            string jsonArray = "{\"data\":" + JsonConvert.SerializeObject(modelArray) + "}";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "SwitchOperatorWise"));
            parameters.Add(new SqlParameter("@data", jsonArray));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_RechargeManageAPI", parameters.ToArray());
            Result result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = Convert.ToBoolean(s["Status"]), Message = s.Field<string>("Message") }).First();
            return result;

        }
        #endregion

        #endregion

        #region Call API
        public async Task<string> CallApi(string url,int apiId)
        {
            HttpWebRequest httpreq = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                HttpWebResponse httpres = (HttpWebResponse)httpreq.GetResponse();
                StreamReader sr = new StreamReader(httpres.GetResponseStream());
                string results = sr.ReadToEnd();
                sr.Close();
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@ApiId", apiId));
                parameters.Add(new SqlParameter("@Url", url));
                parameters.Add(new SqlParameter("@Result", results));
                parameters.Add(new SqlParameter("@Status", "Hit"));
                await _sqlHelper.ExecuteProcedure("SP_TrackRecharge", parameters.ToArray());
                return results;
            }
            catch (Exception ex)
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@ApiId", apiId));
                parameters.Add(new SqlParameter("@Url", url));
                parameters.Add(new SqlParameter("@Result", ex.Message.ToString()));
                parameters.Add(new SqlParameter("@Status", "Error"));
                await _sqlHelper.ExecuteProcedure("SP_TrackRecharge", parameters.ToArray());
                return "0";
            }
        }
        #endregion

        #region Get Pending Recharge
        public async Task<List<TxnRecharge>> GetPendingRecharge()
        {
            List<TxnRecharge> list = new List<TxnRecharge>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "GetPending"));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_RechargeReport", parameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    list = ds.Tables[0].AsEnumerable().Select(s => new TxnRecharge
                    {
                        SrNo = s["SrNo"] != DBNull.Value ? Convert.ToInt32(s["SrNo"]) : 0,
                        Id = s["Id"] != DBNull.Value ? Convert.ToInt32(s["Id"]) : 0,
                        MemberId = s["MemberId"] != DBNull.Value ? Convert.ToString(s["MemberId"]) : "",
                        Name = s["Name"] != DBNull.Value ? Convert.ToString(s["Name"]) : "",
                        ServiceName = s["ServiceName"] != DBNull.Value ? Convert.ToString(s["ServiceName"]) : "",
                        OperatorName = s["OperatorName"] != DBNull.Value ? Convert.ToString(s["OperatorName"]) : "",
                        Amount = s["Amount"] != DBNull.Value ? Convert.ToString(s["Amount"]) : "",
                        Number = s["Number"] != DBNull.Value ? Convert.ToString(s["Number"]) : "",
                        Status = s["Status"] != DBNull.Value ? Convert.ToString(s["Status"]) : "",
                        TxnId = s["TxnId"] != DBNull.Value ? Convert.ToString(s["TxnId"]) : "",
                        ApiTxnId = s["ApiTxnId"] != DBNull.Value ? Convert.ToString(s["ApiTxnId"]) : "",
                        Date = s["AddDate"] != DBNull.Value ? Convert.ToString(s["AddDate"]) : ""
                    }).ToList();
                }
            }
            return list;

        }
        #endregion


        #region Check Status
        public async Task<Result> CheckStatus(TxnRecharge[] txnArray)
        {
            Result result = new Result();
            if (txnArray.Length > 0)
            {
                foreach (var item in txnArray.ToList())
                {
                    string pendingStatus = "Pending";
                    string successStatus = "Success";
                    string failedStatus = "Failed";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@Action", "GetStatusUrl"));
                    parameters.Add(new SqlParameter("@Id", item.Id));
                    DataSet ds = await _sqlHelper.ExecuteProcedure("SP_RechargeReport", parameters.ToArray());
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            string status = "Pending";
                            string txnId = "";
                            string apiTxnId = "";
                            string oprId = "";
                            int apiId = Convert.ToInt32(ds.Tables[0].Rows[0]["ApiId"]);
                            int rechargeId = Convert.ToInt32(ds.Tables[0].Rows[0]["RcId"]);
                            string statusUrl = Convert.ToString(ds.Tables[0].Rows[0]["Url"]);
                            pendingStatus = Convert.ToString(ds.Tables[0].Rows[0]["sPendingStatus"]);
                            successStatus = Convert.ToString(ds.Tables[0].Rows[0]["sSuccessStatus"]);
                            failedStatus = Convert.ToString(ds.Tables[0].Rows[0]["sFailedStatus"]);
                            string rechargeResult = await CallApi(statusUrl, apiId);
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

                                        parameters = new List<SqlParameter>();
                                        parameters.Add(new SqlParameter("@RcId", rechargeId));

                                        if (status.ToLower() == successStatus.ToLower())
                                        {
                                            parameters.Add(new SqlParameter("@Status", "Success"));
                                        }
                                        else if (status.ToLower() == failedStatus.ToLower())
                                        {
                                            parameters.Add(new SqlParameter("@Status", "Failed"));
                                        }
                                        else
                                        {
                                            parameters.Add(new SqlParameter("@Status", "Pending"));
                                        }
                                        parameters.Add(new SqlParameter("@TxnId", txnId));
                                        parameters.Add(new SqlParameter("@ApiTxnId", apiTxnId));
                                        parameters.Add(new SqlParameter("@OprId", oprId));
                                        parameters.Add(new SqlParameter("@ErrMsg", ""));
                                        await _sqlHelper.ExecuteProcedure("SP_UpdateRecharge", parameters.ToArray());
                                    }
                                    catch (Exception ex)
                                    {
                                        result = new Result
                                        {
                                            Status = false,
                                            Message = ex.Message.ToString()
                                        };
                                    }
                                }
                            }
                        }
                    }
                }
                result = new Result
                {
                    Status = true,
                    Message = "Status Updated"
                };
            }
            else
            {
                result.Status = false;
                result.Message = "Status Not Updated";
            }
            return result;
        }

        #endregion

        #region Force Failed
        public async Task<Result> ForceFailed(TxnRecharge[] txnArray)
        {
            Result result = new Result();
            if (txnArray.Length > 0)
            {
                foreach (var item in txnArray.ToList())
                {
                    try
                    {
                        List<SqlParameter> parameters = new List<SqlParameter>();
                        parameters.Add(new SqlParameter("@RcId", item.Id));
                        parameters.Add(new SqlParameter("@Status", "Failed"));
                        parameters.Add(new SqlParameter("@ErrMsg", "Force Failed"));
                        await _sqlHelper.ExecuteProcedure("SP_UpdateRecharge", parameters.ToArray());
                    }
                    catch { }
                }
                result = new Result
                {
                    Status = true,
                    Message = "Status Updated"
                };
            }
            else
            {
                result.Status = false;
                result.Message = "Status Not Updated";
            }
            return result;
        }

        #endregion

        #region Force Success
        public async Task<Result> ForceSuccess(TxnRecharge[] txnArray)
        {
            Result result = new Result();
            if (txnArray.Length > 0)
            {
                foreach (var item in txnArray.ToList())
                {
                    try
                    {
                        List<SqlParameter> parameters = new List<SqlParameter>();
                        parameters.Add(new SqlParameter("@RcId", item.Id));
                        parameters.Add(new SqlParameter("@Status", "Success"));
                        parameters.Add(new SqlParameter("@ErrMsg", "Force Success"));
                        parameters.Add(new SqlParameter("@OprId", item.OprId));
                        await _sqlHelper.ExecuteProcedure("SP_UpdateRecharge", parameters.ToArray());
                    }
                    catch { }
                }
                result = new Result
                {
                    Status = true,
                    Message = "Status Updated"
                };
            }
            else
            {
                result.Status = false;
                result.Message = "Status Not Updated";
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
