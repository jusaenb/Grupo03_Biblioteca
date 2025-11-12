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
        private int duracion; // Duración en minutos
       public AudioLibro(string titulo, string autor, string editorial, int añoPublicacion, int isbn, string formato, int duracion)
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
        public int Duracion
        {
            get { return duracion; }
            set { duracion = value; }
        }
    }
}
