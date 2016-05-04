using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWeather.Clases
{
    class Fotos
    {
        private Uri imagen;

        public Uri Imagen
        {
            get { return imagen; }
            set { imagen = value; /*NotifyPropertyChanged("Imagen");*/ }
        }

        //Falta
    }
}
