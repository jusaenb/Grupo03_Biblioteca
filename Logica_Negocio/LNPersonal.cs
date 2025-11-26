using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MD;

namespace LN
{
    public abstract class LNPersonal
    {
        protected Personal personal;

        public LNPersonal(Personal personal)
        {
            this.personal = personal;
        }

        public Personal Personal { get { return personal; } }

        /// <summary>
        /// Método para loguearse en el sistema.
        /// </summary>
        public bool Loguearse(string password)
        {
            // Aquí iría la lógica real de comprobación de contraseñas.
            // Por ahora devolvemos true como placeholder.
            return true;
        }

        // ==========================================
        // GESTIÓN DE USUARIOS (Común a ambos roles)
        // ==========================================

        /// <summary>
        /// Da de alta un nuevo usuario.
        /// </summary>
        public void AltaUsuario(Usuario usuario)
        {
            if (!ExisteUsuario(usuario.Dni))
            {
                PersistenciaUsuario.CREATE(usuario);
            }
        }

        /// <summary>
        /// Da de baja un usuario existente.
        /// </summary>
        public void BajaUsuario(string dni)
        {
            if (ExisteUsuario(dni))
            {
             
                PersistenciaUsuario.DELETE(dni);
            }
        }

        /// <summary>
        /// Obtiene un usuario por su DNI.
        /// </summary>
        public Usuario ObtenerUsuario(string dni)
        {
            return PersistenciaUsuario.READ(dni);
        }

        /// <summary>
        /// Verifica si un usuario existe.
        /// </summary>
        public bool ExisteUsuario(string dni)
        {
            return PersistenciaUsuario.READ(dni) != null;
        }

        /// <summary>
        /// Obtiene todos los usuarios de la biblioteca.
        /// </summary>
        public List<Usuario> ListadoUsuarios()
        {
            return PersistenciaUsuario.READALL();
        }
    }
}
