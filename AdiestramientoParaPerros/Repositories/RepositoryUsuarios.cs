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
    public class RepositoryUsuarios : IRepositoryUsuarios
    {

        private AdiestramientoContext context;

        public RepositoryUsuarios(AdiestramientoContext context)
        {
            this.context = context;
        }

        #region AAD USUARIOS
        /// <summary>
        ///     Realiza el login en la app de un usuario
        /// </summary>
        /// <param name="email">El email del usuario</param>
        /// <param name="password">La contraseña del usuario</param>
        /// <returns>Devuelve el usuario que ha realizado el login.
        /// Null si no existe o se ha equivocado en las credenciales</returns>
        public Usuario LogIn(String email, String password)
        {
            
            Usuario usuario = this.FindUsuarioEmail(email);

            if (usuario != null)
            {
                if (HelperPassword.CompareHashPassword(usuario.Password, password))
                {
                    return usuario;
                } else
                {
                    return null;
                }
            }

            return null;
            
        }

        /// <summary>
        ///     Devuelve un usuario por su email
        /// </summary>
        /// <param name="email">El email del usuario a buscar</param>
        /// <returns>El usuario si se ha encontrado.
        /// Null si no se ha encontrado</returns>
        public Usuario FindUsuarioEmail(String email)
        {
            return this.context.Usuarios.FirstOrDefault(z => z.Correo == email);
        }
           
        /// <summary>
        ///     Inserta un usuario nuevo en la base de datos a partir de los valores pasados como parametros
        /// </summary>
        /// <param name="nombre">Nombre del usuario</param>
        /// <param name="apellidos">Apellidos del usuario</param>
        /// <param name="nombreusuario">Nickname del usuario</param>
        /// <param name="telefono">Telefono del usuario</param>
        /// <param name="correo">Correo del usuario</param>
        /// <param name="password">Contraseña del usuario</param>
        public void RegistrarUsuario(String nombre, String apellidos, String nombreusuario, String telefono, String correo, String password)
        {
            Usuario usuario = new Usuario();
            usuario.IdUsuario = this.GetMaxIdUsuarios();
            usuario.Nombre = nombre;
            usuario.Apellidos = apellidos;
            usuario.NombreUsuario = nombreusuario;
            usuario.Telefono = telefono;
            usuario.Correo = correo;
            usuario.Password = HelperPassword.GetHashedPassword(password);

            //como es un usuario normal le agrego el rol de cliente
            usuario.IdRol = 0;

            this.context.Usuarios.Add(usuario);
            this.context.SaveChanges();
        }

        /// <summary>
        ///     Retorna el ID maximo de los usuarios
        /// </summary>
        /// <returns>
        ///     El ID mas alto mas 1
        /// </returns>
        public int GetMaxIdUsuarios()
        {
            if(this.context.Usuarios.Count() == 0)
            {
                return 1;
            }
            return this.context.Usuarios.Max(z => z.IdUsuario) + 1;
        }
        #endregion

        #region AAD EMPLEADOS

        public List<Usuario> GetEmpleados()
        {
            var consulta = from datos in this.context.Usuarios
                           where datos.IdRol != 0
                           select datos;
            return consulta.ToList();
        }

        // SUJETO A CAMBIOS
        public void InsertEmpleado(String nombre, String apellidos, String correo, String telefono, int rol)
        {
          
            Usuario usuario = new Usuario();
            usuario.IdUsuario = this.GetMaxIdUsuarios();
            usuario.Nombre = nombre;
            usuario.Apellidos = apellidos;
            usuario.NombreUsuario = nombre.ToLower() + apellidos.ToLower();
            usuario.Correo = correo;
            usuario.Telefono = telefono;
            usuario.Password = HelperPassword.GetHashedPassword(nombre.ToLower()+apellidos.ToLower());
            usuario.IdRol = rol;

            this.context.Usuarios.Add(usuario);
            this.context.SaveChanges();
        }
        #endregion

        #region AAD A ROLES
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
        #endregion
    }
}
