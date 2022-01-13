using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QroApi.MODEL
{
    public class ApiList
    {
        public int ApiId { get; set; }
        public string ApiName { get; set; }
        public string BalanceUrl { get; set; }
        public string Balance { get; set; }
        public string Status { get; set; }

        public string BalanceParam { get; set; }
        public List<ApiList> listApi { get; set; }
    
    }
}
