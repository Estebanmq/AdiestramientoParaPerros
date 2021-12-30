using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdiestramientoParaPerros.Controllers
{
    public class ContactoController : Controller
    {
        public IActionResult ContactoVista()
        {
            return View();
        }
    }
}
