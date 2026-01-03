using System;
using System.Collections.Generic;
using MD;

namespace Persistencia
{
    public static class PersistenciaDocumento
    {
        // PRE:  El parámetro isbn es un entero válido.
        // POST: Devuelve true si existe un documento con ese ISBN en la base de datos, false en caso contrario.
        public static bool EXIST(int isbn)
        {
            return BD.TablaDocumentos.Contains(isbn);
        }

        // PRE:  El objeto documento no debe ser nulo.
        // POST: Si el documento no existía previamente, se añade a la base de datos (y a la tabla de AudioLibros si corresponde). 
        //       Si ya existía, el estado de la base de datos no cambia.
        public static void CREATE(Documento documento)
        {
            if (!BD.TablaDocumentos.Contains(documento.Isbn))
            {
                DocumentoDato dd = TransformersBiblioteca.DocumentoADocumentoDato(documento);
                BD.TablaDocumentos.Add(dd);

                if (documento is AudioLibro audio)
                {
                    AudioLibroDato ad = new AudioLibroDato(audio.Isbn, audio.Duracion, audio.Formato);
                    BD.TablaAudioLibros.Add(ad);
                }
            }
        }

        // PRE:  El objeto documento no debe ser nulo.
        // POST: Si el documento existe en la base de datos (por su ID), sus datos son actualizados con la nueva información.
        //       Si no existía, no se realiza ninguna modificación.
        public static void UPDATE(Documento documento)
        {
            DocumentoDato dd = TransformersBiblioteca.DocumentoADocumentoDato(documento);

            if (BD.TablaDocumentos.Contains(dd.Id))
            {
                DELETE(documento); // Elimina la versión antigua
                CREATE(documento); // Crea la versión nueva
            }
        }

        // PRE:  El objeto documento no debe ser nulo.
        // POST: El documento con ese ISBN es eliminado de la TablaDocumentos (y TablaAudioLibros si aplica).
        //       Se garantiza que tras ejecutar este método, el documento ya no está en la base de datos.
        public static void DELETE(Documento documento)
        {
            if (BD.TablaDocumentos.Contains(documento.Isbn))
            {
                BD.TablaDocumentos.Remove(documento.Isbn);

                // Si es audiolibro, borrar también de su tabla específica
                if (documento is AudioLibro)
                {
                    if (BD.TablaAudioLibros.Contains(documento.Isbn))
                    {
                        BD.TablaAudioLibros.Remove(documento.Isbn);
                    }
                }
            }
        }

        // PRE:  Ninguna.
        // POST: Devuelve el objeto Documento asociado al ISBN si existe. Devuelve null si no se encuentra.
        public static Documento READ(int isbn)
        {
            if (BD.TablaDocumentos.Contains(isbn))
            {
                return TransformersBiblioteca.DocumentoDatoADocumento(BD.TablaDocumentos[isbn]);
            }
            return null;
        }

        // PRE:  Ninguna.
        // POST: Devuelve una lista conteniendo todos los documentos almacenados en la base de datos.
        //       La lista nunca es nula, pero puede estar vacía.
        public static List<Documento> READALL()
        {
            List<Documento> documentos = new List<Documento>();
            foreach (DocumentoDato dd in BD.TablaDocumentos)
            {
                documentos.Add(TransformersBiblioteca.DocumentoDatoADocumento(dd));
            }
            return documentos;
        }
    }
}