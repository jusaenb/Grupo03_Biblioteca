using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class EjemplarDato : Entity<String>
    {
        private bool prestado;
        private int isbn;
        private string personal_adqu;
        public EjemplarDato(String id, bool prestado, int isbn, string personal) : base(id)
        {
            this.prestado = prestado;
            this.isbn
                = isbn;
            this.personal_adqu = personal;
        }
        public bool Prestado
        {
            get
            { return prestado; }
            set
            {
                this.prestado = value;
            }
        }
        public int Isbn
        {
            get
            {
                return isbn;
            }
            set
            {
                isbn = value;
            }
        }
        public string Personal_adqu
        {
            get { return personal_adqu; }
            set
            {
                personal_adqu = value;
            }

        }
    }
}
