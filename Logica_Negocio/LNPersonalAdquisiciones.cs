using MD;
using Persistencia;
using System;
using System.Collections.Generic;

namespace LN
{
    public class LNPersonalAdquisiciones : LNPersonal
    {
        public LNPersonalAdquisiciones(PersonalAdquisiciones personalAdquisiciones) : base(personalAdquisiciones)
        {
        }

        // --- GESTIÓN DE DOCUMENTOS ---

        public void DarAltaDocumento(int isbn, string titulo, string autor, string editorial, int año, string tipo, string formato = "", float duracion = 0)
        {
            // 1. Validar si ya existe
            if (PersistenciaDocumento.EXIST(isbn))
            {
                throw new InvalidOperationException($"El documento con ISBN {isbn} ya existe.");
            }

            // 2. Crear el objeto MD adecuado (Polimorfismo)
            Documento nuevoDoc;

            if (tipo.Equals("AudioLibro", StringComparison.OrdinalIgnoreCase))
            {
                nuevoDoc = new AudioLibro(titulo, autor, editorial, año, isbn, formato, duracion);
            }
            else
            {
                // Libro papel usa la clase base Documento (según tu diseño actual)
                nuevoDoc = new Documento(año, titulo, autor, isbn, editorial);
            }

            // 3. Guardar usando la Fachada
            PersistenciaDocumento.CREATE(nuevoDoc);
        }

        public List<Documento> ListadoDocumentos()
        {
            return PersistenciaDocumento.READALL();
        }

        // --- GESTIÓN DE EJEMPLARES ---

        public void DarAltaEjemplar(int codigoEjemplar, int isbnDocumento)
        {
            // Validar documento
            if (!PersistenciaDocumento.EXIST(isbnDocumento))
                throw new ArgumentException("El documento base no existe.");

            
            if (PersistenciaEjemplar.EXIST(codigoEjemplar.ToString()))
                throw new InvalidOperationException("Ese código de ejemplar ya existe.");

            Documento doc = PersistenciaDocumento.READ(isbnDocumento);

            // Creamos ejemplar (true = disponible)
            Ejemplar nuevoEjemplar = new Ejemplar(codigoEjemplar, doc, true);

            PersistenciaEjemplar.CREATE(nuevoEjemplar);
        }

        public void DarBajaLogicaEjemplar(int codigoEjemplar)
        {
            Ejemplar ej = PersistenciaEjemplar.READ(codigoEjemplar);
            if (ej == null) throw new ArgumentException("El ejemplar no existe.");

            if (!ej.Disponible)
                throw new InvalidOperationException("No se puede dar de baja un ejemplar prestado.");

            PersistenciaEjemplar.DELETE(codigoEjemplar);
        }
        // Método que faltaba para dar de baja documentos
        public void DarBajaDocumento(int isbn)
        {
            if (!PersistenciaDocumento.EXIST(isbn))
                throw new ArgumentException("El documento no existe.");

            // Recuperamos el documento para borrarlo
            Documento doc = PersistenciaDocumento.READ(isbn);
            PersistenciaDocumento.DELETE(doc);
        }
    }
}