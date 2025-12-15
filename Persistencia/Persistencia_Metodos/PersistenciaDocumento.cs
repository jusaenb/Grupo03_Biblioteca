using System;
using System.Collections.Generic;
using MD;

namespace Persistencia
{
    public static class PersistenciaDocumento
    {
        public static bool EXIST(int isbn)
        {
            return BD.TablaDocumentos.Contains(isbn);
        }
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

        public static void UPDATE(Documento documento)
        {
            DocumentoDato dd = TransformersBiblioteca.DocumentoADocumentoDato(documento);

            if (BD.TablaDocumentos.Contains(dd.Id))
            {
                DELETE(documento);
                CREATE(documento);
            }
        }

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

        public static Documento READ(int isbn)
        {
            if (BD.TablaDocumentos.Contains(isbn))
            {
                return TransformersBiblioteca.DocumentoDatoADocumento(BD.TablaDocumentos[isbn]);
            }
            return null;
        }

        
        public static List<Documento> READALL()
        {
            List<Documento> documentos = new List<Documento>();
            foreach (DocumentoDato dd in BD.TablaDocumentos)
            {
                documentos.Add(TransformersBiblioteca.DocumentoDatoADocumento(dd));
            }
            return documentos;
        }

        public static Documento ObtenerDocumento(int isbn)
        {
            // Reutilizamos tu método READ que ya sabe buscar en BD
            return READ(isbn);
        }

        // 2. Devuelve la lista completa de documentos
        public static List<Documento> ListadoDocumentos()
        {
            // Reutilizamos tu método READALL que ya sabe recorrer BD.TablaDocumentos
            return READALL();
        }

        // 3. Borra un documento
        public static void BajaDocumento(int isbn)
        {
            // Primero lo buscamos
            Documento doc = READ(isbn);
            if (doc != null)
            {
                // Reutilizamos tu método DELETE
                DELETE(doc);
            }
        }
    }
}