using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD
{
    internal class Prestamo
    {
        private int idPrestamo;
        private DateTime FechaInicio;
        private DateTime FechaDevolucionMaxima;
        private DateTime FechaDevolucionReal;
        private String estadoPrestamo;

        public Prestamo()
        {
            //idPrestamo = 
            FechaInicio = DateTime.Now;
            if (//prestamo de libros en papel)
            {
                FechaDevolucionMaxima = FechaInicio.AddDays(15);
            }
            else
            {
                FechaDevolucionMaxima = FechaInicio.AddDays(10);
            }
            estadoPrestamo = "En Proceso";
        }

        public void finalizarPrestamo()
        {
            FechaDevolucionReal = DateTime.Now;
            estadoPrestamo = "Finalizado";
        }

        public int diasRetrasoDevolucion()
        {
            if (FechaDevolucionReal > FechaDevolucionMaxima)
            {
                TimeSpan retraso = FechaDevolucionReal - FechaDevolucionMaxima;
                return retraso.Days;
            }
            return 0;
        }

    }
}
