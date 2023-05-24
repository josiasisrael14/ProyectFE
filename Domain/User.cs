using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUser { get; set; }
        public int IdBranchOffice { get; set; }
        [ForeignKey("IdBranchOffice")]
        public virtual BranchOffice DBranchOffice { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string? Username { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string? Userpass { get; set; }
        [Column(TypeName = "varchar(1)")]
        public string? State { get; set; }
    }
}
