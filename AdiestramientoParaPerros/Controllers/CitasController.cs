using AdiestramientoParaPerros.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdiestramientoParaPerros.Controllers
{
    public class CitasController : Controller
    {
        public IActionResult CitasIndex()
        {
            Calendario cal = new Calendario();
            cal.DiasOcupados = new List<DateTime>();
            cal.DiasOcupados.Add(new DateTime(2021, 12, 25));
            cal.DiasOcupados.Add(new DateTime(2022, 01, 12));
            cal.DiasOcupados.Add(new DateTime(2022, 01, 09));
            cal.DiasOcupados.Add(new DateTime(2021, 12, 28));
        
            return View(cal);
        }
    }
}
