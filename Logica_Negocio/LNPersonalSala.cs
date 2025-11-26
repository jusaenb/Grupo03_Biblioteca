using MD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia;

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
        public void DarAltaPrestamo(string dniUsuario, List<int> codigosEjemplares)
        {
            if (!PersistenciaUsuario.EXIST(dniUsuario))
                throw new ArgumentException("Usuario no encontrado.");

            Usuario usuario = PersistenciaUsuario.READ(dniUsuario);
            List<Ejemplar> ejemplaresPrestamo = new List<Ejemplar>();

            foreach (int codigo in codigosEjemplares)
            {
                Ejemplar ej = PersistenciaEjemplar.READ(codigo);
                if (ej == null)
                    throw new ArgumentException($"Ejemplar {codigo} no existe.");

                if (!ej.Disponible)
                    throw new InvalidOperationException($"Ejemplar {codigo} ya está prestado.");

                ejemplaresPrestamo.Add(ej);
            }

            string idPrestamo = DateTime.Now.Ticks.ToString();

            Prestamo nuevoPrestamo = new Prestamo(usuario, ejemplaresPrestamo, DateTime.Now, "En Proceso");

            PersistenciaPrestamo.CREATE(nuevoPrestamo);
        }

        public void DevolverEjemplar(int codigoEjemplar)
        {
            Ejemplar ej = PersistenciaEjemplar.READ(codigoEjemplar);
            if (ej == null) throw new ArgumentException("Ejemplar no existe.");

            PersistenciaPrestamo.DEVOLVER_EJEMPLAR(codigoEjemplar);
        }
    }
}
