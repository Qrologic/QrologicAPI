using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QroApi.MODEL
{
    public class MemberServiceModel
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string ClassName { get; set; }
        public string ServiceIcon { get; set; }
        public string ServiceCode { get; set; }
        public List<MemberServiceModel> list { get; set; }
    }
}
