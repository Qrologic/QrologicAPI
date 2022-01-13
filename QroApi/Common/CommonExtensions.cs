using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace QroApi.Core
{
    public static class IdentityExtensions
    {
        public static string GetDetailOf(this IIdentity identity, string claimName)
        {
            string _returnString = string.Empty;
            var claimsIndentity = ((ClaimsIdentity)identity);
            var userClaims = claimsIndentity.Claims;
            foreach (var claim in userClaims)
            {
                var cType = claim.Type;
                var cValue = claim.Value;
                if (claimName == cType)
                {
                    _returnString = (cValue != null) ? cValue : string.Empty;
                }
            }
            return _returnString;
        }
        public static void AddOrReplace(this IDictionary<string, object> DICT, string key, object value)
        {
            if (DICT.ContainsKey(key))
                DICT[key] = value;
            else
                DICT.Add(key, value);
        }
    }
}
