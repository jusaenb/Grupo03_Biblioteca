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
        void DarAltaPrestamo(string dniUsuario, List<int> codigosEjemplares, string iden);
        void DevolverPrestamoCompleto(int idPrestamo);
        bool ExistePrestamo(string idPrestamo);
        List<Prestamo> ListadoPrestamosActivos();

        // --- GESTIÓN DE DEVOLUCIONES PARCIALES Y EJEMPLARES ---
        void DevolverEjemplar(int codigoEjemplar);
        List<Ejemplar> ListadoEjemplaresDisponibles();
    }
}
