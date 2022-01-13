using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QroApi.MODEL
{
   public class MenuRoleLink
    {
        public int Id { get; set; }
        public int MenuID { get; set; }
        public int RoleID { get; set; }
        public Nullable<int> CUserID { get; set; }
        public Nullable<int> MUserID { get; set; }
        public System.DateTime AddedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string IP { get; set; }
    }
}
