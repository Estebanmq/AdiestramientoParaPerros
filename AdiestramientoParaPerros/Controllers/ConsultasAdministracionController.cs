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
    public class ConsultasAdministracionController : Controller
    {

        private RepositoryConsultas repo;

        public ConsultasAdministracionController(RepositoryConsultas repo)
        {
            this.repo = repo;
        }

        #region Controlador Vista Listado de consultas
        public IActionResult ConsultasListado(int? idestado)
        {
           
            //Esto se debe de poner en otro sitio investigar (esta en trello)
            ViewBag.Layout = "_LayoutEmpleados";

            ViewBag.Estados = this.repo.GetEstados();
            List<Consulta> consultas;
            if (idestado == null)
                idestado = -1;

            if (idestado.Value != -1)
            {
                consultas = this.repo.GetConsultasEstado(idestado.Value);
            } else 
            {
                consultas = this.repo.GetConsultas();
            }

            return View(consultas);
         
        }
        
        [HttpPost]
        public IActionResult ConsultasListado(int idestado)
        {    
            return RedirectToAction("ConsultasListado", new { idestado = idestado});
        }


        #endregion


        #region Controlador Vista Detalles de consulta
        public IActionResult DetallesConsulta(int idconsulta)
        {
            ViewBag.Layout = "_LayoutEmpleados";

            List<Estado> estados = this.repo.GetEstados();
            ViewBag.Estados = estados;

            Consulta c = this.repo.FindConsulta(idconsulta);
            return View(c);
          
        }

        [HttpPost]
        public IActionResult DetallesConsulta(int estado, int idconsulta)
        {
            this.repo.UpdateEstadoConsulta(estado, idconsulta);

            return RedirectToAction("ConsultasListado");
        }
        #endregion

     
    }
}
