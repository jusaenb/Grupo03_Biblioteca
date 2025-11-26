using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    internal class UsuarioDato : Entity<string>
    {
        public string Nombre { get; set; }

        public UsuarioDato(string dni, string nombre) : base(dni)
        {
            this.Nombre = nombre;
        }
    }
}
