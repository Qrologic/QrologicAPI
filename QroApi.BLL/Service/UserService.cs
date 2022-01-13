using QroApi.DLL;
using QroApi.MODEL;
using QroApi.BLL;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Security.Claims;
using System.Threading.Tasks;

namespace QroApi.Service
{
    public class UserService : IUserService
    {
        #region [START : PROPERTIES]
        private readonly ISQLHelper _sqlHelper;
        #endregion

        #region[START :CONSTRUCTER]
        public UserService(ISQLHelper sqlHelper)
        {
            _sqlHelper = sqlHelper;
        }
        #endregion

        #region [START : USER REGISTER] 
        public async Task<Result> User_Register(UserRegistration model)
        {
            var encryptPass = model.Password.EncryptPassword();
            var encryptTPass = GenerateTranPwd().EncryptPassword();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Type", model.Type));
            parameters.Add(new SqlParameter("@Id", model.Id));
            parameters.Add(new SqlParameter("@UserId", model.UserId));
            parameters.Add(new SqlParameter("@UserName", model.UserName));
            parameters.Add(new SqlParameter("@CompanyName", model.CompanyName));
            parameters.Add(new SqlParameter("@Email", model.Email));
            parameters.Add(new SqlParameter("@Mobile", model.Mobile));
            parameters.Add(new SqlParameter("@UserImage", model.UserImage));
            parameters.Add(new SqlParameter("@SecurityKey", encryptPass.Item2));
            parameters.Add(new SqlParameter("@Password", encryptPass.Item1));
            parameters.Add(new SqlParameter("@UserRole", model.UserRole));
            parameters.Add(new SqlParameter("@TPassword", encryptTPass.Item1));
            parameters.Add(new SqlParameter("@ParentMsrNo", model.ParentMsrNo));
            parameters.Add(new SqlParameter("@PackageId", model.PackageId));
            parameters.Add(new SqlParameter("@Address", model.Address));
            parameters.Add(new SqlParameter("@CountryId", model.CountryId));
            parameters.Add(new SqlParameter("@StateId", model.StateId));
            parameters.Add(new SqlParameter("@CityId", model.CityId));
            parameters.Add(new SqlParameter("@Zip", model.Zip));
            parameters.Add(new SqlParameter("@Source", model.Source));
            parameters.Add(new SqlParameter("@LastLoginIP", model.LastLoginIP));
            parameters.Add(new SqlParameter("@PanNumber", model.PanNumber));
            parameters.Add(new SqlParameter("@AadharNumber", model.AadharNumber));
            parameters.Add(new SqlParameter("@IP", model.IP));
            parameters.Add(new SqlParameter("@MAC", model.MAC));

            DataSet ds =await _sqlHelper.ExecuteProcedure("SP_UserRegistration", parameters.ToArray());
            Result result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = Convert.ToBoolean(s["Status"]), Message = s.Field<string>("Message") }).First();
            if (result.Status && ds.Tables.Count > 0)
            {
                result.Results = ds.Tables[0].AsEnumerable().Select(s => new RegistrationResponse
                {
                    MsrNo = s.Field<Int32>("MsrNo"),
                    MemberId = s.Field<string>("MemberId"),
                    Name = s.Field<string>("Name"),
                    Password = s.Field<string>("Password"),
                    TPassword = s.Field<string>("TPassword"),
                    Email = s.Field<string>("Email"),
                    Mobile = s.Field<string>("Mobile")
                }).First();
            }
            return result;
        }

        #region generatePassword
        private string generatePassword()
        {
            Random generator = new Random();
            string r = generator.Next(0, 99999).ToString("D5");
            return r;
        }
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
        #endregion

        #region [START : Get Sponser Details] 
        public async Task<Result> GetSponserDetails(string SponsorId)
        {
            DataSet ds =await _sqlHelper.ExecuteProcedure("SP_GetSponsor", new Dictionary<string, object>
            {
                {"@SponsorId",SponsorId},
            });
            Result result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = Convert.ToBoolean(s["Status"]), Message = s.Field<string>("Message") }).First();
            if (result.Status && ds.Tables.Count > 0)
            {
                result.Results = ds.Tables[0].AsEnumerable().Select(s => new
                {
                    MemberId = s.Field<string>("MemberId"),
                    Name = s.Field<string>("Name")
                }).First();


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
