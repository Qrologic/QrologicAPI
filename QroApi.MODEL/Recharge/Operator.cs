using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QroApi.MODEL
{
    public class Operator
    {
        public int OperatorId { get; set; }
        [Display(Name ="Service")]
        [Required]
        [Range(0, int.MaxValue)]
        public int ServiceId { get; set; }
        [Display(Name = "Operator Name")]
        [Required]
        public string OperatorName { get; set; }
        [Display(Name = "Operator Code")]
        [Required]
        public string OperatorCode { get; set; }
       
        public string OperatorImage { get; set; }
        public int ActiveApi { get; set; }
      
        [Display(Name="Operator Image")]
        public IFormFile ImageFile { get; set; }

    }
    public class OperatorList
    {
        public int SrNo { get; set; }
        public string ServiceName { get; set; }
        public string OperatorName { get; set; }
        public string OperatorCode { get; set; }
        public string Action { get; set; }
    }
}
