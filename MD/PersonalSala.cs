using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD
{
    public class PersonalSala : Personal
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase PersonalSala asignándole el rol de Sala
        /// </summary>
        /// <param name="dni">Número de identificación único del trabajador</param>
        /// <param name="nombre">Nombre del trabajador</param>
        public PersonalSala(string dni, string nombre) : base(dni, nombre)
        {
            this.Rol = Rol.Sala;
        }
    }
}
