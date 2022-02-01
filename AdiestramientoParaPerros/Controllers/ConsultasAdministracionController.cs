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
    public class ConsultasAdministracionController : Controller
    {

        private RepositoryConsultas repo;

        public ConsultasAdministracionController(RepositoryConsultas repo)
        {
            this.repo = repo;
        }

        #region Controlador Vista Listado de consultas
        public IActionResult ConsultasListado()
        {
            if (HttpContext.Session.GetString("USUARIO") != null && HttpContext.Session.GetObject<Usuario>("USUARIO").IdRol != 0)
            { 
                //Esto se debe de poner en otro sitio investigar (esta en trello)
                ViewBag.Layout = "_LayoutEmpleados";

                ViewBag.Estados = this.repo.GetEstados();

                List<Consulta> consultas = this.repo.GetConsultas();

                return View(consultas);
            }
            else
            {
                return RedirectToAction("AccesoDenegado", "Errors");
            }
        } 


        #endregion


        #region Controlador Vista Detalles de consulta
        public IActionResult DetallesConsulta(int idconsulta)
        {
            if (HttpContext.Session.GetString("USUARIO") != null && HttpContext.Session.GetObject<Usuario>("USUARIO").IdRol != 0)
            {
                List<Estado> estados = this.repo.GetEstados();
                ViewBag.Estados = estados;

                Consulta c = this.repo.FindConsulta(idconsulta);
                return View(c);
            }
            else
            {
                return RedirectToAction("AccesoDenegado", "Errors");
            }
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
