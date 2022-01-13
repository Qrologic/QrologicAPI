using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QroApi.MODEL
{
    public class MenuDisplay
    {
        public int id { get; set; }
        public string text { get; set; }
        public Boolean @checked { get; set; }
        public List<MenuDisplay> children { get; set; }
    }
}
