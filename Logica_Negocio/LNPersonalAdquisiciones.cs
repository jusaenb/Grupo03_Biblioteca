using MD;
using Persistencia;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LN
{
    public class LNPersonalAdquisiciones : LNPersonal
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="personalAdquisiciones"></param>
        public LNPersonalAdquisiciones(PersonalAdquisiciones personalAdquisiciones) : base(personalAdquisiciones)
        {
        }
        /// <summary>
        /// Da de alta a un documento.
        /// </summary>
        /// <param name="isbn"></param>
        /// <param name="titulo"></param>
        public void DarAltaDocumento(int isbn, string titulo, string autor, string editorial, int año, string tipo, string formato = "", float duracion = 0)
        {
            if (PersistenciaDocumento.EXIST(isbn))
            {
                throw new InvalidOperationException($"El documento con ISBN {isbn} ya existe.");
            }

            Documento nuevoDoc;

            if (tipo == "AudioLibro")
            {
                nuevoDoc = new AudioLibro(titulo, autor, editorial, año, isbn, formato, duracion);
            }
            else
            {
                nuevoDoc = new Documento(año, titulo, autor, isbn, editorial);
            }

            PersistenciaDocumento.CREATE(nuevoDoc);

            Console.WriteLine($"Alta realizada: {titulo} por {Personal.Nombre}");
        }

    }
}
