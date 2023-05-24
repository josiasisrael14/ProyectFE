using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Company
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCompany { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string? NameCompany { get; set; }
        [Column(TypeName = "varchar(1)")]
        public string? State { get; set; }

    }
}
