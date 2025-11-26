using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    static class BD
    {
        // ==========================================
        // DOCUMENTOS Y EJEMPLARES
        // ==========================================
        static Tabla<int, DocumentoDato> tablaDocumentos;
        static Tabla<int, AudioLibroDato> tablaAudioLibros;
        static Tabla<string, EjemplarDato> tablaEjemplares;

        // ==========================================
        // PERSONAL (Usuarios no incluido por falta de UsuarioDato)
        // ==========================================
        static Tabla<string, PersonalDato> tablaPersonal;
        static Tabla<string, PersonalSalaDato> tablaPersonalSala;
        static Tabla<string, PersonalAdquisicionesDato> tablaPersonalAdquisiciones;

        // ==========================================
        // PRÉSTAMOS
        // ==========================================
        static Tabla<string, PrestamoDato> tablaPrestamos;
        static Tabla<Compuesto, PrestamoEjemplarDato> tablaPrestamoEjemplar;


        // ==========================================
        // PROPIEDADES PÚBLICAS (Lazy Initialization)
        // ==========================================

        // --- DOCUMENTOS ---
        public static Tabla<int, DocumentoDato> TablaDocumentos
        {
            get
            {
                if (tablaDocumentos == null)
                {
                    tablaDocumentos = new Tabla<int, DocumentoDato>();
                }
                return tablaDocumentos;
            }
        }

        public static Tabla<int, AudioLibroDato> TablaAudioLibros
        {
            get
            {
                if (tablaAudioLibros == null)
                {
                    tablaAudioLibros = new Tabla<int, AudioLibroDato>();
                }
                return tablaAudioLibros;
            }
        }

        // --- EJEMPLARES ---
        public static Tabla<string, EjemplarDato> TablaEjemplares
        {
            get
            {
                if (tablaEjemplares == null)
                {
                    tablaEjemplares = new Tabla<string, EjemplarDato>();
                }
                return tablaEjemplares;
            }
        }

        // --- PERSONAL ---
        public static Tabla<string, PersonalDato> TablaPersonal
        {
            get
            {
                if (tablaPersonal == null)
                {
                    tablaPersonal = new Tabla<string, PersonalDato>();
                }
                return tablaPersonal;
            }
        }

        public static Tabla<string, PersonalSalaDato> TablaPersonalSala
        {
            get
            {
                if (tablaPersonalSala == null)
                {
                    tablaPersonalSala = new Tabla<string, PersonalSalaDato>();
                }
                return tablaPersonalSala;
            }
        }

        public static Tabla<string, PersonalAdquisicionesDato> TablaPersonalAdquisiciones
        {
            get
            {
                if (tablaPersonalAdquisiciones == null)
                {
                    tablaPersonalAdquisiciones = new Tabla<string, PersonalAdquisicionesDato>();
                }
                return tablaPersonalAdquisiciones;
            }
        }

        // --- PRÉSTAMOS ---
        public static Tabla<string, PrestamoDato> TablaPrestamos
        {
            get
            {
                if (tablaPrestamos == null)
                {
                    tablaPrestamos = new Tabla<string, PrestamoDato>();
                }
                return tablaPrestamos;
            }
        }

        public static Tabla<Compuesto, PrestamoEjemplarDato> TablaPrestamoEjemplar
        {
            get
            {
                if (tablaPrestamoEjemplar == null)
                {
                    tablaPrestamoEjemplar = new Tabla<Compuesto, PrestamoEjemplarDato>();
                }
                return tablaPrestamoEjemplar;
            }
        }
    }
}
