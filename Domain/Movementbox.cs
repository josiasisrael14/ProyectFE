using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Movementbox
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMovementbox { get; set; }
        public int? IdUser { get; set; }
        public int IdBoxOpening { get; set; }
        [Column(TypeName = "varchar(60)")]
        public string? Amount { get; set; }
        public int IdTypeMovement { get; set; }
        [ForeignKey("IdUser")]
        public virtual User DUser { get; set; }
        [ForeignKey("IdBoxOpening")]
        public virtual BoxOpening DBoxOpening { get; set; }
        [ForeignKey("IdTypeMovement")]
        public virtual MovementType DMovementType { get; set; }
    }
}