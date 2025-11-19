using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    internal class AudioLibroDato : Entity<int>
    {
        private float duracion;
        private string formato;
        public AudioLibroDato(int isbn, float duracion, string formato): base(isbn)
        {
            this.duracion = duracion;
            this.formato = formato;
        }
        public float Duracion
        {
            get { return duracion; }
            set
            {
                this.duracion = value;
            }

        }
        public string Formato
        {
            get { return formato; }
            set { formato = value; }
        }
    }
}
