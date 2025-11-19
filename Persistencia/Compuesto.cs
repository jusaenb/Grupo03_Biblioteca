using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    internal class Compuesto:IEquatable<Compuesto>
    {
        private string cadena1;
        private string cadena2;
        public Compuesto(string prestamo, string ejemplar)
        {
            this.cadena1 = prestamo;
            this.cadena2 = ejemplar;
        }
        public string Cadena1
        {
            get { return this.cadena2; }
        }
        public string Cadena2
        {
            get { return cadena2; }
        }

        public bool Equals(Compuesto other)
        {
           if (other == null) return false;
            return (Cadena1.Equals(other.Cadena1) && Cadena2.Equals(other.Cadena2));
        }
    }
}
