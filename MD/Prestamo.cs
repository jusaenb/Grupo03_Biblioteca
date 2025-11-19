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
        private Ejemplar ejemplar;
        private DateTime fechaPrestamo;
        private DateTime fechaDevolucion;
        private string estado; 
        public Prestamo(Usuario usuario, Ejemplar ejemplar, DateTime fechaPrestamo, string estado)
        {
            this.usuario = usuario;
            this.ejemplar = ejemplar;
            this.fechaPrestamo = fechaPrestamo;
           if(ejemplar.Documento is AudioLibro)
            {
                this.fechaDevolucion = fechaPrestamo.AddDays(10); // 7 días para audiolibros
            }
            else
            {
                this.fechaDevolucion = fechaPrestamo.AddDays(15); // 14 días para otros documentos
            }
            this.estado = estado;
        }
        public Usuario Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }
        public Ejemplar Ejemplar
        {
            get { return ejemplar; }
            set { ejemplar = value; }
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
