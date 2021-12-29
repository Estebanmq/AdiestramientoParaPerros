using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdiestramientoParaPerros.Models
{
    public class Cita
    {
        public int IdCita { get; set; }
        public DateTime FechaCita { get; set; }
        public String TelefonoContacto { get; set; }
        public String NombrePerro { get; set; }
        public String RazaPerro { get; set; }
        public String MotivoCita { get; set; }
        public String ObjetivoCita { get; set; }


    }
}
