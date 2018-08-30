using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GraficadorSenales
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void btnGraficar_Click(object sender, RoutedEventArgs e)
        {
            double amplitud = double.Parse(txtAmplitud.Text);
            double fase = double.Parse(txtFase.Text);
            double frecuencia =double.Parse(txtFrecuencia.Text);

            double TiempoInicial = double.Parse(txtTiempoInicial.Text);
            double TiempoFinal = double.Parse(txtTiempoFinal.Text);
            double FrecuenciaMuestreo = double.Parse(txtFrecuenciaMuestreo.Text);

            SenalSenoidal señal = new SenalSenoidal(amplitud, fase, frecuencia);

            double periodoMuestreo = 1 / FrecuenciaMuestreo;
            for (double i = TiempoInicial; i <= TiempoFinal; i += periodoMuestreo)
            {
                double valorMuestra = señal.evaluar(i);

                if (Math.Abs(valorMuestra) > señal.AmplitudMaxima)
                {
                    señal.AmplitudMaxima = Math.Abs(valorMuestra);
                }

                señal.Muestra.Add(new Muestra(i, valorMuestra ));
            }

            foreach (Muestra muestra in señal.Muestra)
            {
                plnGrafica.Points.Add(new Point(muestra.X * scrContenedor.Width
                    , (muestra.Y * ((scrContenedor.Height / 2.0)-30) * -1)
                    + (scrContenedor.Height / 2))
                    );
            }

        }

        private void btnGraficarRampa_Click(object sender, RoutedEventArgs e)
        {
            double TiempoInicial = double.Parse(txtTiempoInicial.Text);
            double TiempoFinal = double.Parse(txtTiempoFinal.Text);
            double FrecuenciaMuestreo = double.Parse(txtFrecuenciaMuestreo.Text);

            SenalRampa señal = new SenalRampa();

            double periodoMuestreo = 1 / FrecuenciaMuestreo;

            for (double i = TiempoInicial; i <= TiempoFinal; i += periodoMuestreo)
            {
                double valorMuestra = señal.evaluar(i);

                if (Math.Abs(valorMuestra) > señal.AmplitudMaxima)
                {
                    señal.AmplitudMaxima = Math.Abs(valorMuestra);
                }

                señal.Muestra.Add(new Muestra(i, valorMuestra));
            }

            foreach (Muestra muestra in señal.Muestra)
            {
                plnGrafica.Points.Add(new Point(muestra.X * scrContenedor.Width
                    , (muestra.Y * ((scrContenedor.Height / 2.0) - 30) * -1)
                    + (scrContenedor.Height / 2))
                    );
            }
        }
    }
}
