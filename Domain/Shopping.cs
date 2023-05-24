using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Shopping
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPurchase { get; set; }
        public int IdProvider { get; set; }
        public int? IdUser { get; set; }
        public int IdDocumentType { get; set; }
        [ForeignKey("IdUser")]
        public virtual User DUser { get; set; }
        [ForeignKey("IdProvider")]
        public virtual Provider DProvider { get; set; }
        [ForeignKey("IdDocumentType")]
        public virtual DocumentType DDocumentType { get; set; }
    }
}
