using AdiestramientoParaPerros.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdiestramientoParaPerros.Controllers
{
    public class ContactoController : Controller
    {

        private RepositoryConsultas repo;

        public ContactoController(RepositoryConsultas repo)
        {
            this.repo = repo;
        }

        public IActionResult ContactoVista()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ContactoVista(String emailcontacto, String telefonocontacto, String textoconsulta)
        {
            this.repo.InsertConsulta(emailcontacto, telefonocontacto, textoconsulta);

            return RedirectToAction("Index","Home");
        }
    }
}
