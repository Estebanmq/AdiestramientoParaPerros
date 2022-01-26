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
            if(this.IsLogued() && this.IsEmpleado()) {

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
            if (this.IsLogued() && this.IsEmpleado())
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
