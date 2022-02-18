using AdiestramientoParaPerros.Data;
using AdiestramientoParaPerros.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdiestramientoParaPerros.Repositories
{
    public class RepositoryEstadisticas : IRepositoryEstadisticas
    {

        private AdiestramientoContext context;

        public RepositoryEstadisticas(AdiestramientoContext context)
        {
            this.context = context;
        }

        public Estadisticas GetEstadisticas()
        {
            Estadisticas estadisticas = new Estadisticas();
            String procedimiento = "ESTADISTICAS @CONSULTASPENDIENTES OUT, @CONSULTASPROCESO OUT, @CONSULTASTERMINADAS OUT, @CANTIDADCLIENTES OUT, @CANTIDADEMPLEADOS OUT, @TOTALUSUARIOS OUT";
            SqlParameter pamPendientes = new SqlParameter("@CONSULTASPENDIENTES", -1);
            pamPendientes.Direction = System.Data.ParameterDirection.Output;
            SqlParameter pamProceso = new SqlParameter("@CONSULTASPROCESO", -1);
            pamProceso.Direction = System.Data.ParameterDirection.Output;
            SqlParameter pamTerminadas = new SqlParameter("@CONSULTASTERMINADAS", -1);
            pamTerminadas.Direction = System.Data.ParameterDirection.Output;
            SqlParameter pamClientes = new SqlParameter("@CANTIDADCLIENTEs", -1);
            pamClientes.Direction = System.Data.ParameterDirection.Output;
            //Tienda, carrito, usuarios, dibujar component con menu, seguridad
            return estadisticas;
        }
    }
}
