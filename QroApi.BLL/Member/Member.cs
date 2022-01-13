using QroApi.DLL;
using QroApi.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QroApi.BLL
{

    public class Member : IMember
    {
        #region [START : PROPERTIES]
        private readonly ISQLHelper _sqlHelper;
        #endregion

        #region[CONSTRUCTER]
        public Member(ISQLHelper sqlHelper)
        {
            _sqlHelper = sqlHelper;
        }
        #endregion

        #region Member

        #region Get Member List
        public async Task<ReportList> GetMemberList(string search, int pageIndex, int pageSize, string sortCol, string sortDir, int msrNo,CommonFilter model)
        {
            ReportList rpList = new ReportList();
            List<MemberResponse> MemberList = new List<MemberResponse>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "GetAll"));
            parameters.Add(new SqlParameter("@MsrNo", msrNo));
            parameters.Add(new SqlParameter("@fromDate", model.fromDate == null ? "01/01/2015" : model.fromDate));
            parameters.Add(new SqlParameter("@todate", model.toDate == null ? "01/01/2100" : model.toDate));
            parameters.Add(new SqlParameter("@Status", model.status == null ? "" : model.status));
            parameters.Add(new SqlParameter("@UserRole", model.option1==null? 0: model.option1));
            parameters.Add(new SqlParameter("@PackageId", model.option2 == null ? 0 : model.option2));
            parameters.Add(new SqlParameter("@MemberId", model.option3 == null ? "" : model.option3));
            parameters.Add(new SqlParameter("@Name", model.option4 == null ? "" : model.option4));
            parameters.Add(new SqlParameter("@Mobile", model.option5 == null ? "" : model.option5));
            parameters.Add(new SqlParameter("@Email", model.option6 == null ? "" :  model.option6));
            parameters.Add(new SqlParameter("@PageIndex", pageIndex));
            parameters.Add(new SqlParameter("@PageSize", pageSize));
            parameters.Add(new SqlParameter("@Search", search));
            int totalRecord = 0;
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageMember", parameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataView dv = new DataView(ds.Tables[0]);
                    dv.Sort = sortCol + " " + sortDir;
                    totalRecord = Convert.ToInt32(ds.Tables[0].Rows[0]["TotalRow"].ToString());
                    MemberList = dv.ToTable().AsEnumerable().Select(s => new MemberResponse
                    {
                        SrNo = s["SrNo"] == DBNull.Value ? 0 : Convert.ToInt32(s["SrNo"]),
                        MemberId = s["MemberId"] == DBNull.Value ? "" : Convert.ToString(s["MemberId"]),
                        Role = s["RoleName"] == DBNull.Value ? "" : Convert.ToString(s["RoleName"]),
                        Name = s["Name"] == DBNull.Value ? "" : Convert.ToString(s["Name"]),
                        Mobile = s["Mobile"] == DBNull.Value ? "" : Convert.ToString(s["Mobile"]),
                        Email = s["Email"] == DBNull.Value ? "" : Convert.ToString(s["Email"]),
                        SponsorId = s["SponsorID"] == DBNull.Value ? "" : Convert.ToString(s["SponsorID"]),
                        Package = s["Package"] == DBNull.Value ? "" : Convert.ToString(s["Package"]),
                        Action = s["Action"] == DBNull.Value ? "" : Convert.ToString(s["Action"])
                    }).ToList();
                }
            }
            rpList.recordsFiltered = totalRecord;
            rpList.recordsTotal = totalRecord;
            rpList.data = MemberList;
            return rpList;
        }
        #endregion

        #region Get Member Detail
        public async Task<MemberDetail> GetMemberDetail(int msrNo)
        {
            MemberDetail model = new MemberDetail();
            List<MemberResponse> MemberList = new List<MemberResponse>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "ViewDetail"));
            parameters.Add(new SqlParameter("@MsrNo", msrNo));

            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageMember", parameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {

                    model = ds.Tables[0].AsEnumerable().Select(s => new MemberDetail
                    {
                        MsrNo = s["MsrNo"] == DBNull.Value ? 0 : Convert.ToInt32(s["MsrNo"]),
                        Role = s["RoleName"] == DBNull.Value ? "" : Convert.ToString(s["RoleName"]),
                        MemberId = s["MemberId"] == DBNull.Value ? "" : Convert.ToString(s["MemberId"]),
                        Name = s["Name"] == DBNull.Value ? "" : Convert.ToString(s["Name"]),
                        Mobile = s["Mobile"] == DBNull.Value ? "" : Convert.ToString(s["Mobile"]),
                        Email = s["Email"] == DBNull.Value ? "" : Convert.ToString(s["Email"]),
                        Password = s["Password"] == DBNull.Value ? "" : Security.DecryptPassword(Convert.ToString(s["Password"])),
                        TPassword = s["TPassword"] == DBNull.Value ? "" : Security.DecryptPassword(Convert.ToString(s["TPassword"])),
                        Address = s["Address"] == DBNull.Value ? "" : Convert.ToString(s["Address"]),
                        State = s["State"] == DBNull.Value ? "" : Convert.ToString(s["State"]),
                        City = s["District"] == DBNull.Value ? "" : Convert.ToString(s["District"]),
                        PanNumber = s["PanNumber"] == DBNull.Value ? "" : Convert.ToString(s["PanNumber"]),
                        AadharNumber = s["AadharNumber"] == DBNull.Value ? "" : Convert.ToString(s["AadharNumber"]),
                        SponsorId = s["SponsorID"] == DBNull.Value ? "" : Convert.ToString(s["SponsorID"]),
                        SponsorName = s["SponsorName"] == DBNull.Value ? "" : Convert.ToString(s["SponsorName"]),
                        Package = s["Package"] == DBNull.Value ? "" : Convert.ToString(s["Package"]),
                        Status = s["Status"] == DBNull.Value ? "" : Convert.ToString(s["Status"]),
                        DOJ = s["DOJ"] == DBNull.Value ? "" : Convert.ToString(s["DOJ"]),


                    }).FirstOrDefault();
                }
            }

            return model;
        }
        #endregion

        #region GetMemberById
        public async Task<MemberRegisterModel> GetMemberByMsrNo(int MsrNo)
        {
            List<MemberResponse> MemberList = new List<MemberResponse>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "GetByMsrNo"));
            parameters.Add(new SqlParameter("@MsrNo", MsrNo));
            MemberRegisterModel model = new MemberRegisterModel();
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageMember", parameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    model = ds.Tables[0].AsEnumerable().Select(s => new MemberRegisterModel
                    {
                        MsrNo = s["MsrNo"] == DBNull.Value ? 0 : Convert.ToInt32(s["MsrNo"]),
                        UserRole = s["UserRole"] == DBNull.Value ? 0 : Convert.ToInt32(s["UserRole"]),
                        PackageId = s["PackageId"] == DBNull.Value ? 0 : Convert.ToInt32(s["PackageId"]),
                        UserName = s["Name"] == DBNull.Value ? "" : Convert.ToString(s["Name"]),
                        Mobile = s["Mobile"] == DBNull.Value ? "" : Convert.ToString(s["Mobile"]),
                        Email = s["Email"] == DBNull.Value ? "" : Convert.ToString(s["Email"]),
                        Password = s["Password"] == DBNull.Value ? "" : Security.DecryptPassword(Convert.ToString(s["Password"])),
                        //TPassword = s["TPassword"] == DBNull.Value ? "" : Security.DecryptPassword(Convert.ToString(s["TPassword"])),
                        AadharNumber = s["AadharNumber"] == DBNull.Value ? "" : Convert.ToString(s["AadharNumber"]),
                        PanNumber = s["PanNumber"] == DBNull.Value ? "" : Convert.ToString(s["PanNumber"]),
                        Address = s["Address"] == DBNull.Value ? "" : Convert.ToString(s["Address"]),
                        CountryId = s["CountryId"] == DBNull.Value ? 0 : Convert.ToInt32(s["CountryId"]),
                        StateId = s["StateId"] == DBNull.Value ? 0 : Convert.ToInt32(s["StateId"]),
                        CityId = s["CityId"] == DBNull.Value ? 0 : Convert.ToInt32(s["CityId"])

                    }).FirstOrDefault();
                }
            }
            return model;
        }
        #endregion

        #region Add Edit Member
        public async Task<Result> AddEditMember(MemberRegisterModel model)
        {
            string SecurityKey = model.SecurityKey, Password = model.Password, TPassword = model.TPassword;
            if (model.MsrNo == 0)
            {
                var enc = model.Password.EncryptPassword();
                Password = enc.Item1;
                SecurityKey = enc.Item2;                
                TPassword ="1234";
                var encT = TPassword.EncryptPassword();
                TPassword = encT.Item1;
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@MsrNo", model.MsrNo));
            parameters.Add(new SqlParameter("@ParentMsrNo", model.ParentMsrNo));
            parameters.Add(new SqlParameter("@UserRole", model.UserRole));
            parameters.Add(new SqlParameter("@MemberId", model.UserId));
            parameters.Add(new SqlParameter("@Name", model.UserName));
            parameters.Add(new SqlParameter("@Email", model.Email));
            parameters.Add(new SqlParameter("@Mobile", model.Mobile));
            parameters.Add(new SqlParameter("@CompanyName", model.CompanyName));
            parameters.Add(new SqlParameter("@UserImage", model.UserImage));
            parameters.Add(new SqlParameter("@Password", Password));
            parameters.Add(new SqlParameter("@TPassword", TPassword));
            parameters.Add(new SqlParameter("@SecurityKey", SecurityKey));
            parameters.Add(new SqlParameter("@Address", model.Address));
            parameters.Add(new SqlParameter("@CountryId", model.CountryId));
            parameters.Add(new SqlParameter("@StateId", model.StateId));
            parameters.Add(new SqlParameter("@CityId", model.CityId));
            parameters.Add(new SqlParameter("@Zip", model.Zip));
            parameters.Add(new SqlParameter("@PackageId", model.PackageId));
            parameters.Add(new SqlParameter("@PanNumber", model.PanNumber));
            parameters.Add(new SqlParameter("@AadharNumber", model.AadharNumber));
            parameters.Add(new SqlParameter("@IP", model.IP));
            parameters.Add(new SqlParameter("@MAC", model.MAC));
            parameters.Add(new SqlParameter("@Sources", model.Source));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_Users", parameters.ToArray());
            Result result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = Convert.ToBoolean(s["Status"]), Message = s.Field<string>("Message") }).First();
            if (result.Status && ds.Tables.Count > 0)
            {
                result.Results = ds.Tables[0].AsEnumerable().Select(s => new
                {
                    MsrNo = s.Field<Int32>("MsrNo"),
                    MemberId = s.Field<string>("MemberId"),
                    Message = model.MsrNo > 0 ? s.Field<string>("Message") : s.Field<string>("Message") + " , Password Is :" + model.Password + " and Transaction Password Is :" + TPassword.DecryptPassword()
                }).First();
            }
            return result;
        }
        #endregion

        #region Active / Deactive Member
        public async Task<Result> ActiveMember(int MsrNo)
        {
            Result result = new Result();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "IsActive"));
            parameters.Add(new SqlParameter("@MsrNo", MsrNo));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageMember", parameters.ToArray());
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

        #region Employee

        #region Get Employee List
        public async Task<ReportList> GetEmployeeList(string search, int pageIndex, int pageSize, string sortCol, string sortDir,int userId)
        {
            ReportList rpList = new ReportList();
            List<EmployeeResponse> EmployeeList = new List<EmployeeResponse>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "GetAll"));
            parameters.Add(new SqlParameter("@Id", userId));
            parameters.Add(new SqlParameter("@fromDate", "01/01/1900"));
            parameters.Add(new SqlParameter("@todate", "01/01/2100"));
            parameters.Add(new SqlParameter("@LoginId", ""));
            parameters.Add(new SqlParameter("@Name", ""));
            parameters.Add(new SqlParameter("@Status", ""));
            parameters.Add(new SqlParameter("@PageIndex", pageIndex));
            parameters.Add(new SqlParameter("@PageSize", pageSize));
            parameters.Add(new SqlParameter("@Search", search));
            parameters.Add(new SqlParameter("@OrderColumn", sortCol));
            parameters.Add(new SqlParameter("@OrderDir", sortDir));
            int totalRecord = 0;
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageAdmin", parameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataView dv = new DataView(ds.Tables[0]);
                    dv.Sort = sortCol + " " + sortDir;
                    totalRecord = Convert.ToInt32(ds.Tables[0].Rows[0]["TotalRow"].ToString());
                    EmployeeList = dv.ToTable().AsEnumerable().Select(s => new EmployeeResponse
                    {
                        SrNo = s["SrNo"] == DBNull.Value ? 0 : Convert.ToInt32(s["SrNo"]),
                        //Status = s["Status"] == DBNull.Value ? "" : Convert.ToString(s["Status"]),
                        Role = s["RoleName"] == DBNull.Value ? "" : Convert.ToString(s["RoleName"]),
                        LoginId = s["LoginId"] == DBNull.Value ? "" : Convert.ToString(s["LoginId"]),
                        Password = s["Password"] == DBNull.Value ? "" : Security.DecryptPassword(Convert.ToString(s["Password"])),
                        Name = s["Name"] == DBNull.Value ? "" : Convert.ToString(s["Name"]),
                        Mobile = s["Mobile"] == DBNull.Value ? "" : Convert.ToString(s["Mobile"]),
                        Email = s["Email"] == DBNull.Value ? "" : Convert.ToString(s["Email"]),
                        // Address = s["Address"] == DBNull.Value ? "" : Convert.ToString(s["Address"]),
                        //PanNumber = s["PanNumber"] == DBNull.Value ? "" : Convert.ToString(s["PanNumber"]),
                        Action = s["Action"] == DBNull.Value ? "" : Convert.ToString(s["Action"])
                    }).ToList();
                }
            }
            rpList.recordsFiltered = totalRecord;
            rpList.recordsTotal = totalRecord;
            rpList.data = EmployeeList;
            return rpList;
        }
        #endregion

        #region GetEmployeeById
        public async Task<EmployeeRegisterModel> GetEmployeeById(int Id)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "GetById"));
            parameters.Add(new SqlParameter("@Id", Id));
            EmployeeRegisterModel model = new EmployeeRegisterModel();
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageAdmin", parameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    model = ds.Tables[0].AsEnumerable().Select(s => new EmployeeRegisterModel
                    {
                        Id = s["Id"] == DBNull.Value ? 0 : Convert.ToInt32(s["Id"]),
                        UserRole = s["UserRole"] == DBNull.Value ? 0 : Convert.ToInt32(s["UserRole"]),
                        UserId = s["LoginId"] == DBNull.Value ? "" : Convert.ToString(s["LoginId"]),
                        UserName = s["Name"] == DBNull.Value ? "" : Convert.ToString(s["Name"]),
                        Mobile = s["Mobile"] == DBNull.Value ? "" : Convert.ToString(s["Mobile"]),
                        Email = s["Email"] == DBNull.Value ? "" : Convert.ToString(s["Email"]),
                        Password = s["Password"] == DBNull.Value ? "" : Security.DecryptPassword(Convert.ToString(s["Password"])),
                        TPassword = s["TPassword"] == DBNull.Value ? "" : Security.DecryptPassword(Convert.ToString(s["TPassword"])),
                        AadhaarNumber = s["AadhaarNumber"] == DBNull.Value ? "" : Convert.ToString(s["AadhaarNumber"]),
                        PanNumber = s["PanNumber"] == DBNull.Value ? "" : Convert.ToString(s["PanNumber"]),
                        Address = s["Address"] == DBNull.Value ? "" : Convert.ToString(s["Address"]),
                        CountryId = s["CountryId"] == DBNull.Value ? 0 : Convert.ToInt32(s["CountryId"]),
                        StateId = s["StateId"] == DBNull.Value ? 0 : Convert.ToInt32(s["StateId"]),
                        CityId = s["CityId"] == DBNull.Value ? 0 : Convert.ToInt32(s["CityId"])

                    }).FirstOrDefault();
                }
            }
            return model;
        }
        #endregion

        #region Add Edit Employee
        public async Task<Result> AddEditEmployee(EmployeeRegisterModel model)
        {
            string SecurityKey = model.SecurityKey, Password = model.Password, TPassword = model.TPassword;
            if (model.Id == 0)
            {
                var enc = model.Password.EncryptPassword();
                Password = enc.Item1;
                SecurityKey = enc.Item2;
                TPassword = GenerateTranPwd().EncryptPassword().Item1;
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", model.Id));
            parameters.Add(new SqlParameter("@UserRole", model.UserRole));
            parameters.Add(new SqlParameter("@LoginID", model.UserId));
            parameters.Add(new SqlParameter("@Name", model.UserName));
            parameters.Add(new SqlParameter("@Email", model.Email));
            parameters.Add(new SqlParameter("@Mobile", model.Mobile));
            parameters.Add(new SqlParameter("@Image", model.Image));
            parameters.Add(new SqlParameter("@Password", Password));
            parameters.Add(new SqlParameter("@TPassword", TPassword));
            parameters.Add(new SqlParameter("@SecurityKey", SecurityKey));
            parameters.Add(new SqlParameter("@Address", model.Address));
            parameters.Add(new SqlParameter("@CountryId", model.CountryId));
            parameters.Add(new SqlParameter("@StateId", model.StateId));
            parameters.Add(new SqlParameter("@CityId", model.CityId));
            parameters.Add(new SqlParameter("@Zip", model.Zip));
            parameters.Add(new SqlParameter("@PanNumber", model.PanNumber));
            parameters.Add(new SqlParameter("@AadhaarNumber", model.AadhaarNumber));
            parameters.Add(new SqlParameter("@IP", model.IP));
            parameters.Add(new SqlParameter("@MAC", model.MAC));
            parameters.Add(new SqlParameter("@Sources", model.Source));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_Admin", parameters.ToArray());
            Result result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = Convert.ToBoolean(s["Status"]), Message = s.Field<string>("Message") }).First();
            if (result.Status && ds.Tables.Count > 0)
            {
                result.Results = ds.Tables[0].AsEnumerable().Select(s => new
                {
                    Id = s.Field<Int32>("Id"),
                    LoginID = s.Field<string>("LoginID"),
                    Message = model.Id > 0 ? s.Field<string>("Message") : s.Field<string>("Message") + " , Password Is :" + model.Password + " and Transaction Password Is :" + TPassword.DecryptPassword()
                }).First();
            }
            return result;
        }
        #endregion

        #region Active / Deactive Employee
        public async Task<Result> ActiveEmployee(int Id)
        {
            Result result = new Result();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "IsActive"));
            parameters.Add(new SqlParameter("@Id", Id));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageAdmin", parameters.ToArray());
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

        #region Get Employee Detail
        public async Task<EmployeeDetail> GetEmployeeDetail(int id)
        {
            EmployeeDetail model = new EmployeeDetail();
            List<EmployeeResponse> EmployeeList = new List<EmployeeResponse>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "ViewDetail"));
            parameters.Add(new SqlParameter("@Id", id));

            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageAdmin", parameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {

                    model = ds.Tables[0].AsEnumerable().Select(s => new EmployeeDetail
                    {
                        Id = s["Id"] == DBNull.Value ? 0 : Convert.ToInt32(s["Id"]),
                        Role = s["RoleName"] == DBNull.Value ? "" : Convert.ToString(s["RoleName"]),
                        UserId = s["LoginId"] == DBNull.Value ? "" : Convert.ToString(s["LoginId"]),
                        Name = s["Name"] == DBNull.Value ? "" : Convert.ToString(s["Name"]),
                        Mobile = s["Mobile"] == DBNull.Value ? "" : Convert.ToString(s["Mobile"]),
                        Email = s["Email"] == DBNull.Value ? "" : Convert.ToString(s["Email"]),
                        Password = s["Password"] == DBNull.Value ? "" : Security.DecryptPassword(Convert.ToString(s["Password"])),
                        TPassword = s["TPassword"] == DBNull.Value ? "" : Security.DecryptPassword(Convert.ToString(s["TPassword"])),
                        Address = s["Address"] == DBNull.Value ? "" : Convert.ToString(s["Address"]),
                        State = s["State"] == DBNull.Value ? "" : Convert.ToString(s["State"]),
                        City = s["District"] == DBNull.Value ? "" : Convert.ToString(s["District"]),
                        PanNumber = s["PanNumber"] == DBNull.Value ? "" : Convert.ToString(s["PanNumber"]),
                        AadharNumber = s["AadhaarNumber"] == DBNull.Value ? "" : Convert.ToString(s["AadhaarNumber"]),
                        Status = s["Status"] == DBNull.Value ? "" : Convert.ToString(s["Status"]),
                        DOJ = s["DOJ"] == DBNull.Value ? "" : Convert.ToString(s["DOJ"])
                    }).FirstOrDefault();
                }
            }

            return model;
        }
        #endregion
        #region Change Employee Password
        public async Task<Result> ChangeEmployeePassword(ChangePassword model)
        {
            Result result = new Result();
            var encryptPass = model.NewPassword.EncryptPassword();

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "ChangePasswordByAdmin"));
            parameters.Add(new SqlParameter("@Id", model.MsrNo));
            parameters.Add(new SqlParameter("@NewPassword", encryptPass.Item1));
            parameters.Add(new SqlParameter("@SecurityKey", encryptPass.Item2));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageAdmin", parameters.ToArray());
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

        #region Change Employee Transaction Password
        public async Task<Result> ChangeEmployeeTPassword(ChangePassword model)
        {
            Result result = new Result();
            var encryptPass = model.NewTPassword.EncryptPassword();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "ChangeTPasswordByAdmin"));
            parameters.Add(new SqlParameter("@Id", model.MsrNo));
            parameters.Add(new SqlParameter("@NewPassword", encryptPass.Item1));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageAdmin", parameters.ToArray());
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

        #region GenerateTranPwd
        private string GenerateTranPwd()
        {
            int _min = 1000;
            int _max = 9999;
            Random _rdm = new Random();
            return _rdm.Next(_min, _max).ToString();
        }
        #endregion

        #region Get MsrNo
        public async Task<int> GetMsrNo(string memberId)
        {
            int msrNo = 0;
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@Action", "GetMsrNo"));
                parameters.Add(new SqlParameter("@MemberId", memberId));
                msrNo = await _sqlHelper.ExecuteScalerInt("SP_ManageMember", parameters.ToArray());
            }
            catch
            {
            }
            return msrNo;
        }
        #endregion

        #region Get MemberId
        public async Task<string> GetMemberId(int msrNo)
        {
            string memberId = "";
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@Action", "GetMemberID"));
                parameters.Add(new SqlParameter("@MsrNo", msrNo));
                msrNo = await _sqlHelper.ExecuteScalerInt("SP_ManageMember", parameters.ToArray());
            }
            catch
            {
            }
            return memberId;
        }
        #endregion

        #region Get PackageId
        public async Task<int> GetPackageId(int msrNo)
        {
            int packageId = 0;
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@Action", "GetPackageID"));
                parameters.Add(new SqlParameter("@MsrNo", msrNo));
                packageId = await _sqlHelper.ExecuteScalerInt("SP_ManageMember", parameters.ToArray());
            }
            catch
            {
            }
            return packageId;
        }
        #endregion

        #region Search Member By AutoComplete
        public async Task<Result> SearchMember(string search, int msrNo)
        {
            Result model = new Result();
            List<SearchMember> memberList = new List<SearchMember>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "SearcheMember"));
            parameters.Add(new SqlParameter("@MsrNo", msrNo));
            parameters.Add(new SqlParameter("@Search", search));

            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageMember", parameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    memberList = ds.Tables[0].AsEnumerable().Select(s => new SearchMember
                    {

                        MsrNo = s["MsrNo"] == DBNull.Value ? 0 : Convert.ToInt32(s["MsrNo"]),
                        MemberName = s["MemberName"] == DBNull.Value ? "" : Convert.ToString(s["MemberName"])

                    }).ToList();
                    model.Status = true;
                    model.Results = memberList;
                }
                else
                {
                    model.Status = false;
                }
            }
            else
            {
                model.Status = false;
            }

            return model;
        }
        #endregion

        #region Change  Password
        public async Task<Result> ChangePassword(ChangePassword model)
        {
            Result result = new Result();
            var encryptNewPass = model.NewPassword.EncryptPassword();
            var encryptOldPass = model.OldPassword.EncryptPassword();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "ChangePassword"));
            parameters.Add(new SqlParameter("@ID", model.MsrNo));
            parameters.Add(new SqlParameter("@OldPassword", encryptOldPass.Item1));
            parameters.Add(new SqlParameter("@NewPassword", encryptNewPass.Item1));
            parameters.Add(new SqlParameter("@SecurityKey", encryptNewPass.Item2));
            DataSet ds = new DataSet();
            if (model.Type == "Admin")
            {
                ds = await _sqlHelper.ExecuteProcedure("SP_ManageAdmin", parameters.ToArray());
            }
            else
            {
                ds = await _sqlHelper.ExecuteProcedure("SP_ManageMember", parameters.ToArray());
            }
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

        #region Change Member Password
        public async Task<Result> ChangeMemberPassword(ChangePassword model)
        {
            Result result = new Result();
            var encryptPass = model.NewPassword.EncryptPassword();

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "ChangePasswordByAdmin"));
            parameters.Add(new SqlParameter("@MsrNo", model.MsrNo));
            parameters.Add(new SqlParameter("@NewPassword", encryptPass.Item1));
            parameters.Add(new SqlParameter("@SecurityKey", encryptPass.Item2));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageMember", parameters.ToArray());
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

        #region Change Member Transaction Password
        public async Task<Result> ChangeMemberTPassword(ChangePassword model)
        {
            Result result = new Result();
            var encryptPass = model.NewTPassword.EncryptPassword();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "ChangeTPasswordByAdmin"));
            parameters.Add(new SqlParameter("@MsrNo", model.MsrNo));
            parameters.Add(new SqlParameter("@NewPassword", encryptPass.Item1));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageMember", parameters.ToArray());
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
