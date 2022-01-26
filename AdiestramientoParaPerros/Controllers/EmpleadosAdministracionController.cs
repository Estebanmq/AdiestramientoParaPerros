using AdiestramientoParaPerros.Models;
using AdiestramientoParaPerros.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdiestramientoParaPerros.Controllers
{
    public class EmpleadosAdministracionController : Controller
    {

        private RepositoryUsuarios repo;

        public EmpleadosAdministracionController(RepositoryUsuarios repo)
        {
            this.repo = repo;
        }

        #region Controlador Vista Listado de empleados
        public IActionResult EmpleadosListado()
        {
            if(this.IsLogued() && this.IsAdmin())
            {

                //Esto se debe de poner en otro sitio investigar (esta en trello)
                ViewBag.Layout = "_LayoutEmpleados";

                ViewBag.Roles = this.repo.GetRoles();

                List<Usuario> usuariosempleados = this.repo.GetEmpleados();

                return View(usuariosempleados);
            } else
            {
                return RedirectToAction("AccesoDenegado", "Errors");
            }
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
            if (this.IsLogued() && this.IsAdmin())
            {
                //Esto se debe de poner en otro sitio investigar (esta en trello)
                ViewBag.Layout = "_LayoutEmpleados";

                ViewBag.Roles = this.repo.GetRolesEmpleados();

                return View();
            } else
            {
                return RedirectToAction("AccesoDenegado", "Errors");
            }

        }

        [HttpPost]
        public IActionResult AgregarEmpleado(String nombre, String apellidos, String correo, String telefono, int rol)
        {
            this.repo.InsertEmpleado(nombre,apellidos,correo,telefono,rol);

            ViewBag.Roles = this.repo.GetRolesEmpleados();

            return RedirectToAction("EmpleadosListado");
        }
        #endregion

        private bool IsLogued()
        {
            if (HttpContext.Session.GetInt32("IDUSUARIO") == null || HttpContext.Session.GetInt32("IDROL") == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool IsEmpleado()
        {
            if (HttpContext.Session.GetInt32("IDROL") == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool IsAdmin()
        {
            if (HttpContext.Session.GetInt32("IDROL") == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
