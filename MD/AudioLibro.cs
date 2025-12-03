using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD
{
    public class AudioLibro : Documento
    {
        private string formato;
        private float duracion; // Duración en minutos
        public override int DiasPrestamo => 10;
        public AudioLibro(string titulo, string autor, string editorial, int añoPublicacion, int isbn, string formato, float duracion)
            : base(añoPublicacion, titulo, autor, isbn, editorial)
        {
            this.formato = formato;
            this.duracion = duracion;
        }
        public string Formato
        {
            get { return formato; }
            set { formato = value; }
        }
        public float Duracion
        {
            get { return duracion; }
            set { duracion = value; }
        }
    }
}
