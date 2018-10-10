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

        private void btnGraficar_Click(object sender, RoutedEventArgs e)
        {
            double tiempoInicial = double.Parse(txtTiempoInicial.Text);
            double tiempoFinal = double.Parse(txtTiempoFinal.Text);
            double frecMuestreo = double.Parse(txtFrecuenciaMuestreo.Text);

            Señal señal;

            switch (cbTipoSeñal.SelectedIndex)
            {
                case 0:
                    double amplitud = double.Parse(((ConfiguracionSenoidal)(panelConfiguracion.Children[0])).txtAmplitud.Text);
                    double fase = double.Parse(((ConfiguracionSenoidal)(panelConfiguracion.Children[0])).txtFase.Text);
                    double frecuencia = double.Parse(((ConfiguracionSenoidal)(panelConfiguracion.Children[0])).txtFrecuencia.Text);

                    señal = new SenalSenoidal(amplitud, fase, frecuencia);
                    break;

                case 1:
                    señal = new SenalRampa();
                    break;

                case 2:
                    double alpha = double.Parse(((ConfiguracionExponencial)(panelConfiguracion.Children[0])).txtAlpha.Text);

                    señal = new SenalExponencial(alpha);
                    break;

                default:
                    señal = null;
                    break;
            }

            señal.TiempoInicial = tiempoInicial;
            señal.TiempoFinal = tiempoFinal;
            señal.FrecuenciaMuestreo = frecMuestreo;

            señal.construirSenalDigital();

            //Escalar
            double factorEscala = double.Parse(txtFactorEscalaAmplitud.Text);
            señal.escalar(factorEscala);

            señal.actualizarAmplitudMaxima();

            plnGrafica.Points.Clear();

            if (señal != null)
            {
                //Recorrer una colección o arreglo.
                foreach (Muestra muestra in señal.Muestra)
                {
                    plnGrafica.Points.Add(new Point((muestra.X - tiempoInicial) * scrContenedor.Width,
                        (muestra.Y / señal.AmplitudMaxima) * ((scrContenedor.Height / 2.0) - 30) * -1 + (scrContenedor.Height / 2)));
                }

                lblAmplitudMaximaY.Text = señal.AmplitudMaxima.ToString("F");
                lblAmplitudMaximaY_Negativa.Text = "-" + señal.AmplitudMaxima.ToString("F");
            }

            //Graficando el eje de X
            plnEjeX.Points.Clear();
            //Punto de inicio.
            plnEjeX.Points.Add(new Point(0, (scrContenedor.Height / 2)));
            //Punto de fin.
            plnEjeX.Points.Add(new Point((tiempoFinal - tiempoInicial) * scrContenedor.Width, (scrContenedor.Height / 2)));

            //Graficando el eje de Y
            plnEjeY.Points.Clear();
            //Punto de inicio.
            plnEjeY.Points.Add(new Point(0 - tiempoInicial * scrContenedor.Width, scrContenedor.Height));
            //Punto de fin.
            plnEjeY.Points.Add(new Point(0 - tiempoInicial * scrContenedor.Width, scrContenedor.Height * -1));
        }

        private void cbTipoSeñal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (panelConfiguracion != null)
            {
                panelConfiguracion.Children.Clear();

                switch (cbTipoSeñal.SelectedIndex)
                {
                    case 0: //Senoidal
                        panelConfiguracion.Children.Add(new ConfiguracionSenoidal());
                        break;

                    case 1: //Rampa
                        break;

                    case 2: //Exponencial
                        panelConfiguracion.Children.Add(new ConfiguracionExponencial());
                        break;

                    default:
                        break;
                }
            }
        }

        private void cbTipoSeñal_SegundaSeñal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        /* private void txtEscalaAmplitud_TextChanged(object sender, TextChangedEventArgs e)
         {

         }*/
    }
}
