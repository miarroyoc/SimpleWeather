using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SimpleWeather.Clases
{
    class LecturaXml
    {
        /* Método para la lectura de un documento Xml
         * Parametros: 
         *      reader, representa el objeto XmlReader que contiene los datos del Xml.
         *      día, representa el día que queremos buscar en el documento Xml.
         *      franjaHoraria, representa la franja horaria de la que queremos obtener los datos dentro del día especificado.
         *      hora, representa la franja horaria en el caso de la temperatura se divide en horas.
         * Devuelve un objeto de tipo DatosTiempo.
         */
        public DatosTiempo getDatosMeteorologicos(XmlReader reader, String dia, String franjaHoraria, String hora)
        {
            DatosTiempo Datos = new DatosTiempo();

            using (reader)
            {
                // Lee el Xml linea a linea mientras que existan datos.
                while (reader.Read())
                {
                    // Si el nodo en el que se encuentra es de tipo "dia".
                    if (reader.Name.Equals("dia"))
                    {
                        // Saca el único atributo que contiene el nodo "dia", que es la fecha.
                        // Comprueba si es igual al día especificado, sino, salta al siguiente nodo.
                        reader.MoveToNextAttribute(); 
                        if (reader.Value.Equals(dia))
                        {
                            // Si es un nodo "dia" y coincide con el día especificado sigue leyendo.
                            while (reader.Read())
                            {
                                // Si encuentra otro nodo "dia", no entra y se lo salta entero.
                                // Puesto que si se cumple es porque se ha analizado por completo el nodo "dia" del día especificado.
                                if (!reader.Name.Equals("dia"))
                                {
                                    // Si el nodo es de tipo "prob_precipitacion" entra lo analiza y guarda los valores de probabilidad de precipitaciones en el objeto Datos.
                                    if (reader.Name.Equals("prob_precipitacion"))
                                    {
                                        if (reader.MoveToNextAttribute())
                                        {
                                            if (reader.Value.Equals(franjaHoraria))
                                            {
                                                reader.Read();
                                                String aux = reader.Value;

                                                if (aux.Equals(""))
                                                {
                                                    Datos.ProbabilidadPrecipitaciones = "0%";
                                                }
                                                else
                                                {
                                                    Datos.ProbabilidadPrecipitaciones = aux + "%";
                                                }
                                            }
                                        }
                                        else
                                        {
                                            reader.Read();
                                            String aux = reader.Value;
                                            if (!aux.Equals("\n\t\t\t"))
                                            {
                                                if (aux.Equals(""))
                                                {
                                                    Datos.ProbabilidadPrecipitaciones = "0%";
                                                }
                                                else
                                                {
                                                    Datos.ProbabilidadPrecipitaciones = aux + "%";
                                                }
                                            }
                                        }
                                    }

                                    // Si el nodo es de tipo "estado_cielo" entra lo analiza y guarda los valores del estado del cielo en el objeto Datos.
                                    if (reader.Name.Equals("estado_cielo"))
                                    {
                                        reader.MoveToNextAttribute();
                                        if (reader.Name.Equals("periodo"))
                                        {
                                            if (reader.Value.Equals(franjaHoraria))
                                            {
                                                reader.MoveToNextAttribute();
                                                if (reader.Name.Equals("descripcion"))
                                                {
                                                    String aux = reader.Value;
                                                    if (aux.Equals(""))
                                                    {
                                                        Datos.EstadoCielo = "Sin datos";
                                                    }
                                                    else
                                                    {
                                                        Datos.EstadoCielo = aux;
                                                        reader.Read();
                                                        Datos.CodigoEstadoCielo = reader.Value;
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (reader.Name.Equals("descripcion"))
                                            {
                                                String aux = reader.Value;
                                                if (aux.Equals(""))
                                                {
                                                    Datos.EstadoCielo = "Sin datos";
                                                }
                                                else
                                                {
                                                    Datos.EstadoCielo = aux;
                                                    reader.Read();
                                                    Datos.CodigoEstadoCielo = reader.Value;
                                                }
                                            }
                                        }
                                    }

                                    // Si el nodo es de tipo "temperatura" entra lo analiza y guarda los valores de temperatura en el objeto Datos.
                                    // Tanto temperatura máxima, temperatura mínima como la temperatura de la hora especificada si se da el caso.
                                    if (reader.Name.Equals("temperatura"))
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
                                                        Datos.TemperaturaMaxima = reader.Value + "º";
                                                    }
                                                    break;
                                                case "minima":
                                                    if (reader.IsStartElement())
                                                    {
                                                        reader.Read();
                                                        Datos.TemperaturaMinima = reader.Value + "º";
                                                    }
                                                    break;
                                                case "dato":
                                                    reader.MoveToNextAttribute();
                                                    if (reader.Value.Equals(hora))
                                                    {
                                                        reader.Read();
                                                        Datos.TemperaturaActual = reader.Value + "º";
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
                                    // Si encuentra otro nodo "dia", despues de analizar el nodo "dia" especificado, se lo salta entero.
                                    reader.Skip(); 
                                }
                            }
                        }
                        else
                        {
                            // Si no es el nodo del día especificado se lo salta.
                            reader.Skip();
                        }
                    }
                }
            }

            // Devuelve el objeto que contiene todos los datos meteorológicos.
            return Datos;
        }
    }
}
