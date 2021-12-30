using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdiestramientoParaPerros.Controllers
{
    public class HomeEmpleadosController : Controller
    {
        public IActionResult IndexEmpleados()
        {
            ViewBag.Layout = "_LayoutEmpleados";
            return View();
        }
    }
}
