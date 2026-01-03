using System;
using System.Collections.Generic;
using MD;
using System.Linq;

namespace Persistencia
{
    public static class PersistenciaPrestamo
    {
        // PRE: El idPrestamo debe ser una cadena válida.
        // POST: Devuelve true si existe un préstamo con ese ID, false en caso contrario.
        public static bool EXIST(string idPrestamo)
        {
            return BD.TablaPrestamos.Contains(idPrestamo);
        }

        // PRE: El objeto prestamo no debe ser nulo y su ID no debe existir previamente.
        // POST: Se añade el préstamo a la base de datos y se registran sus ejemplares asociados.
        public static void CREATE(Prestamo prestamo)
        {
            PrestamoDato pd = TransformersBiblioteca.PrestamoAPrestamoDato(prestamo);

            if (!BD.TablaPrestamos.Contains(pd.Id))
            {
                BD.TablaPrestamos.Add(pd);

                foreach (var ejemplar in prestamo.Ejemplares)
                {
                    string idEjemplar = ejemplar.CodigoEjemplar.ToString();
                    int dias = ejemplar.Documento.DiasPrestamo;
                    DateTime fechaLimite = prestamo.FechaPrestamo.AddDays(dias);

                    Compuesto claveCompuesta = new Compuesto(pd.Id, idEjemplar);

                    if (!BD.TablaPrestamoEjemplar.Contains(claveCompuesta))
                    {
                        PrestamoEjemplarDato ped = new PrestamoEjemplarDato(pd.Id, idEjemplar, fechaLimite, false);
                        BD.TablaPrestamoEjemplar.Add(ped);
                    }
                    ejemplar.Disponible = false;
                    PersistenciaEjemplar.UPDATE(ejemplar);
                }
            }
        }

        // PRE: El objeto prestamo no debe ser nulo 
        // POST: Actualiza la información básica del préstamo en la base de datos.
        public static void UPDATE(Prestamo prestamo)
        {
            PrestamoDato pd = TransformersBiblioteca.PrestamoAPrestamoDato(prestamo);
            if (BD.TablaPrestamos.Contains(pd.Id))
            {
                BD.TablaPrestamos.Remove(pd.Id);
                BD.TablaPrestamos.Add(pd);
            }
        }

        // PRE: Ninguna.
        // POST: Devuelve una lista con todos los préstamos registrados en el sistema.
        public static List<Prestamo> READALL()
        {
            List<Prestamo> lista = new List<Prestamo>();
            foreach (PrestamoDato pd in BD.TablaPrestamos)
            {
                lista.Add(TransformersBiblioteca.PrestamoDatoAPrestamo(pd));
            }
            return lista;
        }

        // PRE: El parámetro dni no debe ser nulo.
        // POST: Devuelve una lista de todos los préstamos asociados a ese DNI de usuario.
        public static List<Prestamo> READALL_POR_USUARIO(string dni)
        {
            List<Prestamo> lista = new List<Prestamo>();
            foreach (PrestamoDato pd in BD.TablaPrestamos)
            {
                if (pd.Dni_usuario == dni)
                {
                    lista.Add(TransformersBiblioteca.PrestamoDatoAPrestamo(pd));
                }
            }
            return lista;
        }

        // PRE: El isbn debe ser un número entero válido.
        // POST: Devuelve una lista de préstamos que contienen algún ejemplar del libro con ese ISBN.
        public static List<Prestamo> READALL_POR_ISBN(int isbn)
        {
            List<Prestamo> lista = new List<Prestamo>();

            foreach (PrestamoDato pd in BD.TablaPrestamos)
            {
                Prestamo p = TransformersBiblioteca.PrestamoDatoAPrestamo(pd);

                if (p.Ejemplares.Any(e => e.Documento.Isbn == isbn))
                {
                    lista.Add(p);
                }
            }
            return lista;
        }

        // PRE: El codigoEjemplar debe ser válido.
        // POST: Devuelve el préstamo activo que contiene dicho ejemplar, o null si no se encuentra o ya finalizó.
        public static Prestamo READ_POR_EJEMPLAR(int codigoEjemplar)
        {
            string idEjemplar = codigoEjemplar.ToString();

            foreach (PrestamoEjemplarDato ped in BD.TablaPrestamoEjemplar)
            {
                if (ped.Id.Cadena2 == idEjemplar)
                {
                    if (BD.TablaPrestamos.Contains(ped.Id.Cadena1))
                    {
                        PrestamoDato pd = BD.TablaPrestamos[ped.Id.Cadena1];
                        if (pd.Estado == "En Proceso")
                        {
                            return TransformersBiblioteca.PrestamoDatoAPrestamo(pd);
                        }
                    }
                }
            }
            return null;
        }

        // PRE: El idPrestamo debe existir.
        // POST: Devuelve la lista de objetos Ejemplar asociados a ese préstamo.
        public static List<Ejemplar> READEjemplaresDePrestamo(string idPrestamo)
        {
            List<Ejemplar> ejemplares = new List<Ejemplar>();
           
            
            foreach (PrestamoEjemplarDato ped in BD.TablaPrestamoEjemplar)
            {
          
                if (ped.Id.Cadena1 == idPrestamo)
                {
                    int cod = int.Parse(ped.Id.Cadena2);
                    Ejemplar ej = PersistenciaEjemplar.READ(cod);
                    if (ej != null) ejemplares.Add(ej);
                }
            }
            return ejemplares;
        }

        // PRE: Los IDs deben ser válidos y debe existir la relación.
        // POST: Marca la propiedad Devuelto a true para ese ejemplar específico en ese préstamo.
        public static void MARCAR_DEVUELTO(string idPrestamo, string idEjemplar)
        {
            foreach (var ped in BD.TablaPrestamoEjemplar)
            {
                if (ped.Id.Cadena1 == idPrestamo && ped.Id.Cadena2 == idEjemplar)
                {
                    ped.Devuelto = true;
                    break;
                }
            }
        }

        // PRE: El idPrestamo debe ser válido.
        // POST: Devuelve true si todos los ejemplares del préstamo están marcados como devueltos, false en caso contrario.
        public static bool ESTAN_TODOS_DEVUELTOS(string idPrestamo)
        {
            bool quedaAlguno = false;
            foreach (var ped in BD.TablaPrestamoEjemplar)
            {
                if (ped.Id.Cadena1 == idPrestamo && !ped.Devuelto)
                {
                    quedaAlguno = true;
                    break;
                }
            }
            return !quedaAlguno;
        }

        // PRE: El idPrestamo debe ser un entero válido.
        // POST: Devuelve el objeto Prestamo completo si existe, o null si no existe.
        public static Prestamo OBTENER(int idPrestamo)
        {
            string idStr = idPrestamo.ToString();

            if (BD.TablaPrestamos.Contains(idStr))
            {
                PrestamoDato pd = BD.TablaPrestamos[idStr];
                return TransformersBiblioteca.PrestamoDatoAPrestamo(pd);
            }
            return null;
        }

        // PRE: El idPrestamo debe existir en la base de datos.
        // POST: Elimina el préstamo de la tabla principal y todas sus referencias en la tabla intermedia.
        public static void BORRAR(int idPrestamo)
        {
            string idStr = idPrestamo.ToString();
            List<Compuesto> clavesParaBorrar = new List<Compuesto>();

            foreach (PrestamoEjemplarDato ped in BD.TablaPrestamoEjemplar)
            {
                if (ped.Id.Cadena1 == idStr)
                {
                    clavesParaBorrar.Add(ped.Id);
                }
            }

            foreach (Compuesto clave in clavesParaBorrar)
            {
                BD.TablaPrestamoEjemplar.Remove(clave);
            }

            if (BD.TablaPrestamos.Contains(idStr))
            {
                BD.TablaPrestamos.Remove(idStr);
            }
        }
    }
}