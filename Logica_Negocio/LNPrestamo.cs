using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MD;
using Persistencia;

namespace Logica_Negocio
{
    internal class LNPrestamo
    {

        /// <summary>
        /// Realiza un préstamo de varios ejemplares a un usuario.
        /// PRE: Recibe una lista de ejemplares y el usuario que realiza el préstamo.
        /// POST: Los ejemplares se marcan como no disponibles, se crea el préstamo en la base de datos y se guarda la relación con los ejemplares.
        /// </summary>
        public void RealizarPrestamo(Usuario usuario, List<Ejemplar> ejemplares, Personal trabajador)
        {
            // Verificar si todos los ejemplares están disponibles para préstamo
            foreach (var ejemplar in ejemplares)
            {
                if (!ejemplar.Disponible)
                {
                    Console.WriteLine($"El ejemplar con código {ejemplar.CodigoEjemplar} no está disponible para préstamo.");
                    return;
                }
            }

            // Crear el préstamo
            DateTime fechaPrestamo = DateTime.Now;
            Prestamo nuevoPrestamo = new Prestamo(usuario, ejemplares, fechaPrestamo, "En proceso", trabajador);

            // Crear el préstamo en la base de datos
            PersistenciaPrestamo.CREATE(nuevoPrestamo);

            // Marcar los ejemplares como no disponibles
            foreach (var ejemplar in ejemplares)
            {
                ejemplar.Disponible = false;
            }

            // Confirmación de éxito
            Console.WriteLine($"Préstamo realizado con éxito para el usuario {usuario.Nombre}. Fecha de devolución: {nuevoPrestamo.FechaDevolucion.ToShortDateString()}");
        }

        /// <summary>
        /// Realiza la devolución de un ejemplar prestado.
        /// PRE: Recibe un ejemplar que ha sido prestado.
        /// POST: El ejemplar se marca como disponible y el estado del préstamo se actualiza a "Finalizado" si todos los ejemplares han sido devueltos.
        /// </summary>
        public void DevolverPrestamo(Ejemplar ejemplar)
        {
            // Buscar el préstamo activo asociado a este ejemplar
            Prestamo prestamo = PersistenciaPrestamo.READ_POR_EJEMPLAR(ejemplar.CodigoEjemplar);
            if (prestamo == null)
            {
                Console.WriteLine("No se encontró un préstamo activo para este ejemplar.");
                return;
            }

            // Marcar el ejemplar como disponible
            ejemplar.Disponible = true;

            // Verificar si todos los ejemplares del préstamo han sido devueltos
            bool todosDevueltos = prestamo.Ejemplares.All(e => e.Disponible);

            if (todosDevueltos)
            {
                // Si todos los ejemplares han sido devueltos, se finaliza el préstamo
                prestamo.Estado = "Finalizado";
                // Actualizamos el préstamo en la base de datos
                PersistenciaPrestamo.UPDATE(prestamo);
                Console.WriteLine($"El préstamo para el usuario {prestamo.Usuario.Nombre} ha sido finalizado.");
            }
            else
            {
                Console.WriteLine($"El ejemplar con código {ejemplar.CodigoEjemplar} ha sido devuelto. El préstamo sigue en proceso.");
            }
        }


        /// <summary>
        /// Consulta los préstamos activos de un usuario.
        /// PRE: El usuario debe existir en el sistema.
        /// POST: Muestra los préstamos activos de un usuario en el sistema.
        /// </summary>
        public void ConsultarPrestamosActivosPorUsuario(string dni)
        {
            // Obtener todos los préstamos de un usuario
            List<Prestamo> prestamos = PersistenciaPrestamo.READALL_POR_USUARIO(dni);

            if (prestamos.Count == 0)
            {
                Console.WriteLine("No hay préstamos activos para el usuario.");
                return;
            }

            foreach (var prestamo in prestamos)
            {
                if (prestamo.Estado == "En proceso")
                {
                    Console.WriteLine($"Préstamo activo para el usuario {prestamo.Usuario.Nombre}:");
                    Console.WriteLine($"Fecha de préstamo: {prestamo.FechaPrestamo.ToShortDateString()}");
                    Console.WriteLine($"Fecha de devolución: {prestamo.FechaDevolucion.ToShortDateString()}");
                    Console.WriteLine("Ejemplares prestados:");

                    foreach (var ejemplar in prestamo.Ejemplares)
                    {
                        Console.WriteLine($"- Ejemplar código: {ejemplar.CodigoEjemplar}, Documento: {ejemplar.Documento.Titulo}");
                    }

                    Console.WriteLine("-----------------------------");
                }
            }
        }

        /// <summary>
        /// Consulta los préstamos activos de un documento (ISBN).
        /// PRE: El documento debe existir en el sistema.
        /// POST: Muestra los préstamos activos relacionados con un documento (ISBN).
        /// </summary>
        public void ConsultarPrestamosActivosPorDocumento(int isbn)
        {
            // Obtener todos los préstamos de un documento por ISBN
            List<Prestamo> prestamos = PersistenciaPrestamo.READALL_POR_ISBN(isbn);

            if (prestamos.Count == 0)
            {
                Console.WriteLine("No hay préstamos activos para este documento.");
                return;
            }

            foreach (var prestamo in prestamos)
            {
                if (prestamo.Estado == "En proceso")
                {
                    Console.WriteLine($"Préstamo activo para el usuario {prestamo.Usuario.Nombre}:");
                    Console.WriteLine($"Fecha de préstamo: {prestamo.FechaPrestamo.ToShortDateString()}");
                    Console.WriteLine($"Fecha de devolución: {prestamo.FechaDevolucion.ToShortDateString()}");
                    Console.WriteLine("Ejemplares prestados:");

                    foreach (var ejemplar in prestamo.Ejemplares)
                    {
                        Console.WriteLine($"- Ejemplar código: {ejemplar.CodigoEjemplar}, Documento: {ejemplar.Documento.Titulo}");
                    }

                    Console.WriteLine("-----------------------------");
                }
            }
        }

        /// <summary>
        /// Consulta el estado de un préstamo por el código de un ejemplar.
        /// PRE: El ejemplar debe existir en el sistema y estar prestado.
        /// POST: Muestra el estado del préstamo asociado al ejemplar.
        /// </summary>
        public void ConsultarEstadoPrestamoPorEjemplar(Ejemplar ejemplar)
        {
            // Buscar el préstamo asociado al ejemplar
            Prestamo prestamo = PersistenciaPrestamo.READ_POR_EJEMPLAR(ejemplar.CodigoEjemplar);
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
    }

}

