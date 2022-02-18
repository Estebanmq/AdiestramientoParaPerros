using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdiestramientoParaPerros.Models
{
    public class Estadisticas
    {
        public int ConsultasPendientes { get; set; }

        public int ConsultasProceso { get; set; }

        public int ConsultasTerminadas { get; set; }

        public int CantidadClientes { get; set; }

        public int CantidadEmpleados { get; set; }

        public int CantidadUsuarios { get; set; }
    }
}
