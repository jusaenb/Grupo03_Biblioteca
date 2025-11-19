using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    internal class Compuesto
    {
        private string prestamo;
        private string ejemplar;
        public Compuesto(string prestamo, string ejemplar)
        {
            this.prestamo = prestamo;
            this.ejemplar = ejemplar;
        }
        public string Ejemplar
        {
            get { return this.ejemplar; }
        }
        public string Prestamo
        {
            get { return prestamo; }
        }
    }
}
