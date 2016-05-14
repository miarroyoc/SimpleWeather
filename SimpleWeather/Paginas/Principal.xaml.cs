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
using SimpleWeather.Clases;


// La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=234238

namespace SimpleWeather.Paginas
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class Principal : Page
    {

        Metodos Metodos = new Metodos();

        //Constructor de clase principal, contiene el frame donde se muestran los datos.
        public Principal()
        {
            this.InitializeComponent();

            //Comprueba la conexión a internet.
            if (Metodos.Conexion(comboBoxCiudades.SelectedIndex))
            {
                //Activa el combo de elección de ciudad si esta desactivado.
                comboBoxCiudades.IsEnabled = true;

                //Carga el frame que muestra los datos, pasando por parametro la ciudad seleccionada en el combo.
                string ciudad = Metodos.Ciudad(comboBoxCiudades.SelectedIndex);
                FrameDatos.Navigate(typeof(ContentPage), ciudad);
            }
            else
            {
                //Desactiva el combo de elección de ciudad puesto que no hay conexión y no permite elegir localizacion.
                comboBoxCiudades.IsEnabled = false;

                //Carga el frame que muestra el error de conexión.
                FrameDatos.Navigate(typeof(NoDisponible));
            }
        }

        //Evento Click del botón home, mismo funcinamiento que el constructor de Principal.
        private void Home_Click(object sender, RoutedEventArgs e)
        {
            if (Metodos.Conexion(comboBoxCiudades.SelectedIndex))
            {
                comboBoxCiudades.IsEnabled = true;

                string ciudad = Metodos.Ciudad(comboBoxCiudades.SelectedIndex);
                FrameDatos.Navigate(typeof(ContentPage), ciudad);
            }
            else
            {
                comboBoxCiudades.IsEnabled = false;

                FrameDatos.Navigate(typeof(NoDisponible));
            }
        }

        //Evento Click del botón información.
        private void Info_Click(object sender, RoutedEventArgs e)
        {
            //Desactiva el combo de elección de ciudad, en la pagina info no se permite cambiar de localización.
            comboBoxCiudades.IsEnabled = false;

            //Carga el frame de información sobre la applicación.
            FrameDatos.Navigate(typeof(InformacionApp));
        }

        //Evento SelectionChanged del combo, si cambia la ciudad seleccionada se recarga la pagina, mismo funcionamiento que el constructor.
        private void comboBoxCiudades_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxCiudades != null)
            {
                if (Metodos.Conexion(comboBoxCiudades.SelectedIndex))
                {
                    comboBoxCiudades.IsEnabled = true;

                    string ciudad = Metodos.Ciudad(comboBoxCiudades.SelectedIndex);
                    FrameDatos.Navigate(typeof(ContentPage), ciudad);
                }
                else
                {
                    comboBoxCiudades.IsEnabled = false;

                    FrameDatos.Navigate(typeof(NoDisponible));
                }
            }
        }
    }
}
