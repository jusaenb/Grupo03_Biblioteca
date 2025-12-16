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
            // 1. Validar que el ejemplar existe
            Ejemplar ej = PersistenciaEjemplar.READ(codigoEjemplar);
            if (ej == null)
            {
                throw new ArgumentException("El ejemplar no existe en la base de datos.");
            }

            // 2. Llamar al método directo de persistencia que maneja los IDs correctamente
            try
            {
                PersistenciaPrestamo.RegistrarDevolucion(codigoEjemplar);

                // 3. Liberar el ejemplar (ponerlo disponible de nuevo)
                ej.Disponible = true;
                PersistenciaEjemplar.UPDATE(ej);
            }
            catch (Exception ex)
            {
                // Re-lanzamos el error para que salga el mensaje en pantalla
                throw ex;
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
        public Ejemplar ObtenerEjemplar(int codigo)
        {
            // Necesitas 'using Persistencia;' arriba
            return PersistenciaEjemplar.READ(codigo);
        }
        public List<Ejemplar> ObtenerEjemplaresPrestadosUsuario(string dniUsuario)
        {
            List<Ejemplar> resultado = new List<Ejemplar>();

            // Obtenemos todos los préstamos activos
            var prestamosActivos = PersistenciaPrestamo.READALL()
                                   .Where(p => p.Estado == "En Proceso" && p.Usuario.Dni == dniUsuario);

            foreach (var prestamo in prestamosActivos)
            {
                resultado.AddRange(prestamo.Ejemplares);
            }
            return resultado;
        }
        public List<Prestamo> ObtenerPrestamosFueraDePlazo()
        {
            var todos = PersistenciaPrestamo.READALL().Where(p => p.Estado == "En Proceso");
            List<Prestamo> morosos = new List<Prestamo>();

            foreach (var p in todos)
            {
                // Comprobamos cada ejemplar del préstamo
                foreach (var ej in p.Ejemplares)
                {
                    // Calculamos fecha límite: FechaPrestamo + Dias del tipo de documento
                    DateTime fechaLimite = p.FechaPrestamo.AddDays(ej.Documento.DiasPrestamo);

                    if (DateTime.Now > fechaLimite)
                    {
                        morosos.Add(p);
                        break; // Con que tenga uno caducado, el préstamo sale en la lista
                    }
                }
            }
            return morosos;
        }
        public DateTime? ObtenerFechaDisponibilidad(int isbn)
        {
            // 1. Ver si hay alguno libre ya
            var ejemplares = PersistenciaEjemplar.READALL().Where(e => e.Documento.Isbn == isbn);
            if (ejemplares.Any(e => e.Disponible)) return DateTime.Now; // ¡Ya está libre!

            // 2. Si no, buscar cuándo devuelven el primero
            var prestamosConEseLibro = PersistenciaPrestamo.READALL_POR_ISBN(isbn)
                                       .Where(p => p.Estado == "En Proceso");

            DateTime? fechaMasProxima = null;

            foreach (var p in prestamosConEseLibro)
            {
                // Buscamos el ejemplar concreto de este libro dentro del préstamo
                var ejemplar = p.Ejemplares.FirstOrDefault(e => e.Documento.Isbn == isbn);
                if (ejemplar != null)
                {
                    DateTime fechaDev = p.FechaPrestamo.AddDays(ejemplar.Documento.DiasPrestamo);

                    if (fechaMasProxima == null || fechaDev < fechaMasProxima)
                    {
                        fechaMasProxima = fechaDev;
                    }
                }
            }
            return fechaMasProxima;
        }
    }
}