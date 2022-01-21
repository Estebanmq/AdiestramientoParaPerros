using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdiestramientoParaPerros.Models
{
    [Table("ESTADOS")]
    public class Estado
    {
        [Key]
        [Column("IDESTADO")]
        public int IdEstado { get; set; }

        [Column("ESTADO")]
        public String TextoEstado {get;set;}
    }
}
