using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class SaleDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdSaleDetail { get; set; }
        public int? IdSale { get; set; }
        [Column(TypeName = "varchar(60)")]
        public string? Amount { get; set; }
        [Column(TypeName = "varchar(60)")]
        public string? SalePrice { get; set; }
        [Column(TypeName = "varchar(60)")]
        public string? SubTotal { get; set; }
        public int IdFinalProduct { get; set; }
        [ForeignKey("IdSale")]
        public virtual Sale DSale { get; set; }
        [ForeignKey("IdFinalProduct")]
        public virtual FinalProduct DFinalProduct { get; set; }
    }
}
