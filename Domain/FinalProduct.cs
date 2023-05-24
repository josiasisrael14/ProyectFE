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
    public class FinalProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdFinalProduct { get; set; }
        [Column(TypeName = "varchar(60)")]
        public string? SalePrice { get; set; }
        public int IdBranchOffice { get; set; }
        public int IdProduct { get; set; }
        public int IdUnit { get; set; }
        public int IdPresentation { get; set; }
        [Column(TypeName = "varchar(60)")]
        public string? PurchasePrice { get; set; }
        public int? Stock { get; set; }
        [Column(TypeName = "varchar(60)")]
        public string? FinalProductscol { get; set; }
        [ForeignKey("IdBranchOffice")]
        public virtual BranchOffice DBranchOffice { get; set; }
        [ForeignKey("IdUnit")]
        public virtual Unit DUnit { get; set; }
        [ForeignKey("IdProduct")]
        public virtual Product DProduct { get; set; }
        [ForeignKey("IdPresentation")]
        public virtual Presentation DPresentation { get; set; }
    }
}
