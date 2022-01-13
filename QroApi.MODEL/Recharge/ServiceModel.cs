using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QroApi.MODEL
{
    public class ServiceModel
    {
        public int ServiceId { get; set; }
        [Required]
        [Display(Name ="Service Name")]
        public string ServiceName { get; set; }
    }
    public class ServiceList
    {
        public int SrNo { get; set; }
        public string ServiceName { get; set; }
        public string Action { get; set; }
    }
}
