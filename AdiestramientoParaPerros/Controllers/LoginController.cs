using AdiestramientoParaPerros.Extensions;
using AdiestramientoParaPerros.Helpers;
using AdiestramientoParaPerros.Models;
using AdiestramientoParaPerros.Repositories;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Http;
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
                HttpContext.Session.SetObject("USUARIO", usuario);

                //HttpContext.Session.SetInt32("IDUSUARIO", usuario.IdUsuario);
                //HttpContext.Session.SetInt32("IDROL", usuario.IdRol);

                if (usuario.IdRol == 0)
                {
                    //Aqui redirigir a Perfil
                    return RedirectToAction("Index", "Home");
                } else
                {
                    return RedirectToAction("IndexEmpleados", "HomeEmpleados");
                }
            }
            else
            {
                return RedirectToAction("AccesoDenegado","Errors");
            }
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

        #region Controlador Close Session
        public IActionResult CloseSession()
        {
            if(HttpContext.Session.GetString("USUARIO") != null)
            {
                HttpContext.Session.Remove("USUARIO");
            }
            return RedirectToAction("Index","HomeController");
        }
        #endregion
    }
}
