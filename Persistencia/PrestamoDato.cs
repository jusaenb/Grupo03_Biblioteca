using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class PrestamoDato : Entity<String>
    {
        private string dni_Usuario;
        private string dni_trabajador;
        private DateTime fecha_prestamo;
        private string estado;
        public PrestamoDato(string dni, string id_Prestamo, DateTime fecha_prestamo, string estado, string dni_trabajador) : base(id_Prestamo)
        {
            this.dni_Usuario = dni;
            this.fecha_prestamo = fecha_prestamo;
            this.estado = estado;
            this.dni_trabajador = dni_trabajador;
        }
        public string Dni_usuario
        {
            get { return dni_Usuario; }
            set { dni_Usuario = value; }
        }
        public string Dni_trabajador
        {
            get
            {
                return dni_trabajador;
            }
            set { dni_trabajador = value; }
        }
        public DateTime Fecha_prestamo
        {
            get { return fecha_prestamo; }
            set { fecha_prestamo = value; }
        }
        public string Estado
        {
            get { return estado; }
            set
            { estado = value; }
        }
        
    }
}
