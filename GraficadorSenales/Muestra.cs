using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraficadorSenales
{
    class Muestra
    {
        public double X { get; set; }
        public double Y { get; set; }

        //constructor que inicializa valores
        public Muestra(double x, double y)
        {
            X = x;
            Y = y;
        }

        //Constructor sin parametro
        public Muestra()
        {
            X = 0.0;
            Y = 0.0;
        }

    }
}
