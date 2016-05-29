using SimpleWeather.Clases;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

namespace SimpleWeather.Paginas
{
    public sealed partial class ContentPage : Page
    {
        // Fecha y hora actual.
        DateTime now = DateTime.Now;
        // Instancia de la clase para poder utilizar sus métodos.
        Metodos Metodos = new Metodos();
        // urlCiudad enviado desde el frame principal.
        string urlCiudad = null;

        public ContentPage()
        {
            this.InitializeComponent();

            #region Cambio a modo nocturno
            
            // Si la hora es más de las 10p.m. o menos de las 7a.m. la interfaz gráfica cambia a modo nocturno,
            // Con el fondo de noche y los colores del texto claros, además en el modo nocturno los iconos, son con luna y no con sol.
            if ((Convert.ToInt32(now.ToString("HH")) <= 7) || (Convert.ToInt32(now.ToString("HH")) >= 22))
            {
                FondoDeApp.ImageSource = new BitmapImage(new System.Uri("ms-appx:///Assets/noche.png"));
                textTemperatura.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0xDA, 0xED, 0xFE));
                textFlechaMaxima.Foreground = new SolidColorBrush(Color.FromArgb(0xAA, 0xDA, 0xED, 0xFE));
                textTemperaturaMaxima.Foreground = new SolidColorBrush(Color.FromArgb(0xAA, 0xDA, 0xED, 0xFE));
                textFlechaMinima.Foreground = new SolidColorBrush(Color.FromArgb(0x55, 0xDA, 0xED, 0xFE));
                textTemperaturaMinima.Foreground = new SolidColorBrush(Color.FromArgb(0x55, 0xDA, 0xED, 0xFE));
                textEstadoCielo.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0xDA, 0xED, 0xFE));
                textFijoPrecipitaciones.Foreground = new SolidColorBrush(Color.FromArgb(0xAA, 0xDA, 0xED, 0xFE));
                textPrecipitaciones.Foreground = new SolidColorBrush(Color.FromArgb(0xAA, 0xDA, 0xED, 0xFE));
                bordePrincipal.BorderBrush = new SolidColorBrush(Color.FromArgb(0xAA, 0xDA, 0xED, 0xFE));
                bordeDia2.BorderBrush = new SolidColorBrush(Color.FromArgb(0xAA, 0xDA, 0xED, 0xFE));
                textFecha2.Foreground = new SolidColorBrush(Color.FromArgb(0xAA, 0xDA, 0xED, 0xFE));
                textPrecipitacionesDia2.Foreground = new SolidColorBrush(Color.FromArgb(0xAA, 0xDA, 0xED, 0xFE));
                textTemperaturaMaximaDia2.Foreground = new SolidColorBrush(Color.FromArgb(0xAA, 0xDA, 0xED, 0xFE));
                textTemperaturaMinimaDia2.Foreground = new SolidColorBrush(Color.FromArgb(0x55, 0xDA, 0xED, 0xFE));
                bordeDia3.BorderBrush = new SolidColorBrush(Color.FromArgb(0xAA, 0xDA, 0xED, 0xFE));
                textFecha3.Foreground = new SolidColorBrush(Color.FromArgb(0xAA, 0xDA, 0xED, 0xFE));
                textPrecipitacionesDia3.Foreground = new SolidColorBrush(Color.FromArgb(0xAA, 0xDA, 0xED, 0xFE));
                textTemperaturaMaximaDia3.Foreground = new SolidColorBrush(Color.FromArgb(0xAA, 0xDA, 0xED, 0xFE));
                textTemperaturaMinimaDia3.Foreground = new SolidColorBrush(Color.FromArgb(0x55, 0xDA, 0xED, 0xFE));
                bordeDia4.BorderBrush = new SolidColorBrush(Color.FromArgb(0xAA, 0xDA, 0xED, 0xFE));
                textFecha4.Foreground = new SolidColorBrush(Color.FromArgb(0xAA, 0xDA, 0xED, 0xFE));
                textPrecipitacionesDia4.Foreground = new SolidColorBrush(Color.FromArgb(0xAA, 0xDA, 0xED, 0xFE));
                textTemperaturaMaximaDia4.Foreground = new SolidColorBrush(Color.FromArgb(0xAA, 0xDA, 0xED, 0xFE));
                textTemperaturaMinimaDia4.Foreground = new SolidColorBrush(Color.FromArgb(0x55, 0xDA, 0xED, 0xFE));
                bordeDia5.BorderBrush = new SolidColorBrush(Color.FromArgb(0xAA, 0xDA, 0xED, 0xFE));
                textFecha5.Foreground = new SolidColorBrush(Color.FromArgb(0xAA, 0xDA, 0xED, 0xFE));
                textPrecipitacionesDia5.Foreground = new SolidColorBrush(Color.FromArgb(0xAA, 0xDA, 0xED, 0xFE));
                textTemperaturaMaximaDia5.Foreground = new SolidColorBrush(Color.FromArgb(0xAA, 0xDA, 0xED, 0xFE));
                textTemperaturaMinimaDia5.Foreground = new SolidColorBrush(Color.FromArgb(0x55, 0xDA, 0xED, 0xFE));
                bordeDia6.BorderBrush = new SolidColorBrush(Color.FromArgb(0xAA, 0xDA, 0xED, 0xFE));
                textFecha6.Foreground = new SolidColorBrush(Color.FromArgb(0xAA, 0xDA, 0xED, 0xFE));
                textPrecipitacionesDia6.Foreground = new SolidColorBrush(Color.FromArgb(0xAA, 0xDA, 0xED, 0xFE));
                textTemperaturaMaximaDia6.Foreground = new SolidColorBrush(Color.FromArgb(0xAA, 0xDA, 0xED, 0xFE));
                textTemperaturaMinimaDia6.Foreground = new SolidColorBrush(Color.FromArgb(0x55, 0xDA, 0xED, 0xFE));
                bordeDia7.BorderBrush = new SolidColorBrush(Color.FromArgb(0xAA, 0xDA, 0xED, 0xFE));
                textFecha7.Foreground = new SolidColorBrush(Color.FromArgb(0xAA, 0xDA, 0xED, 0xFE));
                textPrecipitacionesDia7.Foreground = new SolidColorBrush(Color.FromArgb(0xAA, 0xDA, 0xED, 0xFE));
                textTemperaturaMaximaDia7.Foreground = new SolidColorBrush(Color.FromArgb(0xAA, 0xDA, 0xED, 0xFE));
                textTemperaturaMinimaDia7.Foreground = new SolidColorBrush(Color.FromArgb(0x55, 0xDA, 0xED, 0xFE));
            }
            else
            {
                FondoDeApp.ImageSource = new BitmapImage(new System.Uri("ms-appx:///Assets/dia.png"));
                textTemperatura.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x1E, 0x32, 0x3C));
                textFlechaMaxima.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x1E, 0x32, 0x3C));
                textTemperaturaMaxima.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x1E, 0x32, 0x3C));
                textFlechaMinima.Foreground = new SolidColorBrush(Color.FromArgb(0xBF, 0x3A, 0x5A, 0x6A));
                textTemperaturaMinima.Foreground = new SolidColorBrush(Color.FromArgb(0xBF, 0x3A, 0x5A, 0x6A));
                textEstadoCielo.Foreground = new SolidColorBrush(Color.FromArgb(0xFA, 0x1E, 0x32, 0x3C));
                textFijoPrecipitaciones.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x1E, 0x32, 0x3C));
                textPrecipitaciones.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x1E, 0x32, 0x3C));
                bordePrincipal.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0x1E, 0x32, 0x3C));
                bordeDia2.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0x1E, 0x32, 0x3C));
                textFecha2.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x1E, 0x32, 0x3C));
                textPrecipitacionesDia2.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x1E, 0x32, 0x3C));
                textTemperaturaMaximaDia2.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x1E, 0x32, 0x3C));
                textTemperaturaMinimaDia2.Foreground = new SolidColorBrush(Color.FromArgb(0xBF, 0x3A, 0x5A, 0x6A));
                bordeDia3.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0x1E, 0x32, 0x3C));
                textFecha3.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x1E, 0x32, 0x3C));
                textPrecipitacionesDia3.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x1E, 0x32, 0x3C));
                textTemperaturaMaximaDia3.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x1E, 0x32, 0x3C));
                textTemperaturaMinimaDia3.Foreground = new SolidColorBrush(Color.FromArgb(0xBF, 0x3A, 0x5A, 0x6A));
                bordeDia4.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0x1E, 0x32, 0x3C));
                textFecha4.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x1E, 0x32, 0x3C));
                textPrecipitacionesDia4.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x1E, 0x32, 0x3C));
                textTemperaturaMaximaDia4.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x1E, 0x32, 0x3C));
                textTemperaturaMinimaDia4.Foreground = new SolidColorBrush(Color.FromArgb(0xBF, 0x3A, 0x5A, 0x6A));
                bordeDia5.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0x1E, 0x32, 0x3C));
                textFecha5.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x1E, 0x32, 0x3C));
                textPrecipitacionesDia5.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x1E, 0x32, 0x3C));
                textTemperaturaMaximaDia5.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x1E, 0x32, 0x3C));
                textTemperaturaMinimaDia5.Foreground = new SolidColorBrush(Color.FromArgb(0xBF, 0x3A, 0x5A, 0x6A));
                bordeDia6.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0x1E, 0x32, 0x3C));
                textFecha6.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x1E, 0x32, 0x3C));
                textPrecipitacionesDia6.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x1E, 0x32, 0x3C));
                textTemperaturaMaximaDia6.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x1E, 0x32, 0x3C));
                textTemperaturaMinimaDia6.Foreground = new SolidColorBrush(Color.FromArgb(0xBF, 0x3A, 0x5A, 0x6A));
                bordeDia7.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0x1E, 0x32, 0x3C));
                textFecha7.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x1E, 0x32, 0x3C));
                textPrecipitacionesDia7.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x1E, 0x32, 0x3C));
                textTemperaturaMaximaDia7.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x1E, 0x32, 0x3C));
                textTemperaturaMinimaDia7.Foreground = new SolidColorBrush(Color.FromArgb(0xBF, 0x3A, 0x5A, 0x6A));
            }
            #endregion
        }

        // Obtiene los parametros enviados desde la llamada (la ciudad seleccionada).
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
                string ciudad = e.Parameter as string;
                urlCiudad = ciudad;
                obtener();
        }

        // Método para la obtención de datos y uso de estos en la interfaz para mostrar los datos.
        private void obtener()
        {
            LecturaXml Datos = new LecturaXml();
            String URLString = urlCiudad;
            XmlReader reader = null;

            #region Primer Dia
            try
            {
                reader = XmlReader.Create(URLString);

                #region Primer Dia
                //Lectura de datos.
                DatosTiempo DatosHoy = null;

                String franjaHoraria = Metodos.getFranjaHoraria(now);
                String hora = Metodos.getHora(now);

                String dia1 = now.ToString("yyyy-MM-dd");

                DatosHoy = Datos.getDatosMeteorologicos(reader, dia1, franjaHoraria, hora);

                textTemperatura.Text = DatosHoy.TemperaturaActual;
                textTemperaturaMaxima.Text = DatosHoy.TemperaturaMaxima;
                textTemperaturaMinima.Text = DatosHoy.TemperaturaMinima;
                textEstadoCielo.Text = DatosHoy.EstadoCielo;
                textPrecipitaciones.Text = DatosHoy.ProbabilidadPrecipitaciones;
                #endregion
                #region Imagen
                // Cambio de imagen según el modo día o nocturno.

                string codigoEstadoCielo = DatosHoy.CodigoEstadoCielo;

                codigoEstadoCielo = codigoEstadoCielo.Substring(0, 2);

                if ((Convert.ToInt32(now.ToString("HH")) <= 7) || (Convert.ToInt32(now.ToString("HH")) >= 22))
                {
                    imagenEstadoCielo.Source = new BitmapImage(new System.Uri("ms-appx:///Assets/" + (codigoEstadoCielo) + "n" + ".png"));
                }
                else
                {
                    imagenEstadoCielo.Source = new BitmapImage(new System.Uri("ms-appx:///Assets/" + (codigoEstadoCielo) + ".png"));
                }

                #endregion
            }
            catch (System.Net.WebException exc)
            {
                //"No se ha podido mostrar el contenido, problemas con la conexion a internet. esto es controlado anteriormente.";
                Debug.WriteLine("Error for {0} has name {1}", GetHashCode(), exc);
            }
            #endregion
            #region Segundo Dia
            try
            {
                reader = XmlReader.Create(URLString);

                #region Segundo dia
                //Lectura de datos.
                DatosTiempo DatosDia2 = null;

                String dia2 = (now.AddDays(1)).ToString("yyyy-MM-dd");

                DatosDia2 = Datos.getDatosMeteorologicos(reader, dia2, "00-24", "24");

                textFecha2.Text = (now.AddDays(1)).ToString("dddd, dd");

                textPrecipitacionesDia2.Text = "☂" + DatosDia2.ProbabilidadPrecipitaciones;
                textTemperaturaMaximaDia2.Text = DatosDia2.TemperaturaMaxima;
                textTemperaturaMinimaDia2.Text = DatosDia2.TemperaturaMinima;

                #endregion
                #region Imagen
                // Cambio de imagen según el modo día o nocturno.
                string codigoEstadoCielo = DatosDia2.CodigoEstadoCielo;

                codigoEstadoCielo = codigoEstadoCielo.Substring(0, 2);

                if ((Convert.ToInt32(now.ToString("HH")) <= 7) || (Convert.ToInt32(now.ToString("HH")) >= 22))
                {
                    imagenEstadoCieloDia2.Source = new BitmapImage(new System.Uri("ms-appx:///Assets/" + (codigoEstadoCielo) + "n" + ".png"));
                }
                else
                {
                    imagenEstadoCieloDia2.Source = new BitmapImage(new System.Uri("ms-appx:///Assets/" + (codigoEstadoCielo) + ".png"));
                }

                #endregion
            }
            catch (System.Net.WebException exc)
            {
                //"No se ha podido mostrar el contenido, problemas con la conexion a internet. esto es controlado anteriormente.";
                Debug.WriteLine("Error for {0} has name {1}", GetHashCode(), exc);
            }
            #endregion
            #region Tercer Dia
            try
            {
                reader = XmlReader.Create(URLString);

                #region Tercer dia
                //Lectura de datos.
                DatosTiempo DatosDia3 = null;

                String dia3 = (now.AddDays(2)).ToString("yyyy-MM-dd");

                DatosDia3 = Datos.getDatosMeteorologicos(reader, dia3, "00-24", "24");

                textFecha3.Text = (now.AddDays(2)).ToString("dddd, dd");

                textPrecipitacionesDia3.Text = "☂" + DatosDia3.ProbabilidadPrecipitaciones;
                textTemperaturaMaximaDia3.Text = DatosDia3.TemperaturaMaxima;
                textTemperaturaMinimaDia3.Text = DatosDia3.TemperaturaMinima;

                #endregion
                #region Imagen
                // Cambio de imagen según el modo día o nocturno.
                string codigoEstadoCielo = DatosDia3.CodigoEstadoCielo;

                codigoEstadoCielo = codigoEstadoCielo.Substring(0, 2);

                if ((Convert.ToInt32(now.ToString("HH")) <= 7) || (Convert.ToInt32(now.ToString("HH")) >= 22))
                {
                    imagenEstadoCieloDia3.Source = new BitmapImage(new System.Uri("ms-appx:///Assets/" + (codigoEstadoCielo) + "n" + ".png"));
                }
                else
                {
                    imagenEstadoCieloDia3.Source = new BitmapImage(new System.Uri("ms-appx:///Assets/" + (codigoEstadoCielo) + ".png"));
                }

                #endregion
            }
            catch (System.Net.WebException exc)
            {
                //"No se ha podido mostrar el contenido, problemas con la conexion a internet. esto es controlado anteriormente.";
                Debug.WriteLine("Error for {0} has name {1}", GetHashCode(), exc);
            }
            #endregion
            #region Cuarto Dia
            try
            {
                reader = XmlReader.Create(URLString);

                #region Cuarto dia
                //Lectura de datos.
                DatosTiempo DatosDia4 = null;

                String dia4 = (now.AddDays(3)).ToString("yyyy-MM-dd");

                DatosDia4 = Datos.getDatosMeteorologicos(reader, dia4, "00-24", "24");

                textFecha4.Text = (now.AddDays(3)).ToString("dddd, dd");

                textPrecipitacionesDia4.Text = "☂" + DatosDia4.ProbabilidadPrecipitaciones;
                textTemperaturaMaximaDia4.Text = DatosDia4.TemperaturaMaxima;
                textTemperaturaMinimaDia4.Text = DatosDia4.TemperaturaMinima;

                #endregion
                #region Imagen
                // Cambio de imagen según el modo día o nocturno.
                string codigoEstadoCielo = DatosDia4.CodigoEstadoCielo;

                codigoEstadoCielo = codigoEstadoCielo.Substring(0, 2);

                if ((Convert.ToInt32(now.ToString("HH")) <= 7) || (Convert.ToInt32(now.ToString("HH")) >= 22))
                {
                    imagenEstadoCieloDia4.Source = new BitmapImage(new System.Uri("ms-appx:///Assets/" + (codigoEstadoCielo) + "n" + ".png"));
                }
                else
                {
                    imagenEstadoCieloDia4.Source = new BitmapImage(new System.Uri("ms-appx:///Assets/" + (codigoEstadoCielo) + ".png"));
                }

                #endregion
            }
            catch (System.Net.WebException exc)
            {
                //"No se ha podido mostrar el contenido, problemas con la conexion a internet. esto es controlado anteriormente.";
                Debug.WriteLine("Error for {0} has name {1}", GetHashCode(), exc);
            }
            #endregion
            #region Quinto Dia
            try
            {
                reader = XmlReader.Create(URLString);

                #region Quinto dia
                //Lectura de datos.
                DatosTiempo DatosDia5 = null;

                String dia5 = (now.AddDays(4)).ToString("yyyy-MM-dd");

                DatosDia5 = Datos.getDatosMeteorologicos(reader, dia5, "00-24", "24");

                textFecha5.Text = (now.AddDays(4)).ToString("dddd, dd");

                textPrecipitacionesDia5.Text = "☂" + DatosDia5.ProbabilidadPrecipitaciones;
                textTemperaturaMaximaDia5.Text = DatosDia5.TemperaturaMaxima;
                textTemperaturaMinimaDia5.Text = DatosDia5.TemperaturaMinima;

                #endregion
                #region Imagen
                // Cambio de imagen según el modo día o nocturno.
                string codigoEstadoCielo = DatosDia5.CodigoEstadoCielo;

                codigoEstadoCielo = codigoEstadoCielo.Substring(0, 2);

                if ((Convert.ToInt32(now.ToString("HH")) <= 7) || (Convert.ToInt32(now.ToString("HH")) >= 22))
                {
                    imagenEstadoCieloDia5.Source = new BitmapImage(new System.Uri("ms-appx:///Assets/" + (codigoEstadoCielo) + "n" + ".png"));
                }
                else
                {
                    imagenEstadoCieloDia5.Source = new BitmapImage(new System.Uri("ms-appx:///Assets/" + (codigoEstadoCielo) + ".png"));
                }

                #endregion
            }
            catch (System.Net.WebException exc)
            {
                //"No se ha podido mostrar el contenido, problemas con la conexion a internet. esto es controlado anteriormente.";
                Debug.WriteLine("Error for {0} has name {1}", GetHashCode(), exc);
            }
            #endregion
            #region Sexto Dia
            try
            {
                reader = XmlReader.Create(URLString);

                #region Sexto dia
                //Lectura de datos.
                DatosTiempo DatosDia6 = null;

                String dia6 = (now.AddDays(5)).ToString("yyyy-MM-dd");

                DatosDia6 = Datos.getDatosMeteorologicos(reader, dia6, "00-24", "24");

                textFecha6.Text = (now.AddDays(5)).ToString("dddd, dd");

                textPrecipitacionesDia6.Text = "☂" + DatosDia6.ProbabilidadPrecipitaciones;
                textTemperaturaMaximaDia6.Text = DatosDia6.TemperaturaMaxima;
                textTemperaturaMinimaDia6.Text = DatosDia6.TemperaturaMinima;

                #endregion
                #region Imagen
                // Cambio de imagen según el modo día o nocturno.
                string codigoEstadoCielo = DatosDia6.CodigoEstadoCielo;

                codigoEstadoCielo = codigoEstadoCielo.Substring(0, 2);

                if ((Convert.ToInt32(now.ToString("HH")) <= 7) || (Convert.ToInt32(now.ToString("HH")) >= 22))
                {
                    imagenEstadoCieloDia6.Source = new BitmapImage(new System.Uri("ms-appx:///Assets/" + (codigoEstadoCielo) + "n" + ".png"));
                }
                else
                {
                    imagenEstadoCieloDia6.Source = new BitmapImage(new System.Uri("ms-appx:///Assets/" + (codigoEstadoCielo) + ".png"));
                }

                #endregion
            }
            catch (System.Net.WebException exc)
            {
                //"No se ha podido mostrar el contenido, problemas con la conexion a internet. esto es controlado anteriormente.";
                Debug.WriteLine("Error for {0} has name {1}", GetHashCode(), exc);
            }
            #endregion
            #region Septimo Dia
            try
            {
                reader = XmlReader.Create(URLString);

                #region Septimo dia
                //Lectura de datos.
                DatosTiempo DatosDia7 = null;

                String dia7 = (now.AddDays(6)).ToString("yyyy-MM-dd");

                DatosDia7 = Datos.getDatosMeteorologicos(reader, dia7, "00-24", "24");

                textFecha7.Text = (now.AddDays(6)).ToString("dddd, dd");

                textPrecipitacionesDia7.Text = "☂" + DatosDia7.ProbabilidadPrecipitaciones;
                textTemperaturaMaximaDia7.Text = DatosDia7.TemperaturaMaxima;
                textTemperaturaMinimaDia7.Text = DatosDia7.TemperaturaMinima;

                #endregion
                #region Imagen
                // Cambio de imagen según el modo día o nocturno.
                string codigoEstadoCielo = DatosDia7.CodigoEstadoCielo;

                codigoEstadoCielo = codigoEstadoCielo.Substring(0, 2);

                if ((Convert.ToInt32(now.ToString("HH")) <= 7) || (Convert.ToInt32(now.ToString("HH")) >= 22))
                {
                    imagenEstadoCieloDia7.Source = new BitmapImage(new System.Uri("ms-appx:///Assets/" + (codigoEstadoCielo) + "n" + ".png"));
                }
                else
                {
                    imagenEstadoCieloDia7.Source = new BitmapImage(new System.Uri("ms-appx:///Assets/" + (codigoEstadoCielo) + ".png"));
                }

                #endregion
            }
            catch (System.Net.WebException exc)
            {
                //"No se ha podido mostrar el contenido, problemas con la conexion a internet. esto es controlado anteriormente.";
                Debug.WriteLine("Error for {0} has name {1}", GetHashCode(), exc);

            }
            #endregion
        }
    }
}
