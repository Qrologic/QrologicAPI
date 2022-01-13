using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QroApi.MODEL
{
    public class PackageWiseApi
    {
        [Required (ErrorMessage ="Please Select Package")]
        [Display (Name ="Package")]
        public int packageId { get; set; }
        [Required(ErrorMessage = "Please Select Api")]
        [Display(Name = "API")]
        public int apiId { get; set; }
    }

    public class OperatorWiseApi
    {
        public int OperatorId { get; set; }
        public int ApiId { get; set; }
        public string OperatorName { get; set; }
        public List<OperatorWiseApi> list { get; set; }
    }
}
