using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QroApi.DLL
{
   public interface ISQLHelper:IDisposable
    {
        public  Task<DataSet> ExecuteProcedure(string procedureName, IDictionary<string, object> Parameters);
        public Task<DataSet> ExecuteProcedure(string procedureName, params SqlParameter[] param);
        Task<int> ExecuteScalerInt(string storeProcedureName, params SqlParameter[] Parameters);
        Task<string> ExecuteScalerString(string storeProcedureName, params SqlParameter[] Parameters);
    }
}
