using AdiestramientoParaPerros.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public IActionResult Index(String emailcontacto, String telefonocontacto, String textoconsulta)
        {
            this.repo.InsertConsulta(emailcontacto, telefonocontacto, textoconsulta);
            return View();
        }
    }
}
