using System;
using System.Collections.Generic;
using MD;
using System.Linq;

namespace Persistencia
{
    public static class PersistenciaPrestamo
    {
        public static bool EXIST(string idPrestamo)
        {
            return BD.TablaPrestamos.Contains(idPrestamo);
        }
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


            // Crear clave compuesta (IdPrestamo, IdEjemplar)
            Compuesto claveCompuesta = new Compuesto(pd.Id, idEjemplar);

            if (!BD.TablaPrestamoEjemplar.Contains(claveCompuesta))
            {
                // Guardamos la relación
                PrestamoEjemplarDato ped = new PrestamoEjemplarDato(pd.Id, idEjemplar, fechaLimite, false);
                BD.TablaPrestamoEjemplar.Add(ped);
            }
        }
    }
}

        public static void UPDATE(Prestamo prestamo)
        {
            
            PrestamoDato pd = TransformersBiblioteca.PrestamoAPrestamoDato(prestamo);
            if (BD.TablaPrestamos.Contains(pd.Id))
            {
                // Actualizamos datos básicos (Estado, etc.)
                BD.TablaPrestamos.Remove(pd.Id);
                BD.TablaPrestamos.Add(pd);

                // Nota: Actualizar relaciones es más complejo, pero para este ejercicio
                // suele bastar con actualizar el estado del préstamo.
            }
        }

        public static List<Prestamo> READALL()
        {
            List<Prestamo> lista = new List<Prestamo>();
            foreach (PrestamoDato pd in BD.TablaPrestamos)
            {
                lista.Add(TransformersBiblioteca.PrestamoDatoAPrestamo(pd));
            }
            return lista;
        }

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

       public static List<Prestamo> READALL_POR_ISBN(int isbn)
        {
            List<Prestamo> lista = new List<Prestamo>();
        
            foreach (PrestamoDato pd in BD.TablaPrestamos)
            {
                // Convertimos el dato a objeto Prestamo (que ya tiene la lista de ejemplares cargada)
                Prestamo p = TransformersBiblioteca.PrestamoDatoAPrestamo(pd);
        
                // CORRECCIÓN:
                // Verificamos si en la lista 'Ejemplares' existe ALGUNO (.Any) 
                // cuyo documento tenga el ISBN buscado.
                if (p.Ejemplares.Any(e => e.Documento.Isbn == isbn))
                {
                    lista.Add(p);
                }
            }
            return lista;
        }

        public static Prestamo READ_POR_EJEMPLAR(int codigoEjemplar)
        {
            string idEjemplar = codigoEjemplar.ToString();

            // Buscar en la tabla intermedia
            foreach (PrestamoEjemplarDato ped in BD.TablaPrestamoEjemplar)
            {
                // La clase Compuesto o el Dato debe permitir acceder al ID del ejemplar
                // Asumimos que ped.Id (Compuesto) tiene acceso a Cadena2 (Ejemplar)
                if (ped.Id.Cadena2 == idEjemplar)
                {
                    // Encontrado la relación, buscamos el préstamo padre si está activo
                    if (BD.TablaPrestamos.Contains(ped.Id.Cadena1)) // Cadena1 = IdPrestamo
                    {
                        PrestamoDato pd = BD.TablaPrestamos[ped.Id.Cadena1];
                        if (pd.Estado == "En Proceso") // Solo devolvemos si está activo
                        {
                            return TransformersBiblioteca.PrestamoDatoAPrestamo(pd);
                        }
                    }
                }
            }
            return null;
        }

        // Método auxiliar usado por el Transformer
        public static List<Ejemplar> READEjemplaresDePrestamo(string idPrestamo)
        {
            List<Ejemplar> ejemplares = new List<Ejemplar>();
            foreach (PrestamoEjemplarDato ped in BD.TablaPrestamoEjemplar)
            {
                if (ped.Id.Cadena1 == idPrestamo)
                {
                    // Convertir ID string a int
                    int cod = int.Parse(ped.Id.Cadena2);
                    Ejemplar ej = PersistenciaEjemplar.READ(cod);
                    if (ej != null) ejemplares.Add(ej);
                }
            }
            return ejemplares;
        }
        public static void MARCAR_DEVUELTO(string idPrestamo, string idEjemplar)
        {
            // Buscamos en la tabla intermedia usando la clave compuesta
            // Nota: Como tu clase Tabla busca por ID, tenemos que iterar o construir la clave
            foreach (var ped in BD.TablaPrestamoEjemplar)
            {
                if (ped.Id.Cadena1 == idPrestamo && ped.Id.Cadena2 == idEjemplar)
                {
                    ped.Devuelto = true;
                    break;
                }
            }
        }
        public static bool ESTAN_TODOS_DEVUELTOS(string idPrestamo)
        {
            // Buscamos todas las líneas de este préstamo
            // Si hay ALGUNA que tenga Devuelto == false, entonces NO están todos.
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
        public static void RegistrarDevolucion(int codigoEjemplar)
        {
            string idEjemplar = codigoEjemplar.ToString();
            string idPrestamoEncontrado = null;

            // 1. BUSCAR LA RELACIÓN EN LA TABLA INTERMEDIA
            // Buscamos a qué préstamo pertenece este libro
            foreach (PrestamoEjemplarDato ped in BD.TablaPrestamoEjemplar)
            {
                // ped.Id.Cadena2 es el ID del Ejemplar
                if (ped.Id.Cadena2 == idEjemplar && !ped.Devuelto)
                {
                    // ¡ENCONTRADO!
                    idPrestamoEncontrado = ped.Id.Cadena1; // Recuperamos el ID REAL del préstamo

                    // A. Marcamos el libro como devuelto
                    ped.Devuelto = true;
                    break; // Ya encontramos el libro, salimos del bucle
                }
            }

            if (idPrestamoEncontrado == null)
            {
                throw new Exception("No se encontró ningún préstamo activo para el ejemplar " + codigoEjemplar);
            }

            // 2. COMPROBAR SI HAY QUE CERRAR EL PRÉSTAMO COMPLETO
            // Verificamos si quedan libros sin devolver en ese mismo préstamo
            bool quedanLibros = false;
            foreach (PrestamoEjemplarDato ped in BD.TablaPrestamoEjemplar)
            {
                // Buscamos otros libros del MISMO préstamo (Cadena1)
                if (ped.Id.Cadena1 == idPrestamoEncontrado && !ped.Devuelto)
                {
                    quedanLibros = true;
                    break;
                }
            }

            // 3. SI NO QUEDAN LIBROS, CAMBIAMOS EL ESTADO DEL PRÉSTAMO A "FINALIZADO"
            if (!quedanLibros)
            {
                if (BD.TablaPrestamos.Contains(idPrestamoEncontrado))
                {
                    PrestamoDato pd = BD.TablaPrestamos[idPrestamoEncontrado];
                    pd.Estado = "Finalizado";

                    // Actualizamos en la lista (Borrar y Añadir para forzar refresco si es necesario)
                    BD.TablaPrestamos.Remove(idPrestamoEncontrado);
                    BD.TablaPrestamos.Add(pd);
                }
            }
        }
    }
}
