using AdiestramientoParaPerros.Data;
using AdiestramientoParaPerros.Helpers;
using AdiestramientoParaPerros.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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

        public bool LogIn(String email, String password)
        {
            
            Usuario usuario = this.FindUsuarioEmail(email);
           
            if (usuario != null)
            {
                if( HelperPassword.CompareHashPassword(usuario.Password, password))
                {
                    //Guardo en session el usuario
                    //Guardo en temp el tipo?
                    return true;
                }
            }

            Empleado empleado = this.FindEmpleadoEmail(email);
            if(empleado != null)
            {
                if (HelperPassword.CompareHashPassword(empleado.Password, password))
                {
                    //Guardo en session el empleado
                    //Guardo en temp el tipo?
                    return true;
                }
            }
           
           
            return false;
            
        }

        public Usuario FindUsuarioEmail(String email)
        {
            return this.context.Usuarios.FirstOrDefault(z => z.Correo == email);
        }

        public Empleado FindEmpleadoEmail(String email)
        {
          
            return this.context.Empleados.FirstOrDefault(z => z.Correo == email);
        }

        //Metodo que devuelve todos los empleados
        public List<Empleado> GetEmpleados()
        {
            var consulta = from datos in this.context.Empleados
                           select datos;
            return consulta.ToList();
        }

        //Metodo que agrega un empleado a partir de los datos pasados como parametro
        public void InsertEmpleado(String nombre, String apellidos, String correo, String telefono, int rol)
        {
            String sql = "SP_INSERT_EMPLEADO @NOMBRE, @APELLIDOS, @CORREO, @TELEFONO, @IDROL, @PASSWORD";
            SqlParameter pamnombre = new SqlParameter("@NOMBRE", nombre);
            SqlParameter pamapellidos = new SqlParameter("@APELLIDOS", apellidos);
            SqlParameter pamcorreo = new SqlParameter("@CORREO", correo);
            SqlParameter pamtelefono = new SqlParameter("@TELEFONO", telefono);
            SqlParameter pamrol = new SqlParameter("@IDROL", rol);
            SqlParameter pampwd = new SqlParameter("@PASSWORD", nombre + apellidos);
            this.context.Database.ExecuteSqlRaw(sql, pamnombre, pamapellidos, pamcorreo, pamtelefono, pamrol, pampwd);
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
