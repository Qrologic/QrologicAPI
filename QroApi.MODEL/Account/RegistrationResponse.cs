using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QroApi.MODEL
{
    public class RegistrationResponse
    {

        public Int32 MsrNo { get; set; }
        public string MemberId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string TPassword { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }

    }
}
