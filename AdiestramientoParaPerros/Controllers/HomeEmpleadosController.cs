using AdiestramientoParaPerros.Filters;
using AdiestramientoParaPerros.Models;
using AdiestramientoParaPerros.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdiestramientoParaPerros.Controllers
{
    [AuthorizeUsuarios(Policy = "PermisosEmpleado")]
    public class HomeEmpleadosController : Controller
    {
        private RepositoryEstadisticas repo;

        public HomeEmpleadosController(RepositoryEstadisticas repo) { this.repo = repo; }

        public IActionResult IndexEmpleados()
        {
            Estadisticas estadisticas = this.repo.GetEstadisticas();
            //Esto se debe de poner en otro sitio investigar (esta en trello)
            ViewBag.Layout = "_LayoutEmpleados";
            return View(estadisticas);
        }
    }
}
