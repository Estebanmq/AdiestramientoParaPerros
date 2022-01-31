using AdiestramientoParaPerros.Data;
using AdiestramientoParaPerros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdiestramientoParaPerros.Repositories
{
    public class RepositoryCitas : IRepositoryCitas
    {
        private AdiestramientoContext context;

        public RepositoryCitas(AdiestramientoContext context)
        {
            this.context = context;
        }

        #region AAD de Citas
        /// <summary>
        ///     Metodo que devuelve todas las citas de la bbdd
        /// </summary>
        /// <returns>
        ///     Todas las citas
        /// </returns>
        public List<Cita> GetCitas()
        {
            var consulta = from datos in this.context.Citas
                           select datos;

            return consulta.ToList();

        }

        /// <summary>
        ///     Metodo que devuelve una cita a traves de su id
        /// </summary>
        /// <param name="idcita">
        ///     El id de la cita a recuperar
        /// </param>
        /// <returns>
        ///     La cita con el id pasado como parametro
        /// </returns>
        public Cita FindCita(int idcita)
        {
            return this.context.Citas.FirstOrDefault(z => z.IdCita == idcita);

        }

        /// <summary>
        ///     Inserta en la base de datos una nueva cita con los datos pasados como parametros
        /// </summary>
        /// <param name="fechacita">La fecha de la cita</param>
        /// <param name="telefonocontacto">El telefono de contacto</param>
        /// <param name="nombreperro">El nombre del perro</param>
        /// <param name="razaperro">La raza del perro</param>
        /// <param name="motivocita">El motivo de la cita</param>
        /// <param name="objetivocita">El objetivo de la cita</param>
        /// <param name="idcliente">El id del cliente que pidio la cita</param>
        public void InsertCita(String fechacita, String telefonocontacto, String nombreperro, String razaperro, String motivocita, String objetivocita, int idcliente)
        {
            //Formateo la fecha para agregarla al objeto Cita
            DateTime fecha = DateTime.ParseExact(fechacita, "d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture);

            //Objeto Cita para trabajar sobre la Base de datos
            Cita cita = new Cita();
            cita.IdCita = this.GetMaxIdCita();
            cita.FechaCita = fecha;
            cita.TelefonoContacto = telefonocontacto;
            cita.NombrePerro = nombreperro;
            cita.RazaPerro = razaperro;
            cita.MotivoCita = motivocita;
            cita.ObjetivoCita = objetivocita;
            cita.IdCliente = idcliente;

            this.context.Citas.Add(cita);
            this.context.SaveChanges();
        }

        /// <summary>
        ///     Metodo que actualiza el motivo y el objetivo de la cita con el id pasado como parametro
        /// </summary>
        /// <param name="idcita">El id de la cita a actualizar</param>
        /// <param name="motivocita">El nuevo motivo de la cita</param>
        /// <param name="objetivocita">El nuevo motivo de la cita</param>
        public void UpdateCita(int idcita, String motivocita, String objetivocita)
        {
            Cita cita = this.FindCita(idcita);
            cita.MotivoCita = motivocita;
            cita.ObjetivoCita = objetivocita;

            this.context.SaveChanges();
        }

        /// <summary>
        ///     Elimina la cita con el id indicado como parametro
        /// </summary>
        /// <param name="idcita">El id de la cita a eliminar</param>
        public void DeleteCita(int idcita)
        {
            Cita cita = this.FindCita(idcita);
            this.context.Citas.Remove(cita);
            this.context.SaveChanges();



        }

        /// <summary>
        ///     Devuelve todas las citas asignadas al empleado con el id pasado como parametro
        /// </summary>
        /// <param name="idempleado">El id del empleado</param>
        /// <returns>
        ///     Una lista de Cita        
        /// </returns>
        public List<Cita> GetCitasEmpleado(int idempleado)
        {
            return null;
        }

        /// <summary>
        ///     Devuelve todas las citas del cliente con el id pasado como parametro
        /// </summary>
        /// <param name="idcliente">El id del cliente</param>
        /// <returns>
        ///     Una lista de Cita
        /// </returns>
        public List<Cita> GetCitasCliente(int idcliente)
        {
            var consulta = from datos in this.context.Citas
                           where datos.IdCliente == idcliente
                           select datos;
            return consulta.ToList();
        }

        /// <summary>
        ///     Devuelve el Id mas alto de la tabla citas mas 1
        /// </summary>
        /// <returns>El id mas 1</returns>
        public int GetMaxIdCita()
        {
            return this.context.Citas.Max(x => x.IdCita) + 1;
        }


        #endregion
    }
}
