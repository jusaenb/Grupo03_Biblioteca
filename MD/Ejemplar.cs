using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD
{
    public class Ejemplar
    {
        private int codigoEjemplar;
        private Documento documento;

        private bool disponible;
        public Ejemplar(int codigoEjemplar, Documento documento, bool disponible)
        {
            this.documento= documento;
            this.codigoEjemplar = codigoEjemplar;
            this.disponible = disponible;
        }
        public int CodigoEjemplar
        {
            get { return codigoEjemplar; }
            set { codigoEjemplar = value; }
        }
        public Documento Documento
        {
            get { return documento; }
            set { documento = value; }
        }
        public bool Disponible
        {
            get { return disponible; }
            set { disponible = value; }
        }

    }
}
