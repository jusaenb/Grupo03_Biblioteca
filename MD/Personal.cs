using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MD
{
    public abstract class Personal
    {
        public string Dni { get; set; }
        public string Nombre { get; }
        public Rol Rol { get; protected set; }
        /// <summary>
        /// Inicializa una nueva instancia de clase Personal.
        /// </summary>
        /// <param name="dni">Número de identificación único del trabajador</param>
        /// <param name="nombre">Nombre del trabajador</param>
        public Personal(string dni, string nombre)
        {
            Dni = dni;
            Nombre = nombre;
        }
        public override string ToString()
        {
            return  this.Nombre;
        }
    }
}
