using MD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LN
{
    public class LNPersonalSala : LNPersonal
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="personalSala"></param>
        public LNPersonalSala(PersonalSala personalSala) : base(personalSala)
        {

        }   
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dniUsuario"></param>
        /// <param name="ejemplares"></param>
        public void DarAltaPrestamo(string dniUsuario, List<string> ejemplares)
        {

        }
    }
}
