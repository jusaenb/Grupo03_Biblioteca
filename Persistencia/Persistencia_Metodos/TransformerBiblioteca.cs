using MD;
using System.Collections.Generic;

namespace Persistencia
{
    public static class TransformersBiblioteca
    {
        // --- USUARIO ---

        // PRE:  El objeto usuario no debe ser nulo.
        // POST: Devuelve un objeto UsuarioDato con los mismos valores de DNI y Nombre que el objeto de dominio.
        public static UsuarioDato UsuarioAUsuarioDato(Usuario usuario)
        {
            return new UsuarioDato(usuario.Dni, usuario.Nombre);
        }

        // PRE:  El objeto dato no debe ser nulo.
        // POST: Devuelve un objeto Usuario del dominio creado a partir de los datos persistentes.
        public static Usuario UsuarioDatoAUsuario(UsuarioDato dato)
        {
            // Asumiendo que Usuario tiene un constructor (dni, nombre)
            return new Usuario(dato.Id, dato.Nombre);
        }

        // --- DOCUMENTO ---

        // PRE:  El objeto doc no debe ser nulo.
        // POST: Devuelve un DocumentoDato con la información mapeada. 
        //       El campo 'Tipo' se asigna como "AudioLibro" o "Libro" según la instancia real de doc.
        public static DocumentoDato DocumentoADocumentoDato(Documento doc)
        {
            string tipo = (doc is AudioLibro) ? "AudioLibro" : "Libro";
            return new DocumentoDato(doc.Isbn, doc.AñoPublicacion, doc.Titulo, doc.Autor, doc.Editorial, tipo);
        }

        // PRE:  El objeto dato no debe ser nulo. Si Tipo es "AudioLibro", debe existir el registro correspondiente en BD.TablaAudioLibros.
        // POST: Devuelve una instancia de AudioLibro o Documento (Libro) según el campo Tipo del dato.
        public static Documento DocumentoDatoADocumento(DocumentoDato dato)
        {
            if (dato.Tipo == "AudioLibro")
            {
                AudioLibroDato audioDato = BD.TablaAudioLibros[dato.Id];
                return new AudioLibro(dato.Titulo, dato.Autor, dato.Editorial, dato.Año, dato.Id, audioDato.Formato, audioDato.Duracion);
            }
            else
            {
                return new Documento(dato.Año, dato.Titulo, dato.Autor, dato.Id, dato.Editorial);
            }
        }

        // --- EJEMPLAR ---

        // PRE:  El objeto ejemplar no debe ser nulo y debe tener un Documento asociado válido.
        // POST: Devuelve un EjemplarDato mapeando el código, disponibilidad y el ISBN del documento asociado.
        public static EjemplarDato EjemplarAEjemplarDato(Ejemplar ejemplar)
        {
            // Nota: Asumimos que Personal_adqu se guarda como string (ej. null o dni del trabajador)
            return new EjemplarDato(ejemplar.CodigoEjemplar.ToString(), !ejemplar.Disponible, ejemplar.Documento.Isbn, "");
        }

        // PRE:  El objeto dato no debe ser nulo. Debe existir un Documento válido en la BD con el Isbn especificado en dato.
        // POST: Devuelve un objeto Ejemplar reconstruido, enlazado con su objeto Documento correspondiente obtenido de la persistencia.
        public static Ejemplar EjemplarDatoAEjemplar(EjemplarDato dato)
        {
            Documento doc = PersistenciaDocumento.READ(dato.Isbn);

            int codigo = int.Parse(dato.Id);
            return new Ejemplar(codigo, doc, !dato.Prestado);
        }


        // --- PRÉSTAMO ---

        // PRE:  El objeto p no debe ser nulo. Si tiene un Trabajador asociado, este debe tener DNI.
        // POST: Devuelve un PrestamoDato conteniendo los IDs de usuario y trabajador, fecha y estado del préstamo.
        public static PrestamoDato PrestamoAPrestamoDato(Prestamo p)
        {
            // Nota: Asumimos que Prestamo tiene un ID único generado (p.ej. un string o GUID)

            string idPrestamo = p.Identi;
            string dniTrabajador = (p.Trabajador != null) ? p.Trabajador.Dni : "";

            // PrestamoDato(string dni, string id_Prestamo, DateTime fecha, string estado, int id_trabajador)
            // Asumimos 0 o null para id_trabajador si no se tiene el dato a mano en el objeto Prestamo

            return new PrestamoDato(p.Usuario.Dni, idPrestamo, p.FechaPrestamo, p.Estado, dniTrabajador);
        }

        // PRE:  El objeto pd no debe ser nulo. Los IDs de usuario y trabajador deben existir en la BD.
        // POST: Devuelve un objeto Prestamo reconstruido con todas sus relaciones (Usuario, Lista de Ejemplares, Trabajador) cargadas desde la BD.
        public static Prestamo PrestamoDatoAPrestamo(PrestamoDato pd)
        {
            Usuario usuario = PersistenciaUsuario.READ(pd.Dni_usuario);
            // Recuperar ejemplares usando la tabla intermedia
            List<Ejemplar> ejemplares = PersistenciaPrestamo.READEjemplaresDePrestamo(pd.Id);
            Personal trabajador = PersistenciaPersonal.READ(pd.Dni_trabajador);

            // Constructor MD.Prestamo(Usuario, Ejemplar, DateTime, string)
            Prestamo p = new Prestamo(usuario, ejemplares, pd.Fecha_prestamo, pd.Estado, trabajador, pd.Id);

            // Si el dato tiene fecha devolución (calculada en MD), se setea.
            // Si MD.Prestamo calcula la fecha devolución en el constructor, ya está listo.
            return p;
        }

        // --- PERSONAL ---

        // PRE:  El objeto p no debe ser nulo.
        // POST: Devuelve un PersonalSalaDato o PersonalAdquisicionesDato (o genérico) dependiendo del tipo runtime de p.
        public static PersonalDato PersonalAPersonalDato(Personal p)
        {
            if (p is PersonalSala)
                return new PersonalSalaDato(p.Dni, p.Nombre);
            else if (p is PersonalAdquisiciones)
                return new PersonalAdquisicionesDato(p.Dni, p.Nombre);

            return new PersonalDato(p.Dni, p.Nombre);
        }

        // PRE:  El objeto pd no debe ser nulo. El DNI (pd.Id) debe existir en alguna de las tablas específicas de personal.
        // POST: Devuelve una instancia de la subclase correcta (PersonalSala o PersonalAdquisiciones) según en qué tabla se encuentre el ID.
        //       Devuelve null si no se encuentra en ninguna tabla específica.
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