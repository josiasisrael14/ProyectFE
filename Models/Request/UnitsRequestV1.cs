using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Request
{
    public class UnitsRequestV1
    {

        public int IdUnit { get; set; }
        public string MeasureCodeUnit { get; set; }

        public string MeasureName { get; set; }

        public int MeasureActive { get; set; }
    }
}
