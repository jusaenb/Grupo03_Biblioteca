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
        //PRE: no puede haber valores nulos
        //Post: da de alta un prestamo a un usuario a un ejemplar si esta disponible
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
            Prestamo nuevoPrestamo = new Prestamo(usuario, ejemplaresParaPrestar, DateTime.Now, "En Proceso", this.Personal);

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
            // 1. Buscar el préstamo activo
            Prestamo prestamo = PersistenciaPrestamo.READ_POR_EJEMPLAR(codigoEjemplar);
            if (prestamo == null)
            {
                throw new InvalidOperationException("No se encontró préstamo activo.");
            }

            string idPrestamo = prestamo.GetHashCode().ToString(); // Ojo, usar el mismo ID que uses en Transformer
            string idEjemplar = codigoEjemplar.ToString();

            // 2. Marcar ESTE libro como devuelto en la BD (Tabla intermedia)
            PersistenciaPrestamo.MARCAR_DEVUELTO(idPrestamo, idEjemplar);

            // 3. Liberar el Ejemplar (para que otro lo pueda coger)
            Ejemplar ej = PersistenciaEjemplar.READ(codigoEjemplar);
            ej.Disponible = true;
            PersistenciaEjemplar.UPDATE(ej);

            // 4. Comprobar si el préstamo se cierra COMPLETAMENTE
            if (PersistenciaPrestamo.ESTAN_TODOS_DEVUELTOS(idPrestamo))
            {
                prestamo.Estado = "Finalizado";
                PersistenciaPrestamo.UPDATE(prestamo);
                Console.WriteLine("Préstamo finalizado por completo.");
            }
            else
            {
                Console.WriteLine("Libro devuelto. El préstamo sigue activo con otros libros.");
            }
        }

        public List<Prestamo> ListadoPrestamosActivos()
        {
            return PersistenciaPrestamo.READALL()
                .Where(p => p.Estado == "En Proceso")
                .ToList();
        }
        // Método para obtener solo los ejemplares que se pueden prestar
        public List<Ejemplar> ListadoEjemplaresDisponibles()
        {
            List<Ejemplar> todos = PersistenciaEjemplar.READALL(); // Usamos el método que añadimos antes a Persistencia
            return todos.Where(e => e.Disponible).ToList();
        }
    }
}