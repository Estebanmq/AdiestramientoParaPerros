using AdiestramientoParaPerros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdiestramientoParaPerros.Repositories
{
    public interface IRepositoryUsuarios
    {

        #region AAD USUARIOS
        /// <summary>
        ///     Realiza el login en la app de un usuario
        /// </summary>
        /// <param name="email">El email del usuario</param>
        /// <param name="password">La contraseña del usuario</param>
        /// <returns>Devuelve el usuario que ha realizado el login.
        /// Null si no existe o se ha equivocado en las credenciales</returns>
        Usuario LogIn(String email, String password);

        /// <summary>
        ///     Devuelve un usuario por su email
        /// </summary>
        /// <param name="email">El email del usuario a buscar</param>
        /// <returns>El usuario si se ha encontrado.
        /// Null si no se ha encontrado</returns>
        Usuario FindUsuarioEmail(String email);

        /// <summary>
        ///     Devuelve un usuario por su id
        /// </summary>
        /// <param name="idusuario">El id del usuario a buscar</param>
        /// <returns>El usuario si se ha encontrado.
        /// Null si no se ha encontrado</returns>
        Usuario FindUsuarioId(int idusuario);

        /// <summary>
        ///     Inserta un usuario nuevo en la base de datos a partir de los valores pasados como parametros
        /// </summary>
        /// <param name="nombre">Nombre del usuario</param>
        /// <param name="apellidos">Apellidos del usuario</param>
        /// <param name="nombreusuario">Nickname del usuario</param>
        /// <param name="telefono">Telefono del usuario</param>
        /// <param name="correo">Correo del usuario</param>
        /// <param name="password">Contraseña del usuario</param>
        void RegistrarUsuario(String nombre, String apellidos, String nombreusuario, String telefono, String correo, String password);

        /// <summary>
        ///     Retorna el ID maximo de los usuarios
        /// </summary>
        /// <returns>
        ///     El ID mas alto mas 1
        /// </returns>
        int GetMaxIdUsuarios();

        /// <summary>
        /// Actualiza los datos de un usuario
        /// </summary>
        /// <param name="nombre">El nuevo nombre</param>
        /// <param name="apellidos">Los nuevos apellidos</param>
        /// <param name="nombreusuario">El nuevo nombre de usuario</param>
        /// <param name="telefono">El nuevo telefono</param>
        /// <param name="correo">El nuevo correo</param>
        void ModificarUsuario(int idusuario, string nombre, string apellidos, string nombreusuario, string telefono);

        #endregion

        #region AAD EMPLEADOS
        /// <summary>
        ///     Devuelve todos los empleados en la bdd
        /// </summary>
        /// <returns>Una lista de Usuario con todos los empleados</returns>
        List<Usuario> GetEmpleados();

        /// <summary>
        ///     Inserta un empleado nuevo en la base de datos con los datos pasaods como parametros
        /// </summary>
        /// <param name="nombre">El nombre del empleado</param>
        /// <param name="apellidos">Los apellidos del empleado</param>
        /// <param name="correo">El correo del empleado</param>
        /// <param name="telefono">El telefono del empleado</param>
        /// <param name="idrol">El id del rol que tendra el empleado</param>
        void InsertEmpleado(String nombre, String apellidos, String correo, String telefono, int idrol);
        #endregion

        #region AAD ROLES
        /// <summary>
        ///     Devuelve una lista de Rol con todos los roles en la base de datos
        /// </summary>
        /// <returns>Una lista con todos los roles</returns>
        List<Rol> GetRoles();

        /// <summary>
        ///     Devuelve un rol con el id pasado como parametro
        /// </summary>
        /// <param name="idrol">El id del rol a buscar</param>
        /// <returns>Un objeto Rol con el rol</returns>
        Rol FindRol(int idrol);

        /// <summary>
        ///     Devuelve una lista con los roles que corresponden a empleados
        /// </summary>
        /// <returns>Una lista de Rol con los roles de empleados</returns>
        List<Rol> GetRolesEmpleados();
        #endregion

    }
}
