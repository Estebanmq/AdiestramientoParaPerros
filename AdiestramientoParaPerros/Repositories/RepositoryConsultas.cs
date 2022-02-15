using AdiestramientoParaPerros.Data;
using AdiestramientoParaPerros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdiestramientoParaPerros.Repositories
{
    public class RepositoryConsultas : IRepositoryConsultas
    {

        private AdiestramientoContext context;

        public RepositoryConsultas(AdiestramientoContext context)
        {
            this.context = context;
        }

        #region AAD Consultas

        /// <summary>
        ///     Inserta una consulta con los datos pasados commo parametros
        /// </summary>
        /// <param name="emailcontacto">El email de contacto</param>
        /// <param name="telefonocontacto">El telefono de contacto</param>
        /// <param name="textoconsulta">El texto con la consulta</param>        
        public void InsertConsulta(String emailcontacto, String telefonocontacto, String textoconsulta)
        {       
            Consulta consulta = new Consulta();
            consulta.EmailContacto = emailcontacto;
            consulta.TelefonoContacto = telefonocontacto;
            consulta.TextoConsulta = textoconsulta;

            //Cambiar por store procedure
            int id = this.context.Consultas.Max(z => z.IdConsulta + 1);
            consulta.IdConsulta = id;
            consulta.Estado = 0;

            this.context.Consultas.Add(consulta);
            this.context.SaveChanges();
        }

        /// <summary>
        ///     Devuelve todas las consultas almacenadas en la bdd
        /// </summary>        
        /// <returns></returns>
        public List<Consulta> GetConsultas()
        {
            var consulta = from datos in this.context.Consultas
                           select datos;
            return consulta.ToList();
        }

        /// <summary>
        ///     Devuelve una consulta a partir de su id 
        /// </summary>
        /// <param name="idconsulta">El id de la consulta</param>
        /// <returns>Laconsulta si la encuentra, si no, null</returns>
        public Consulta FindConsulta(int idconsulta)
        {
            return this.context.Consultas.FirstOrDefault(z => z.IdConsulta == idconsulta);
        }

        /// <summary>
        /// Devuelve las consultas con el estado indicado como parametro
        /// </summary>
        /// <param name="idestado">El id del estado de las consultas</param>
        /// <returns>La lista con las consultas</returns>
        public List<Consulta> GetConsultasEstado(int idestado)
        {
            var consulta = from datos in this.context.Consultas
                           where datos.Estado == idestado
                           select datos;
            return consulta.ToList();
        }


        /// <summary>
        ///     Actualiza el estado de una consulta con el id pasado como parametro
        /// </summary>
        /// <param name="estado">El id del estado nuevo</param>
        /// <param name="idconsulta">El id de la consulta</param>
        public void UpdateEstadoConsulta(int estado, int idconsulta)
        {
            Consulta consulta = this.FindConsulta(idconsulta);
            consulta.Estado = estado;
            this.context.SaveChanges();
        }
        #endregion

        #region AAD Estados
        
        /// <summary>
        ///     Devuelve todos los estados para las consultas
        /// </summary>        
        /// <returns>Una lista con todos los estados</returns>
        public List<Estado> GetEstados()
        {
            var consulta = from datos in this.context.Estados
                           select datos;
            return consulta.ToList();
        }

        /// <summary>
        ///     Devuelve un estado a partir de su id
        /// </summary>
        /// <param name="id">El id del estado</param>
        /// <returns>El Estado si lo encuentra.
        /// Null si no lo encuentra</returns>
        public Estado FindEstado(int id)
        {
            return this.context.Estados.FirstOrDefault(z => z.IdEstado == id);
        }

     

        #endregion
    }
}
