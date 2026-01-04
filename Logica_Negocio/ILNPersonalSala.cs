using MD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica_Negocio
{
    public interface ILNPersonalSala : ILNPersonal
    {
        // PRE:  dniUsuario corresponde a un usuario existente.
        //       codigosEjemplares es una lista no vacía de IDs de ejemplares que existen y están disponibles.
        //       iden es el identificador del personal que realiza la operación.
        // POST: Se crea un nuevo préstamo en estado "En Proceso" y los ejemplares indicados pasan a estar no disponibles.
        void DarAltaPrestamo(string dniUsuario, List<int> codigosEjemplares, string iden);

        // PRE:  idPrestamo corresponde a un préstamo existente en el sistema.
        // POST: El préstamo se elimina o finaliza, y todos los ejemplares asociados a él quedan marcados como disponibles.
        void DevolverPrestamoCompleto(int idPrestamo);

        // PRE:  idPrestamo es una cadena válida.
        // POST: Devuelve true si existe un préstamo con ese identificador, false en caso contrario.
        bool ExistePrestamo(string idPrestamo);

        // PRE:  Ninguna.
        // POST: Devuelve una lista de todos los préstamos que están actualmente "En Proceso" (no finalizados).
        //       La lista nunca es nula.
        List<Prestamo> ListadoPrestamosActivos();

        // --- GESTIÓN DE DEVOLUCIONES PARCIALES Y EJEMPLARES ---

        // PRE:  codigoEjemplar corresponde a un ejemplar que se encuentra actualmente prestado.
        // POST: El ejemplar se marca como disponible (devuelto). Si era el último ejemplar pendiente del préstamo, el préstamo pasa a estado "Finalizado".
        void DevolverEjemplar(int codigoEjemplar);

        // PRE:  Ninguna.
        // POST: Devuelve una lista con todos los ejemplares del sistema que tienen la propiedad Disponible en true.
        List<Ejemplar> ListadoEjemplaresDisponibles();
    }
}