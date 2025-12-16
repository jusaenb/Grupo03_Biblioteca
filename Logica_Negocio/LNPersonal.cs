using System;
using System.Collections.Generic;
using System.Linq;
using MD;
using Persistencia;

namespace LN
{
    public class LNPersonal 
    {
        protected Personal personal;

        public LNPersonal(Personal personal)
        {
            this.personal = personal;
        }

        public Personal Personal { get { return personal; } }

        /// <summary>
        /// Verifica si el trabajador existe para permitir el acceso.
        /// </summary>
        public bool Loguearse(string password)
        {
            if (!PersistenciaPersonal.EXIST(this.personal.Dni))
            {
                return false;
            }
            Personal personalEnBD = PersistenciaPersonal.READ(this.personal.Dni);
            if (personalEnBD == null) return false;
            if (personalEnBD.Rol != this.personal.Rol)
            {
                return false;
            }
            return true;
        }

        // GESTIÓN DE USUARIOS

        public void AltaUsuario(string dni, string nombre)
        {
            if (string.IsNullOrWhiteSpace(dni) || string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("DNI y Nombre son obligatorios.");

            if (PersistenciaUsuario.EXIST(dni))
            {
                throw new InvalidOperationException($"El usuario con DNI {dni} ya existe.");
            }

            Usuario usuario = new Usuario(dni, nombre);
            PersistenciaUsuario.CREATE(usuario);
        }

        public void BajaUsuario(string dni)
        {
            if (!PersistenciaUsuario.EXIST(dni))
            {
                throw new ArgumentException("El usuario no existe.");
            }

            // REGLA DE NEGOCIO: No borrar si tiene préstamos activos
            if (TienePrestamosActivos(dni))
            {
                throw new InvalidOperationException("No se puede borrar al usuario: Tiene préstamos en proceso.");
            }

            PersistenciaUsuario.DELETE(dni);
        }

        public Usuario ObtenerUsuario(string dni)
        {
            return PersistenciaUsuario.READ(dni);
        }

        public bool ExisteUsuario(string dni)
        {
            return PersistenciaUsuario.EXIST(dni);
        }

        public List<Usuario> ListadoUsuarios()
        {
            return PersistenciaUsuario.READALL();
        }

        // --- MÉTODOS AUXILIARES PARA VALIDACIONES ---

        public bool TienePrestamosActivos(string dni)
        {
            var prestamos = PersistenciaPrestamo.READALL_POR_USUARIO(dni);
            return prestamos.Any(p => p.Estado == "En Proceso");
        }

        public bool TienePrestamosFueraDePlazo(string dni)
        {
            var prestamos = PersistenciaPrestamo.READALL_POR_USUARIO(dni);
            return prestamos.Any(p => p.Estado == "En Proceso" && p.FechaDevolucion < DateTime.Now);
        }
    }
}