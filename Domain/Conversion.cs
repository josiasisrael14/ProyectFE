using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Conversion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdConversion { get; set; }
        public int IdFinalProduct { get; set; }
        public int Factor { get; set; }
        public int? IdUser { get; set; }
        [ForeignKey("IdUser")]
        public virtual User DUser { get; set; }
        [ForeignKey("IdFinalProduct")]
        public virtual FinalProduct DFinalProduct { get; set; }
    }
}
