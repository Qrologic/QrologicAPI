using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace QroApi.MODEL
{
    public class PackageModel
    {
        public int PackageId { get; set; }
        public int MsrNo { get; set; }
        [Required (ErrorMessage ="Please Enter Package Name !")]
        [Display(Name = "Package Name")]
        public string PackageName { get; set; }
    }
    public class PackageList
    {
        public int SrNo { get; set; }    
        public string PackageName { get; set; }
        public string Action { get; set; }
    }
    public class AssignedService
    {
        public int Id { get; set; }

        public int MsrNo { get; set; }
        public string MemberName { get; set; }
        public int PackageId { get; set; }
        public string PackageName { get; set; }
        public string ServiceName { get; set; }
        public int ServiceId { get; set; }
        public bool IsAssign { get; set; }
        public List<AssignedService> list { get; set; }
    }
}
