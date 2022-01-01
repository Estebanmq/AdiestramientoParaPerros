using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdiestramientoParaPerros.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public String NombreUsuario { get; set; }
        public String Nombre { get; set; }
        public String Apellidos { get; set; }
        public String Correo { get; set; }
        public String Telefono { get; set; }
        public String Password { get; set; }
    }
}
