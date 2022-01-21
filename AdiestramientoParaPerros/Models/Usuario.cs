using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdiestramientoParaPerros.Models
{
    [Table("USUARIOS")]
    public class Usuario
    {
        [Key]
        [Column("IDUSUARIO")]
        public int IdUsuario { get; set; }

        [Column("NOMBREUSUARIO")]
        public String NombreUsuario { get; set; }

        [Column("NOMBRE")]
        public String Nombre { get; set; }

        [Column("APELLIDOS")]
        public String Apellidos { get; set; }

        [Column("CORREO")]
        public String Correo { get; set; }

        [Column("TELEFONO")]
        public String Telefono { get; set; }

        [Column("IDROL")]
        public int IdRol { get; set; }

        //[Column("PASSWORD")]
        //public String Password { get; set; }
    }
}
