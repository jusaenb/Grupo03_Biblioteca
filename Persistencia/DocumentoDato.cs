using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    internal class DocumentoDato : Entity<int>
    {
        private int año;
        private string titulo;
        private string autor;
        private string editorial;
        private string tipo;

        public DocumentoDato(int isbn, int año, string titulo, string autor, string editorial, string tipo) : base(isbn)
        {
            this.año = año;
            this.titulo = titulo;
            this.autor = autor;
            this.editorial = editorial;
            this.tipo = tipo;
        }
        public int Año
        {
            get
            {
                return this.año;
            }
            set
            {
                this.año= value;
            }
        }
        public string Titulo
        {
            get { return this.titulo; }
            set { this.titulo = value; }
        }
        public string Autor
        {
            get { return this.autor; }
            set { this.autor = value; }
        }
        public string Editorial
        {
            get { return this.editorial; }
            set { this.editorial = value; }
            }
        public string Tipo
        {
            get { return this.tipo; }
            set { this.tipo = value; }
        }
      

    }
}
