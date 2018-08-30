using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraficadorSenales
{
    class SenalRampa
    {
        public List<Muestra> Muestra { get; set; }
        public double AmplitudMaxima { get; set; }

        public SenalRampa()
        {
            Muestra = new List<Muestra>();
            AmplitudMaxima = 0.0;
        }

        public SenalRampa(double amplitud, double fase, double frecuencia)
        {
            Muestra = new List<Muestra>();
            AmplitudMaxima = 0.0;
        }

        public double evaluar(double tiempo)
        {
            double resultado;
            
            if (tiempo >= 0)
            {
                resultado = tiempo;
            } else
            {
                resultado = 0;
            }

            return resultado;


        }

    }
}
