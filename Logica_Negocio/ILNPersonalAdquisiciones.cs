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
        // PRE:  El objeto documento 'd' no debe ser nulo y debe contener datos válidos (ISBN, Título, etc.).
        // POST: El documento se registra en el sistema. Si ya existía un documento con ese ISBN, no se duplica (dependiendo de la implementación puede actualizarse o ignorarse).
        void DarAltaDocumento(Documento d);

        // PRE:  Ninguna.
        // POST: Devuelve una lista con todos los documentos registrados en la biblioteca. La lista nunca es nula.
        List<Documento> ListadoDocumentos();

        // PRE:  isbn es un entero válido que identifica un documento.
        // POST: El documento con dicho ISBN es eliminado del sistema. Si no existía, no se produce ningún cambio.
        void DarBajaDocumento(int isbn);

        // PRE:  isbn es un entero válido.
        // POST: Devuelve true si el documento está registrado en el sistema, false en caso contrario.
        bool ExisteDocumento(int isbn);

        // PRE:  isbn es un entero válido.
        // POST: Devuelve el objeto Documento asociado al ISBN si existe, o null si no se encuentra.
        Documento ObtenerDocumento(int isbn);

        // --- GESTIÓN DE EJEMPLARES ---

        // PRE:  codigoEjemplar es un ID válido y isbnDocumento corresponde a un documento existente en el sistema.
        // POST: Se crea y registra un nuevo ejemplar asociado al documento indicado.
        void DarAltaEjemplar(int codigoEjemplar, int isbnDocumento);

        // PRE:  codigoEjemplar identifica a un ejemplar existente.
        // POST: El ejemplar queda marcado como retirado o no disponible en el sistema (baja lógica), sin necesariamente borrarse el registro histórico.
        void DarBajaLogicaEjemplar(int codigoEjemplar);

        // PRE:  codigoEjemplar es un entero válido.
        // POST: Devuelve true si el ejemplar existe en el sistema, false en caso contrario.
        bool ExisteEjemplar(int codigoEjemplar);

        // PRE:  codigoEjemplar es un entero válido.
        // POST: Devuelve el objeto Ejemplar asociado si se encuentra, o null si no existe.
        Ejemplar ObtenerEjemplar(int codigoEjemplar);

        // PRE:  Ninguna.
        // POST: Devuelve una lista con todos los ejemplares registrados (disponibles y no disponibles). La lista nunca es nula.
        List<Ejemplar> ListadoEjemplares();

        // PRE:  La instancia de personal debe estar correctamente inicializada.
        // POST: Devuelve el nombre del personal de adquisiciones que está utilizando el sistema.
        String getNombre();
    }
}