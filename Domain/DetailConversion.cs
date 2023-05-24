using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class DetailConversion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDetailConversions { get; set; }
        public int? Factor { get; set; }
        public int? amount { get; set; }
        public int? SubTotal { get; set; }
        public int IdConversion { get; set; }
        [ForeignKey("IdConversion")]
        public virtual Conversion DConversion { get; set; }
    }
}
