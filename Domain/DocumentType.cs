using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class DocumentType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDocumentType { get; set; }
        [Column(TypeName = "varchar(60)")]
        public string? EsSunat { get; set; }
        [Column(TypeName = "varchar(60)")]
        public string? CodSunat { get; set; }
    }
}

