﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdiestramientoParaPerros.Controllers
{
    public class QuienesSomosController : Controller
    {
        public IActionResult QuienesSomosVista()
        {
            return View();
        }
    }
}