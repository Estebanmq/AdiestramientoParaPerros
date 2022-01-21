using AdiestramientoParaPerros.Models;
using AdiestramientoParaPerros.Repositories;
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
            //Codigo de prueba de datoss
            //List<Consulta> consultas = new List<Consulta>();
            //Consulta c = new Consulta();

            //c.TextoConsulta = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Nemo, laborum inventore iure itaque eum ea maxime natus excepturi? Eum unde porro sint nam corporis.";
            //c.TelefonoContacto = "657777233";
            //c.EmailContacto = "email@email.com";
            //c.Estado = Consulta.Estados.ENPROCESO;
            //consultas.Add(c);
            //c = new Consulta();

            //c.TextoConsulta = "Loremea ipsum dolor  itaque eum  maxime natus excepturi? Eum unde porro sint nam  sit amet consectetur adipisicing elit. Nemo, laborum inventore iurecorporis.";
            //c.TelefonoContacto = "657902333";
            //c.EmailContacto = "email2@email2.com";
            //c.Estado = Consulta.Estados.PENDIENTE;
            //consultas.Add(c);
            //c = new Consulta();

            //c.TextoConsulta = "maxime natus excepturi? Eum undeLoremea ipsum dolor  itaque eum porro sint nam  sit amet consectetur adipisicing elit. Nemo, laborum inventore iurecorporis.";
            //c.TelefonoContacto = "631202333";
            //c.EmailContacto = "email3@email3.com";
            //c.Estado = Consulta.Estados.TERMINADA;
            //consultas.Add(c);
            //c = new Consulta();

            //Fin codigo de prueba

            //Esto se debe de poner en otro sitio investigar (esta en trello)
            ViewBag.Layout = "_LayoutEmpleados";

            ViewBag.Estados = this.repo.GetEstados();

            List<Consulta> consultas = this.repo.GetConsultas();

            return View(consultas);
        }


        #endregion


        #region Controlador Vista Detalles de consulta
        public IActionResult DetallesConsulta(int idconsulta)
        {
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
