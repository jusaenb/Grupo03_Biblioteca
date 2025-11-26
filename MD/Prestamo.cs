using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD
{
    public class Prestamo
    {
        private Usuario usuario;
        private List<Ejemplar> ejemplares;
        private DateTime fechaPrestamo;
        private DateTime fechaDevolucion;
        private string estado; 
        public Prestamo(Usuario usuario, List<Ejemplar> ejemplares, DateTime fechaPrestamo, string estado)
        {
            this.usuario = usuario;
            this.ejemplares = ejemplares ?? new List<Ejemplar>();
            this.fechaPrestamo = fechaPrestamo;
            bool contieneAudiolibro = this.ejemplares.Any(e => e.Documento is AudioLibro);

            if (contieneAudiolibro)
            {
                this.fechaDevolucion = fechaPrestamo.AddDays(10);
            }
            else
            {
                this.fechaDevolucion = fechaPrestamo.AddDays(15);
            }
        }
        public Usuario Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }
        public List<Ejemplar> Ejemplares
        {
            get { return ejemplares; }

            set { ejemplares = value; }
        }
        public DateTime FechaPrestamo
        {
            get { return fechaPrestamo; }
            set { fechaPrestamo = value; }
        }
        public DateTime FechaDevolucion
        {
            get { return fechaDevolucion; }
            set { fechaDevolucion = value; }
        }
        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }
    }
}
