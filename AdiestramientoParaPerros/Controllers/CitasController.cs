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
            cal.DiasOcupados = this.repo.GetDiasOcupados();

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
            if (HttpContext.Session.GetString("USUARIO") == null)
                return RedirectToAction("NoRegistradoCitas", "Errors");
            
            //Convierto el String a DateTime para mostrar la fecha en formato dd/MM/yyyy
            DateTime dateFecha = DateTime.ParseExact(fecha, "ddd MMM dd yyyy HH:mm:ss ", System.Globalization.CultureInfo.InvariantCulture);
            ViewBag.fechacita = dateFecha.Day + "/" + dateFecha.Month + "/" + dateFecha.Year;
            return View();
            
        }

        //Metodo post de la vista ConcertarCita
        //Recibe todos los parametros necesarios para crear un objeto Cita
        //Devuelve un string con la view a cargar
        [HttpPost]
        public IActionResult ConcertarCita(String fechacita, String telefonocontacto, String nombreperro, String razaperro, String motivocita, String objetivocita)
        {

            //El id tiene que ser del session usuario registrado
            this.repo.InsertCita(fechacita, telefonocontacto, nombreperro, razaperro, motivocita, objetivocita, 4);

            return RedirectToAction("ListadoCitas");
        }
        #endregion


        #region Controlador Vista ListadoCitas
        public IActionResult ListadoCitas()
        {

           if(HttpContext.Session.GetString("USUARIO") == null)
                return RedirectToAction("NoRegistradoCitas", "Errors");
            
           //AQUI RECUPERAR EL ID DEL USUARIO REGISTRADO
            List<Cita> citas = this.repo.GetCitasCliente(4);
            return View(citas);
            
        } 
        #endregion

     
    }
}
