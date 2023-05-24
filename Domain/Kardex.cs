using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Kardex
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idKardex { get; set; }
        public int idTypeMovement { get; set; }
        public int IdFinalProduct { get; set; }
        [Column(TypeName = "varchar(60)")]
        public string? IdTypeTransaccion { get; set; }
        public int? IdUser { get; set; }
        [ForeignKey("IdUser")]
        public virtual User DUser { get; set; }
        [ForeignKey("idTypeMovement")]
        public virtual MovementType DMovementType { get; set; }
        [ForeignKey("IdFinalProduct")]
        public virtual FinalProduct DFinalProduct { get; set; }
    }
}
