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
    public class Settings : ISettings
    {
        #region [START : PROPERTIES]
        private readonly ISQLHelper _sqlHelper;
        #endregion

        #region[CONSTRUCTER]
        public Settings(ISQLHelper sqlHelper)
        {
            _sqlHelper = sqlHelper;
        }
        #endregion
       
        #region Add Edit Company Detail
        public async Task<Result> AddEditCompanyDetail(CompanyModel model)
        {
           
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "Insert"));
            parameters.Add(new SqlParameter("@Id", model.Id));
            parameters.Add(new SqlParameter("@MsrNo", model.MsrNo));
            parameters.Add(new SqlParameter("@CompanyName", model.CompanyName));
            parameters.Add(new SqlParameter("@CompanyLogo", model.CompanyLogo));
            parameters.Add(new SqlParameter("@CompanyOwner", model.CompanyOwner));
            parameters.Add(new SqlParameter("@Mobile", model.Mobile));
            parameters.Add(new SqlParameter("@Email", model.Email));
            parameters.Add(new SqlParameter("@WebsiteUrl", model.WebsiteUrl));
            parameters.Add(new SqlParameter("@GstNo", model.GstNo));
            parameters.Add(new SqlParameter("@CIN", model.CIN));
            parameters.Add(new SqlParameter("@PanNo", model.PanNo));
            parameters.Add(new SqlParameter("@TanNo", model.TanNo));
            parameters.Add(new SqlParameter("@Copyright", model.Copyright));
            parameters.Add(new SqlParameter("@Address", model.Address));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageCompany", parameters.ToArray());
            Result result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = Convert.ToBoolean(s["Status"]), Message = s.Field<string>("Message") }).First();
            return result;
        
        }
        #endregion

        #region Update Logo
        public async Task<Result> UpdateCompanyLogo(CompanyModel model,string type)
        {

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", type=="logo"? "UpdateLogo": "UpdateFevicon"));
            parameters.Add(new SqlParameter("@Id", model.Id));         
            parameters.Add(new SqlParameter("@CompanyLogo", model.CompanyLogo));          
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageCompany", parameters.ToArray());
            Result result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = Convert.ToBoolean(s["Status"]), Message = s.Field<string>("Message") }).First();
            return result;

        }
        #endregion

        #region Get Company Detail By Id
        public async Task<CompanyModel> GetCompanyDetailById(int id)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "GetById"));
            parameters.Add(new SqlParameter("@MsrNo", id));
            CompanyModel model = new CompanyModel();
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageCompany", parameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    model = ds.Tables[0].AsEnumerable().Select(s => new CompanyModel
                    {
                        Id = Convert.ToInt32(s["Id"] == DBNull.Value ? 0 : s["Id"]),
                        MsrNo = Convert.ToInt32(s["MsrNo"] == DBNull.Value ? 0 : s["MsrNo"]),
                        CompanyName = Convert.ToString(s["CompanyName"] == DBNull.Value ? "" : s["CompanyName"]),
                        CompanyLogo = Convert.ToString(s["CompanyLogo"] == DBNull.Value ? "" : s["CompanyLogo"]),
                        FeviconIcon = Convert.ToString(s["FeviconIcon"] == DBNull.Value ? "" : s["FeviconIcon"]),
                        CompanyOwner = Convert.ToString(s["CompanyOwner"] == DBNull.Value ? "" : s["CompanyOwner"]),
                        Mobile = Convert.ToString(s["Mobile"] == DBNull.Value ? "" : s["Mobile"]),
                        Email = Convert.ToString(s["Email"] == DBNull.Value ? "" : s["Email"]),
                        WebsiteUrl = Convert.ToString(s["WebsiteUrl"] == DBNull.Value ? "" : s["WebsiteUrl"]),
                        GstNo = Convert.ToString(s["GstNo"] == DBNull.Value ? "" : s["GstNo"]),
                        CIN = Convert.ToString(s["CIN"] == DBNull.Value ? "" : s["CIN"]),
                        PanNo = Convert.ToString(s["PanNo"] == DBNull.Value ? "" : s["PanNo"]),
                        TanNo = Convert.ToString(s["TanNo"] == DBNull.Value ? "" : s["TanNo"]),
                        Copyright = Convert.ToString(s["Copyright"] == DBNull.Value ? "" : s["Copyright"]),
                        Address = Convert.ToString(s["Address"] == DBNull.Value ? "" : s["Address"]),

                    }).FirstOrDefault();
                }
            }
            return model;
        }
        #endregion

        #region MemberBank
        #region Get Member Bank List
        public async Task<ReportList> GetMemberBankList(string search, int pageIndex, int pageSize, string sortCol, string sortDir,int msrNo)
        {
            ReportList rpList = new ReportList();
            List<MemberBankResponse> list = new List<MemberBankResponse>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "GetAll"));
            parameters.Add(new SqlParameter("@PageIndex", pageIndex));
            parameters.Add(new SqlParameter("@PageSize", pageSize));
            parameters.Add(new SqlParameter("@Search", search));
            parameters.Add(new SqlParameter("@MsrNo", msrNo));
            int totalRecord = 0;
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageMemberBank", parameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataView dv = new DataView(ds.Tables[0]);
                    dv.Sort = sortCol + " " + sortDir;
                    totalRecord = Convert.ToInt32(ds.Tables[0].Rows[0]["TotalRow"].ToString());
                    list = ds.Tables[0].AsEnumerable().Select(s => new MemberBankResponse
                    {
                        SrNo = Convert.ToInt32(s["SrNo"] == null ? 0 : s["SrNo"]),
                        BankName = Convert.ToString(s["BankName"] == DBNull.Value ? "" : s["BankName"]),
                        Branch = Convert.ToString(s["Branch"] == DBNull.Value ? "" : s["Branch"]),
                        AccountNumber = Convert.ToString(s["AccountNumber"] == DBNull.Value ? "" : s["AccountNumber"]),
                        Ifsc = Convert.ToString(s["IFSC"] == DBNull.Value ? "" : s["IFSC"]),
                        AccountHolder = Convert.ToString(s["AccountHolder"] == DBNull.Value ? "" : s["AccountHolder"]),
                        Action = Convert.ToString(s["Action"] == DBNull.Value ? "" : s["Action"])
                    }).ToList();
                }
            }
            rpList.recordsFiltered = totalRecord;
            rpList.recordsTotal = totalRecord;
            rpList.data = list;
            return rpList;
        }
        #endregion

        #region GetMemberBankById
        public async Task<MemberBankModel> GetMemberBankById(int id)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "GetById"));
            parameters.Add(new SqlParameter("@Id", id));
            MemberBankModel model = new MemberBankModel();
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageMemberBank", parameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    model = ds.Tables[0].AsEnumerable().Select(s => new MemberBankModel
                    {
                        BankId = Convert.ToInt32(s["BankId"] == DBNull.Value ? 0 : s["BankId"]),
                        Branch = Convert.ToString(s["Branch"] == DBNull.Value ? "" : s["Branch"]),
                        AccountNumber = Convert.ToString(s["AccountNumber"] == DBNull.Value ? "" : s["AccountNumber"]),
                        IFSC = Convert.ToString(s["IFSC"] == DBNull.Value ? "" : s["IFSC"]),
                        AccountHolder = Convert.ToString(s["AccountHolder"] == DBNull.Value ? "" : s["AccountHolder"])
                    }).FirstOrDefault();
                }
            }
            return model;
        }
        #endregion
        #region Add Edit MemberBank
        public async Task<Result> AddEditMemberBank(MemberBankModel model)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "Insert"));
            parameters.Add(new SqlParameter("@ID", model.Id));
            parameters.Add(new SqlParameter("@MsrNo", model.MsrNo));
            parameters.Add(new SqlParameter("@BankId", model.BankId));
            parameters.Add(new SqlParameter("@Branch", model.Branch));
            parameters.Add(new SqlParameter("@AccountNumber", model.AccountNumber));
            parameters.Add(new SqlParameter("@IFSC", model.IFSC));
            parameters.Add(new SqlParameter("@AccountHolder", model.AccountHolder));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageMemberBank", parameters.ToArray());
            Result result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = Convert.ToBoolean(s["Status"]), Message = s.Field<string>("Message") }).First();
            return result;
        }
        #endregion

        #region Delete MemberBank
        public async Task<Result> DeleteMemberBank(int id)
        {
            Result result = new Result();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "IsDelete"));
            parameters.Add(new SqlParameter("@ID", id));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageMemberBank", parameters.ToArray());
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

        #region Active / Deactive MemberBank
        public async Task<Result> ActiveMemberBank(int id)
        {
            Result result = new Result();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "IsActive"));
            parameters.Add(new SqlParameter("@ID", id));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageMemberBank", parameters.ToArray());
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
