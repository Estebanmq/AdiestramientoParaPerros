using AdiestramientoParaPerros.Models;
using AdiestramientoParaPerros.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdiestramientoParaPerros.Controllers
{
    public class CitasController : Controller
    {
        private RepositoryAdiestramiento repo;

        public CitasController(RepositoryAdiestramiento repo)
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

            this.repo.InsertCita(fechacita, telefonocontacto, nombreperro, razaperro, motivocita, objetivocita);

            return RedirectToAction("ListadoCitas");
        }
        #endregion


        #region Controlador Vista ListadoCitas
        public IActionResult ListadoCitas()
        {


            //Codigo prueba para cargar citas
            //String fechacita = "07/01/2021";
            //DateTime fecha = DateTime.ParseExact(fechacita, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            //List<Cita> citas = new List<Cita>();
            #region Listado de pruebas de citas
            Cita c = new Cita();
            c.IdCita = 1;
            c.FechaCita = fecha;
            c.TelefonoContacto = "653334778";
            c.NombrePerro = "Canela";
            c.RazaPerro = "Espagneul Breton";
            c.MotivoCita = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit deserunt " +
                    "vitae enim sapiente et architecto, praesentium, ipsa quidem dolores incidunt voluptas " +
                    "voluptatum nemo est assumenda asperiores magnam reiciendis, dolorum fugiat.";
            c.ObjetivoCita = "Adipisci, reiciendis eveniet, id saepe dicta commodi sunt enim tempore repellendus " +
                "perferendis mollitia cumque maxime? Debitis laborum esse consequuntur pariatur! Vero dolorem ut mollitia!";
            citas.Add(c);

            c = new Cita();
            c.IdCita = 2;
            c.FechaCita = fecha;
            c.TelefonoContacto = "653313078";
            c.NombrePerro = "Sola";
            c.RazaPerro = "Espagneul Breton";
            c.MotivoCita = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit deserunt " +
                    "vitae enim sapiente et architecto, praesentium, ipsa quidem dolores incidunt voluptas " +
                    "voluptatum nemo est assumenda asperiores magnam reiciendis, dolorum fugiat.";
            c.ObjetivoCita = "Adipisci, reiciendis eveniet, id saepe dicta commodi sunt enim tempore repellendus " +
                "perferendis mollitia cumque maxime? Debitis laborum esse consequuntur pariatur! Vero dolorem ut mollitia!";
            citas.Add(c);

            c = new Cita();
            c.IdCita = 3;
            c.FechaCita = fecha;
            c.TelefonoContacto = "653331928";
            c.NombrePerro = "Ella";
            c.RazaPerro = "Espagneul Breton";
            c.MotivoCita = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit deserunt " +
                    "vitae enim sapiente et architecto, praesentium, ipsa quidem dolores incidunt voluptas " +
                    "voluptatum nemo est assumenda asperiores magnam reiciendis, dolorum fugiat.";
            c.ObjetivoCita = "Adipisci, reiciendis eveniet, id saepe dicta commodi sunt enim tempore repellendus " +
                "perferendis mollitia cumque maxime? Debitis laborum esse consequuntur pariatur! Vero dolorem ut mollitia!";
            citas.Add(c);

            c = new Cita();
            c.IdCita = 4;
            c.FechaCita = fecha;
            c.TelefonoContacto = "65234478";
            c.NombrePerro = "Pepe";
            c.RazaPerro = "Akita";
            c.MotivoCita = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit deserunt " +
                    "vitae enim sapiente et architecto, praesentium, ipsa quidem dolores incidunt voluptas " +
                    "voluptatum nemo est assumenda asperiores magnam reiciendis, dolorum fugiat.";
            c.ObjetivoCita = "Adipisci, reiciendis eveniet, id saepe dicta commodi sunt enim tempore repellendus " +
                "perferendis mollitia cumque maxime? Debitis laborum esse consequuntur pariatur! Vero dolorem ut mollitia!";
            citas.Add(c);

            c = new Cita();
            c.IdCita = 5;
            c.FechaCita = fecha;
            c.TelefonoContacto = "612894778";
            c.NombrePerro = "Imanol";
            c.RazaPerro = "Shiba Inu";
            c.MotivoCita = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit deserunt " +
                    "vitae enim sapiente et architecto, praesentium, ipsa quidem dolores incidunt voluptas " +
                    "voluptatum nemo est assumenda asperiores magnam reiciendis, dolorum fugiat.";
            c.ObjetivoCita = "Adipisci, reiciendis eveniet, id saepe dicta commodi sunt enim tempore repellendus " +
                "perferendis mollitia cumque maxime? Debitis laborum esse consequuntur pariatur! Vero dolorem ut mollitia!";
            citas.Add(c);
            #endregion
            //Fin codigo prueba

            List<Cita>citas = this.repo.GetCitas();

            return View(citas);
        } 



        #endregion
    }
}
