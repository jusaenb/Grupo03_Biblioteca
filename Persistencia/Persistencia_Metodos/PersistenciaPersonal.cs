using System.Collections.Generic;
using MD;

namespace Persistencia
{
    public static class PersistenciaPersonal
    {
        public static bool EXIST(string dni)
        {
            return BD.TablaPersonal.Contains(dni);
        }
        public static void CREATE(Personal personal)
        {
            if (!BD.TablaPersonal.Contains(personal.Dni))
            {
                PersonalDato pd = TransformersBiblioteca.PersonalAPersonalDato(personal);
                BD.TablaPersonal.Add(pd);

                // Añadir también a las tablas específicas para mantener la jerarquía
                if (personal is PersonalSala)
                {
                    BD.TablaPersonalSala.Add((PersonalSalaDato)pd);
                }
                else if (personal is PersonalAdquisiciones)
                {
                    BD.TablaPersonalAdquisiciones.Add((PersonalAdquisicionesDato)pd);
                }
            }
        }

        public static Personal READ(string dni)
        {
            if (BD.TablaPersonal.Contains(dni))
            {
                return TransformersBiblioteca.PersonalDatoAPersonal(BD.TablaPersonal[dni]);
            }
            return null;
        }

        // Método simple para simular login buscando por DNI (ya que no gestionamos contraseñas en el PDF)
        public static bool ExistePersonal(string dni)
        {
            return BD.TablaPersonal.Contains(dni);
        }
    }
}
