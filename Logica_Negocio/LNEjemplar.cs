using MD;
using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace Logica_Negocio
{
    public class LNEjemplar
    {
        private List<Ejemplar> listaEjemplares;

        public LNEjemplar()
        {
            this.listaEjemplares = new List<Ejemplar>();
        }

        /// <summary>
        /// Da de alta un nuevo ejemplar en el sistema.
        /// PRE: El ejemplar e no debe ser nulo y su código no debe existir ya en la lista.
        /// POST: El ejemplar e se añade a la lista de ejemplares si no existía previamente.
        /// </summary>
        public void DarDeAltaEjemplar(Ejemplar e)
        {
            // PRE
            if (e == null)
            {
                Console.WriteLine("Error: el ejemplar es nulo.");
                return;
            }

            for (int i = 0; i < listaEjemplares.Count; i++)
            {
                if (listaEjemplares[i].CodigoEjemplar == e.CodigoEjemplar)
                {
                    Console.WriteLine("El ejemplar ya existe en el sistema.");
                    return;
                }
            }

            // POST
            listaEjemplares.Add(e);
            Console.WriteLine("Ejemplar dado de alta exitosamente.");
        }

        /// <summary>
        /// Da de baja lógica un ejemplar (lo marca como no disponible).
        /// PRE: El ejemplar e no debe ser nulo y debe existir en la lista.
        /// POST: Si el ejemplar existe y está disponible, se marca como no disponible.
        ///       Si está prestado, no se realiza la baja lógica.
        /// </summary>
        public void DarDeBajaEjemplar(Ejemplar e)
        {
            // PRE
            if (e == null)
            {
                Console.WriteLine("Error: el ejemplar es nulo.");
                return;
            }

            for (int i = 0; i < listaEjemplares.Count; i++)
            {
                if (listaEjemplares[i].CodigoEjemplar == e.CodigoEjemplar)
                {
                    // PRE adicional: no se puede dar de baja si está prestado
                    if (listaEjemplares[i].Disponible == false)
                    {
                        Console.WriteLine("No se puede dar de baja lógica un ejemplar que está prestado.");
                        return;
                    }

                    // POST
                    listaEjemplares[i].Disponible = false;
                    Console.WriteLine("Ejemplar dado de baja (lógica) exitosamente.");
                    return;
                }
            }

            Console.WriteLine("El ejemplar no se encuentra en el sistema.");
        }

        /// <summary>
        /// Consulta si un ejemplar está disponible.
        /// PRE: El ejemplar e no debe ser nulo y debe tener un código válido.
        /// POST: Muestra en consola si el ejemplar está disponible o no. 
        ///       Si no existe, informa que no se encuentra en el sistema.
        /// </summary>
        public void ConsultarDisponibilidad(Ejemplar e)
        {
            // PRE
            if (e == null )
            {
                Console.WriteLine("Error: ejemplar nulo o código no válido.");
                return;
            }

            for (int i = 0; i < listaEjemplares.Count; i++)
            {
                if (listaEjemplares[i].CodigoEjemplar == e.CodigoEjemplar)
                {
                    // POST
                    if (listaEjemplares[i].Disponible)
                        Console.WriteLine("El ejemplar está disponible.");
                    else
                        Console.WriteLine("El ejemplar no está disponible.");
                    return;
                }
            }

            Console.WriteLine("El ejemplar no se encuentra en el sistema.");
        }

        

        /// <summary>
        /// Muestra la información de un ejemplar concreto.
        /// PRE: El ejemplar e no debe ser nulo y debe tener un código válido.
        /// POST: Muestra toda la información del ejemplar si existe; 
        ///       si no existe, informa que no está en el sistema.
        /// </summary>
        public void ConsultarInfoEjemplar(Ejemplar e)
        {
            // PRE
            if (e == null )
            {
                Console.WriteLine("Error: ejemplar nulo o código no válido.");
                return;
            }

            for (int i = 0; i < listaEjemplares.Count; i++)
            {
                if (listaEjemplares[i].CodigoEjemplar == e.CodigoEjemplar)
                {
                    Documento doc = listaEjemplares[i].Documento;

                    // POST
                    Console.WriteLine("Información del ejemplar:");
                    Console.WriteLine($"Código de Ejemplar: {listaEjemplares[i].CodigoEjemplar}");
                    Console.WriteLine($"Título: {doc.Titulo}");
                    Console.WriteLine($"Autor: {doc.Autor}");
                    Console.WriteLine($"Año de Publicación: {doc.AñoPublicacion}");
                    Console.WriteLine($"ISBN: {doc.Isbn}");
                    Console.WriteLine($"Editorial: {doc.Editorial}");
                    Console.WriteLine($"Disponible: {(listaEjemplares[i].Disponible ? "Sí" : "No")}");
                    return;
                }
            }

            Console.WriteLine("El ejemplar no se encuentra en el sistema.");
        }

       
     
    }
}
