using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QroApi.MODEL
{
    public class DatatableParam
    {
       public string search { get; set; } 
       public string draw { get; set; }
       public string order { get; set; }
       public string orderDir { get; set; }
       public int startRec { get; set; }
       public int pageSize { get; set; }
    }
}
