using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QroApi.MODEL
{
    public class OperatorCodeModel
    {
        public int Id { get; set; }
        public int OperatorId { get; set; }
        public int ApiId { get; set; }
        public string OperatorName { get; set; }
        public string OperatorCode { get; set; }
        public decimal Commission { get; set; }
        public bool CommissionIsFlat { get; set; }
        public decimal Surcharge { get; set; }
        public bool SurchargeIsFlat { get; set; }
        public List<OperatorCodeModel> list { get; set; }
    }
}
