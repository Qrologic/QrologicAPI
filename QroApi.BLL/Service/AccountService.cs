
using QroApi.DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using QroApi.BLL;
using QroApi.MODEL;
using System.Threading.Tasks;

namespace QroApi.BLL
{
    public class AccountService : IAccountService
    {
        #region [START : PROPERTIES]
        private readonly ISQLHelper _sqlHelper;
        #endregion

        #region[START :CONSTRUCTER]
        public AccountService(ISQLHelper sqlHelper)
        {
            _sqlHelper = sqlHelper;
        }
        #endregion

        #region[START : INITIAL ADMIN USER]
        //public bool InitialAdminUser()
        //{
        //    Users user = new Users();
        //    user.UserId = "SuperAdmin";
        //    user.UserName = "SuperAdmin";
        //    user.UserEmail = "durgesh@gmail.com";
        //    user.UserAddDate = DateTime.Now;
        //    user.UserActive = true;
        //    user.UserRole = 1;
        //    var password = SecurityService.encriptPasswor("Admin@123");
        //    user.UserPassword = password.Item1;
        //    user.UserSecurityKey = password.Item2;
        //    user.UserVerified = true;
        //    user.UserContact = "1234567890";
        //    user.UserDescription = "I am Admin";
        //    _repoUser.ChangeEntityState(user, ObjectState.Added);
        //    _repoUser.SaveChanges();
        //    return true;
        //}
        #endregion

        #region[START : LOGINSERVICE]
        public async Task<Result> Login(LoginRequest model)
        {
            var pas = Security.EncryptPassword(model.Password);
            string tpass = Security.EncryptPassword("1234").Item1;
            string key= pas.Item2;
            string p = pas.Item1;
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_Login", new Dictionary<string, object>
            {
               
                {"@Action",model.Type },
                {"@LoginId",model.UserId },
                {"@Password",Security.EncryptPassword(model.Password).Item1 },
                {"@IP",model.IP},
                {"@MAC",model.MAC}
            }); 
            Result result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = Convert.ToBoolean(s["Status"]),Message = s.Field<string>("Message") }).First();
            if (result.Status && ds.Tables.Count > 0)
            {
                result.Results = ds.Tables[0].AsEnumerable().Select(s => new Users
                {
                    MsrNo= Convert.ToString(s.Field<int>("MsrNo")),
                    UserName = s.Field<string>("Name"),
                    UserId = s.Field<int>("UserId"),
                    Email = s.Field<string>("Email"),
                    Mobile = s.Field<string>("Mobile"),
                    UserRole = s.Field<string>("RoleName"),                    
                    UserImage = string.IsNullOrEmpty(s.Field<string>("Image")) ? "/img/Noimg.png" : s.Field<string>("Image")
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
