using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace QroApi.Core
{
   public static class Network
    {
        static Network()
        {

        }

 
        public static string GetIPAddress(HttpContext context)
        {
            string ip = string.Empty;
            if (!string.IsNullOrEmpty(context.Request.Headers["X-Forwarded-For"]))
            {
                ip = context.Request.Headers["X-Forwarded-For"];
            }
            else
            {
                ip = context.Request.HttpContext.Features.Get<IHttpConnectionFeature>().RemoteIpAddress.ToString();
            }
            return ip;
        }
        public static string GetMACAddress()
        {
            String sMacAddress = string.Empty;
            try
            {
                NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
                foreach (NetworkInterface adapter in nics)
                {
                    if (sMacAddress == String.Empty)// only return MAC Address from first card  
                    {
                        IPInterfaceProperties properties = adapter.GetIPProperties();
                        sMacAddress = adapter.GetPhysicalAddress().ToString();
                    }
                }
            }
            catch { sMacAddress = string.Empty; }
            return sMacAddress;
        }
    }
}
