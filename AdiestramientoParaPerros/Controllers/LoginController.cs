using AdiestramientoParaPerros.Helpers;
using AdiestramientoParaPerros.Models;
using AdiestramientoParaPerros.Repositories;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdiestramientoParaPerros.Controllers
{
    public class LoginController : Controller
    {

        private RepositoryUsuariosEmpleados repo;

        public LoginController(RepositoryUsuariosEmpleados repo)
        {
            this.repo = repo;
        } 

        #region Controlador Vista LoginIndex
        public IActionResult LoginIndex()
        {

            return View();
        }


        [HttpPost]
        public IActionResult LoginIndex(String email, String password)
        {
            bool logea = this.repo.LogIn(email, password);
            if(logea)
            {
                
            }
            else
            {
                return RedirectToAction("AccesoDenegado","Errors");
            }
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
