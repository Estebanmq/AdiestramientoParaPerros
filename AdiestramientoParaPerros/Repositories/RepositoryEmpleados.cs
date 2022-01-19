using AdiestramientoParaPerros.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdiestramientoParaPerros.Repositories
{
    public class RepositoryEmpleados
    {

        private AdiestramientoContext context;


        public RepositoryEmpleados(AdiestramientoContext context) { 
            this.context = context; 
        }

        //Metodo que recibe todos los empleados
    }
}
