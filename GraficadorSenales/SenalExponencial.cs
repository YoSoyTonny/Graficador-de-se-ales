using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraficadorSenales
{
    class SenalExponencial : Señal
    {
        //Exclusivos de señal exponencial.
        public double alpha { get; set; }
        //

        public SenalExponencial()
        {
            alpha = 0.0;
            Muestra = new List<Muestra>();
        }

        public SenalExponencial(double Alpha)
        {
            alpha = Alpha;
            Muestra = new List<Muestra>();
        }

        public override double evaluar(double tiempo)
        {
            double resultado;

            resultado = Math.Exp(alpha * tiempo);

            return resultado;
        }
    }
}