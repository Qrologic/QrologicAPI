using QroApi.BLL;
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
    public class UtilityService: IUtilityService
	{
		#region [START : PROPERTIES]
		private readonly ISQLHelper _sqlHelper;
		#endregion

		#region[START :CONSTRUCTER]
		public UtilityService(ISQLHelper sqlHelper)
		{
			_sqlHelper = sqlHelper;
		}
        #endregion

        #region Get State
        public async Task<Result> GetState(int countryId)
        {
			List<SqlParameter> parameters = new List<SqlParameter>();
			parameters.Add(new SqlParameter("@Action", "GetByCountryID"));
			parameters.Add(new SqlParameter("@ID", countryId));
			DataSet ds =await _sqlHelper.ExecuteProcedure("SP_ManageState", parameters.ToArray());
			Result result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = true, Message = "Data Fatched" }).First();
			result.Results = ds.Tables[0].AsEnumerable().Select(s => new
			{
				Id = Convert.ToInt32(s["StateID"]),
				StateName = s.Field<string>("StateName"),

			}).ToList();
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
				CityName = s.Field<string>("CityName"),
				
			}).ToList();
			return result;
		}
		#endregion

		#region Get Role
		public async Task<Result> GetRole(int userId)
		{
			List<SqlParameter> parameters = new List<SqlParameter>();
			parameters.Add(new SqlParameter("@Action", "GetByUserId"));
			parameters.Add(new SqlParameter("@UserId", userId));
			DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageRole", parameters.ToArray());
			Result result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = true, Message = "Data Fatched" }).First();
			result.Results = ds.Tables[0].AsEnumerable().Select(s => new
			{
				Id = Convert.ToInt32(s["Id"]),
				RoleName = s.Field<string>("RoleName"),

			}).ToList();
			return result;
		}
		#endregion

		#region Get Package
		public async Task<Result> GetPackage(int MsrNo)
		{
		
			List<SqlParameter> parameters = new List<SqlParameter>();
			parameters.Add(new SqlParameter("@Action", "GetByMsrNo"));
			parameters.Add(new SqlParameter("@ID", MsrNo));
			parameters.Add(new SqlParameter("@MsrNo", MsrNo));
			parameters.Add(new SqlParameter("@PackageName", ""));
			DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManagePackage", parameters.ToArray());
			Result result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = true, Message = "Data Fatched" }).First();
			result.Results = ds.Tables[0].AsEnumerable().Select(s => new
			{
				Id = Convert.ToInt32(s["PackageID"]),
				PackageName = s.Field<string>("PackageName"),

			}).ToList();
			return result;
		}
		#endregion

		#region Get Country
		public async Task<Result> GetCountry()
		{
			List<SqlParameter> parameters = new List<SqlParameter>();
			parameters.Add(new SqlParameter("@Action", "Get"));
			
			DataSet ds =await _sqlHelper.ExecuteProcedure("SP_ManageCountry", parameters.ToArray());
			Result result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = true, Message = "Data Fatched" }).First();
			result.Results = ds.Tables[0].AsEnumerable().Select(s => new
			{
				Id = Convert.ToInt32(s["CountryID"]),
				CountryName = s.Field<string>("CountryName"),

			}).ToList();
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
