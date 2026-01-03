using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD
{
    public class PersonalAdquisiciones : Personal
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase PersonalAdquisiciones asignándole el rol de Adquisiciones
        /// </summary>
        /// <param name="dni">Número de identificación único del trabajador</param>
        /// <param name="nombre">Nombre del trabajador</param>
        public PersonalAdquisiciones(string dni, string nombre) : base(dni, nombre)
        {
            this.Rol = Rol.Adquisiciones;
        }


    }
}
