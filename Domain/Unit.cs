using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Unit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUnit { get; set; }

        [Column(TypeName="varchar(100)")]
        public string MeasureCodeUnit { get; set; }

        [Column (TypeName ="varchar(50)")]
        public string MeasureName { get; set; }

        public int MeasureActive { get; set; }


    }

}
