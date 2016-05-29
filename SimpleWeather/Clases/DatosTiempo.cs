using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWeather.Clases
{
    // Objeto contenedor de datos meteorológicos.
    class DatosTiempo
    {
        #region Datos tiempo
        private string probabilidadPrecipitaciones;
        private string estadoCielo;
        private string codigoEstadoCielo;
        private string temperaturaActual;
        private string temperaturaMaxima;
        private string temperaturaMinima;
        #endregion

        public string ProbabilidadPrecipitaciones
        {
            get
            {
                return probabilidadPrecipitaciones;
            }

            set
            {
                probabilidadPrecipitaciones = value;
            }
        }

        public string EstadoCielo
        {
            get
            {
                return estadoCielo;
            }

            set
            {
                estadoCielo = value;
            }
        }

        public string CodigoEstadoCielo
        {
            get
            {
                return codigoEstadoCielo;
            }

            set
            {
                codigoEstadoCielo = value;
            }
        }

        public string TemperaturaActual
        {
            get
            {
                return temperaturaActual;
            }

            set
            {
                temperaturaActual = value;
            }
        }

        public string TemperaturaMaxima
        {
            get
            {
                return temperaturaMaxima;
            }

            set
            {
                temperaturaMaxima = value;
            }
        }

        public string TemperaturaMinima
        {
            get
            {
                return temperaturaMinima;
            }

            set
            {
                temperaturaMinima = value;
            }
        }
    }
}
