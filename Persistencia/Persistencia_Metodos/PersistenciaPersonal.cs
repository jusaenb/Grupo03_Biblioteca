using MD;
using System.Collections.Generic;
using System.Net;

namespace Persistencia
{
    public static class PersistenciaPersonal
    {
        // PRE:  El objeto p no debe ser nulo.
        // POST: Devuelve true si el personal existe en su tabla específica (Sala o Adquisiciones), false en caso contrario.
        public static bool EXIST(Personal p )
        {
            if(p is PersonalSala)
            {
                return BD.TablaPersonalSala.Contains(p.Dni);
            }
            else
            {
                return BD.TablaPersonalAdquisiciones.Contains(p.Dni);
            }
                
        }

        // PRE:  El objeto personal no debe ser nulo y debe tener un DNI válido.
        // POST: Si el personal no existe en la tabla general, se añade a esta y a la tabla específica correspondiente.
        //       Si ya existe, el estado de la base de datos no cambia.
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

        // PRE:  dni es una cadena válida.
        // POST: Devuelve el objeto Personal asociado al DNI si existe en la tabla general. Devuelve null si no se encuentra.
        public static Personal READ(string dni)
        {
            if (BD.TablaPersonal.Contains(dni))
            {
                return TransformersBiblioteca.PersonalDatoAPersonal(BD.TablaPersonal[dni]);
            }
            return null;
        }

        // Método simple para simular login buscando por DNI (ya que no gestionamos contraseñas en el PDF)
        // PRE:  dni es una cadena válida.
        // POST: Devuelve true si el DNI existe en la tabla general de personal, false en caso contrario.
        public static bool ExistePersonal(string dni)
        {
            return BD.TablaPersonal.Contains(dni);
        }
    }
}