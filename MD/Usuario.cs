using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MD
{
    public class Usuario
    {
        private string dni;
        private string nombre;

        /// <summary>
        /// Constructor de la clase Usuario.
        /// </summary>
        /// <param name="dni">DNI del usuario (Identificador único)</param>
        /// <param name="nombre">Nombre completo del usuario</param>
        public Usuario(string dni, string nombre)
        {
            this.dni = dni;
            this.nombre = nombre;
        }

        public string Dni
        {
            get { return dni; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Usuario other = (Usuario)obj;
            return this.dni == other.dni;
        }

        public override int GetHashCode()
        {
            return this.dni.GetHashCode();
        }
    }
}
