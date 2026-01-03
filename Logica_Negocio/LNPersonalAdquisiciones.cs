using Logica_Negocio;
using MD;
using Persistencia;
using System;
using System.Collections.Generic;

namespace LN
{
    public class LNPersonalAdquisiciones : LNPersonal,ILNPersonalAdquisiciones
    {
        public LNPersonalAdquisiciones(PersonalAdquisiciones personalAdquisiciones) : base(personalAdquisiciones)
        {
        }

        // --- GESTIÓN DE DOCUMENTOS ---

        public void DarAltaDocumento(Documento d)
        {
            // 1. Validar si ya existe
            if (PersistenciaDocumento.EXIST(d.Isbn))
            {
                throw new InvalidOperationException($"El documento con ISBN {d.Isbn} ya existe.");
            }
            PersistenciaDocumento.CREATE(d);
        }

        public List<Documento> ListadoDocumentos()
        {
            return PersistenciaDocumento.READALL();
        }

        // --- GESTIÓN DE EJEMPLARES ---

        public void DarAltaEjemplar(int codigoEjemplar, int isbnDocumento)
        {
            // Validar documento
            if (!PersistenciaDocumento.EXIST(isbnDocumento))
                throw new ArgumentException("El documento base no existe.");

            
            if (PersistenciaEjemplar.EXIST(codigoEjemplar.ToString()))
                throw new InvalidOperationException("Ese código de ejemplar ya existe.");

            Documento doc = PersistenciaDocumento.READ(isbnDocumento);

            // Creamos ejemplar (true = disponible)
            Ejemplar nuevoEjemplar = new Ejemplar(codigoEjemplar, doc, true);

            PersistenciaEjemplar.CREATE(nuevoEjemplar);
        }

        public void DarBajaLogicaEjemplar(int codigoEjemplar)
        {
            Ejemplar ej = PersistenciaEjemplar.READ(codigoEjemplar);
            if (ej == null) throw new ArgumentException("El ejemplar no existe.");

            if (!ej.Disponible)
                throw new InvalidOperationException("No se puede dar de baja un ejemplar prestado.");

            PersistenciaEjemplar.DELETE(codigoEjemplar);
        }
        // Método que faltaba para dar de baja documentos
        public void DarBajaDocumento(int isbn)
        {
            if (!PersistenciaDocumento.EXIST(isbn))
                throw new ArgumentException("El documento no existe.");

            // Recuperamos el documento para borrarlo
            Documento doc = PersistenciaDocumento.READ(isbn);
            PersistenciaDocumento.DELETE(doc);
            // Recorremos TODOS los ejemplares
            PersistenciaEjemplar.READALL().ForEach(ej =>
            {
                
                if (ej.Documento.Isbn == isbn)
                {
                  
                    PersistenciaEjemplar.DELETE(ej.CodigoEjemplar);
                }
            });

        }
        public bool ExisteDocumento(int isbn)
        {
            if (PersistenciaDocumento.EXIST(isbn))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ExisteEjemplar(int codigoEjemplar)
        {
            if (PersistenciaEjemplar.EXIST(codigoEjemplar.ToString()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Ejemplar ObtenerEjemplar(int codigoEjemplar)
        {
            return PersistenciaEjemplar.READ(codigoEjemplar);
        }
        public Documento ObtenerDocumento(int isbn)
        {
            return PersistenciaDocumento.READ(isbn);
        }
        public List<Ejemplar> ListadoEjemplares()
        {
            return PersistenciaEjemplar.READALL();
        }

        public string getNombre()
        {
           return personal.Nombre;
        }
    }
}