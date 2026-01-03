using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD
{
    public  class Documento
    {
        private int añoPublicacion;
        private string titulo;
        private string autor;
        private int isbn;
        private string editorial;
        public virtual int DiasPrestamo => 15;
        public Documento(int añoPublicacion, string titulo, string autor, int isbn, string editorial)
        {
            this.añoPublicacion = añoPublicacion;
            this.titulo = titulo;
            this.autor = autor;
            this.isbn = isbn;
            this.editorial = editorial;
        }
        public int AñoPublicacion
        {
            get { return añoPublicacion; }
            set { añoPublicacion = value; }
        }
        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; }
        }
        public string Autor
        {
            get { return autor; }
            set { autor = value; }
        }
        public int Isbn
        {
            get { return isbn; }
            set { isbn = value; }
        }
        public string Editorial
        {
            get { return editorial; }
            set { editorial = value; }
        }
        public override string ToString()
        {
            return this.titulo;
        }

    }
}
