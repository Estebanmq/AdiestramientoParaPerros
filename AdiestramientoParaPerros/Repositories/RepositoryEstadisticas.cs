﻿using AdiestramientoParaPerros.Data;
using AdiestramientoParaPerros.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#region Procedimientos Almacenados

//Procedimiento que devuelve varias estadisticas
//ALTER PROCEDURE ESTADISTICAS(@CONSULTASPENDIENTES INT OUT, @CONSULTASPROCESO INT OUT, @CONSULTASTERMINADAS INT OUT, @CANTIDADCLIENTES INT OUT, @CANTIDADEMPLEADOS INT OUT, @TOTALUSUARIOS INT OUT)
//AS
//    SELECT @CONSULTASPENDIENTES = COUNT(IDCONSULTA) FROM CONSULTAS WHERE ESTADO = 0;
//SELECT @CONSULTASPROCESO = COUNT(IDCONSULTA) FROM CONSULTAS WHERE ESTADO = 1;
//SELECT @CONSULTASTERMINADAS = COUNT(IDCONSULTA) FROM CONSULTAS WHERE ESTADO = 2;
//SELECT @CANTIDADCLIENTES = COUNT(IDUSUARIO) FROM USUARIOS WHERE IDROL = 0;
//SELECT @CANTIDADEMPLEADOS = COUNT(IDUSUARIO) FROM USUARIOS WHERE IDROL = 1 OR IDROL = 2;
//SELECT @TOTALUSUARIOS = COUNT(IDUSUARIO) FROM USUARIOS;
//GO

#endregion

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
            String procedimiento = "ESTADISTICAS @CONSULTASPENDIENTES out, @CONSULTASPROCESO out, @CONSULTASTERMINADAS out, @CANTIDADCLIENTES out, @CANTIDADEMPLEADOS out, @TOTALUSUARIOS out";


            SqlParameter pamPendientes = new SqlParameter("@CONSULTASPENDIENTES", -1);
            pamPendientes.Direction = System.Data.ParameterDirection.Output;
            SqlParameter pamProceso = new SqlParameter("@CONSULTASPROCESO", -1);
            pamProceso.Direction = System.Data.ParameterDirection.Output;
            SqlParameter pamTerminadas = new SqlParameter("@CONSULTASTERMINADAS", -1);
            pamTerminadas.Direction = System.Data.ParameterDirection.Output;
            SqlParameter pamClientes = new SqlParameter("@CANTIDADCLIENTES", -1);
            pamClientes.Direction = System.Data.ParameterDirection.Output;
            SqlParameter pamEmpleados = new SqlParameter("@CANTIDADEMPLEADOS", -1);
            pamEmpleados.Direction = System.Data.ParameterDirection.Output;
            SqlParameter pamUsuarios = new SqlParameter("@TOTALUSUARIOS", -1);
            pamUsuarios.Direction = System.Data.ParameterDirection.Output;


            var consulta = this.context.Database.ExecuteSqlRaw(procedimiento, pamPendientes, pamProceso, pamTerminadas, pamClientes, pamEmpleados, pamUsuarios);
            estadisticas.ConsultasPendientes = int.Parse(pamPendientes.Value.ToString());
            estadisticas.ConsultasProceso = int.Parse(pamProceso.Value.ToString());
            estadisticas.ConsultasTerminadas = int.Parse(pamTerminadas.Value.ToString());
            estadisticas.CantidadClientes = int.Parse(pamClientes.Value.ToString());
            estadisticas.CantidadEmpleados = int.Parse(pamEmpleados.Value.ToString());
            estadisticas.CantidadUsuarios = int.Parse(pamUsuarios.Value.ToString());
            return estadisticas;
        }
    }
}
