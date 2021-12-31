using AdiestramientoParaPerros.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdiestramientoParaPerros.Controllers
{
    public class CitasAdministracionController : Controller
    {

        #region Controlador Vista Listado de citas
        public IActionResult CitasListado()
        {

            //Codigo prueba para cargar citas
            String fechacita = "07/01/2021";
            DateTime fecha = DateTime.ParseExact(fechacita, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            List<Cita> citas = new List<Cita>();
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

            //Esto se debe de poner en otro sitio investigar (esta en trello)
            ViewBag.Layout = "_LayoutEmpleados";
            return View(citas);
        }
        #endregion

        #region Controlador Vista Detalles de cita

        public IActionResult DetallesCita()
        {
            //Codigo prueba para cargar cita
            String fechacita = "07/01/2021";
            DateTime fecha = DateTime.ParseExact(fechacita, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
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
            //Fin codigo prueba

            //Esto se debe de poner en otro sitio investigar (esta en trello)
            ViewBag.Layout = "_LayoutEmpleados";
            return View(c);
        }

        #endregion

        #region Controlador Vista Modificar cita

        public IActionResult ModificarCita()
        {
            //Codigo prueba para cargar cita
            String fechacita = "07/01/2021";
            DateTime fecha = DateTime.ParseExact(fechacita, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
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
            //Fin codigo prueba


            //Esto se debe de poner en otro sitio investigar (esta en trello)
            ViewBag.Layout = "_LayoutEmpleados";
            return View(c);
        }
        #endregion
    }
}
