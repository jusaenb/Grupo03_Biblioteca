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
        private Personal trabajador;
        public Prestamo(Usuario usuario, List<Ejemplar> ejemplares, DateTime fechaPrestamo, string estado, Personal trabajador)
        {
            this.usuario = usuario;
            this.ejemplares = ejemplares ?? new List<Ejemplar>();
            this.fechaPrestamo = fechaPrestamo;
            this.estado = estado;
            this.trabajador = trabajador;

            int dias = 15;
            if (this.ejemplares.Count > 0)
            {
                dias = this.ejemplares.Min(e => e.Documento.DiasPrestamo);
            }
            this.fechaDevolucion = fechaPrestamo.AddDays(dias);

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
        public Personal Trabajador
        {
            get { return trabajador; }
            set { trabajador = value; }
        }
    }
}
