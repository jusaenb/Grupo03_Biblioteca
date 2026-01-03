using LN;
using MD;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentacion
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                

                var jefeAdq = new PersonalAdquisiciones("1111", "Admin1");
                var lnAdq = new LNPersonalAdquisiciones(jefeAdq);
                lnAdq.RegistrarEstePersonal(); 

                var jefeSala = new PersonalSala("2222", "Admin2");
                var lnSala = new LNPersonalSala(jefeSala);
                lnSala.RegistrarEstePersonal();

                
                Documento libro1 = new Documento(1605, "Don Quijote", "Cervantes", 100, "Anaya");
                lnAdq.DarAltaDocumento(libro1);

                // Creamos sus ejemplares (Estos siguen necesitando ID + ISBN)
                // Nota: Verifica si tu DarAltaEjemplar pide (id, isbn) o (Ejemplar)
                // Asumo que sigue pidiendo ID e ISBN:
                if (lnAdq.ObtenerEjemplar(10) == null) lnAdq.DarAltaEjemplar(10, 100);
                if (lnAdq.ObtenerEjemplar(11) == null) lnAdq.DarAltaEjemplar(11, 100);

                // Segundo libro
                Documento libro2 = new Documento(1997, "Harry Potter", "Rowling", 200, "Salamandra");
                lnAdq.DarAltaDocumento(libro2);

                if (lnAdq.ObtenerEjemplar(20) == null) lnAdq.DarAltaEjemplar(20, 200);


                // 3. Crear Usuarios
                if (!lnSala.ExisteUsuario("1A")) lnSala.AltaUsuario("1A", "Pepe Usuario");
                if (!lnSala.ExisteUsuario("2B")) lnSala.AltaUsuario("2B", "Maria Usuario");

               
               
              
                
                    lnSala.DarAltaPrestamo("1A", new List<int> { 10 },"1");
                

                
            }
            catch (Exception ex)
            {
                
            }

            
           
            
                Application.Run(new FLogin());
            
        }
    }
}