using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class PersonalDato : Entity<String>
    {
        private String nombre;

        public PersonalDato(String dni, String nombre) : base(dni)
        {
            this.nombre = nombre;
        }

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
    }
}
