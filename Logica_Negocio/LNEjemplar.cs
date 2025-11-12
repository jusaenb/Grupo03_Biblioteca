using MD;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Logica_Negocio
{
    public class LNEjemplar
    {
        private List<Ejemplar> listaEjemplares;
        public LNEjemplar() { 
        this.listaEjemplares=new List<Ejemplar>();
        }
        public void DarDeAltaEjemplar(Ejemplar e ) 
        {
          for(int i=0;i<listaEjemplares.Count;i++) 
            {
                if (listaEjemplares[i].CodigoEjemplar==e.CodigoEjemplar)
                {
                    Console.WriteLine("El ejemplar ya existe en el sistema.");
                    return;
                }
            }
            listaEjemplares.Add(e);
            Console.WriteLine("Ejemplar dado de alta exitosamente.");

        }
        public void DarDeBajaEjemplar(Ejemplar e) 
        {
            for(int i = 0; i < listaEjemplares.Count; i++)
            {
                if (listaEjemplares[i].CodigoEjemplar == e.CodigoEjemplar)
                {
                    listaEjemplares.RemoveAt(i);
                    Console.WriteLine("Ejemplar dado de baja exitosamente.");
                    return;
                }
            }
        }
        public void consularDisponibilidad(Ejemplar e) 
        {
           for(int i=0;i<listaEjemplares.Count;i++) 
            {
                if (listaEjemplares[i].CodigoEjemplar==e.CodigoEjemplar)
                {
                    if (listaEjemplares[i].Disponible)
                    {
                        Console.WriteLine("El ejemplar está disponible.");
                    }
                    else
                    {
                        Console.WriteLine("El ejemplar no está disponible.");
                    }
                    return;
                }
            }
            Console.WriteLine("El ejemplar no se encuentra en el sistema.");
        }
        public void cosultarInfoEjemplar(Ejemplar e) 
        {
           for(int i=0;i<listaEjemplares.Count;i++) 
            {
                if (listaEjemplares[i].CodigoEjemplar==e.CodigoEjemplar)
                {
                    Documento doc=listaEjemplares[i].Documento;
                    Console.WriteLine("Información del ejemplar:");
                    Console.WriteLine($"Código de Ejemplar: {listaEjemplares[i].CodigoEjemplar}");
                    Console.WriteLine($"Título: {doc.Titulo}");
                    Console.WriteLine($"Autor: {doc.Autor}");
                    Console.WriteLine($"Año de Publicación: {doc.AñoPublicacion}");
                    Console.WriteLine($"ISBN: {doc.Isbn}");
                    Console.WriteLine($"Editorial: {doc.Editorial}");
                    return;
                }
            }
            Console.WriteLine("El ejemplar no se encuentra en el sistema.");
        }

    }
}
