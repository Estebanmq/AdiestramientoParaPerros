using AdiestramientoParaPerros.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AdiestramientoParaPerros.Controllers
{
    public class HomeController : Controller
    {
        private RepositoryConsultas repo;

        public HomeController(RepositoryConsultas repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(String emailcontacto, int telefonocontacto, String textoconsulta)
        {
            this.repo.InsertConsulta(emailcontacto, telefonocontacto, textoconsulta);
            ViewBag.Mensaje = "Se ha enviado correctamente, nos pondremos en contacto con usted.";
            return View();
        }
    }
}
