using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdiestramientoParaPerros.Controllers
{
    public class LoginController : Controller
    {
        #region Controlador Vista LoginIndex
        public IActionResult LoginIndex()
        {

            return View();
        }


        [HttpPost]
        public IActionResult LoginIndex(String email, String password)
        {
            //LLamar a la BBDD 

            return View();
        }
        #endregion

        #region Controlador Vista SignUp
        public IActionResult SignUp()
        {
            return View();
        }
        #endregion
    }
}
