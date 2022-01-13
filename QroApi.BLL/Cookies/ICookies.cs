using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QroApi.BLL
{
    public interface ICookies : IDisposable
    {
        string GetCookie(string key);
        void SetCookie(string key, string value, double? expireTime);
        void RemoveCookie(string key);
    }
}
