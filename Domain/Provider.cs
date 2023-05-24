using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Provider
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProvider { get; set; }
        public int IdCompany { get; set; }
        [ForeignKey("IdCompany")]
        public virtual Company DCompany { get; set; }
    }
}
