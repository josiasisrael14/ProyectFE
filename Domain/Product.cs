using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProduct { get; set; }
        public int IdProductCategory { get; set; }
        [Column(TypeName = "varchar(60)")]
        public string? Price { get; set; }
        [ForeignKey("IdProductCategory")]
        public virtual CategoryProduct DCategoryProduct { get; set; }
    }
}
