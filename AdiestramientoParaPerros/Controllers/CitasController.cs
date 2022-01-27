using AdiestramientoParaPerros.Models;
using AdiestramientoParaPerros.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            cal.DiasOcupados = new List<DateTime>();

            //Lista de prueba para los dias ocupados
            //BBDD
            cal.DiasOcupados.Add(new DateTime(2021, 12, 25));
            cal.DiasOcupados.Add(new DateTime(2022, 01, 12));
            cal.DiasOcupados.Add(new DateTime(2022, 01, 09));
            cal.DiasOcupados.Add(new DateTime(2021, 12, 28));

            return View(cal);
            

        
        }

        //Metodo post de la vista CitasIndex
        //Recibe un string con la cita seleccionada
        //Formatea ese string y lo convierte a un objeto DateTime
        //Devuelve un string con la view a cargar y el model con la fecha formateada
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
        public IActionResult ConcertarCita(String fecha)
        {
            if (!this.IsLogued())
            {
                return RedirectToAction("NoRegistradoCitas", "Errors");
            }
            else
            {
                //Convierto el String a DateTime para mostrar la fecha en formato dd/MM/yyyy
                DateTime dateFecha = DateTime.ParseExact(fecha, "ddd MMM dd yyyy HH:mm:ss ", System.Globalization.CultureInfo.InvariantCulture);
                ViewBag.fechacita = dateFecha.Day + "/" + dateFecha.Month + "/" + dateFecha.Year;
                return View();
            }
        }

        //Metodo post de la vista ConcertarCita
        //Recibe todos los parametros necesarios para crear un objeto Cita
        //Devuelve un string con la view a cargar
        [HttpPost]
        public IActionResult ConcertarCita(String fechacita, String telefonocontacto, String nombreperro, String razaperro, String motivocita, String objetivocita)
        {

            this.repo.InsertCita(fechacita, telefonocontacto, nombreperro, razaperro, motivocita, objetivocita);

            return RedirectToAction("ListadoCitas");
        }
        #endregion


        #region Controlador Vista ListadoCitas
        public IActionResult ListadoCitas()
        {


            if (!this.IsLogued())
            {
                return RedirectToAction("NoRegistradoCitas", "Errors");
            }
            else
            {
                List<Cita> citas = this.repo.GetCitas();

                return View(citas);
            }
        } 
        #endregion

        private bool IsLogued()
        {
            if (HttpContext.Session.GetInt32("IDUSUARIO") == null || HttpContext.Session.GetInt32("IDROL") == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
