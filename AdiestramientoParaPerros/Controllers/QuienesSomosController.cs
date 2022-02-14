using AdiestramientoParaPerros.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdiestramientoParaPerros.Controllers
{
    public class QuienesSomosController : Controller
    {

        private RepositoryCitas repo;

        public QuienesSomosController(RepositoryCitas repo)
        {
            this.repo = repo;
        }

        public IActionResult QuienesSomosVista()
        {
            List<int> resumen = this.repo.GetResumenUsuariosCitas();
            ViewBag.TotalCitas = resumen[0];
            ViewBag.TotalClientes = resumen[1];
            return View();
        }
    }
}
