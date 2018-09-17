using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraficadorSenales
{
    abstract class Señal
    {
        public List<Muestra> Muestra { get; set; }
        public double AmplitudMaxima { get; set; }
        public double tiempoInicial { get; set; }
        public double tiempoFinal { get; set; }
        public double frecuenciaMuestreo { get; set; }

        public abstract double evaluar(double tiempo);

        public void constrirSeñalDigital()
        {

            double periodoMuestreo = 1 / frecuenciaMuestreo;

            for (double i = tiempoInicial; i <= tiempoFinal; i += periodoMuestreo)
            {
                double valorMuestra = evaluar(i);

                if (Math.Abs(valorMuestra) > AmplitudMaxima)
                {
                    AmplitudMaxima = Math.Abs(valorMuestra);
                }

                Muestra.Add(new Muestra(i, valorMuestra));
            }
        }
    }
}
