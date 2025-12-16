using LN;
using Logica_Negocio;
using MD;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        /*static void Main()
        {
            Application
            if (login.ShowDialog() == DialogResult.OK)
            {.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FLogin login = new FLogin();
                // 2. Si el login es correcto, recuperamos la LN creada en el login
                LNPersonal logicaNegocio = login.LogicaNegocio;

                // 3. Abrimos la ventana principal pasándole la lógica
                Application.Run(new frmPrincipal(logicaNegocio));
            }
        }*/
        static void Main()
        {
            // =========================================================================
            // 1. POBLAR LA BASE DE DATOS (SEEDING)
            // =========================================================================
            // Como la BD son listas en memoria, si no creamos datos aquí,
            // no podrás hacer Login ni ver nada.

            try
            {
                // --- A. CREAR PERSONAL (Necesario para poder hacer Login) ---
                // NOTA: En tu FLogin compruebas si el DNI existe en PersistenciaPersonal.

                // 1. Personal de Sala (Para probar el Rol de Sala)
                // Ajusta los constructores según tu clase PersonalSala (supongo DNI, Nombre)
                PersonalSala personalSala = new PersonalSala("1", "Juan Sala");
                PersistenciaPersonal.CREATE(personalSala); // Asumo que tienes un método CREATE en PersistenciaPersonal

                // 2. Personal de Adquisiciones (Para probar Rol Adquisiciones)
                PersonalAdquisiciones personalAdq = new PersonalAdquisiciones("2", "Ana Adquisiciones");
                PersistenciaPersonal.CREATE(personalAdq);


                Usuario usuario1 = new Usuario("1111A", "Luis Lector");
                Usuario usuario2 = new Usuario("2222B", "Maria Estudiante");

                PersistenciaUsuario.CREATE(usuario1);
                PersistenciaUsuario.CREATE(usuario2);


                // --- C. CREAR DOCUMENTOS (LIBROS / AUDIOLIBROS) ---
                // Constructor: año, titulo, autor, isbn, editorial
                Documento libro1 = new Documento(2020, "C# para Todos", "Microsoft", 1001, "TechEdit");
                Documento libro2 = new Documento(1967, "Cien Años de Soledad", "Gabo", 1002, "Sudamericana");

                // Si tienes una subclase AudioLibro:
                Documento audio1 = new AudioLibro("2", "Audiolibro Moderno", "Narrador", 1003, 120, "aaa", 21);

                PersistenciaDocumento.CREATE(libro1);
                PersistenciaDocumento.CREATE(libro2);
                PersistenciaDocumento.CREATE(audio1);


                // --- D. CREAR EJEMPLARES ---
                // Constructor: codigo, Documento, disponible (bool)
                Ejemplar ej1 = new Ejemplar(1, libro1, true);
                Ejemplar ej2 = new Ejemplar(2, libro1, true); // Otro ejemplar del mismo libro
                Ejemplar ej3 = new Ejemplar(3, libro2, true);

                PersistenciaEjemplar.CREATE(ej1); // Asumo PersistenciaEjemplar.CREATE
                PersistenciaEjemplar.CREATE(ej2);
                PersistenciaEjemplar.CREATE(ej3);

            }
            catch (Exception ex)
            {
                // Si algo falla al crear datos (ej. claves duplicadas si recargas),
                // mostramos error pero intentamos abrir la app.
                MessageBox.Show("Error al cargar datos de prueba: " + ex.Message);
            }


            // =========================================================================
            // 2. INICIAR LA APLICACIÓN
            // =========================================================================

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // En tu proyecto, FLogin es el encargado de crear la LNPersonal y 
            // abrir el frmPrincipal si el logueo es correcto.
            Application.Run(new FLogin());
        }
    }
}
