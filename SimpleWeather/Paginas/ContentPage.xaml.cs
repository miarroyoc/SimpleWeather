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

        string urlCiudad = null;
        //Fotos fotos = new Fotos;
        bool conexionCorrecta = true;

        LecturaXml Datos = new LecturaXml();

        DatosTiempo DatosHoy = null;

        public ContentPage()
        {
            this.InitializeComponent();

            //fotos.Imagen = new Uri("ms-appx:///Assets/ui_preview.gif");
            //this.DataContent = fotos;

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
            //aqui tambien se pueden poner para hacer el binding.

            String URLString = urlCiudad;
            XmlReader reader = null;
            
            try
            {
                reader = XmlReader.Create(URLString);
                conexionCorrecta = true;
            }
            catch (System.Net.WebException exc)
            {
                //"No se ha podido mostrar el contenido, problemas con la conexion a internet.";
                conexionCorrecta = false;
            }

            if (conexionCorrecta)
            {
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

                DatosHoy = Datos.getDatosActuales(reader);

                textTemperatura.Text = DatosHoy.TemperaturaActual;
                textTemperaturaMaxima.Text = DatosHoy.TemperaturaMaxima;
                textTemperaturaMinima.Text = DatosHoy.TemperaturaMinima;
                textEstadoCielo.Text = DatosHoy.EstadoCielo;
                textPrecipitaciones.Text = DatosHoy.ProbabilidadPrecipitaciones;
            }
        }
    }
}
