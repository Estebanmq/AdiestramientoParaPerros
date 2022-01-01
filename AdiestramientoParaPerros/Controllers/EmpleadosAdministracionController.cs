using AdiestramientoParaPerros.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdiestramientoParaPerros.Controllers
{
    public class EmpleadosAdministracionController : Controller
    {

        #region Controlador Vista Listado de empleados
        public IActionResult EmpleadosListado()
        {
            //usuarios buscar correo en usuarios y correo en empleados - se juntan con el correo
            //Traer usuarios con el correo que exista en empleados juntarlos con inner join
           
            //Codigo de prueba de datos
            List<Empleado> empleados = new List<Empleado>();
            Usuario usr = new Usuario();
            Empleado emp = new Empleado();

            #region relleno empleados
            usr.Nombre = "Esteban";
            usr.Apellidos = "Martínez";
            usr.Correo = "correo@gmail.com";
            usr.Telefono = "344328856";
            emp.Usuario = usr;
            emp.NvlPermiso = 1;
            empleados.Add(emp);

            usr = new Usuario();
            emp = new Empleado();
            usr.Nombre = "Mar";
            usr.Apellidos = "Mar";
            usr.Correo = "lachicamasmonaymascutedeluniveros@laquieroinfinito.com";
            usr.Telefono = "11122021";
            emp.Usuario = usr;
            emp.NvlPermiso = 1;
            empleados.Add(emp);

            usr = new Usuario();
            emp = new Empleado();
            usr.Nombre = "Hehe?";
            usr.Apellidos = "Not hehe";
            usr.Correo = "hehenothehe@ARRIBAESPAÑA.com";
            usr.Telefono = "89348956";
            emp.Usuario = usr;
            emp.NvlPermiso = 0;
            empleados.Add(emp);
            #endregion
            //Fin codigo de pruebas

            //Esto se debe de poner en otro sitio investigar (esta en trello)
            ViewBag.Layout = "_LayoutEmpleados";
            return View(empleados);
        }

        [HttpPost]
        public IActionResult EmpleadosListado(String nombre)
        {
            System.Diagnostics.Debug.WriteLine(nombre);
            return View();
        }
        #endregion

        #region Controlador Vista Agregar Empleado
        public IActionResult AgregarEmpleado()
        {


            //Esto se debe de poner en otro sitio investigar (esta en trello)
            ViewBag.Layout = "_LayoutEmpleados";

            return View();
        }

        [HttpPost]
        public IActionResult AgregarEmpleado(String nombreusuario, String nombre, String apellidos, String correo,
            String telefono, int nvlpermiso)
        {

            return View();
        }
        #endregion
    }
}
