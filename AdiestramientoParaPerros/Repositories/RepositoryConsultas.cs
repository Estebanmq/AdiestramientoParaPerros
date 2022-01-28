using AdiestramientoParaPerros.Data;
using AdiestramientoParaPerros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdiestramientoParaPerros.Repositories
{
    public class RepositoryConsultas
    {

        private AdiestramientoContext context;

        public RepositoryConsultas(AdiestramientoContext context)
        {
            this.context = context;
        }


        #region AAD para consultas

        //Metodo que recibe los datos necesarios para insertar una consulta en el a base de datos
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

        //Metodo que devuelve todas las consulta
        public List<Consulta> GetConsultas()
        {
            var consulta = from datos in this.context.Consultas
                           select datos;
            return consulta.ToList();
        }

        //Metodo que encuentra una consulta por un id
        public Consulta FindConsulta(int idconsulta)
        {
            return this.context.Consultas.FirstOrDefault(z => z.IdConsulta == idconsulta);
        }


        //Método que cambia el estaod de una consulta
        public void UpdateEstadoConsulta(int estado, int idconsulta)
        {
            Consulta consulta = this.FindConsulta(idconsulta);
            consulta.Estado = estado;
            this.context.SaveChanges();
        }
        #endregion

        #region AAD Estados
        //MEtodo que devuelve todos los estados
        public List<Estado> GetEstados()
        {
            var consulta = from datos in this.context.Estados
                           select datos;
            return consulta.ToList();
        }

        //Metodo que devuelve un estado a partir de su id
        public Estado FindEstado(int id)
        {
            return this.context.Estados.FirstOrDefault(z => z.IdEstado == id);
        }

        #endregion
    }
}
