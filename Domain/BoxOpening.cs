using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class BoxOpening
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdBoxOpening { get; set; }
        public int IdBox { get; set; }
        [Column(TypeName = "varchar(60)")]
        public string? OpenDate { get; set; }
        [Column(TypeName = "varchar(60)")]
        public string? ClosingDate { get; set; }
        [Column(TypeName = "varchar(60)")]
        public string? BoxState { get; set; }
        public int IdUser { get; set; }
        [Column(TypeName = "varchar(60)")]
        public string? OpeningAmount { get; set; }
        [Column(TypeName = "varchar(60)")]
        public string? CloseAmount { get; set; }
        [Column(TypeName = "varchar(60)")]
        public string? CurrentAmount { get; set; }
        [ForeignKey("IdUser")]
        public virtual User DUser { get; set; }
        [ForeignKey("IdBox")]
        public virtual Box DBox { get; set; }
    }
}
