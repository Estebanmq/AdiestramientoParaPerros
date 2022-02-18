using AdiestramientoParaPerros.Filters;
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
        public IActionResult IndexEmpleados()
        {
            //Esto se debe de poner en otro sitio investigar (esta en trello)
            ViewBag.Layout = "_LayoutEmpleados";
            return View();
        }
    }
}
