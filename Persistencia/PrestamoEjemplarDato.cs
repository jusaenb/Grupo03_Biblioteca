using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    internal class PrestamoEjemplarDato : Entity<Compuesto>
    {
        private DateTime fecha;
        private bool devuelto;
        public PrestamoEjemplarDato(string prestamo, string ejemplar, DateTime fecha, bool devuelto) : base(new Compuesto(prestamo, ejemplar))
        {
            this.fecha = fecha;
            this.devuelto = false;
        }
        public DateTime Fecha
        {
            get { return this.fecha; }
            set { this.fecha = value; }
        }
        public bool Devuelto
        {
            get { return this.devuelto; }
            set { this.devuelto = value; }
        }
    }
}
