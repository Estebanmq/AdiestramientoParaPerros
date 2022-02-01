using AdiestramientoParaPerros.Extensions;
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
            if (HttpContext.Session.GetString("USUARIO") != null && HttpContext.Session.GetObject<Usuario>("USUARIO").IdRol == 2)
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
            if (HttpContext.Session.GetString("USUARIO") != null && HttpContext.Session.GetObject<Usuario>("USUARIO").IdRol == 2)
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
    }
}
