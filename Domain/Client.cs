using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdClient { get; set; }
        public int IdBranchOffice { get; set; }
        public int? IdTypeClient { get; set; }
        [Column(TypeName = "varchar(25)")]
        public string? DniRucClient { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string? NameClient { get; set; }
        [Column(TypeName = "varchar(80)")]
        public string? DirectionClient { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string? TelephoneClient { get; set; }
        [Column(TypeName = "varchar(1)")]
        public string? State { get; set; }
        [ForeignKey("IdBranchOffice")]
        public virtual BranchOffice BranchOffice { get; set; }
        [ForeignKey("IdTypeClient")]
        public virtual TypeClient TypeClient { get; set; }
    }
}
