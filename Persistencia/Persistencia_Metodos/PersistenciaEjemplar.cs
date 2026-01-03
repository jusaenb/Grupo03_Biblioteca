using System.Collections.Generic;
using System.Linq;
using MD;

namespace Persistencia
{
    public static class PersistenciaEjemplar
    {
        // PRE:  codigoEjemplar es una cadena válida representando el ID del ejemplar.
        // POST: Devuelve true si el ejemplar existe en la base de datos, false en caso contrario.
        public static bool EXIST(string codigoEjemplar)
        {
            return BD.TablaEjemplares.Contains(codigoEjemplar);
        }

        // PRE:  El objeto ejemplar no debe ser nulo.
        // POST: Si no existe un ejemplar con ese código, se añade a la base de datos.
        //       Si ya existe, el estado de la base de datos no cambia.
        public static void CREATE(Ejemplar ejemplar)
        {
            string id = ejemplar.CodigoEjemplar.ToString();
            if (!BD.TablaEjemplares.Contains(id))
            {
                EjemplarDato ed = TransformersBiblioteca.EjemplarAEjemplarDato(ejemplar);
                BD.TablaEjemplares.Add(ed);
            }
        }

        // PRE:  El objeto ejemplar no debe ser nulo.
        // POST: Si el ejemplar existe, se actualizan sus datos eliminando el antiguo y creando el nuevo.
        //       Si no existe, no se realiza ninguna acción.
        public static void UPDATE(Ejemplar ejemplar)
        {
            string id = ejemplar.CodigoEjemplar.ToString();
            if (BD.TablaEjemplares.Contains(id))
            {
                BD.TablaEjemplares.Remove(id);
                CREATE(ejemplar);
            }
        }

        // PRE:  codigoEjemplar es un entero válido.
        // POST: Si existe un ejemplar con ese código, es eliminado de la base de datos.
        //       Si no existe, el estado de la base de datos no cambia.
        public static void DELETE(int codigoEjemplar)
        {
            string id = codigoEjemplar.ToString();
            if (BD.TablaEjemplares.Contains(id))
            {
                BD.TablaEjemplares.Remove(id);
            }
        }

        // PRE:  codigoEjemplar es un entero válido.
        // POST: Devuelve el objeto Ejemplar asociado al código si existe. Devuelve null si no se encuentra.
        public static Ejemplar READ(int codigoEjemplar)
        {
            string id = codigoEjemplar.ToString();
            if (BD.TablaEjemplares.Contains(id))
            {
                return TransformersBiblioteca.EjemplarDatoAEjemplar(BD.TablaEjemplares[id]);
            }
            return null;
        }

        // PRE:  isbnDocumento es un entero válido.
        // POST: Devuelve una lista de objetos Ejemplar asociados al documento con el ISBN proporcionado.
        //       La lista puede estar vacía si no hay ejemplares.
        public static List<Ejemplar> READALL(int isbnDocumento)
        {
            return BD.TablaEjemplares
                     .Where(ed => ed.Isbn == isbnDocumento)
                     .Select(ed => TransformersBiblioteca.EjemplarDatoAEjemplar(ed))
                     .ToList();
        }

        // PRE:  Ninguna.
        // POST: Devuelve una lista con TODOS los ejemplares registrados en el sistema.
        //       La lista nunca es nula.
        public static List<Ejemplar> READALL()
        {
            return BD.TablaEjemplares
                     .Select(ed => TransformersBiblioteca.EjemplarDatoAEjemplar(ed))
                     .ToList();
        }
    }
}