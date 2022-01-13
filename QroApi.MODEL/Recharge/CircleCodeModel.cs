using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QroApi.MODEL
{
   public class CircleCodeModel
    {
        public int Id { get; set; }
        public int CircleId { get; set; }
        public int ApiId { get; set; }
        public string CircleName { get; set; }
        public string CircleCode { get; set; }      
        public List<CircleCodeModel> list { get; set; }
    }
}
