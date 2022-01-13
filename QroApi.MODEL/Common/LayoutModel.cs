using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QroApi.MODEL
{
    public class LayoutModel
    {
        public int Id { get; set; }
        public int MsrNo { get; set; }
        public string SidebarClass  { get; set; }
        public string TopbarClass { get; set; }
        public string Type { get; set; }
    }
}
