using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace SimpleWeather.Paginas
{
    // Pagina donde se muestran los datos, info y ayuda de la app. 
    public sealed partial class InformacionApp : Page
    {
        public InformacionApp()
        {
            this.InitializeComponent();

            FrameDatos.Navigate(typeof(InformacionCreditos));
        }

        private void tapped_botonCreditos(object sender, TappedRoutedEventArgs e)
        {
            botonCreditos.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x00, 0x00, 0x00));
            botonInformacion.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x66, 0x66, 0x66));
            botonAyuda.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x66, 0x66, 0x66));

            FrameDatos.Navigate(typeof(InformacionCreditos));
        }

        private void tapped_botonInformacion(object sender, TappedRoutedEventArgs e)
        {
            botonCreditos.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x66, 0x66, 0x66));
            botonInformacion.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x00, 0x00, 0x00));
            botonAyuda.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x66, 0x66, 0x66));

            FrameDatos.Navigate(typeof(InformacionInformacion));
        }

        private void tapped_botonAyuda(object sender, TappedRoutedEventArgs e)
        {
            botonCreditos.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x66, 0x66, 0x66));
            botonInformacion.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x66, 0x66, 0x66));
            botonAyuda.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x00, 0x00, 0x00));

            FrameDatos.Navigate(typeof(InformacionAyuda));
        }
    }
}
