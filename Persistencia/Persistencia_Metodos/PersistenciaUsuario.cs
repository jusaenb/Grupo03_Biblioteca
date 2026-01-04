using System.Collections.Generic;
using MD;

namespace Persistencia
{
    public static class PersistenciaUsuario
    {
        // PRE:  dni es una cadena válida representando el identificador del usuario.
        // POST: Devuelve true si el usuario existe en la base de datos, false en caso contrario.
        public static bool EXIST(string dni)
        {
            return BD.TablaUsuarios.Contains(dni);
        }

        // PRE:  El objeto usuario no debe ser nulo y debe tener un DNI válido.
        // POST: Si no existe un usuario con ese DNI, se añade a la base de datos.
        //       Si ya existe, el estado de la base de datos no cambia.
        public static void CREATE(Usuario usuario)
        {
            if (!BD.TablaUsuarios.Contains(usuario.Dni))
            {
                UsuarioDato ud = TransformersBiblioteca.UsuarioAUsuarioDato(usuario);
                BD.TablaUsuarios.Add(ud);
            }
        }

        // PRE:  El objeto usuario no debe ser nulo.
        // POST: Si el usuario existe (por DNI), se actualizan sus datos eliminando el antiguo y creando el nuevo.
        //       Si no existe, no se realiza ninguna acción.
        public static void UPDATE(Usuario usuario)
        {
            // Para actualizar, verificamos si existe, borramos el viejo y ponemos el nuevo
            if (BD.TablaUsuarios.Contains(usuario.Dni))
            {
                BD.TablaUsuarios.Remove(usuario.Dni);
                CREATE(usuario);
            }
        }

        // PRE:  dni es una cadena válida.
        // POST: Si existe un usuario con ese DNI, es eliminado de la base de datos.
        //       Si no existe, el estado de la base de datos no cambia.
        public static void DELETE(string dni)
        {
            if (BD.TablaUsuarios.Contains(dni))
            {
                BD.TablaUsuarios.Remove(dni);


            }
        }

        // PRE:  dni es una cadena válida.
        // POST: Devuelve el objeto Usuario asociado al DNI si existe. Devuelve null si no se encuentra.
        public static Usuario READ(string dni)
        {
            if (BD.TablaUsuarios.Contains(dni))
            {
                return TransformersBiblioteca.UsuarioDatoAUsuario(BD.TablaUsuarios[dni]);
            }
            return null;
        }

        // PRE:  Ninguna.
        // POST: Devuelve una lista con TODOS los usuarios registrados en el sistema.
        //       La lista nunca es nula.
        public static List<Usuario> READALL()
        {
            List<Usuario> lista = new List<Usuario>();
            foreach (UsuarioDato ud in BD.TablaUsuarios)
            {
                lista.Add(TransformersBiblioteca.UsuarioDatoAUsuario(ud));
            }
            return lista;
        }
    }
}