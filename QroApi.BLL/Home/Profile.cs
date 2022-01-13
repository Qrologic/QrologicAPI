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
    public class Profile : IProfile
    {
        #region Properties
        private readonly ISQLHelper _iSQLHelper;
        #endregion
        #region Constructer
        public Profile(ISQLHelper iSQLHelper)
        {
            _iSQLHelper = iSQLHelper;
        }
        #endregion

        #region Admin
        #region Profile
        public async Task<ProfileModel> getAdmiProfile(int userId)
        {
            List<SqlParameter> prm = new List<SqlParameter>();
            prm.Add(new SqlParameter("@Action", "ViewDetail"));
            prm.Add(new SqlParameter("@Id", userId));
            DataSet ds = await _iSQLHelper.ExecuteProcedure("SP_ManageAdmin", prm.ToArray());
            ProfileModel model = new ProfileModel();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    model = ds.Tables[0].AsEnumerable().Select(s => new ProfileModel()
                    {
                        Id = s["Id"] == DBNull.Value ? 0 : Convert.ToInt32(s["Id"]),
                        UserId = s["UserId"] == DBNull.Value ? 0 : Convert.ToInt32(s["UserId"]),
                        RoleName = s["RoleName"] == DBNull.Value ? "" : Convert.ToString(s["RoleName"]),
                        Name = s["Name"] == DBNull.Value ? "" : Convert.ToString(s["Name"]),
                        Email = s["Email"] == DBNull.Value ? "" : Convert.ToString(s["Email"]),
                        Mobile = s["Mobile"] == DBNull.Value ? "" : Convert.ToString(s["Mobile"]),
                        FullAddress = s["FullAddress"] == DBNull.Value ? "" : Convert.ToString(s["FullAddress"]),
                        PanNumber = s["PanNumber"] == DBNull.Value ? "" : Convert.ToString(s["PanNumber"]),
                        AadhaarNumber = s["AadhaarNumber"] == DBNull.Value ? "" : Convert.ToString(s["AadhaarNumber"]),
                        Status = s["Status"] == DBNull.Value ? "" : Convert.ToString(s["Status"]),
                        DOJ = s["DOJ"] == DBNull.Value ? "" : Convert.ToString(s["DOJ"]),
                        Balance = s["Balance"] == DBNull.Value ? "" : Convert.ToString(s["Balance"]),
                        Image = s["Image"] == DBNull.Value ? "" : Convert.ToString(s["Image"])
                    }).FirstOrDefault();
                }
            }
            return model;
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
