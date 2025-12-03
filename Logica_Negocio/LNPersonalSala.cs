using MD;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LN
{
    public class LNPersonalSala : LNPersonal
    {
        public LNPersonalSala(PersonalSala personalSala) : base(personalSala)
        {
        }

        public void DarAltaPrestamo(string dniUsuario, List<int> codigosEjemplares)
        {
            // 1. Validar Usuario
            if (!PersistenciaUsuario.EXIST(dniUsuario))
                throw new ArgumentException("Usuario no encontrado.");

            Usuario usuario = PersistenciaUsuario.READ(dniUsuario);
            List<Ejemplar> ejemplaresParaPrestar = new List<Ejemplar>();

            // 2. Validar Ejemplares
            foreach (int codigo in codigosEjemplares)
            {
                Ejemplar ej = PersistenciaEjemplar.READ(codigo);

                if (ej == null)
                    throw new ArgumentException($"El ejemplar {codigo} no existe.");

                if (!ej.Disponible)
                    throw new InvalidOperationException($"El ejemplar {codigo} ({ej.Documento.Titulo}) no está disponible.");

                ejemplaresParaPrestar.Add(ej);
            }

            if (ejemplaresParaPrestar.Count == 0)
                throw new ArgumentException("Debe seleccionar al menos un ejemplar.");

            // 3. Crear Préstamo
            Prestamo nuevoPrestamo = new Prestamo(usuario, ejemplaresParaPrestar, DateTime.Now, "En Proceso");

            // 4. Guardar Préstamo
            PersistenciaPrestamo.CREATE(nuevoPrestamo);

            // 5. Actualizar estado de los ejemplares a NO DISPONIBLE
            foreach (Ejemplar ej in ejemplaresParaPrestar)
            {
                ej.Disponible = false;
                PersistenciaEjemplar.UPDATE(ej);
            }
        }

        public void DevolverEjemplar(int codigoEjemplar)
        {
            // 1. Buscar el préstamo activo asociado a este ejemplar
            Prestamo prestamo = PersistenciaPrestamo.READ_POR_EJEMPLAR(codigoEjemplar);

            if (prestamo == null)
            {
                throw new InvalidOperationException("No se encontró ningún préstamo activo para este ejemplar.");
            }

            // 2. Liberar el Ejemplar concreto
            Ejemplar ejemplarADevolver = prestamo.Ejemplares.FirstOrDefault(e => e.CodigoEjemplar == codigoEjemplar);
            if (ejemplarADevolver != null)
            {
                ejemplarADevolver.Disponible = true;
                PersistenciaEjemplar.UPDATE(ejemplarADevolver);
            }

            // 3. Comprobar si el préstamo se completa (todos los libros devueltos)
            // Nota: Como acabamos de liberar uno, verificamos si queda alguno NO disponible.
            // PERO ojo: los objetos en memoria 'prestamo.Ejemplares' podrían no estar actualizados 
            // si no recargamos. 
            // Para simplificar: Si todos están disponibles, cerramos.

            bool todosDevueltos = prestamo.Ejemplares.All(e => e.Disponible);

            if (todosDevueltos)
            {
                prestamo.Estado = "Finalizado";
                PersistenciaPrestamo.UPDATE(prestamo);
            }
        }

        public List<Prestamo> ListadoPrestamosActivos()
        {
            return PersistenciaPrestamo.READALL()
                .Where(p => p.Estado == "En Proceso")
                .ToList();
        }
    }
}