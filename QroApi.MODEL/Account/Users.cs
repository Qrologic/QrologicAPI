using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QroApi.MODEL
{
    public class Users
    {
        public int Id { get; set; }
        public string MsrNo { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string UserImage { get; set; }
        public string SecurityKey { get; set; }
        public string Password { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsVerified { get; set; }
        public bool IsActive { get; set; }
        public string UserRole { get; set; }      
        public bool IsDeleted { get; set; }
        public bool IsEmailVerified { get; set; }
        public bool IsBlock { get; set; }
        public string TPassword { get; set; }
    }

    
}
