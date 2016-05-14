using SimpleWeather.Clases;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

//Autor 

// La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=234238

namespace SimpleWeather.Paginas
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class ContentPage : Page
    {
        //Fecha y hora actual
        DateTime now = DateTime.Now;

        string urlCiudad = null;
        bool conexionCorrecta = true;

        LecturaXml Datos = new LecturaXml();

        Metodos Metodos = new Metodos();

        public ContentPage()
        {
            this.InitializeComponent();



            #region equivaente ha sharedPreferences de android en c#
            /**/
            //necesary
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

            //Create setting
            localSettings.Values["caceres"] = true;
            localSettings.Values["badajoz"] = false;
            localSettings.Values["merida"] = true;

            //Read data
            Object value = localSettings.Values["caceres"];

            if (value == null)
            {
                //no data
            }
            else
            {
                //Access data in value
            }

            //delete simple setting

            localSettings.Values.Remove("merida");
            /**/
            #endregion
        }

        //Obtiene los parametros enviados desde la llamada (la ciudad seleccionada).
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (conexionCorrecta)
            {
                string ciudad = e.Parameter as string;
                urlCiudad = ciudad;
                obtener();
            }
        }



        private void obtener()
        {
            #region background
            if ((Convert.ToInt32(now.ToString("HH")) <= 7) || (Convert.ToInt32(now.ToString("HH")) >= 22))
            {
                FondoDeApp.ImageSource = new BitmapImage(new System.Uri("ms-appx:///Assets/noche.png"));
            }
            else
            {
                FondoDeApp.ImageSource = new BitmapImage(new System.Uri("ms-appx:///Assets/dia.png"));
            }
            #endregion

            String URLString = urlCiudad;
            XmlReader reader = null;

            #region Primer Dia
            try
            {
                reader = XmlReader.Create(URLString);

                #region Primer Dia
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
                string codigoEstadoCielo = DatosHoy.CodigoEstadoCielo;

                codigoEstadoCielo = codigoEstadoCielo.Substring(0, 2);

                if ((Convert.ToInt32(now.ToString("HH")) <= 7) || (Convert.ToInt32(now.ToString("HH")) >= 22))
                {
                    imagenEstadoCielo.Source = new BitmapImage(new System.Uri("ms-appx:///Assets/" + (DatosHoy.CodigoEstadoCielo) + "n" + ".png"));
                }
                else
                {
                    imagenEstadoCielo.Source = new BitmapImage(new System.Uri("ms-appx:///Assets/" + (DatosHoy.CodigoEstadoCielo) + ".png"));
                }

                #endregion
            }
            catch (System.Net.WebException exc)
            {
                //"No se ha podido mostrar el contenido, problemas con la conexion a internet.";
                conexionCorrecta = false;
            }
            #endregion
            #region Segundo Dia
            try
            {
                reader = XmlReader.Create(URLString);

                #region Segundo dia

                DatosTiempo DatosDia2 = null;

                String dia2 = (now.AddDays(1)).ToString("yyyy-MM-dd");

                DatosDia2 = Datos.getDatosMeteorologicos(reader, dia2, "00-24", "24");

                textFecha2.Text = (now.AddDays(1)).ToString("dddd, dd/MM/yyyy");

                textPrecipitacionesDia2.Text = "☂" + DatosDia2.ProbabilidadPrecipitaciones;
                textTemperaturaMaximaDia2.Text = DatosDia2.TemperaturaMaxima;
                textTemperaturaMinimaDia2.Text = DatosDia2.TemperaturaMinima;

                #endregion

                #region Imagen
                string codigoEstadoCielo = DatosDia2.CodigoEstadoCielo;

                codigoEstadoCielo = codigoEstadoCielo.Substring(0, 2);

                if ((Convert.ToInt32(now.ToString("HH")) <= 7) || (Convert.ToInt32(now.ToString("HH")) >= 22))
                {
                    imagenEstadoCieloDia2.Source = new BitmapImage(new System.Uri("ms-appx:///Assets/" + (DatosDia2.CodigoEstadoCielo) + "n" + ".png"));
                }
                else
                {
                    imagenEstadoCieloDia2.Source = new BitmapImage(new System.Uri("ms-appx:///Assets/" + (DatosDia2.CodigoEstadoCielo) + ".png"));
                }

                #endregion
            }
            catch (System.Net.WebException exc)
            {
                //"No se ha podido mostrar el contenido, problemas con la conexion a internet.";
                conexionCorrecta = false;
            }
            #endregion
            #region Tercer Dia
            try
            {
                reader = XmlReader.Create(URLString);

                #region Tercer dia

                DatosTiempo DatosDia3 = null;

                String dia3 = (now.AddDays(2)).ToString("yyyy-MM-dd");

                DatosDia3 = Datos.getDatosMeteorologicos(reader, dia3, "00-24", "24");

                textFecha3.Text = (now.AddDays(2)).ToString("dddd, dd/MM/yyyy");

                textPrecipitacionesDia3.Text = "☂" + DatosDia3.ProbabilidadPrecipitaciones;
                textTemperaturaMaximaDia3.Text = DatosDia3.TemperaturaMaxima;
                textTemperaturaMinimaDia3.Text = DatosDia3.TemperaturaMinima;

                #endregion
                #region Imagen
                string codigoEstadoCielo = DatosDia3.CodigoEstadoCielo;

                codigoEstadoCielo = codigoEstadoCielo.Substring(0, 2);

                if ((Convert.ToInt32(now.ToString("HH")) <= 7) || (Convert.ToInt32(now.ToString("HH")) >= 22))
                {
                    imagenEstadoCieloDia3.Source = new BitmapImage(new System.Uri("ms-appx:///Assets/" + (DatosDia3.CodigoEstadoCielo) + "n" + ".png"));
                }
                else
                {
                    imagenEstadoCieloDia3.Source = new BitmapImage(new System.Uri("ms-appx:///Assets/" + (DatosDia3.CodigoEstadoCielo) + ".png"));
                }

                #endregion
            }
            catch (System.Net.WebException exc)
            {
                //"No se ha podido mostrar el contenido, problemas con la conexion a internet.";
                conexionCorrecta = false;
            }
            #endregion
            #region Cuarto Dia
            try
            {
                reader = XmlReader.Create(URLString);

                #region Cuarto dia

                DatosTiempo DatosDia4 = null;

                String dia4 = (now.AddDays(3)).ToString("yyyy-MM-dd");

                DatosDia4 = Datos.getDatosMeteorologicos(reader, dia4, "00-24", "24");

                textFecha4.Text = (now.AddDays(3)).ToString("dddd, dd/MM/yyyy");

                textPrecipitacionesDia4.Text = "☂" + DatosDia4.ProbabilidadPrecipitaciones;
                textTemperaturaMaximaDia4.Text = DatosDia4.TemperaturaMaxima;
                textTemperaturaMinimaDia4.Text = DatosDia4.TemperaturaMinima;

                #endregion

                #region Imagen
                string codigoEstadoCielo = DatosDia4.CodigoEstadoCielo;

                codigoEstadoCielo = codigoEstadoCielo.Substring(0, 2);

                if ((Convert.ToInt32(now.ToString("HH")) <= 7) || (Convert.ToInt32(now.ToString("HH")) >= 22))
                {
                    imagenEstadoCieloDia4.Source = new BitmapImage(new System.Uri("ms-appx:///Assets/" + (DatosDia4.CodigoEstadoCielo) + "n" + ".png"));
                }
                else
                {
                    imagenEstadoCieloDia4.Source = new BitmapImage(new System.Uri("ms-appx:///Assets/" + (DatosDia4.CodigoEstadoCielo) + ".png"));
                }

                #endregion
            }
            catch (System.Net.WebException exc)
            {
                //"No se ha podido mostrar el contenido, problemas con la conexion a internet.";
                conexionCorrecta = false;
            }
            #endregion
            #region Quinto Dia
            try
            {
                reader = XmlReader.Create(URLString);

                #region Quinto dia

                DatosTiempo DatosDia5 = null;

                String dia5 = (now.AddDays(4)).ToString("yyyy-MM-dd");

                DatosDia5 = Datos.getDatosMeteorologicos(reader, dia5, "00-24", "24");

                textFecha5.Text = (now.AddDays(4)).ToString("dddd, dd/MM/yyyy");

                textPrecipitacionesDia5.Text = "☂" + DatosDia5.ProbabilidadPrecipitaciones;
                textTemperaturaMaximaDia5.Text = DatosDia5.TemperaturaMaxima;
                textTemperaturaMinimaDia5.Text = DatosDia5.TemperaturaMinima;

                #endregion

                #region Imagen
                string codigoEstadoCielo = DatosDia5.CodigoEstadoCielo;

                codigoEstadoCielo = codigoEstadoCielo.Substring(0, 2);

                if ((Convert.ToInt32(now.ToString("HH")) <= 7) || (Convert.ToInt32(now.ToString("HH")) >= 22))
                {
                    imagenEstadoCieloDia5.Source = new BitmapImage(new System.Uri("ms-appx:///Assets/" + (DatosDia5.CodigoEstadoCielo) + "n" + ".png"));
                }
                else
                {
                    imagenEstadoCieloDia5.Source = new BitmapImage(new System.Uri("ms-appx:///Assets/" + (DatosDia5.CodigoEstadoCielo) + ".png"));
                }

                #endregion
            }
            catch (System.Net.WebException exc)
            {
                //"No se ha podido mostrar el contenido, problemas con la conexion a internet.";
                conexionCorrecta = false;
            }
            #endregion
            #region Sexto Dia
            try
            {
                reader = XmlReader.Create(URLString);

                #region Sexto dia

                DatosTiempo DatosDia6 = null;

                String dia6 = (now.AddDays(5)).ToString("yyyy-MM-dd");

                DatosDia6 = Datos.getDatosMeteorologicos(reader, dia6, "00-24", "24");

                textFecha6.Text = (now.AddDays(5)).ToString("dddd, dd/MM/yyyy");

                textPrecipitacionesDia6.Text = "☂" + DatosDia6.ProbabilidadPrecipitaciones;
                textTemperaturaMaximaDia6.Text = DatosDia6.TemperaturaMaxima;
                textTemperaturaMinimaDia6.Text = DatosDia6.TemperaturaMinima;

                #endregion

                #region Imagen
                string codigoEstadoCielo = DatosDia6.CodigoEstadoCielo;

                codigoEstadoCielo = codigoEstadoCielo.Substring(0, 2);

                if ((Convert.ToInt32(now.ToString("HH")) <= 7) || (Convert.ToInt32(now.ToString("HH")) >= 22))
                {
                    imagenEstadoCieloDia6.Source = new BitmapImage(new System.Uri("ms-appx:///Assets/" + (DatosDia6.CodigoEstadoCielo) + "n" + ".png"));
                }
                else
                {
                    imagenEstadoCieloDia6.Source = new BitmapImage(new System.Uri("ms-appx:///Assets/" + (DatosDia6.CodigoEstadoCielo) + ".png"));
                }

                #endregion
            }
            catch (System.Net.WebException exc)
            {
                //"No se ha podido mostrar el contenido, problemas con la conexion a internet.";
                conexionCorrecta = false;
            }
            #endregion
            #region Septimo Dia
            try
            {
                reader = XmlReader.Create(URLString);

                #region Septimo dia

                DatosTiempo DatosDia7 = null;

                String dia7 = (now.AddDays(6)).ToString("yyyy-MM-dd");

                DatosDia7 = Datos.getDatosMeteorologicos(reader, dia7, "00-24", "24");

                textFecha7.Text = (now.AddDays(6)).ToString("dddd, dd/MM/yyyy");

                textPrecipitacionesDia7.Text = "☂" + DatosDia7.ProbabilidadPrecipitaciones;
                textTemperaturaMaximaDia7.Text = DatosDia7.TemperaturaMaxima;
                textTemperaturaMinimaDia7.Text = DatosDia7.TemperaturaMinima;

                #endregion

                #region Imagen
                string codigoEstadoCielo = DatosDia7.CodigoEstadoCielo;

                codigoEstadoCielo = codigoEstadoCielo.Substring(0, 2);

                if ((Convert.ToInt32(now.ToString("HH")) <= 7) || (Convert.ToInt32(now.ToString("HH")) >= 22))
                {
                    imagenEstadoCieloDia7.Source = new BitmapImage(new System.Uri("ms-appx:///Assets/" + (DatosDia7.CodigoEstadoCielo) + "n" + ".png"));
                }
                else
                {
                    imagenEstadoCieloDia7.Source = new BitmapImage(new System.Uri("ms-appx:///Assets/" + (DatosDia7.CodigoEstadoCielo) + ".png"));
                }

                #endregion
            }
            catch (System.Net.WebException exc)
            {
                //"No se ha podido mostrar el contenido, problemas con la conexion a internet.";
                conexionCorrecta = false;
            }
            #endregion

            #region utilizar la clase XmlReader y leer xml
            /*using (reader)
            {
                //reader.ReadToDescendant("dia"); para ir a un nodo exacto

                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            cad += "<" + reader.Name;
                            if (reader.HasAttributes)
                            {
                                while (reader.MoveToNextAttribute())
                                { // Read the attributes.
                                    cad += " " + reader.Name + "='" + reader.Value + "'";
                                }
                            }
                            cad += ">";
                            break;
                        case XmlNodeType.Text:
                            cad += reader.Value;
                            break;
                        case XmlNodeType.EndElement:
                            cad += "</" + reader.Name + ">" + "\n";
                            break;
                    }
                }

                texto.Text = cad;
            }*/

            #endregion

        }
    }
}
