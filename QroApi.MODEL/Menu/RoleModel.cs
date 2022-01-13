using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QroApi.MODEL
{
    public class RoleModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Role")]
        public string UserRole { get; set; }
    }
    public class RoleResponse
    {
        public int Id { get; set; }
        public int SrNo { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }
        public string Action { get; set; }
        public List<RoleResponse> list { get; set; }
    }
}
