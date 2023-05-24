using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Request
{
    public class BoxesRequestV1
    {
        public int IdBox { get; set; }
        public string? TradeMark { get; set; }
        public string? Description { get; set; }
        public string? BarCode { get; set; }
        public string? State { get; set; }
    }
}
