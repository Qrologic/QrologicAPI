using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QroApi.MODEL
{
    public class CityModel
    {
        [Display(Name = "City")]
        public int CityId { get; set; }
        [Required]
        [Display(Name = "State")]
        public int? StateId { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [Display(Name = "City")]
        public string CityName { get; set; }
        [MaxLength(10)]
        [Required]
        [Display(Name = "City Code")]
        public string CityCode { get; set; }
        public List<CityModel> listCity { get; set; }
    }

    public class CityResponse
    {
        public int Id { get; set; }
        public int SrNo { get; set; }
        public string CityName { get; set; }
        public string CityCode { get; set; }
        public string Action { get; set; }
    }

}
