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
        // PRE:  password es una cadena no nula (puede ser vacía si no se requiere seguridad estricta).
        // POST: Devuelve true si la contraseña coincide con la del personal autenticado, false en caso contrario.
        bool Loguearse(string password);

        // PRE:  dni y nombre son cadenas válidas y no nulas. El DNI debe tener un formato correcto.
        // POST: Crea un nuevo usuario en el sistema. Si el usuario ya existía, lanza una excepción o no realiza cambios (según implementación).
        void AltaUsuario(string dni, string nombre);

        // PRE:  dni es una cadena válida. El usuario no debe tener préstamos activos pendientes de devolución.
        // POST: El usuario con ese DNI es eliminado del sistema. Si no existía, no ocurre nada.
        void BajaUsuario(string dni);

        // PRE:  dni es una cadena válida.
        // POST: Devuelve el objeto Usuario asociado si existe. Devuelve null si no se encuentra.
        Usuario ObtenerUsuario(string dni);

        // PRE:  dni es una cadena válida.
        // POST: Devuelve true si existe un usuario registrado con ese DNI, false en caso contrario.
        bool ExisteUsuario(string dni);

        // PRE:  Ninguna.
        // POST: Devuelve una lista con todos los usuarios registrados. La lista nunca es nula (puede estar vacía).
        List<Usuario> ListadoUsuarios();

        // PRE:  dni corresponde a un usuario existente en el sistema.
        // POST: Devuelve true si el usuario tiene libros sin devolver (estado 'En Proceso'), false si ha devuelto todo o no tiene préstamos.
        bool TienePrestamosActivos(string dni);

        // PRE:  La instancia actual de Personal tiene datos válidos (DNI, Nombre).
        // POST: Guarda o actualiza la información de este miembro del personal en la base de datos de persistencia.
        void RegistrarEstePersonal();
    }
}