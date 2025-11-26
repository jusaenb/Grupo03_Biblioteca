using MD;
using Persistencia;
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

            foreach (Ejemplar ej in ejemplaresPrestamo)
            {
                ej.Disponible = false;
                PersistenciaEjemplar.UPDATE(ej);
            }
        }

        public void DevolverEjemplar(int codigoEjemplar)
        {
            // 1. Buscar el préstamo activo asociado a este ejemplar
            // Este método SÍ existe en tu PersistenciaPrestamo.cs actual
            Prestamo prestamo = PersistenciaPrestamo.READ_POR_EJEMPLAR(codigoEjemplar);

            if (prestamo == null)
            {
                throw new InvalidOperationException("Este ejemplar no está prestado actualmente.");
            }

            // 2. Liberar el Ejemplar (Marcarlo como disponible)
            Ejemplar ejemplarADevolver = prestamo.Ejemplares.FirstOrDefault(e => e.CodigoEjemplar == codigoEjemplar);
            if (ejemplarADevolver != null)
            {
                ejemplarADevolver.Disponible = true;
                PersistenciaEjemplar.UPDATE(ejemplarADevolver);
            }

            // 3. Comprobar si finalizamos el préstamo completo
            // Requisito: "finalizado en el caso de que se hayan devuelto TODOS los documentos"
            bool todosDevueltos = prestamo.Ejemplares.All(e => e.Disponible);

            if (todosDevueltos)
            {
                prestamo.Estado = "Finalizado";
                PersistenciaPrestamo.UPDATE(prestamo);
            }
        }
    }
}
