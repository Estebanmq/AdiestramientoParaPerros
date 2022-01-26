using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdiestramientoParaPerros.Controllers
{
    public class ErrorsController : Controller
    {
        public IActionResult AccesoDenegado()
        {
            return View();
        }

        public IActionResult NoRegistradoCitas()
        {
            return View();
        }
    }
}
