using QroApi.DLL;
using QroApi.MODEL;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QroApi.BLL
{
    public class CommonClass: ICommonClass
    {
        #region Properties & Constructor
        private readonly ISQLHelper _sqlHelper;
       
        public CommonClass(ISQLHelper sqlHelper)
        {
            _sqlHelper = sqlHelper;
        }
        #endregion

        public async Task<Result> AddEditLayout(LayoutModel model)
        {
            Result result = new Result();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "Insert"));
            parameters.Add(new SqlParameter("@MsrNo", model.MsrNo));
            parameters.Add(new SqlParameter("@SidebarClass", model.SidebarClass));
            parameters.Add(new SqlParameter("@TopbarClass", model.TopbarClass));
            parameters.Add(new SqlParameter("@Type", model.Type));
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageLayout", parameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = Convert.ToBoolean(s["Status"]), Message = s.Field<string>("Message") }).First();
                }
            }
            return result;
        }
        public async Task<Result> GetLayout(int msrNo)
        {
            Result result = new Result();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "Get"));
            parameters.Add(new SqlParameter("@MsrNo", msrNo));
           
            DataSet ds = await _sqlHelper.ExecuteProcedure("SP_ManageLayout", parameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    result = ds.Tables[0].AsEnumerable().Select(s => new Result { Status = Convert.ToBoolean(s["Status"]), Message = s.Field<string>("Message") }).First();
                    result.Results = ds.Tables[0].AsEnumerable().Select(s => new LayoutModel
                    {
                        SidebarClass = s["SideBarClass"] == DBNull.Value ? "" : Convert.ToString(s["SideBarClass"]),
                        TopbarClass = s["TopBarClass"] == DBNull.Value ? "" : Convert.ToString(s["TopBarClass"])

                    }).First();
                }
            }
            return result;
        }

        public async Task<string> UploadImage(string path, IFormFile imageFile)
        {
            string imageName = "";
            try
            {
                string uploadsFolder = Path.Combine(path, "images/UploadImages");
                string fileName = Path.GetFileNameWithoutExtension(imageFile.FileName);
                string extension = Path.GetExtension(imageFile.FileName);
                imageName = fileName = fileName + Guid.NewGuid().ToString() + extension;
                path = Path.Combine(uploadsFolder, fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await imageFile.CopyToAsync(fileStream);
                }
            }
            catch (Exception ex) { }
            return imageName;
        }
        public async Task<string> UploadFevicon(string path, IFormFile imageFile)
        {
            string imageName = "";
            try
            {
                string uploadsFolder = path;
                string fileName = "favicon";// Path.GetFileNameWithoutExtension(imageFile.FileName);
                string extension = ".ico";// Path.GetExtension(imageFile.FileName);
                imageName = fileName=fileName + extension;//= fileName + Guid.NewGuid().ToString() + extension;
                path = Path.Combine(uploadsFolder, fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await imageFile.CopyToAsync(fileStream);
                }
            }
            catch (Exception ex) { }
            return imageName;
        }
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
