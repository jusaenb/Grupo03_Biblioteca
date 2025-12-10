using System.Collections.Generic;
using MD;

namespace Persistencia
{
    public static class PersistenciaEjemplar
    {
        public static bool EXIST(string codigoEjemplar)
        {
            return BD.TablaEjemplares.Contains(codigoEjemplar);
        }
        public static void CREATE(Ejemplar ejemplar)
        {
            string id = ejemplar.CodigoEjemplar.ToString();
            if (!BD.TablaEjemplares.Contains(id))
            {
                EjemplarDato ed = TransformersBiblioteca.EjemplarAEjemplarDato(ejemplar);
                BD.TablaEjemplares.Add(ed);
            }
        }

        public static void UPDATE(Ejemplar ejemplar)
        {
            string id = ejemplar.CodigoEjemplar.ToString();
            if (BD.TablaEjemplares.Contains(id))
            {
                BD.TablaEjemplares.Remove(id);
                CREATE(ejemplar);
            }
        }
        //Pre: codigoEjmplar no puede ser nulo
        //Post: Borra el ejemplar con codigo codigoEjemplar
        public static void DELETE(int codigoEjemplar)
        {
            string id = codigoEjemplar.ToString();
            if (BD.TablaEjemplares.Contains(id))
            {
                BD.TablaEjemplares.Remove(id);
            }
        }

        public static Ejemplar READ(int codigoEjemplar)
        {
            string id = codigoEjemplar.ToString();
            if (BD.TablaEjemplares.Contains(id))
            {
                return TransformersBiblioteca.EjemplarDatoAEjemplar(BD.TablaEjemplares[id]);
            }
            return null;
        }

        public static List<Ejemplar> READALL(int isbnDocumento)
        {
            List<Ejemplar> lista = new List<Ejemplar>();
            foreach (EjemplarDato ed in BD.TablaEjemplares)
            {
                if (ed.Isbn == isbnDocumento)
                {
                    lista.Add(TransformersBiblioteca.EjemplarDatoAEjemplar(ed));
                }
            }
            return lista;
        }
        // Sobrecarga para obtener TODOS los ejemplares (necesario para Alta Préstamo)
        public static List<Ejemplar> READALL()
        {
            List<Ejemplar> lista = new List<Ejemplar>();

            // Recorremos toda la tabla de ejemplares sin filtrar por ISBN
            foreach (EjemplarDato ed in BD.TablaEjemplares)
            {
                lista.Add(TransformersBiblioteca.EjemplarDatoAEjemplar(ed));
            }
            return lista;
        }
    }
}
