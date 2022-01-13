using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QroApi.BLL
{
    public class SiteKeys
    {
        private static IConfigurationSection _configuration;
        public static void Configure(IConfigurationSection configuration)
        {
            _configuration = configuration;
        }
        public static string Domain => _configuration["Domain"];
        public static string ApiDomain => _configuration["ApiDomain"];
        public static string Token => _configuration["Secret"];
        public static string AssetsDomain => _configuration["AssetsDomain"];
        public static string SharedFolder => _configuration["SharedFolder"];
        public static string Chippertext => _configuration["Chippertext"];
    }
}
