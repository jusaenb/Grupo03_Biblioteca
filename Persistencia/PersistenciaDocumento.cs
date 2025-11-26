using System.Collections.Generic;
using MD;

namespace Persistencia
{
    public static class PersistenciaDocumento
    {
        public static void CREATE(Documento documento)
        {
            if (!BD.TablaDocumentos.Contains(documento.Isbn))
            {
                DocumentoDato dd = TransformersBiblioteca.DocumentoADocumentoDato(documento);
                BD.TablaDocumentos.Add(dd);

                if (documento is AudioLibro audio)
                {
                    // Crear dato específico para audio
                    AudioLibroDato ad = new AudioLibroDato(audio.Isbn, audio.Duracion, audio.Formato);
                    BD.TablaAudioLibros.Add(ad);
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
    }
}