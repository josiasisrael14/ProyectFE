using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class BranchOffice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdBranchOffice { get; set; }
        public int IdCompany { get; set; }
        [Column(TypeName = "varchar(1)")]
        public string? State { get; set; }
        [ForeignKey("IdCompany")]
        public virtual Company DCompany { get; set; }
    }
}
