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
using System.Net.NetworkInformation;
using System.Xml;

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

            if (Conexion())
            {
                comboBoxCiudades.IsEnabled = true;

                string ciudad = Ciudad();
                FrameDatos.Navigate(typeof(ContentPage), ciudad);
            }
            else {
                comboBoxCiudades.IsEnabled = false;

                FrameDatos.Navigate(typeof(NoDisponible));
            }
        }

        public Boolean Conexion() {
            try
            {
                string ciudad = Ciudad();
                XmlReader reader = XmlReader.Create(ciudad);
                return true;
            }
            catch (System.Net.WebException exc)
            {
                return false;
            }
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {

            if (Conexion())
            {
                comboBoxCiudades.IsEnabled = true;

                string ciudad = Ciudad();
                FrameDatos.Navigate(typeof(ContentPage), ciudad);
            }
            else
            {
                comboBoxCiudades.IsEnabled = false;

                FrameDatos.Navigate(typeof(NoDisponible));
            }
        }

        private void Info_Click(object sender, RoutedEventArgs e) {
            FrameDatos.Navigate(typeof(InformacionApp));
            comboBoxCiudades.IsEnabled = false;
        }

        private void comboBoxCiudades_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxCiudades != null)
            {
                if (Conexion())
                {
                    comboBoxCiudades.IsEnabled = true;

                    string ciudad = Ciudad();
                    FrameDatos.Navigate(typeof(ContentPage), ciudad);
                }
                else
                {
                    comboBoxCiudades.IsEnabled = false;

                    FrameDatos.Navigate(typeof(NoDisponible));
                }
            }
        }

        private string Ciudad()
        {
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
    }
}
