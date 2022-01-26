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
    public class CitasAdministracionController : Controller
    {

        private RepositoryCitas repo;

        public CitasAdministracionController(RepositoryCitas repo)
        {
            this.repo = repo;
        }

        #region Controlador Vista Listado de citas
        public IActionResult CitasListado()
        {
            if(this.IsLogued() && this.IsEmpleado())
            {
                //Aqui cargar las citas del empleado logeado !!!!!

                //Esto se debe de poner en otro sitio investigar (esta en trello)
                ViewBag.Layout = "_LayoutEmpleados";

                List<Cita> citas = this.repo.GetCitas();

                return View(citas);
            } else
            {
                return RedirectToAction("AccesoDenegado", "Errors");
            }

           
        }
        #endregion

        #region Controlador Vista Detalles de cita

        public IActionResult DetallesCita(int idcita)
        {

            if (this.IsLogued() && this.IsEmpleado()) 
            { 
                //Esto se debe de poner en otro sitio investigar (esta en trello)
                ViewBag.Layout = "_LayoutEmpleados";

                Cita cita = this.repo.FindCita(idcita);
    
                return View(cita);
            } 
            else 
            {
                return RedirectToAction("AccesoDenegado", "Errors");
            }
        }

        #endregion

        #region Controlador Vista Modificar cita

        public IActionResult ModificarCita(int idcita)
        {
            if (this.IsLogued() && this.IsEmpleado())
            {
                //Esto se debe de poner en otro sitio investigar (esta en trello)
                ViewBag.Layout = "_LayoutEmpleados";

                Cita cita = this.repo.FindCita(idcita);

                return View(cita);
            } 
            else
            {
                return RedirectToAction("AccesoDenegado", "Errors");
            }
        }

        [HttpPost]
        public IActionResult ModificarCita(int idcita, String motivocita, String objetivocita)
        {
            this.repo.UpdateCita(idcita,motivocita,objetivocita);
            return RedirectToAction("CitasListado");
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
            if(HttpContext.Session.GetInt32("IDROL") == 0)
            {
                return false;
            } else
            {
                return true;
            }
        }

        private bool IsAdmin()
        {
            if(HttpContext.Session.GetInt32("IDROL") == 2)
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}
