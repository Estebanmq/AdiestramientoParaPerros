﻿using AdiestramientoParaPerros.Models;
using AdiestramientoParaPerros.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using AdiestramientoParaPerros.Filters;

namespace AdiestramientoParaPerros.Controllers
{
    public class CitasController : Controller
    {
        private RepositoryCitas repo;

        public CitasController(RepositoryCitas repo)
        {
            this.repo = repo;
        }

        #region Controlador Vista CitasIndex
        public IActionResult CitasIndex()
        {
         
            //Modelo para la vista CitasIndex
            //CAMBIO: solo una lista de datetime
            Calendario cal = new Calendario();
            cal.DiasOcupados = this.repo.GetDiasOcupados();

            return View(cal);
        
        }

        //Metodo post de la vista CitasIndex
        //Recibe un string con la cita seleccionada
        //Formatea ese string y lo convierte a un objeto DateTime
        //Devuelve un string con la view a cargar y el model con la fecha formateada
        [AuthorizeUsuarios(Policy = "PermisosCliente")]
        [HttpPost]
        public IActionResult CitasIndex(String cita)
        {
            //Mirar para recibir DateTime

            //Variable con el index del texto GMT que se utiliza para cortar la cadena de texto con la fecha de la cita
            int indexTxtGmt = cita.IndexOf("GMT");
            String fechaformateada = cita.Substring(0, indexTxtGmt);
            return RedirectToAction("ConcertarCita", new { fecha = fechaformateada});
        }
        #endregion


        #region Controlador Vista ConcertarCita
        //Recibe la fecha seleccionada en el calendario
        [AuthorizeUsuarios(Policy = "PermisosCliente")]
        public IActionResult ConcertarCita(String fecha)
        {
            
            //Convierto el String a DateTime para mostrar la fecha en formato dd/MM/yyyy
            DateTime dateFecha = DateTime.ParseExact(fecha, "ddd MMM dd yyyy HH:mm:ss ", System.Globalization.CultureInfo.InvariantCulture);
            ViewBag.fechacita = dateFecha.Day + "/" + dateFecha.Month + "/" + dateFecha.Year;
            return View();
            
        }

        //Metodo post de la vista ConcertarCita
        //Recibe todos los parametros necesarios para crear un objeto Cita
        //Devuelve un string con la view a cargar
        [AuthorizeUsuarios(Policy = "PermisosCliente")]
        [HttpPost]
        public IActionResult ConcertarCita(String fechacita, int telefonocontacto, String nombreperro, String razaperro, String motivocita, String objetivocita)
        {

            //El id tiene que ser del session usuario registrado
            this.repo.InsertCita(fechacita, telefonocontacto, nombreperro, razaperro, motivocita, objetivocita, int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value));

            return RedirectToAction("PerfilUsuario","Manage", new { mensaje = "Su cita ha sido enviada" });
        }
        #endregion
     
    }
}
