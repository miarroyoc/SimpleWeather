using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=234238

namespace SimpleWeather.Paginas
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class Principal : Page
    {
        public Principal()
        {
            this.InitializeComponent();

            comboBoxCiudades.IsEnabled = true;

            string ciudad = Ciudad();
            Frame.Navigate(typeof(ContentPage), ciudad);
        }

        private void Home_Click(object sender, RoutedEventArgs e) {

            string ciudad = Ciudad();
            comboBoxCiudades.IsEnabled = true;
            Frame.Navigate(typeof(ContentPage), ciudad);
        }

        private void Info_Click(object sender, RoutedEventArgs e) {
            Frame.Navigate(typeof(InformacionApp));
            comboBoxCiudades.IsEnabled = false;
        }

        private string Ciudad() {
            string urlCiudad = null;

            switch (comboBoxCiudades.SelectedIndex)
            {
                case 0:
                    urlCiudad = "http://www.aemet.es/xml/municipios/localidad_10037.xml";
                    break;
                case 1:
                    urlCiudad = "http://www.aemet.es/xml/municipios/localidad_06015.xml";
                    break;
                case 2:
                    urlCiudad = "http://www.aemet.es/xml/municipios/localidad_06083.xml";
                    break;
                case 3:
                    urlCiudad = "http://www.aemet.es/xml/municipios/localidad_28079.xml";
                    break;
                case 4:
                    urlCiudad = "http://www.aemet.es/xml/municipios/localidad_41091.xml";
                    break;
                default:
                    urlCiudad = null;
                    break;
            }

            return urlCiudad;
        }


        private void comboBoxCiudades_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxCiudades != null)
            {
                string ciudad = Ciudad();
                comboBoxCiudades.IsEnabled = true;
                Frame.Navigate(typeof(ContentPage), ciudad);
            }
        }
        
    }
}
