﻿using AdiestramientoParaPerros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdiestramientoParaPerros.Repositories
{
    public interface IRepositoryCitas
    {

        /// <summary>
        ///     Devuelve todas las citas asignadas al empleado con el id pasado como parametro
        /// </summary>
        /// <param name="idempleado">El id del empleado</param>
        /// <returns></returns>
        List<Cita> GetCitasEmpleado(int idempleado);

        /// <summary>
        ///     Devuelve todas las citas del cliente con el id pasado como parametro
        /// </summary>
        /// <param name="idcliente">El id del cliente</param>
        /// <returns></returns>
        List<Cita> GetCitasCliente(int idcliente);

        /// <summary>
        ///     Devuelve todas las citas de la bbdd
        /// </summary>
        /// <returns>
        ///     Todas las citas
        /// </returns>
        List<Cita> GetCitas();

        /// <summary>
        ///    Devuelve una cita a traves de su id
        /// </summary>
        /// <param name="idcita">
        ///     El id de la cita a recuperar
        /// </param>
        /// <returns>
        ///     La cita con el id pasado como parametro
        /// </returns>
        Cita FindCita(int idcita);

        /// <summary>
        ///     Inserta en la base de datos una nueva cita con los datos pasados como parametros
        /// </summary>
        /// <param name="fechacita">La fecha de la cita</param>
        /// <param name="telefonocontacto">El telefono de contacto</param>
        /// <param name="nombreperro">El nombre del perro</param>
        /// <param name="razaperro">La raza del perro</param>
        /// <param name="motivocita">El motivo de la cita</param>
        /// <param name="objetivocita">El objetivo de la cita</param>
        void InsertCita(String fechacita, String telefonocontacto, String nombreperro, String razaperro, String motivocita, String objetivocita);

        /// <summary>
        ///     Metodo que actualiza el motivo y el objetivo de la cita con el id pasado como parametro
        /// </summary>
        /// <param name="idcita">El id de la cita a actualizar</param>
        /// <param name="motivocita">El nuevo motivo de la cita</param>
        /// <param name="objetivocita">El nuevo motivo de la cita</param>
        void UpdateCita(int idcita, String motivocita, String objetivocita);

        /// <summary>
        ///     Elimina la cita con el id indicado como parametro
        /// </summary>
        /// <param name="idcita">El id de la cita a eliminar</param>
        void DeleteCita(int cita);
    }
}