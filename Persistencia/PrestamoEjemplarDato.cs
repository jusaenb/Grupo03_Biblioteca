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
        public PrestamoEjemplarDato(string prestamo, string ejemplar, DateTime fecha) : base(new Compuesto(prestamo, ejemplar))
        {
            this.fecha = fecha;
            
        }
        public DateTime Fecha
        {
            get { return this.fecha; }
            set { this.fecha = value; }
        }
    }
}
