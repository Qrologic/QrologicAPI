using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QroApi.MODEL
{
    public class basicApi
    {
        public class apiResponse
        {
            public string statuscode { get; set; }
            public string status { get; set; }           
            public dynamic data { get; set; }
            public string timestamp { get; set; }
            public string orderid { get; set; }
            public string token { get; set; }
        }
    }
}
