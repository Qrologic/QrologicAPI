using System;

namespace QroApi.MODEL
{
    public class Result
    {
        public bool Status { get; set; }
        public int ErrorCode { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
        public string RedirectUrl { get; set; }
        public dynamic Results { get; set; }
        public bool isRedirect { get; set; }
        public bool IsPost { get; set; } = false;

    }
}
