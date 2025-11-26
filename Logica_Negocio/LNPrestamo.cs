using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MD;

namespace Logica_Negocio
{
    internal class LNPrestamo
    {
        private List<Prestamo> listaPrestamos;

        public LNPrestamo()
        {
            listaPrestamos = new List<Prestamo>();
        }

        /// <summary>
        /// Un usuario realiza un prestamo.
        /// PRE: Recibe unejemplar, el usuario que realiza el prestamo y el trabajador que lo realiza.
        /// POST:El ejemplar se marca como no disponible y el préstamo se registra.
        /// </summary>
        public void RealizarPrestamo(Usuario usuario, Ejemplar ejemplar, string trabajador)
        {
            // Verificar si esta disponible
            if (!ejemplar.Disponible)
            {
                 Console.WriteLine($"El ejemplar con código {ejemplar.CodigoEjemplar} no está disponible para préstamo.");
                 return;
            }

            // Crear el préstamo
            DateTime fechaPrestamo = DateTime.Now;
            Prestamo nuevoPrestamo = new Prestamo(usuario, ejemplar, fechaPrestamo, trabajador);

            // Marcar los ejemplar como no disponibles
            ejemplar.Disponible = false;

            // Registrar el préstamo
            listaPrestamos.Add(nuevoPrestamo);
            
        }

        /// <summary>
        /// Realiza la devolución de un ejemplar prestado.
        /// PRE: recibe el ejemplar a devolver.
        /// POST: El ejemplar se marca como disponible y el préstamo se actualiza a 'Finalizado'.
        /// </summary>
        public void DevolverPrestamo(Ejemplar ejemplar)
        {
            var prestamo = listaPrestamos.FirstOrDefault(p => p.Ejemplar == ejemplar && p.Estado == "En proceso");

            if (prestamo == null)
            {
                Console.WriteLine("No se encontró un préstamo activo para este ejemplar.");
                return;
            }

            // Marcar el ejemplar como disponible
            ejemplar.Disponible = true;
            prestamo.Estado = "Finalizado";
            Console.WriteLine($"El préstamo con el usuario {prestamo.Usuario} se ha finalizado.");

        }

        /// <summary>
        /// Consultar los préstamos activos y su estado.
        /// PRE:
        /// POST: Se muestra información de los préstamos que están activos (en proceso).
        /// </summary>
        public void ConsultarPrestamosActivos()
        {
            var prestamosActivos = listaPrestamos.Where(p => p.Estado == "En proceso").ToList();

            if (prestamosActivos.Count == 0)
            {
                Console.WriteLine("No hay préstamos activos en el sistema.");
                return;
            }

            foreach (var prestamo in prestamosActivos)
            {
                Console.WriteLine($"Préstamo activo para el usuario {prestamo.Usuario}:");
                Console.WriteLine($"Fecha de préstamo: {prestamo.FechaPrestamo.ToShortDateString()}");
                Console.WriteLine($"Fecha de devolución: {prestamo.FechaDevolucion.ToShortDateString()}");              
                Console.WriteLine($" - Ejemplar código: {prestamo.Ejemplar.CodigoEjemplar}, Documento: {prestamo.Ejemplar.Documento.Titulo}");
                Console.WriteLine("-----------------------------");
            }
        }

        /// <summary>
        /// Obtener el estado de un préstamo.
        /// PRE: Recibe el ejemplar del que se quiere saber el estado.
        /// POST:Se muestra el estado del préstamo (en proceso o finalizado).
        /// </summary>
        public void ConsultarEstadoPrestamo(Ejemplar ejemplar)
        {
            var prestamo = listaPrestamos.FirstOrDefault(p => p.Ejemplar == ejemplar);

            if (prestamo == null)
            {
                Console.WriteLine("El ejemplar no tiene un préstamo asociado.");
                return;
            }

            Console.WriteLine($"Préstamo {prestamo.Estado} para el ejemplar {ejemplar.CodigoEjemplar}:");
            Console.WriteLine($"Fecha de préstamo: {prestamo.FechaPrestamo.ToShortDateString()}");
            Console.WriteLine($"Fecha de devolución: {prestamo.FechaDevolucion.ToShortDateString()}");
            if (prestamo.Estado == "En proceso")
            {
                Console.WriteLine("El ejemplar aún no ha sido devuelto.");
            }
            else
            {
                Console.WriteLine("El ejemplar ha sido devuelto.");
            }
        }

        /// <summary>
        /// Obtener todos los préstamos en los que aparece un determinado documento.
        /// PRE: El documento debe existir en el sistema.
        /// POST: Se muestra información sobre los préstamos asociados a ese documento.
        /// </summary>
        public void ConsultarPrestamosPorDocumento(Documento documento)
        {
            var prestamosDelDocumento = listaPrestamos.Where(p => p.Ejemplar.Documento == documento).ToList();

            if (prestamosDelDocumento.Count == 0)
            {
                Console.WriteLine("No hay préstamos asociados a este documento.");
                return;
            }

            foreach (var prestamo in prestamosDelDocumento)
            {
                Console.WriteLine($"Préstamo {prestamo.Estado} para el usuario {prestamo.Usuario}:");
                Console.WriteLine($"Fecha de préstamo: {prestamo.FechaPrestamo.ToShortDateString()}");
                Console.WriteLine($"Fecha de devolución: {prestamo.FechaDevolucion.ToShortDateString()}");
                Console.WriteLine($"Ejemplar prestado: Código {prestamo.Ejemplar.CodigoEjemplar}, Documento: {prestamo.Ejemplar.Documento.Titulo}");
                Console.WriteLine("-----------------------------");
            }
        }
    }
}
