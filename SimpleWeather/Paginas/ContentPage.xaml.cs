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
        //Fecha y hora actual
        DateTime now = DateTime.Now;
        //Fotos fotos = new Fotos;
        bool conexionCorrecta = true;

        #region Datos tiempo Hoy
        string probabilidadPrecipitaciones;
        string estadoCielo;
        string codigoEstadoCielo;
        string temperaturaActual;
        string temperaturaMaxima;
        string temperaturaMinima;
        #endregion

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
            //String cad = "";

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

                getDatosActuales(reader);

                textTemperatura.Text = temperaturaActual;
                textTemperaturaMaxima.Text = temperaturaMaxima;
                textTemperaturaMinima.Text = temperaturaMinima;

                textEstadoCielo.Text = estadoCielo;
                textPrecipitaciones.Text = probabilidadPrecipitaciones;
            }
        }

        public void getDatosActuales(XmlReader reader)
        {

            String dia = now.ToString("yyyy-MM-dd");
            String fh6 = getFranjaHoraria6(now), fh12 = getFranjaHoraria12(now), h6 = getHora(now);
            
            using (reader)
            {
                while (reader.Read())
                {
                    if (reader.Name.Equals("dia")) //lee hasta que es un nodo "dia"
                    {
                        reader.MoveToNextAttribute(); //saca el unico atributo que contiene el nodo dia
                        if (reader.Value.Equals(dia)) //comprueba si es igual al dia actual, sino, se lo salta entero
                        {
                            while (reader.Read())
                            {
                                if (!reader.Name.Equals("dia")) //si encuentra otro nodo dia, no entra y se lo salta entero, 
                                                                //puesto que si llega aqui es por que se ha analizado el nodo dia del dia actual
                                {
                                    if (reader.Name.Equals("prob_precipitacion")) //si es precipitaciones entra y sala los datos
                                    {
                                        reader.MoveToNextAttribute();
                                        if (reader.Value.Equals(fh6))
                                        {
                                            reader.Read();
                                            String aux = reader.Value;

                                            if (aux.Equals(""))
                                            {
                                                probabilidadPrecipitaciones = "0%";
                                            }
                                            else
                                            {
                                                probabilidadPrecipitaciones = aux + "%";
                                            }
                                        }
                                    }

                                    if (reader.Name.Equals("estado_cielo")) //si es estado_cielo entra y saca los datos
                                    {
                                        reader.MoveToNextAttribute();
                                        if (reader.Value.Equals(fh6))
                                        {
                                            reader.MoveToNextAttribute();
                                            if (reader.Name.Equals("descripcion"))
                                            {
                                                String aux = reader.Value;
                                                if (aux.Equals(""))
                                                {
                                                    estadoCielo = "Sin datos";
                                                }
                                                else
                                                {
                                                    reader.Read();
                                                    estadoCielo = aux;
                                                    codigoEstadoCielo = reader.Value;
                                                }
                                            }
                                        }
                                    }

                                    if (reader.Name.Equals("temperatura")) //si es temperatura entra y saca los datos de temperatura maxima, tempretura minima y tempratura actual
                                    {

                                        do
                                        {
                                            reader.Read();
                                            switch (reader.Name)
                                            {
                                                case "maxima":
                                                    if (reader.IsStartElement())
                                                    {
                                                        reader.Read();
                                                        temperaturaMaxima = reader.Value + "º";
                                                    }
                                                    break;
                                                case "minima":
                                                    if (reader.IsStartElement())
                                                    {
                                                        reader.Read();
                                                        temperaturaMinima = reader.Value + "º";
                                                    }
                                                    break;
                                                case "dato":
                                                    reader.MoveToNextAttribute();
                                                    if (reader.Value.Equals(h6))
                                                    {
                                                        reader.Read();
                                                        temperaturaActual = reader.Value + "º";
                                                    }
                                                    break;
                                                default:

                                                    break;
                                            }
                                        } while (!reader.Name.Equals("sens_termica"));
                                    }

                                }
                                else
                                {
                                    reader.Skip(); //si encuentra otro nodo dia, despues de analizar el nodo dia actual, se lo salta entero
                                }
                            }
                        }
                        else
                        {
                            reader.Skip(); //si no es el dia actual se lo salta
                        }
                    }
                }
            }

            #region leer xml entero
            /*
            //leyendo...
            while (reader.Read())
            {
                //definiendo el indentado
                string indentado = new string('\t', reader.Depth);

                //evaluando el tipo de nodo
                switch (reader.NodeType)
                {
                    //tipo de nodo declaración del documento xml.
                    case XmlNodeType.XmlDeclaration:
                        //imprimi valor
                        cad += "<?"+ reader.Value+ "?>"+"\n";
                        break;

                    //tipo de nodo elemento
                    case XmlNodeType.Element:
                        {
                            //si existen atributos.
                            if (reader.HasAttributes)
                            {
                                //cadena que guardará temporalmente los atributos leidos
                                string atributos = null;

                                //leyendo cada uno de los atributos
                                for (int i = 0; i < reader.AttributeCount; i++)
                                {
                                    //usamos el indice para movernos por cada atributo.
                                    reader.MoveToAttribute(i);
                                    //imprimimos, tanto el nombre del atributo, como el valor de este.
                                    atributos += " " + reader.Name + "='" + reader.Value + "'";
                                }

                                //regresamos el puntero al inicio del nodo 
                                //donde se estaba leyendo los atributos.
                                reader.MoveToElement();

                                //evaluamos la profundidad del nodo.
                                if (reader.Depth != 2)
                                {
                                    //si es que el nodo tiene un prefijo
                                    if (reader.Prefix != string.Empty)
                                        //imprimimos.
                                        cad += indentado + "<" + reader.Prefix + ":" + reader.LocalName + atributos + "/>" + "\n";
                                    else
                                        //imprimos pero sin prefijo
                                        cad += indentado + "<" + reader.LocalName + atributos + "/>" + "\n";
                                }
                                //si la profundidad es igual a 2
                                else
                                {
                                    cad += indentado + "<" + reader.LocalName + atributos + "/>" + "\n";
                                }
                            }

                            //si es que no tiene atributos.
                            else
                            {
                                //de nuevo con este rollo de la profundidad.
                                if (reader.Depth != 2)
                                {
                                    //esto es igual a lo de arriba que ya te expliqué.
                                    if (reader.Prefix != string.Empty)
                                        //imprimimos
                                        cad += indentado + "<" + reader.Prefix + ":" + reader.LocalName + ">";

                                    else
                                        //y dale! con la misma pasta, je, je, je...
                                        cad += indentado + "<" + reader.Name + ">";
                                }
                                //en caso de que la profundidad del nodo sea igual a 2.
                                else
                                {
                                    cad += indentado + "<" + reader.Name + ">";
                                }
                            }
                        } break;

                    //ya sabéis para que sirve esto...
                    case XmlNodeType.Comment:
                        cad += indentado + "<!--" + reader.Value + "-->" + "\n";
                        break;

                    //y esto también ya sabéis.
                    case XmlNodeType.Text:
                        cad += reader.Value;
                        break;

                    //y esto más aún... esto en verdad, ya me aburre..
                    case XmlNodeType.EndElement:

                        if (reader.Depth != 2)
                        {
                            if (reader.Prefix != String.Empty)
                                cad += indentado + "</" + reader.Prefix + ":" + reader.LocalName + ">" + "\n";
                            else
                                cad += indentado + "</" + reader.Name + ">" + "\n";
                        }
                        else
                        {
                            cad += reader.Prefix + "</" + reader.Name + ">" + "\n";
                        }
                        break;
                }
            }

            texto.Text = cad;
            */


            /*String cad = "";

            using (reader)
            {
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        if (reader.IsEmptyElement)
                            cad += "<"+ reader.Name+ "/>";
                        else
                        {
                            cad += "<"+ reader.Name+">";
                            reader.Read(); // Read the start tag.
                            if (reader.IsStartElement())  // Handle nested elements.
                                cad += "\r\n" + reader.Name;
                            cad += reader.Value;  //Read the text content of the element.
                        }
                    }
                } 
            }

             */
            #endregion

        }
        #region metodo para obtener la franja horaria 24/4
        public String getFranjaHoraria6(DateTime DT)
        {
            String aux = DT.ToString("HH");
            String franja = "";
            switch (aux)
            {
                case "00":
                    franja = "00-06";
                    break;
                case "01":
                    franja = "00-06";
                    break;
                case "02":
                    franja = "00-06";
                    break;
                case "03":
                    franja = "00-06";
                    break;
                case "04":
                    franja = "00-06";
                    break;
                case "05":
                    franja = "00-06";
                    break;
                case "06":
                    franja = "06-12";
                    break;
                case "07":
                    franja = "06-12";
                    break;
                case "08":
                    franja = "06-12";
                    break;
                case "09":
                    franja = "06-12";
                    break;
                case "10":
                    franja = "06-12";
                    break;
                case "11":
                    franja = "06-12";
                    break;
                case "12":
                    franja = "12-18";
                    break;
                case "13":
                    franja = "12-18";
                    break;
                case "14":
                    franja = "12-18";
                    break;
                case "15":
                    franja = "12-18";
                    break;
                case "16":
                    franja = "12-18";
                    break;
                case "17":
                    franja = "12-18";
                    break;
                case "18":
                    franja = "18-24";
                    break;
                case "19":
                    franja = "18-24";
                    break;
                case "20":
                    franja = "18-24";
                    break;
                case "21":
                    franja = "18-24";
                    break;
                case "22":
                    franja = "18-24";
                    break;
                case "23":
                    franja = "18-24";
                    break;
                case "24":
                    franja = "18-24";
                    break;
            }

            return franja;
        }
        #endregion
        #region metodo para obtener la franja horaria 24/2
        public String getFranjaHoraria12(DateTime DT)
        {
            String aux = DT.ToString("HH");
            String franja = "";
            switch (aux)
            {
                case "00":
                    franja = "00-12";
                    break;
                case "01":
                    franja = "00-12";
                    break;
                case "02":
                    franja = "00-12";
                    break;
                case "03":
                    franja = "00-12";
                    break;
                case "04":
                    franja = "00-12";
                    break;
                case "05":
                    franja = "00-12";
                    break;
                case "06":
                    franja = "00-12";
                    break;
                case "07":
                    franja = "00-12";
                    break;
                case "08":
                    franja = "00-12";
                    break;
                case "09":
                    franja = "00-12";
                    break;
                case "10":
                    franja = "00-12";
                    break;
                case "11":
                    franja = "00-12";
                    break;
                case "12":
                    franja = "12-24";
                    break;
                case "13":
                    franja = "12-24";
                    break;
                case "14":
                    franja = "12-24";
                    break;
                case "15":
                    franja = "12-24";
                    break;
                case "16":
                    franja = "12-24";
                    break;
                case "17":
                    franja = "12-24";
                    break;
                case "18":
                    franja = "12-24";
                    break;
                case "19":
                    franja = "12-24";
                    break;
                case "20":
                    franja = "12-24";
                    break;
                case "21":
                    franja = "12-24";
                    break;
                case "22":
                    franja = "12-24";
                    break;
                case "23":
                    franja = "12-24";
                    break;
                case "24":
                    franja = "12-24";
                    break;
            }

            return franja;
        }
        #endregion
        #region metodo para obtener la hora "HH" 24/4
        public String getHora(DateTime DT)
        {
            String aux = DT.ToString("HH");
            String hora = "";
            switch (aux)
            {
                case "00":
                    hora = "06";
                    break;
                case "01":
                    hora = "06";
                    break;
                case "02":
                    hora = "06";
                    break;
                case "03":
                    hora = "06";
                    break;
                case "04":
                    hora = "06";
                    break;
                case "05":
                    hora = "06";
                    break;
                case "06":
                    hora = "12";
                    break;
                case "07":
                    hora = "12";
                    break;
                case "08":
                    hora = "12";
                    break;
                case "09":
                    hora = "12";
                    break;
                case "10":
                    hora = "12";
                    break;
                case "11":
                    hora = "12";
                    break;
                case "12":
                    hora = "18";
                    break;
                case "13":
                    hora = "18";
                    break;
                case "14":
                    hora = "18";
                    break;
                case "15":
                    hora = "18";
                    break;
                case "16":
                    hora = "18";
                    break;
                case "17":
                    hora = "18";
                    break;
                case "18":
                    hora = "24";
                    break;
                case "19":
                    hora = "24";
                    break;
                case "20":
                    hora = "24";
                    break;
                case "21":
                    hora = "24";
                    break;
                case "22":
                    hora = "24";
                    break;
                case "23":
                    hora = "24";
                    break;
                case "24":
                    hora = "24";
                    break;
            }

            return hora;
        }
        #endregion
    }
}
