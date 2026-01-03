using MD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica_Negocio
{
    public interface ILNPersonalAdquisiciones : ILNPersonal
    {
        void DarAltaDocumento(Documento d);
        List<Documento> ListadoDocumentos();
        void DarBajaDocumento(int isbn);
        bool ExisteDocumento(int isbn);
        Documento ObtenerDocumento(int isbn);

        // --- GESTIÓN DE EJEMPLARES ---
        void DarAltaEjemplar(int codigoEjemplar, int isbnDocumento);
        void DarBajaLogicaEjemplar(int codigoEjemplar);
        bool ExisteEjemplar(int codigoEjemplar);
        Ejemplar ObtenerEjemplar(int codigoEjemplar);
        List<Ejemplar> ListadoEjemplares();
        String getNombre();
    }
}
