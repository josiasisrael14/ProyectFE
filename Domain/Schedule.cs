using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Schedule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdSchedule { get; set; }
        public int IdSale { get; set; }
        [Column(TypeName = "varchar(60)")]
        public string? PaymentDate { get; set; }
        [Column(TypeName = "varchar(60)")]
        public string? QuotaAmount { get; set; }
        [Column(TypeName = "varchar(60)")]
        public string? AmountPaid { get; set; }

        [ForeignKey("IdSale")]
        public virtual Sale DSale { get; set; }
    }
}
