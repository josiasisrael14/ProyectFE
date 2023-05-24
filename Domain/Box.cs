using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Box
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdBox { get; set; }
        [Column(TypeName = "varchar(60)")]
        public string? TradeMark { get; set; }
        [Column(TypeName = "varchar(60)")]
        public string? Description { get; set; }
        [Column(TypeName = "varchar(40)")]
        public string? BarCode { get; set; }
        [Column(TypeName = "varchar(1)")]
        public string? State { get; set; }
    }
}
