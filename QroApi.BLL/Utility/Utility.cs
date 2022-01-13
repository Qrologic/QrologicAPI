using QroApi.DLL;
using QroApi.MODEL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QroApi.BLL
{
    public class Utility : IUtility
    {
        #region [START : PROPERTIES]
        private readonly ISQLHelper _sqlHelper;
        #endregion

        #region[CONSTRUCTER]
        public Utility(ISQLHelper sqlHelper)
        {
            _sqlHelper = sqlHelper;
        }
        #endregion

        #region State
        #region Get State List
        public async Task<ReportList> GetStateList(string search, int pageIndex, int pageSize, string sortCol, string sortDir)
        {
            ReportList rpList = new ReportList();
            List<StateResponse> stateList = new List<StateResponse>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "GetAll"));
            parameters.Add(new SqlParameter("@PageIndex", pageIndex));
            parameters.Add(new SqlParameter("@PageSize", pageSize));
            parameters.Add(new SqlParameter("@Search", search));
            int totalRecord = 0;
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageState", parameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataView dv = new DataView(ds.Tables[0]);
                    dv.Sort = sortCol + " " + sortDir;
                    totalRecord = Convert.ToInt32(ds.Tables[0].Rows[0]["TotalRow"].ToString());
                    stateList = dv.ToTable().AsEnumerable().Select(s => new StateResponse
                    {
                        SrNo = Convert.ToInt32(s["SrNo"] == null ? 0 : s["SrNo"]),
                        StateName = Convert.ToString(s["StateName"] == null ? "" : s["StateName"]),
                        StateCode = Convert.ToString(s["StateCode"] == null ? "" : s["StateCode"]),
                        Tin = Convert.ToString(s["Tin"] == null ? "" : s["Tin"]),
                        Action = Convert.ToString(s["Action"] == null ? "" : s["Action"])
                    }).ToList();
                }
            }
            rpList.recordsFiltered = totalRecord;
            rpList.recordsTotal = totalRecord;
            rpList.data = stateList;
            return rpList;
        }
        #endregion
        #region GetStateById
        public async Task<StateModel> GetStateById(int id)
        {
            List<StateResponse> stateList = new List<StateResponse>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "GetById"));
            parameters.Add(new SqlParameter("@Id", id));
            StateModel model = new StateModel();
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageState", parameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    model = ds.Tables[0].AsEnumerable().Select(s => new StateModel
                    {
                        CountryId = Convert.ToInt32(s["CountryId"] == null ? 1 : s["CountryId"]),
                        StateId = Convert.ToInt32(s["StateId"] == null ? 0 : s["StateId"]),
                        StateName = Convert.ToString(s["StateName"] == null ? "" : s["StateName"]),
                        StateCode = Convert.ToString(s["StateCode"] == null ? "" : s["StateCode"]),
                        Tin = Convert.ToString(s["Tin"] == null ? "" : s["Tin"])
                    }).FirstOrDefault();
                }
            }
            return model;
        }
        #endregion
        #region Add Edit State
        public async Task<Result> AddEditState(StateModel model)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "Insert"));
            parameters.Add(new SqlParameter("@ID", model.StateId));
            parameters.Add(new SqlParameter("@CountryID", model.CountryId));
            parameters.Add(new SqlParameter("@StateName", model.StateName));
            parameters.Add(new SqlParameter("@StateCode", model.StateCode));
            parameters.Add(new SqlParameter("@Tin", model.Tin));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageState", parameters.ToArray());
            Result result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = Convert.ToBoolean(s["Status"]), Message = s.Field<string>("Message") }).First();
            return result;
        }
        #endregion
        #region Delete State
        public async Task<Result> DeleteState(int id)
        {
            Result result = new Result();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "IsDelete"));
            parameters.Add(new SqlParameter("@ID", id));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageState", parameters.ToArray());
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
        #region Active / Deactive State
        public async Task<Result> ActiveState(int id)
        {
            Result result = new Result();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "IsActive"));
            parameters.Add(new SqlParameter("@ID", id));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageState", parameters.ToArray());
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
        #region Get Country
        public async Task<Result> GetCountry()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "Get"));

            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageCountry", parameters.ToArray());
            Result result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = true, Message = "Data Fatched" }).First();
            result.Results = ds.Tables[0].AsEnumerable().Select(s => new
            {
                Id = Convert.ToInt32(s["CountryID"]),
                Name = s.Field<string>("CountryName"),

            }).ToList();
            return result;
        }
        #endregion
        #region Get State
        public async Task<Result> GetState(int countryId)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "GetByCountryID"));
            parameters.Add(new SqlParameter("@ID", countryId));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageState", parameters.ToArray());
            Result result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = true, Message = "Data Fatched" }).First();
            result.Results = ds.Tables[0].AsEnumerable().Select(s => new
            {
                Id = Convert.ToInt32(s["StateID"]),
                Name = s.Field<string>("StateName"),

            }).ToList();
            return result;
        }
        #endregion
        #endregion

        #region City
        #region Get City List
        public async Task<ReportList> GetCityList(string search, int pageIndex, int pageSize, string sortCol, string sortDir)
        {
            ReportList rpList = new ReportList();
            List<CityResponse> CityList = new List<CityResponse>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "GetAll"));
            parameters.Add(new SqlParameter("@PageIndex", pageIndex));
            parameters.Add(new SqlParameter("@PageSize", pageSize));
            parameters.Add(new SqlParameter("@Search", search));
            int totalRecord = 0;
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageCity", parameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataView dv = new DataView(ds.Tables[0]);
                    dv.Sort = sortCol + " " + sortDir;
                    totalRecord = Convert.ToInt32(ds.Tables[0].Rows[0]["TotalRow"].ToString());
                    CityList = dv.ToTable().AsEnumerable().Select(s => new CityResponse
                    {
                        SrNo = Convert.ToInt32(s["SrNo"] == null ? 0 : s["SrNo"]),
                        CityName = Convert.ToString(s["CityName"] == null ? "" : s["CityName"]),
                        CityCode = Convert.ToString(s["CityCode"] == null ? "" : s["CityCode"]),
                        Action = Convert.ToString(s["Action"] == null ? "" : s["Action"])
                    }).ToList();
                }
            }
            rpList.recordsFiltered = totalRecord;
            rpList.recordsTotal = totalRecord;
            rpList.data = CityList;
            return rpList;
        }
        #endregion
        #region GetCityById
        public async Task<CityModel> GetCityById(int id)
        {
            List<CityResponse> CityList = new List<CityResponse>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "GetById"));
            parameters.Add(new SqlParameter("@Id", id));
            CityModel model = new CityModel();
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageCity", parameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    model = ds.Tables[0].AsEnumerable().Select(s => new CityModel
                    {
                        StateId = Convert.ToInt32(s["StateID"] == DBNull.Value ? 0 : s["StateID"]),
                        CityId = Convert.ToInt32(s["CityId"] == null ? 0 : s["CityId"]),
                        CityName = Convert.ToString(s["CityName"] == null ? "" : s["CityName"]),
                        CityCode = Convert.ToString(s["CityCode"] == null ? "" : s["CityCode"])
                    }).FirstOrDefault();
                }
            }
            return model;
        }
        #endregion
        #region Add Edit City
        public async Task<Result> AddEditCity(CityModel model)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "Insert"));
            parameters.Add(new SqlParameter("@ID", model.CityId));
            parameters.Add(new SqlParameter("@StateID", model.StateId));
            parameters.Add(new SqlParameter("@CityName", model.CityName));
            parameters.Add(new SqlParameter("@CityCode", model.CityCode));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageCity", parameters.ToArray());
            Result result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = Convert.ToBoolean(s["Status"]), Message = s.Field<string>("Message") }).First();
            return result;
        }
        #endregion

        #region Delete City
        public async Task<Result> DeleteCity(int id)
        {
            Result result = new Result();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "IsDelete"));
            parameters.Add(new SqlParameter("@ID", id));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageCity", parameters.ToArray());
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
        #region Active / Deactive City
        public async Task<Result> ActiveCity(int id)
        {
            Result result = new Result();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "IsActive"));
            parameters.Add(new SqlParameter("@ID", id));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageCity", parameters.ToArray());
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
        #region Get City
        public async Task<Result> GetCity(int stateId)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "GetByStateID"));
            parameters.Add(new SqlParameter("@ID", stateId));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageCity", parameters.ToArray());
            Result result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = true, Message = "Data Fatched" }).First();
            result.Results = ds.Tables[0].AsEnumerable().Select(s => new
            {
                Id = Convert.ToInt32(s["CityID"]),
                Name = s.Field<string>("CityName"),

            }).ToList();
            return result;
        }
        #endregion
        #endregion

        #region Package
        #region Get Package List
        public async Task<ReportList> GetPackageList(string search, int pageIndex, int pageSize, string sortCol, string sortDir, int msrNo)
        {
            ReportList rpList = new ReportList();
            List<PackageList> packageList = new List<PackageList>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "GetListByMsrNo"));
            parameters.Add(new SqlParameter("@MsrNo", msrNo));
            parameters.Add(new SqlParameter("@PageIndex", pageIndex));
            parameters.Add(new SqlParameter("@PageSize", pageSize));
            parameters.Add(new SqlParameter("@Search", search));
            int totalRecord = 0;
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManagePackage", parameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataView dv = new DataView(ds.Tables[0]);
                    dv.Sort = sortCol + " " + sortDir;
                    totalRecord = Convert.ToInt32(ds.Tables[0].Rows[0]["TotalRow"].ToString());
                    packageList = dv.ToTable().AsEnumerable().Select(s => new PackageList
                    {
                        SrNo = Convert.ToInt32(s["SrNo"] == null ? 0 : s["SrNo"]),
                        PackageName = Convert.ToString(s["PackageName"] == null ? "" : s["PackageName"]),
                        Action = Convert.ToString(s["Action"] == null ? "" : s["Action"])
                    }).ToList();
                }
            }
            rpList.recordsFiltered = totalRecord;
            rpList.recordsTotal = totalRecord;
            rpList.data = packageList;
            return rpList;
        }
        #endregion

        #region Add Edit Package
        public async Task<Result> AddEditPackage(PackageModel model)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "Insert"));
            parameters.Add(new SqlParameter("@ID", model.PackageId));
            parameters.Add(new SqlParameter("@MsrNo", model.MsrNo));
            parameters.Add(new SqlParameter("@PackageName", model.PackageName));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManagePackage", parameters.ToArray());
            Result result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = Convert.ToBoolean(s["Status"]), Message = s.Field<string>("Message") }).First();
            return result;
        }
        #endregion

        #region Get Package By Id
        public async Task<PackageModel> GetPackageById(int id)
        {

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "Get"));
            parameters.Add(new SqlParameter("@Id", id));
            PackageModel model = new PackageModel();
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManagePackage", parameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    model = ds.Tables[0].AsEnumerable().Select(s => new PackageModel
                    {
                        PackageId = Convert.ToInt32(s["PackageId"] == DBNull.Value ? 0 : s["PackageId"]),
                        PackageName = Convert.ToString(s["PackageName"] == null ? 0 : s["PackageName"])
                    }).FirstOrDefault();
                }
            }
            return model;
        }
        #endregion

        #region Delete Package
        public async Task<Result> DeletePackage(int id)
        {
            Result result = new Result();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "Delete"));
            parameters.Add(new SqlParameter("@ID", id));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManagePackage", parameters.ToArray());
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

        #region Active / Deactive Package
        public async Task<Result> ActivePackage(int id)
        {
            Result result = new Result();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "IsActive"));
            parameters.Add(new SqlParameter("@ID", id));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManagePackage", parameters.ToArray());
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

        #region Get Package
        public async Task<Result> GetPackage(int msrNo)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "GetByMsrNo"));
            parameters.Add(new SqlParameter("@MsrNo", msrNo));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManagePackage", parameters.ToArray());
            Result result = new Result();
            result.Status = false;
            result.Message = "Data Not Avaliable";
            if (ds.Tables[0].Rows.Count > 0)
            {
                result.Status = true;
                result.Message = "Data Fatched";
                result.Results = ds.Tables[0].AsEnumerable().Select(s => new
                {
                    Id = Convert.ToInt32(s["PackageID"]),
                    Name = s.Field<string>("PackageName")
                }).ToList();
            }

            return result;
        }
        #endregion
        #region GetServiceForFilter
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
        #region Get Service By Package Id
        public async Task<AssignedService> GetServiceByPackageId(int packageId)
        {
            AssignedService model = new AssignedService();
            List<AssignedService> serviceList = new List<AssignedService>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "GetServiceByPackageId"));
            parameters.Add(new SqlParameter("@ID", packageId));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManagePackage", parameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0 && ds.Tables[1].Rows.Count > 0)
                {
                    model.PackageName = ds.Tables[1].Rows[0]["PackageName"].ToString();
                    model.PackageId = Convert.ToInt32(ds.Tables[1].Rows[0]["PackageId"]);
                    serviceList = ds.Tables[0].AsEnumerable().Select(s => new AssignedService
                    {
                        ServiceId = Convert.ToInt32(s["ServiceId"] == null ? 0 : s["ServiceId"]),
                        ServiceName = Convert.ToString(s["ServiceName"] == null ? "" : s["ServiceName"]),
                        IsAssign = Convert.ToBoolean(s["IsAssign"] == null ? "" : s["IsAssign"])
                    }).ToList();
                }
            }
            model.list = serviceList;
            return model;
        }
        #endregion
        #region Get Service By Package Id
        public async Task<AssignedService> GetServiceByMsrNo(int MsrNo)
        {
            AssignedService model = new AssignedService();
            List<AssignedService> serviceList = new List<AssignedService>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "GetServiceByMsrNo"));
            parameters.Add(new SqlParameter("@MsrNo", MsrNo));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManagePackage", parameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        model.MemberName = ds.Tables[1].Rows[0]["Name"].ToString();
                        model.MsrNo = Convert.ToInt32(ds.Tables[1].Rows[0]["MsrNo"]);
                    }
                    serviceList = ds.Tables[0].AsEnumerable().Select(s => new AssignedService
                    {
                        ServiceId = Convert.ToInt32(s["ServiceId"] == null ? 0 : s["ServiceId"]),
                        ServiceName = Convert.ToString(s["ServiceName"] == null ? "" : s["ServiceName"]),
                        IsAssign = Convert.ToBoolean(s["IsAssign"] == null ? "" : s["IsAssign"])
                    }).ToList();
                }
            }
            model.list = serviceList;
            return model;
        }
        #endregion
        #region Assigne Service On Package

        public async Task<Result> AssigneServiceOnPackage(AssignedService[] modelArray, int packageId)
        {
            string jsonArray = "{\"data\":" + JsonConvert.SerializeObject(modelArray) + "}";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "AssignService"));
            parameters.Add(new SqlParameter("@ID", packageId));
            parameters.Add(new SqlParameter("@data", jsonArray));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManagePackage", parameters.ToArray());
            Result result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = Convert.ToBoolean(s["Status"]), Message = s.Field<string>("Message") }).First();
            return result;

        }

        #endregion

        #region Assigne Service On MsrNo

        public async Task<Result> AssigneServiceOnMsrNo(AssignedService[] modelArray, int MsrNo)
        {
            string jsonArray = "{\"data\":" + JsonConvert.SerializeObject(modelArray) + "}";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "AssignServiceByMsrNo"));
            parameters.Add(new SqlParameter("@MsrNo", MsrNo));
            parameters.Add(new SqlParameter("@data", jsonArray));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManagePackage", parameters.ToArray());
            Result result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = Convert.ToBoolean(s["Status"]), Message = s.Field<string>("Message") }).First();
            return result;

        }

        #endregion
        #endregion

        #region Role
        #region Get Role For Registration
        public async Task<Result> GetRoleForRegistration(int? id, int userId)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "GetForRegistration"));
            parameters.Add(new SqlParameter("@Id", id));
            parameters.Add(new SqlParameter("@UserId", userId));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageRole", parameters.ToArray());
            Result result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = true, Message = "Data Fatched" }).First();
            result.Results = ds.Tables[0].AsEnumerable().Select(s => new
            {
                Id = Convert.ToInt32(s["Id"]),
                Name = s.Field<string>("RoleName")
            }).ToList();
            return result;
        }
        #endregion
        #region GetRoleForRegistration
        public async Task<Result> GetRoleForEmployee(int? id, int userId)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "GetForEmpRegistration"));
            parameters.Add(new SqlParameter("@Id", id));
            parameters.Add(new SqlParameter("@UserId", userId));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageRole", parameters.ToArray());
            Result result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = true, Message = "Data Fatched" }).First();
            result.Results = ds.Tables[0].AsEnumerable().Select(s => new
            {
                Id = Convert.ToInt32(s["Id"]),
                Name = s.Field<string>("RoleName")
            }).ToList();
            return result;
        }
        #endregion
        #region GetRoleForRights
        public async Task<Result> GetRoleForRights(int userId)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "GetForRights"));
            parameters.Add(new SqlParameter("@UserId", userId));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageRole", parameters.ToArray());
            Result result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = true, Message = "Data Fatched" }).First();
            result.Results = ds.Tables[0].AsEnumerable().Select(s => new
            {
                Id = Convert.ToInt32(s["Id"]),
                Name = s.Field<string>("RoleName")
            }).ToList();
            return result;
        }
        #endregion
        #endregion

        #region Bank
        #region Get Bank
        public async Task<Result> GetBank()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "GetDDL"));

            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageBank", parameters.ToArray());
            Result result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = true, Message = "Data Fatched" }).First();
            result.Results = ds.Tables[0].AsEnumerable().Select(s => new
            {
                Id = s.Field<int>("Id"),
                Name = s.Field<string>("BankName")
            }).ToList();
            return result;
        }
        #endregion
        #endregion

        #region Support
        #region Get Support List
        public async Task<ReportList> GetSupportList(string search, int pageIndex, int pageSize, string sortCol, string sortDir, int msrNo, CommonFilter model)
        {
            ReportList rpList = new ReportList();
            List<SupportResponse> list = new List<SupportResponse>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "GetAll"));
            parameters.Add(new SqlParameter("@MsrNo", msrNo));
            parameters.Add(new SqlParameter("@fromDate", model.fromDate == null ? "01/01/2015" : model.fromDate));
            parameters.Add(new SqlParameter("@todate", model.toDate == null ? "01/01/2100" : model.toDate));
            parameters.Add(new SqlParameter("@Status", model.status == null ? "" : model.status));
            parameters.Add(new SqlParameter("@MemberId", model.option3 == null ? "" : model.option3));
            parameters.Add(new SqlParameter("@Name", model.option4 == null ? "" : model.option4));
            parameters.Add(new SqlParameter("@Mobile", model.option5 == null ? "" : model.option5));
            parameters.Add(new SqlParameter("@PageIndex", pageIndex));
            parameters.Add(new SqlParameter("@PageSize", pageSize));
            parameters.Add(new SqlParameter("@Search", search));
            parameters.Add(new SqlParameter("@OrderColumn", sortCol));
            parameters.Add(new SqlParameter("@OrderDir", sortDir));
            int totalRecord = 0;
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageTicket", parameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataView dv = new DataView(ds.Tables[0]);
                    dv.Sort = sortCol + " " + sortDir;
                    totalRecord = Convert.ToInt32(ds.Tables[0].Rows[0]["TotalRow"].ToString());
                    list = dv.ToTable().AsEnumerable().Select(s => new SupportResponse
                    {
                        SrNo = s["SrNo"] == DBNull.Value ? 0 : Convert.ToInt32(s["SrNo"]),
                        Status = s["Status"] == DBNull.Value ? "" : Convert.ToString(s["Status"]),
                        MemberId = s["MemberId"] == DBNull.Value ? "" : Convert.ToString(s["MemberId"]),
                        Name = s["Name"] == DBNull.Value ? "" : Convert.ToString(s["Name"]),
                        Subject = s["Subject"] == DBNull.Value ? "" : Convert.ToString(s["Subject"]),
                        Message = s["Message"] == DBNull.Value ? "" : Convert.ToString(s["Message"]),
                        //Department = s["Department"] == DBNull.Value ? "" : Convert.ToString(s["Department"]),
                        //Priority = s["Priority"] == DBNull.Value ? "" : Convert.ToString(s["Priority"]),
                        Remarks = s["Remarks"] == DBNull.Value ? "" : Convert.ToString(s["Remarks"]),
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
        #region Get Support ById
        public async Task<SupportModel> GetSupportById(int id)
        {
            SupportModel model = new SupportModel();
            List<SupportModel> list = new List<SupportModel>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "GetById"));
            parameters.Add(new SqlParameter("@Id", id));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageTicket", parameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    model.Id = Convert.ToInt32(ds.Tables[0].Rows[0]["Id"].ToString());
                    model.MsrNo = Convert.ToInt32(ds.Tables[0].Rows[0]["MsrNo"].ToString());
                    model.PriorityID = ds.Tables[0].Rows[0]["PriorityID"] == DBNull.Value ? 0 : Convert.ToInt32(ds.Tables[0].Rows[0]["PriorityID"].ToString());
                    model.Subject = ds.Tables[0].Rows[0]["Subject"] == DBNull.Value ? "" : Convert.ToString(ds.Tables[0].Rows[0]["Subject"]);
                    model.Message = ds.Tables[0].Rows[0]["Message"] == DBNull.Value ? "" : Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                    model.Attachment = ds.Tables[0].Rows[0]["Attachment"] == DBNull.Value ? "" : Convert.ToString(ds.Tables[0].Rows[0]["Attachment"]);
                    model.Date = Convert.ToString(ds.Tables[0].Rows[0]["AddedDate"]);
                    list = ds.Tables[1].AsEnumerable().Select(s => new SupportModel
                    {
                        Id = s["Id"] == DBNull.Value ? 0 : Convert.ToInt32(s["Id"]),
                        MsrNo = s["MsrNo"] == DBNull.Value ? 0 : Convert.ToInt32(s["MsrNo"]),
                        PriorityID = s["PriorityID"] == DBNull.Value ? 0 : Convert.ToInt32(s["PriorityID"]),
                        Subject = s["Subject"] == DBNull.Value ? "" : Convert.ToString(s["Subject"]),
                        Message = s["Message"] == DBNull.Value ? "" : Convert.ToString(s["Message"]),
                        Attachment = s["Attachment"] == DBNull.Value ? "" : Convert.ToString(s["Attachment"]),
                        Date = s["AddedDate"] == DBNull.Value ? "" : Convert.ToString(s["AddedDate"]),
                        DateGroup =s["DateGroup"] == DBNull.Value ? 0 : Convert.ToInt32(s["DateGroup"]),
                        MsgTime = s["MsgTime"] == DBNull.Value ? "": Convert.ToString(s["MsgTime"])
                    }).ToList();
                }
            }
            model.list = list;
            return model;
        }
        #endregion
        #region Close Ticket
        public async Task<Result> CloseTicket(int id)
        {
            Result result = new Result();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "IsActive"));
            parameters.Add(new SqlParameter("@ID", id));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManagePackage", parameters.ToArray());
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
        #region CreateTicket
        public async Task<Result> CreateTicket(SupportModel model)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "Insert"));
            parameters.Add(new SqlParameter("@ID", model.Id));
            parameters.Add(new SqlParameter("@MsrNo", model.MsrNo));
            parameters.Add(new SqlParameter("@PriorityID", model.PriorityID));
            parameters.Add(new SqlParameter("@Subject", model.Subject));
            parameters.Add(new SqlParameter("@Message", model.Message));
            parameters.Add(new SqlParameter("@Attachment", model.Attachment));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageTicket", parameters.ToArray());
            Result result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = Convert.ToBoolean(s["Status"]), Message = s.Field<string>("Message") }).First();
            return result;
        }
        #endregion
        #region Get Priority
        public async Task<Result> GetPriority()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "GetPriority"));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageTicket", parameters.ToArray());
            Result result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = true, Message = "Data Fatched" }).First();
            result.Results = ds.Tables[0].AsEnumerable().Select(s => new
            {
                Id = Convert.ToInt32(s["ID"]),
                Name = s.Field<string>("PriorityName"),
            }).ToList();
            return result;
        }
        #endregion
        #region Get Department
        public async Task<Result> GetDepartment()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "GetDepartment"));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageTicket", parameters.ToArray());
            Result result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = true, Message = "Data Fatched" }).First();
            result.Results = ds.Tables[0].AsEnumerable().Select(s => new
            {
                Id = Convert.ToInt32(s["ID"]),
                Name = s.Field<string>("DeptName"),
            }).ToList();
            return result;
        }
        #endregion
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
