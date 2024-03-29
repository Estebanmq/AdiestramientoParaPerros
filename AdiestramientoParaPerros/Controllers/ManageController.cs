﻿using AdiestramientoParaPerros.Filters;
using AdiestramientoParaPerros.Models;
using AdiestramientoParaPerros.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AdiestramientoParaPerros.Controllers
{
    public class ManageController : Controller
    {
        private RepositoryUsuarios repo;
        private RepositoryCitas repoCitas;
        public ManageController(RepositoryUsuarios repo, RepositoryCitas repoCitas)
        {
            this.repo = repo;
            this.repoCitas = repoCitas;
        }

        #region Controlador Usuario y sesion
        public IActionResult IniciarSesion()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IniciarSesion(String email, String password)
        {
            Usuario usuario = this.repo.LogIn(email, password);
            if(usuario != null) {
                ClaimsIdentity identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);

                Claim claimIdUsuario = new Claim(ClaimTypes.NameIdentifier, usuario.IdUsuario.ToString());
                identity.AddClaim(claimIdUsuario);

                Claim claimNombreUsuario = new Claim(ClaimTypes.Name, usuario.NombreUsuario);
                identity.AddClaim(claimNombreUsuario);

                Claim claimIdRol = new Claim(ClaimTypes.Role, usuario.IdRol.ToString());
                identity.AddClaim(claimIdRol);

                Claim claimNombreCompleto = new Claim("NombreCompleto", usuario.Nombre + " " + usuario.Apellidos);
                identity.AddClaim(claimNombreCompleto);

                ClaimsPrincipal usuarioPrincipal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, usuarioPrincipal);

                if(usuario.IdRol == 0)
                {
                    string controller = TempData["controller"].ToString();
                    string action = TempData["action"].ToString();

                    return RedirectToAction(action, controller);
                } else
                {
                    return RedirectToAction("IndexEmpleados", "HomeEmpleados");
                }
              

            }
            else
            {
                ViewBag.Mensaje = "Usuario/Password incorrectos";
            }
            return View();
        }
       

        public IActionResult Registrarse()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrarse(String nombre, String apellidos, String nombreusuario, int telefono, String correo, String password)
        {
            this.repo.RegistrarUsuario(nombre, apellidos, nombreusuario, telefono, correo, password);
            return RedirectToAction("PerfilUsuario");
        }

        public async Task<IActionResult> CerrarSesion()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region Controlador Perfil usuario

        [AuthorizeUsuarios(Policy = "PermisosCliente")]
        public IActionResult PerfilUsuario(string mensaje)
        {
            if(mensaje != null)
            {
                ViewBag.Mensaje = mensaje;
            }
            int id = int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            List<Cita> citasUsuario = this.repoCitas.GetCitasCliente(id);
            citasUsuario.OrderByDescending(x => x.FechaCita);
            return View(citasUsuario);
        }

        [AuthorizeUsuarios(Policy = "PermisosCliente")]
        public IActionResult ModificarPerfilUsuario()
        {
            Usuario usuario = this.repo.FindUsuarioId(int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value));
            return View(usuario);
        }

        [AuthorizeUsuarios(Policy = "PermisosCliente")]
        [HttpPost]
        public async  Task<IActionResult> ModificarPerfilUsuario(string nombre, string apellidos, string nombreusuario, int telefono, string correo)
        {
            this.repo.ModificarUsuario(int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value), nombre, apellidos, nombreusuario, telefono);
            var claimNombre = HttpContext.User.FindFirst(ClaimTypes.Name);
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (claimNombre != null)
            {
                identity.RemoveClaim(claimNombre);
                identity.AddClaim(new Claim(ClaimTypes.Name, nombreusuario));
            }

            var claimNombreCompleto = HttpContext.User.FindFirst("NombreCompleto");
            if (claimNombreCompleto != null)
            {
                identity.RemoveClaim(claimNombreCompleto);
                identity.AddClaim(new Claim("NombreCompleto", nombre + " " + apellidos));
            }
            ClaimsPrincipal usuarioPrincipal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, usuarioPrincipal);
           
            return RedirectToAction("PerfilUsuario", new { mensaje = "Se ha modificado correctamente" });
        }


        [AuthorizeUsuarios(Policy = "PermisosEmpleado")]
        public IActionResult PerfilEmpleado(string mensaje)
        {
            if(mensaje != null)
            {
                ViewBag.Mensaje = mensaje;
            }
            ViewBag.Layout = "_LayoutEmpleados";
            ViewBag.Roles = this.repo.GetRoles();

            Usuario usuario = this.repo.FindUsuarioId(int.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value));
            return View(usuario);
        }


        [AuthorizeUsuarios(Policy = "PermisosEmpleado")]
        public IActionResult ModificarPerfilEmpleado()
        {
            ViewBag.Layout = "_LayoutEmpleados";

            ViewBag.Roles = this.repo.GetRoles();

            Usuario usuario = this.repo.FindUsuarioId(int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value));
            return View(usuario);
        }

        [HttpPost]
        [AuthorizeUsuarios(Policy = "PermisosEmpleado")]
        public async  Task<IActionResult> ModificarPerfilEmpleado(int idusuario, string nombreusuario, string nombre, string apellidos, int telefono)
        {
            if (nombreusuario == null)
                nombreusuario = HttpContext.User.FindFirst(ClaimTypes.Name).Value;

            this.repo.ModificarUsuario(idusuario, nombre, apellidos, nombreusuario, telefono);

            var claimNombre = HttpContext.User.FindFirst(ClaimTypes.Name);
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (claimNombre != null)
            {
                identity.RemoveClaim(claimNombre);
                identity.AddClaim(new Claim(ClaimTypes.Name, nombreusuario));
            }

            var claimNombreCompleto = HttpContext.User.FindFirst("NombreCompleto");
            if (claimNombreCompleto != null)
            {
                identity.RemoveClaim(claimNombreCompleto);
                identity.AddClaim(new Claim("NombreCompleto", nombre + " " + apellidos));
            }
            ClaimsPrincipal usuarioPrincipal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, usuarioPrincipal);

            return RedirectToAction("PerfilEmpleado", new { mensaje = "Perfil modificado correctamente"});
        }
        #endregion

        #region Controlador de Error de acceso
        public IActionResult ErrorAcceso()
        {
            //String controller = HttpContext.RouteData.Values["controller"].ToString();
            //String action = HttpContext.Request.RouteValues["action"].ToString();
            ////if else depende laypout sisisi
            if (HttpContext.User.IsInRole("0") == true )
            {
                ViewBag.Layout = "_LayoutClientes";

            } else
            {
                ViewBag.Layout = "_LayoutEmpleados";

            }

            return View();
        }
        #endregion


    }
}
