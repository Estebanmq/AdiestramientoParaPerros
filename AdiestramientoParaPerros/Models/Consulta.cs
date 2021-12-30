using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdiestramientoParaPerros.Models
{
    public class Consulta
    {
        public enum Estados { PENDIENTE = 0 , ENPROCESO = 1 , TERMINADA = 2}

        public int IdConsulta { get; set; }
        public String TextoConsulta { get; set; }
        public String TelefonoContacto { get; set; }
        public String EmailContacto { get; set; }
        public Estados Estado { get; set; }
    }
}
