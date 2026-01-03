using System;
using System.Collections.Generic;
using System.Linq;
using Logica_Negocio;
using MD;
using Persistencia;

namespace LN
{
    public abstract class LNPersonal : ILNPersonal
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
            // Usamos la fachada de PersistenciaPersonal
            return PersistenciaPersonal.EXIST(this.personal);
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
        // -----------------------------------------------------------------------------
        // Método para registrar al personal actual en la Base de Datos
        // (Necesario para la carga inicial de datos desde Program.cs)
        // -----------------------------------------------------------------------------
        public void RegistrarEstePersonal()
        {
            // Verificamos si ya existe usando el DNI del personal actual
            if (!PersistenciaPersonal.EXIST(this.personal))
            {
                // Si no existe, llamamos a la capa de persistencia para crearlo
                PersistenciaPersonal.CREATE(this.personal);
            }
        }

       

      
    }
}