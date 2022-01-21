using AdiestramientoParaPerros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdiestramientoParaPerros.Repositories
{
    public interface IRepositoryEmpleadosUsuarios
    {
       
        //Metodo que devuelve todos los roles de la bdd
        List<Rol> GetRoles();

        //Metodo que devuelve un rol a partir de su id
        Rol FindRol(int idrol);

    }
}
