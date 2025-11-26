using System.Collections.Generic;
using MD;

namespace Persistencia
{
    public static class PersistenciaUsuario
    {
        public static void CREATE(Usuario usuario)
        {
            if (!BD.TablaUsuarios.Contains(usuario.Dni))
            {
                UsuarioDato ud = TransformersBiblioteca.UsuarioAUsuarioDato(usuario);
                BD.TablaUsuarios.Add(ud);
            }
        }

        public static void UPDATE(Usuario usuario)
        {
            // Para actualizar, verificamos si existe, borramos el viejo y ponemos el nuevo
            if (BD.TablaUsuarios.Contains(usuario.Dni))
            {
                BD.TablaUsuarios.Remove(usuario.Dni);
                CREATE(usuario);
            }
        }

        public static void DELETE(string dni)
        {
            if (BD.TablaUsuarios.Contains(dni))
            {
                BD.TablaUsuarios.Remove(dni);

                
            }
        }

        public static Usuario READ(string dni)
        {
            if (BD.TablaUsuarios.Contains(dni))
            {
                return TransformersBiblioteca.UsuarioDatoAUsuario(BD.TablaUsuarios[dni]);
            }
            return null;
        }

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