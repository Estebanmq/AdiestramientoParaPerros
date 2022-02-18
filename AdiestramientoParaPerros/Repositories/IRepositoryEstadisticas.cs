using AdiestramientoParaPerros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdiestramientoParaPerros.Repositories
{
    public interface IRepositoryEstadisticas
    {
        /// <summary>
        /// Metodo que carga estadisticas
        /// </summary>
        /// <returns>El objeto con todas las estadisticas</returns>
        Estadisticas GetEstadisticas();
    }
}
