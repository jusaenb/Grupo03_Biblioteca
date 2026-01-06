using Logica_Negocio;
using MD;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LN
{
    public class LNPersonalSala : LNPersonal,ILNPersonalSala
    {
        public LNPersonalSala(PersonalSala personalSala) : base(personalSala)
        {
        }

        // PRE:  codigosEjemplares no debe ser nulo ni vacío y dniUsuario es una string.
        // POST: Crea un nuevo préstamo, lo guarda y marca los ejemplares como no disponibles. Lanza excepción si hay errores de validación.
        public void DarAltaPrestamo(string dniUsuario, List<int> codigosEjemplares,String iden)
        {
            if (!PersistenciaUsuario.EXIST(dniUsuario))
                throw new ArgumentException("Usuario no encontrado.");

            Usuario usuario = PersistenciaUsuario.READ(dniUsuario);
            List<Ejemplar> ejemplaresParaPrestar = new List<Ejemplar>();

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

            Prestamo nuevoPrestamo = new Prestamo(usuario, ejemplaresParaPrestar, DateTime.Now, "En Proceso", this.Personal,iden);

            PersistenciaPrestamo.CREATE(nuevoPrestamo);

           
        }

        // PRE: codigoEjemplar debe corresponder a un libro actualmente prestado.
        // POST: Marca el libro como devuelto y disponible. Si era el último del préstamo, finaliza el préstamo.
        public void DevolverEjemplar(int codigoEjemplar)
        {
            Prestamo prestamo = PersistenciaPrestamo.READ_POR_EJEMPLAR(codigoEjemplar);
            if (prestamo == null)
            {
                throw new InvalidOperationException("No se encontró préstamo activo para este ejemplar.");
            }

            string idPrestamo = prestamo.Identi;
            string idEjemplar = codigoEjemplar.ToString();

            PersistenciaPrestamo.MARCAR_DEVUELTO(idPrestamo, idEjemplar);

            Ejemplar ej = PersistenciaEjemplar.READ(codigoEjemplar);
            if (ej != null)
            {
                ej.Disponible = true;
                PersistenciaEjemplar.UPDATE(ej);
            }

            if (PersistenciaPrestamo.ESTAN_TODOS_DEVUELTOS(idPrestamo))
            {
                prestamo.Estado = "Finalizado";
                PersistenciaPrestamo.UPDATE(prestamo);
            }
        }

        // PRE: Ninguna.
        // POST: Devuelve la lista de préstamos que se encuentran en estado 'En Proceso'.
        public List<Prestamo> ListadoPrestamosActivos()
        {
            return PersistenciaPrestamo.READALL()
                .Where(p => p.Estado == "En Proceso")
                .ToList();
        }

        // PRE: Ninguna.
        // POST: Devuelve la lista de ejemplares que están marcados como disponibles.
        public List<Ejemplar> ListadoEjemplaresDisponibles()
        {
            List<Ejemplar> todos = PersistenciaEjemplar.READALL();
            return todos.Where(e => e.Disponible).ToList();
        }

        // PRE: El idPrestamo debe existir en la base de datos.
        // POST: Libera (pone disponibles) todos los ejemplares asociados y elimina el préstamo definitivamente.
        public void DevolverPrestamoCompleto(int idPrestamo)
        {
            Prestamo p = PersistenciaPrestamo.OBTENER(idPrestamo);

            if (p == null)
            {
                throw new Exception("No existe ningún préstamo con el ID " + idPrestamo);
            }

            
            List<Ejemplar> ejemplaresDelPrestamo = PersistenciaPrestamo.READEjemplaresDePrestamo(idPrestamo.ToString());

            foreach (Ejemplar ej in ejemplaresDelPrestamo)
            {
                if (ej != null)
                {
                    ej.Disponible = true;
                    // IMPORTANTE: Guardamos el cambio en la persistencia
                    PersistenciaEjemplar.UPDATE(ej);
                }
            }

            PersistenciaPrestamo.BORRAR(idPrestamo);
        }
        public bool ExistePrestamo(string idPrestamo)
        {
            return PersistenciaPrestamo.EXIST(idPrestamo);
        }
    }
}