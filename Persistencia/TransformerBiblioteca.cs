using MD;
using System.Collections.Generic;

namespace Persistencia
{
    public static class TransformersBiblioteca
    {
        // --- USUARIO ---
        public static UsuarioDato UsuarioAUsuarioDato(Usuario usuario)
        {
            return new UsuarioDato(usuario.Dni, usuario.Nombre);
        }

        public static Usuario UsuarioDatoAUsuario(UsuarioDato dato)
        {
            // Asumiendo que Usuario tiene un constructor (dni, nombre)
            return new Usuario(dato.Id, dato.Nombre);
        }

        // --- DOCUMENTO ---
        public static DocumentoDato DocumentoADocumentoDato(Documento doc)
        {
            string tipo = (doc is AudioLibro) ? "AudioLibro" : "Libro";
            return new DocumentoDato(doc.Isbn, doc.AñoPublicacion, doc.Titulo, doc.Autor, doc.Editorial, tipo);
        }

        public static Documento DocumentoDatoADocumento(DocumentoDato dato)
        {
            if (dato.Tipo == "AudioLibro")
            {
                // Recuperar AudioLibroDato específico si fuera necesario para duración/formato
                AudioLibroDato audioDato = BD.TablaAudioLibros[dato.Id];
                return new AudioLibro(dato.Titulo, dato.Autor, dato.Editorial, dato.Año, dato.Id, audioDato.Formato, audioDato.Duracion);
            }
            else
            {
                return new Documento(dato.Año, dato.Titulo, dato.Autor, dato.Id, dato.Editorial);
            }
        }

        // --- EJEMPLAR ---
        public static EjemplarDato EjemplarAEjemplarDato(Ejemplar ejemplar)
        {
            // Nota: Asumimos que Personal_adqu se guarda como string (ej. null o dni del trabajador)
            return new EjemplarDato(ejemplar.CodigoEjemplar.ToString(), !ejemplar.Disponible, ejemplar.Documento.Isbn, "");
        }

        public static Ejemplar EjemplarDatoAEjemplar(EjemplarDato dato)
        {
            Documento doc = PersistenciaDocumento.READ(dato.Isbn);
            // Convertimos el ID string a int si tu modelo MD.Ejemplar usa int
            int codigo = int.Parse(dato.Id);
            return new Ejemplar(codigo, doc, !dato.Prestado);
        }
    }
}
