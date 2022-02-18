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
    [AuthorizeUsuarios(Policy = "PermisosEmpleado")]
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
         

          
            //Esto se debe de poner en otro sitio investigar (esta en trello)
            ViewBag.Layout = "_LayoutEmpleados";

            Cita cita = this.repo.FindCita(idcita);
    
            return View(cita);
            
            
        }

        #endregion

        #region Controlador Vista Modificar cita
        public IActionResult ModificarCita(int idcita)
        {
         

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

        #region Controlador Vista Listado de citas
        public IActionResult DeleteCita(int idcita, String fechacita)
        {
            //Esto se debe de poner en otro sitio investigar (esta en trello)
            ViewBag.Layout = "_LayoutEmpleados";

            ViewBag.IdCita = idcita;
            ViewBag.FechaCita = fechacita;
            return View();
        }

        [HttpPost]
        public IActionResult DeleteCita(int idcita, bool elimina)
        {
            if(elimina)
            {
                this.repo.DeleteCita(idcita);
            }
            return RedirectToAction("CitasListado");
        }
        #endregion  

    }
}
