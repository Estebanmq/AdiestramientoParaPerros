using AdiestramientoParaPerros.Data;
using AdiestramientoParaPerros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdiestramientoParaPerros.Repositories
{
    public class RepositoryAdiestramiento
    {
        private AdiestramientoContext context;

        public RepositoryAdiestramiento(AdiestramientoContext context)
        {
            this.context = context;
        }


        #region AAD de Citas
        //Metodo que devuelve todas las citas a partir del id de un usuario
        //TENGO QUE RECIBIR EL ID DE USUARIO
        public List<Cita> GetCitas()
        {
            var consulta = from datos in this.context.Citas
                           select datos;

            return consulta.ToList();

        }

        public void InsertCita(String fechacita, String telefonocontacto, String nombreperro, String razaperro, String motivocita, String objetivocita)
        {
            //Formateo la fecha para agregarla al objeto Cita
            DateTime fecha = DateTime.ParseExact(fechacita, "d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture);

            //Objeto Cita para trabajar sobre la Base de datos
            Cita cita = new Cita();
            cita.FechaCita = fecha;
            cita.TelefonoContacto = telefonocontacto;
            cita.NombrePerro = nombreperro;
            cita.RazaPerro = razaperro;
            cita.MotivoCita = motivocita;
            cita.ObjetivoCita = objetivocita;

            //Agrego el objeto a la coleccion que gestiona los datos en la bdd
            this.context.Citas.Add(cita);
            this.context.SaveChanges();
        }

        #endregion
    }
}
