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
       

        // --- PRÉSTAMO ---
        public static PrestamoDato PrestamoAPrestamoDato(Prestamo p)
        {
            // Nota: Asumimos que Prestamo tiene un ID único generado (p.ej. un string o GUID)
        
            string idPrestamo = p.GetHashCode().ToString();

            // PrestamoDato(string dni, string id_Prestamo, DateTime fecha, string estado, int id_trabajador)
            // Asumimos 0 o null para id_trabajador si no se tiene el dato a mano en el objeto Prestamo
            return new PrestamoDato(p.Usuario.Dni, idPrestamo, p.FechaPrestamo, p.Estado, 0);
        }

        public static Prestamo PrestamoDatoAPrestamo(PrestamoDato pd)
        {
            Usuario usuario = PersistenciaUsuario.READ(pd.Dni_usuario);
            // Recuperar ejemplares usando la tabla intermedia
            List<Ejemplar> ejemplares = PersistenciaPrestamo.READEjemplaresDePrestamo(pd.Id);

            // Como MD.Prestamo suele tener un solo ejemplar o una lista, ajustamos:
            // Si tu constructor de Prestamo recibe 1 ejemplar:
           

            // Constructor MD.Prestamo(Usuario, Ejemplar, DateTime, string)
            Prestamo p = new Prestamo(usuario, ejemplares, pd.Fecha_prestamo, pd.Estado);

            // Si el dato tiene fecha devolución (calculada en MD), se setea.
            // Si MD.Prestamo calcula la fecha devolución en el constructor, ya está listo.
            return p;
        }

        // --- PERSONAL ---
        public static PersonalDato PersonalAPersonalDato(Personal p)
        {
            if (p is PersonalSala)
                return new PersonalSalaDato(p.Dni, p.Nombre);
            else if (p is PersonalAdquisiciones)
                return new PersonalAdquisicionesDato(p.Dni, p.Nombre);

            return new PersonalDato(p.Dni, p.Nombre);
        }

        public static Personal PersonalDatoAPersonal(PersonalDato pd)
        {
            // Verificamos el tipo exacto en las tablas específicas si es necesario
            if (BD.TablaPersonalSala.Contains(pd.Id))
            {
                return new PersonalSala(pd.Id, pd.Nombre);
            }
            if (BD.TablaPersonalAdquisiciones.Contains(pd.Id))
            {
                return new PersonalAdquisiciones(pd.Id, pd.Nombre);
            }
            return null; 
        }
    }
}
