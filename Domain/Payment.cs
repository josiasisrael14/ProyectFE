using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPayment { get; set; }
        public int IdSchedule { get; set; }
        [Column(TypeName = "varchar(60)")]
        public string? PaymentDate { get; set; }
        [Column(TypeName = "varchar(60)")]
        public string? PaymentAmount { get; set; }
        [ForeignKey("IdSchedule")]
        public virtual Schedule DSchedule { get; set; }
    }
}
