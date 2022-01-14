using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdiestramientoParaPerros.Models
{
    [Table("CONSULTAS")]
    public class Consulta
    {
        public enum Estados { PENDIENTE = 0 , ENPROCESO = 1 , TERMINADA = 2}

        [Key]
        [Column("IDCONSULTA")]
        public int IdConsulta { get; set; }

        [Column("CONSULTA")]
        public String TextoConsulta { get; set; }

        [Column("TELEFONOCONTACTO")]
        public String TelefonoContacto { get; set; }

        [Column("EMAILCONTACTO")]
        public String EmailContacto { get; set; }

        [Column("ESTADO")]
        public Estados Estado { get; set; }
    }
}
