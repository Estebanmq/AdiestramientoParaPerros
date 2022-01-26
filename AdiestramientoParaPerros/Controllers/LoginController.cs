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

        private RepositoryUsuarios repo;

        public LoginController(RepositoryUsuarios repo)
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
            Usuario usuario = this.repo.LogIn(email, password);
            if(usuario != null)
            {
                if(usuario.IdRol == 0)
                {
                    return RedirectToAction("Index", "Home");
                } else if (usuario.IdRol == 1)
                {
                    return RedirectToAction("IndexEmpleados", "HomeEmpleados");
                } else if(usuario.IdRol == 2)
                {
                    return RedirectToAction("IndexEmpleados", "HomeEmpleados");
                }
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


        [HttpPost]
        public IActionResult SignUp(String nombre, String apellidos, String nombreusuario, String telefono, String correo, String password)
        {
            this.repo.RegistrarUsuario(nombre, apellidos, nombreusuario, telefono, correo, password);
            return RedirectToAction("Index","Home");
        }
        #endregion
    }
}
