﻿using AdiestramientoParaPerros.Data;
using AdiestramientoParaPerros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdiestramientoParaPerros.Repositories
{
    public class RepositoryUsuariosEmpleados : IRepositoryEmpleadosUsuarios
    {

        private AdiestramientoContext context;

        public RepositoryUsuariosEmpleados(AdiestramientoContext context)
        {
            this.context = context;
        }

        //Metodo que devuelve todos los empleados
        public List<Empleado> GetEmpleados()
        {
            var consulta = from datos in this.context.Empleados
                           select datos;
            return consulta.ToList();
        }

        //Metodo que devuelve todos los roles de la bdd
        public List<Rol> GetRoles()
        {
            var consulta = from datos in this.context.Roles
                           select datos;
            return consulta.ToList();
        }
       
        //Metodo que devuelve un rol a partir de su id
        public Rol FindRol(int idrol)
        {
            return this.context.Roles.FirstOrDefault(z => z.IdRol == idrol);
        }

        //Metodo que devuelve los roles de empleados
        public List<Rol>GetRolesEmpleados()
        {
            var consulta = from datos in this.context.Roles
                           where datos.NombreRol != "Cliente"
                           select datos;
            return consulta.ToList();
        }
    }
}
