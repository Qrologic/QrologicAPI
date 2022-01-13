using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QroApi.Core
{
    #region [START : MESSAGETYPE]
    public enum MessageType
    {
        Warning,
        Success,
        Danger,
        Info
    }
    #endregion

    #region [START : Email Type]
    public enum EmailType
    {
        [Display(Name = "Registration")]
        Register = 1,
        [Display(Name = "Forgot Password")]
        ForgotPassword = 2,
        [Display(Name = "Contact Enquiry")]
        ContactEnquiry = 3,
        [Display(Name = "Change Password")]
        ChangePassword = 4,
        [Display(Name = "FeedBack")]
        FeedBack = 5,
    }
    #endregion
}
