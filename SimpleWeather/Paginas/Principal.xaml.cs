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
using Windows.UI;

namespace SimpleWeather.Paginas
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class Principal : Page
    {
        Metodos Metodos = new Metodos();

        String hoy = null;
        //Constructor de clase principal, contiene el frame donde se muestran los datos.
        public Principal()
        {
            this.InitializeComponent();

            //Fecha y hora actual,
            DateTime now = DateTime.Now;

            //usado para comprobar la feha de elaboración
            hoy = now.ToString("yyyy-MM-dd");

            #region Cambio a modo nocturno

            if ((Convert.ToInt32(now.ToString("HH")) <= 7) || (Convert.ToInt32(now.ToString("HH")) >= 22))
            {
                gridPrincipal.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x1E, 0x09, 0x31));
            }
            else
            {
                gridPrincipal.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x18, 0x20, 0x20));
            }

            #endregion

            //Comprueba la conexión a internet.
            if (Metodos.Conexion(comboBoxCiudades.SelectedIndex))
            {
                //Activa el combo de elección de ciudad si esta desactivado.
                comboBoxCiudades.IsEnabled = true;
                //Carga el frame que muestra los datos, pasando por parametro la ciudad seleccionada en el combo.
                string ciudad = Metodos.Ciudad(comboBoxCiudades.SelectedIndex);

                if ((Metodos.FechaElaboracion(comboBoxCiudades.SelectedIndex)).Equals(hoy))
                {
                    FrameDatos.Navigate(typeof(ContentPage), ciudad);
                }
                else
                {
                    FrameDatos.Navigate(typeof(ContentPageAtemporal), ciudad);
                }
               
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
                if ((Metodos.FechaElaboracion(comboBoxCiudades.SelectedIndex)).Equals(hoy))
                {
                    FrameDatos.Navigate(typeof(ContentPage), ciudad);
                }
                else
                {
                    FrameDatos.Navigate(typeof(ContentPageAtemporal), ciudad);
                }
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
                    if ((Metodos.FechaElaboracion(comboBoxCiudades.SelectedIndex)).Equals(hoy))
                    {
                        FrameDatos.Navigate(typeof(ContentPage), ciudad);
                    }
                    else
                    {
                        FrameDatos.Navigate(typeof(ContentPageAtemporal), ciudad);
                    }
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
