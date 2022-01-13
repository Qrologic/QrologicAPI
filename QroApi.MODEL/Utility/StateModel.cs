using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QroApi.MODEL
{
    public class StateModel
    {
        [Display(Name = "State")]
        public int StateId { get; set; }
        [Required]
        [Display(Name = "Country")]
        public int? CountryId { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [Display(Name = "State")]
        public string StateName { get; set; }
        [MaxLength(10)]
        [Required]
        [Display(Name = "State Code")]
        public string StateCode { get; set; }

        [MaxLength(10)]
        [Display(Name = "Tin")]
        public string Tin { get; set; }
        public List<StateModel> listState { get; set; }
    }

    public class StateResponse
    {
        public int Id { get; set; }
        public int SrNo { get; set; }
        public string StateName { get; set; }
        public string StateCode { get; set; }
        public string Tin { get; set; }
        public string Action { get; set; }
    }

}
