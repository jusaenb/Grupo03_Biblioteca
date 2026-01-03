using MD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica_Negocio
{
    public interface ILNPersonal
    {
        bool Loguearse(string password);
        void AltaUsuario(string dni, string nombre);
        void BajaUsuario(string dni);
        Usuario ObtenerUsuario(string dni);
        bool ExisteUsuario(string dni);
        List<Usuario> ListadoUsuarios();
        bool TienePrestamosActivos(string dni);
        void RegistrarEstePersonal();
    }
}
