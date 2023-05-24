using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Sale
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdSale { get; set; }
        public int IdClient { get; set; }
        public int? IdUser { get; set; }
        public int IdDocumentType { get; set; }
        public int IdBox { get; set; }
        public int IdPaymentType { get; set; }
        [ForeignKey("IdUser")]
        public virtual User DUser { get; set; }
        [ForeignKey("IdClient")]
        public virtual Client DClient { get; set; }
        [ForeignKey("IdDocumentType")]
        public virtual DocumentType DDocumentType { get; set; }
        [ForeignKey("IdBox")]
        public virtual Box DBox { get; set; }
        [ForeignKey("IdPaymentType")]
        public virtual PaymentType DPaymentType { get; set; }
    }
}
