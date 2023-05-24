using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class DetailShopping
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDetailShopping { get; set; }
        public int? IdPurchase { get; set; }
        public int IdFinalProduct { get; set; }
        [ForeignKey("IdPurchase")]
        public virtual Shopping DShopping { get; set; }
        [ForeignKey("IdFinalProduct")]
        public virtual FinalProduct DFinalProduct { get; set; }
    }
}
