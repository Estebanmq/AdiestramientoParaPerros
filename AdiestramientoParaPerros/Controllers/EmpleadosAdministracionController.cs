using AdiestramientoParaPerros.Filters;
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
    [AuthorizeUsuarios(Policy = "PermisosAdministrador")]
    public class EmpleadosAdministracionController : Controller
    {

        private RepositoryUsuarios repo;

        public EmpleadosAdministracionController(RepositoryUsuarios repo)
        {
            this.repo = repo;
        }

        #region Controlador Vista Listado de empleados
        public IActionResult EmpleadosListado(string mensaje)
        {
            if(mensaje != null)
            {
                ViewBag.Mensaje = mensaje;
            }


            //Esto se debe de poner en otro sitio investigar (esta en trello)
            ViewBag.Layout = "_LayoutEmpleados";

            ViewBag.Roles = this.repo.GetRoles();

            List<Usuario> usuariosempleados = this.repo.GetEmpleados();

            return View(usuariosempleados);
          
        }

        
        #endregion

        #region Controlador Vista Agregar Empleado
        public IActionResult AgregarEmpleado()
        {
          
            //Esto se debe de poner en otro sitio investigar (esta en trello)
            ViewBag.Layout = "_LayoutEmpleados";

            ViewBag.Roles = this.repo.GetRolesEmpleados();

            return View();
        

        }

        [HttpPost]
        public IActionResult AgregarEmpleado(String nombre, String apellidos, String correo, int telefono, int rol)
        {
            this.repo.InsertEmpleado(nombre,apellidos,correo,telefono,rol);

            ViewBag.Roles = this.repo.GetRolesEmpleados();

            return RedirectToAction("EmpleadosListado", new { mensaje = "Empleado agregado correctamente"});
        }
        #endregion
    }
}
