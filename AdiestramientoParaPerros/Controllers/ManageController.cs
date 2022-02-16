using AdiestramientoParaPerros.Filters;
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
        public IActionResult Registrarse(String nombre, String apellidos, String nombreusuario, String telefono, String correo, String password)
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

        [AuthorizeUsuarios]
        public IActionResult PerfilUsuario()
        {
            int id = int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            List<Cita> citasUsuario = this.repoCitas.GetCitasCliente(id);
            return View(citasUsuario);
        }

        [AuthorizeUsuarios]
        public IActionResult ModificarPerfilUsuario()
        {
            Usuario usuario = this.repo.FindUsuarioId(int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value));
            return View(usuario);
        }

        [HttpPost]
        public async  Task<IActionResult> ModificarPerfilUsuario(string nombre, string apellidos, string nombreusuario, string telefono, string correo)
        {
            this.repo.ModificarUsuario(int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value), nombre, apellidos, nombreusuario, telefono, correo);
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
            return RedirectToAction("PerfilUsuario");
        }

      [AuthorizeUsuarios]
        public IActionResult PerfilEmpleado()
        {
            ViewBag.Layout = "_LayoutEmpleados";
            ViewBag.Roles = this.repo.GetRoles();

            Usuario usuario = this.repo.FindUsuarioId(int.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value));
            return View(usuario);
        }


        [AuthorizeUsuarios]
        public IActionResult ModificarPerilEmpleado()
        {
            Usuario usuario = this.repo.FindUsuarioId(int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value));
            return View(usuario);
        }
        #endregion

        #region Controlador de Error de acceso
        public IActionResult ErrorAcceso()
        {
            return View();
        }
        #endregion


    }
}
