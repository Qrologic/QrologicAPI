using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QroApi.MODEL
{
    public class CircleModel
    {
        public int CircleId { get; set; }
        [Required]
        [Display(Name = "Circle Name")]
        public string CircleName { get; set; }
        [Required]
        [Display(Name = "Circle Code")]
        public string CircleCode { get; set; }
    }

    public class CircleList
    {
        public int SrNo { get; set; }
        public string CircleName { get; set; }
        public string CircleCode { get; set; }
        public string Action { get; set; }
    }
}
