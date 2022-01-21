using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdiestramientoParaPerros.Models
{
    [Table("ROLES")]
    public class Rol
    {
        [Key]
        [Column("IDROL")]
        public int IdRol { get; set; }

        [Column("NOMBREROL")]
        public String NombreRol { get; set; }
    }
}
