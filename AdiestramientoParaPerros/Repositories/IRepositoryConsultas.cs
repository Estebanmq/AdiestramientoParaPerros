using AdiestramientoParaPerros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdiestramientoParaPerros.Repositories
{
    public interface IRepositoryConsultas
    {

        #region AAD CONSULTAS

        /// <summary>
        ///     Inserta una consulta con los datos pasados commo parametros
        /// </summary>
        /// <param name="emailcontacto">El email de contacto</param>
        /// <param name="telefonocontacto">El telefono de contacto</param>
        /// <param name="textoconsulta">El texto con la consulta</param>        
        void InsertConsulta(String emailcontacto, int telefonocontacto, String textoconsulta);

        /// <summary>
        ///     Metodo que calcula el id mas alto de la tabla
        /// </summary>
        /// <returns>El id mas alto</returns>
        int GetMaxIdConsulta();

        /// <summary>
        ///     Devuelve todas las consultas almacenadas en la bdd
        /// </summary>        
        /// <returns></returns>
        List<Consulta> GetConsultas();

        /// <summary>
        /// Devuelve las consultas con el estado indicado como parametro
        /// </summary>
        /// <param name="idestado">El id del estado de las consultas</param>
        /// <returns>La lista con las consultas</returns>
        List<Consulta> GetConsultasEstado(int idestado);

        /// <summary>
        ///     Devuelve una consulta a partir de su id 
        /// </summary>
        /// <param name="idconsulta">El id de la consulta</param>
        /// <returns>Laconsulta si la encuentra, si no, null</returns>
        Consulta FindConsulta(int idconsulta);

        /// <summary>
        ///     Actualiza el estado de una consulta con el id pasado como parametro
        /// </summary>
        /// <param name="estado">El id del estado nuevo</param>
        /// <param name="idconsulta">El id de la consulta</param>
        void UpdateEstadoConsulta(int estado, int idconsulta);

        #endregion

        #region AAD ESTADOS
        /// <summary>
        ///     Devuelve todos los estados para las consultas
        /// </summary>        
        /// <returns>Una lista con todos los estados</returns>
        List<Estado> GetEstados();


        /// <summary>
        ///     Devuelve un estado a partir de su id
        /// </summary>
        /// <param name="id">El id del estado</param>
        /// <returns>El Estado si lo encuentra.
        /// Null si no lo encuentra</returns>
        Estado FindEstado(int id);

        #endregion
    }
}
