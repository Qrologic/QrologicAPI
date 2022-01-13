using System;
using System.Collections.Generic;
using System.Text;

namespace QroApi.Core
{
    #region [START : USERROLES] 
    public struct Role
    {
        public const string SuperAdmin = "Super Admin";
        public const string Admin = "Admin";
        public const string SuperDistributor = "Super Distributor";
        public const string MasterDistributor = "Master Distributor";
        public const string Distributor = "Distributor";
        public const string Retailer = "Retailer";
        public const string Customer = "Customer";
        public const string SubAdmin = "Sub Admin";
        public const string Reseller = "Reseller";
        public const string ApiMember = "API Member";
        public const string User = SuperDistributor+","+ MasterDistributor + "," + Distributor + "," + Retailer + "," + Customer;
    }
    #endregion

    #region [START : Notification]
    public class Notification
    {
        public string Heading { get; set; }
        public string Message { get; set; }
        public MessageType Type { get; set; }
        public string Icon
        {
            get
            {
                switch (this.Type)
                {
                    case MessageType.Warning:
                        return "fa fa-exclamation-triangle";
                    case MessageType.Success:
                        return "fa fa-check-circle";
                    case MessageType.Danger:
                        return "fa fa-question-circle";
                    case MessageType.Info:
                        return "fa fa-exclamation-circle";
                    default:
                        return "fa fa-exclamation-circle";
                }
            }
        }
    }
    #endregion

    #region [START : Message]
    public class Message
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string DisplayName { get; set; }
        public string FontAwesomeIcon { get; set; }
        public string AvatarURL { get; set; }
        public string URLPath { get; set; }
        public string ShortDesc { get; set; }
        public string TimeSpan { get; set; }
        public int Percentage { get; set; }
        public string Type { get; set; }
    }
    #endregion
}
