using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MD;

namespace LN
{
    public class LNPersonal
    {
        public Personal Personal { get; private set; }
        public LNPersonal(Personal personal)
        {
            this.Personal = personal;
        }
        public bool Loguearse(string password)
        {
            return true;
        }
        public void darAltaUsuario(string dni, string nombre)
        {
        }
        public void darBajaUsuario(string dni, string nombre)
        {
        }
    }
}
