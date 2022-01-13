using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QroApi.MODEL
{
    public class BBPS
    {

        public class BillFatch
        {
            [JsonProperty("operator")]
            public int _operator { get; set; }
            public string canumber { get; set; }
            public string mode { get; set; }
        }
        public class BillFetchDetail
        {
            public string billAmount { get; set; }
            public string billnetamount { get; set; }
            public string billdate { get; set; }
            public string dueDate { get; set; }
            public bool acceptPayment { get; set; }
            public bool acceptPartPay { get; set; }
            public string cellNumber { get; set; }
            public string userName { get; set; }
        }

        public class BillPayRequest
        {
            public int serviceId { get; set; }
            public int operatorId { get; set; }
            [JsonProperty("operator")]
            public string _operator { get; set; }
            public string canumber { get; set; }
            public string amount { get; set; }
            public string referenceid { get; set; }
            public string latitude { get; set; }
            public string longitude { get; set; }
            public string mode { get; set; }
            public string mobile { get; set; }
            public BillFetchDetail bill_fetch { get; set; }
        }
        public class Response
        {
            public int id { get; set; }
            public bool status { get; set; }
            public int response_code { get; set; }
            public string message { get; set; }
            public dynamic data { get; set; }
            public string operatorid { get; set; }
            public int ackno { get; set; }
            public string refid { get; set; }
        }
    }
}
