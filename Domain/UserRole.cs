using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class UserRole
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUserRole { get; set; }
        public int IdRole { get; set; }
        public int IdUser { get; set; }
        [Column(TypeName = "varchar(1)")]
        public string? State { get; set; }
        [ForeignKey("IdUser")]
        public virtual User DUser { get; set; }
        [ForeignKey("IdRole")]
        public virtual Role DRole { get; set; }
    }
}
