using LN;
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
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FLogin login = new FLogin();
            if (login.ShowDialog() == DialogResult.OK)
            {
                // 2. Si el login es correcto, recuperamos la LN creada en el login
                LNPersonal logicaNegocio = login.LogicaNegocio;

                // 3. Abrimos la ventana principal pasándole la lógica
                Application.Run(new FPrincipal(logicaNegocio));
            }
        }
    }
}
