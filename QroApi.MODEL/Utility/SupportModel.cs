using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QroApi.MODEL
{
    public class SupportModel
    {
        public int Id { get; set; }
        public int? MsrNo { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [Display(Name = "Subject")]
        public string Subject { get; set; }
        [Required]
        [Display(Name = "Message")]
        public string Message { get; set; }

        [Display(Name = "Attachment")]
        public string Attachment { get; set; }
 
        [Display(Name = "Priority")]
        public int PriorityID { get; set; }
        public string Remarks { get; set; }
        public string Date { get; set; }
        public int DateGroup { get; set; }
        public string MsgTime { get; set; }
        [Display(Name = "Attachment")]
        public IFormFile ImageFile { get; set; }
        public List<SupportModel> list { get; set; }
    }

    public class SupportResponse
    {
        public int Id { get; set; }
        public int SrNo { get; set; }
        public string Status { get; set; }
        public string MemberId { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        //public string Department { get; set; }
        //public string Priority { get; set; }
        public string Remarks { get; set; }
        //public string Attachment { get; set; }
        public string Action { get; set; }
    }
}
