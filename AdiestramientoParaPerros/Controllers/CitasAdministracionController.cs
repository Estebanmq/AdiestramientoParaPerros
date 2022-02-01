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
            if(HttpContext.Session.GetString("USUARIO") == null)
                return RedirectToAction("AccesoDenegado", "Errors");

            //Aqui cargar las citas del empleado logeado !!!!!

            //Esto se debe de poner en otro sitio investigar (esta en trello)
            ViewBag.Layout = "_LayoutEmpleados";

            List<Cita> citas = this.repo.GetCitas();

            return View(citas);
            
            

           
        }
        #endregion

        #region Controlador Vista Detalles de cita

        public IActionResult DetallesCita(int idcita)
        {
            if(HttpContext.Session.GetString("USUARIO") == null)
                return RedirectToAction("AccesoDenegado", "Errors");

          
            //Esto se debe de poner en otro sitio investigar (esta en trello)
            ViewBag.Layout = "_LayoutEmpleados";

            Cita cita = this.repo.FindCita(idcita);
    
            return View(cita);
            
            
        }

        #endregion

        #region Controlador Vista Modificar cita

        public IActionResult ModificarCita(int idcita)
        {
            if(HttpContext.Session.GetString("USUARIO") == null) 
                return RedirectToAction("AccesoDenegado", "Errors");

            //Esto se debe de poner en otro sitio investigar (esta en trello)
            ViewBag.Layout = "_LayoutEmpleados";

            Cita cita = this.repo.FindCita(idcita);

            return View(cita);
          
            
        }

        [HttpPost]
        public IActionResult ModificarCita(int idcita, String motivocita, String objetivocita)
        {
            this.repo.UpdateCita(idcita,motivocita,objetivocita);
            return RedirectToAction("CitasListado");
        }
        #endregion

    }
}
