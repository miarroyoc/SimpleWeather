using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SimpleWeather.Clases
{
    class Metodos
    {
        //Metodo utilizado por el combo para la elección de la ciudad.
        public string Ciudad(int indice)
        {
            string urlCiudad = null;

            switch (indice)
            {
                #region Ciudades
                case 0: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_38001.xml	"; break;
                case 1: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_04003.xml	"; break;
                case 2: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_30003.xml	"; break;
                case 3: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_35002.xml	"; break;
                case 4: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_02003.xml	"; break;
                case 5: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_46013.xml	"; break;
                case 6: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_41004.xml	"; break;
                case 7: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_28005.xml	"; break;
                case 8: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_23002.xml	"; break;
                case 9: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_30005.xml	"; break;
                case 10: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_13005.xml	"; break;
                case 11: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_28006.xml	"; break;
                case 12: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_28007.xml	"; break;
                case 13: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_03009.xml	"; break;
                case 14: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_46022.xml	"; break;
                case 15: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_11004.xml	"; break;
                case 16: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_46029.xml	"; break;
                case 17: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_28009.xml	"; break;
                case 18: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_30008.xml	"; break;
                case 19: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_29007.xml	"; break;
                case 20: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_29008.xml	"; break;
                case 21: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_03014.xml	"; break;
                case 22: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_02009.xml	"; break;
                case 23: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_12009.xml	"; break;
                case 24: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_06011.xml	"; break;
                case 25: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_04013.xml	"; break;
                case 26: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_21005.xml	"; break;
                case 27: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_18017.xml	"; break;
                case 28: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_03018.xml	"; break;
                case 29: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_15002.xml	"; break;
                case 30: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_43014.xml	"; break;
                case 31: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_23005.xml	"; break;
                case 32: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_29015.xml	"; break;
                case 33: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_09018.xml	"; break;
                case 34: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_28013.xml	"; break;
                case 35: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_11006.xml	"; break;
                case 36: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_28014.xml	"; break;
                case 37: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_18021.xml	"; break;
                case 38: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_38006.xml	"; break;
                case 39: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_35004.xml	"; break;
                case 40: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_35006.xml	"; break;
                case 41: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_03019.xml	"; break;
                case 42: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_05019.xml	"; break;
                case 43: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_33004.xml	"; break;
                case 44: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_21010.xml	"; break;
                case 45: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_19046.xml	"; break;
                case 46: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_06015.xml	"; break;
                case 47: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_08015.xml	"; break;
                case 48: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_14007.xml	"; break;
                case 49: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_48013.xml	"; break;
                case 50: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_31901.xml	"; break;
                case 51: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_11007.xml	"; break;
                case 52: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_08252.xml	"; break;
                case 53: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_08019.xml	"; break;
                case 54: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_48015.xml	"; break;
                case 55: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_18023.xml	"; break;
                case 56: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_29025.xml	"; break;
                case 57: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_12027.xml	"; break;
                case 58: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_03031.xml	"; break;
                case 59: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_46070.xml	"; break;
                case 60: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_48020.xml	"; break;
                case 61: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_17023.xml	"; break;
                case 62: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_28022.xml	"; break;
                case 63: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_09059.xml	"; break;
                case 64: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_46078.xml	"; break;
                case 65: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_12032.xml	"; break;
                case 66: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_14013.xml	"; break;
                case 67: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_10037.xml	"; break;
                case 68: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_11012.xml	"; break;
                case 69: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_43037.xml	"; break;
                case 70: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_26036.xml	"; break;
                case 71: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_50067.xml	"; break;
                case 72: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_07011.xml	"; break;
                case 73: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_39016.xml	"; break;
                case 74: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_41021.xml	"; break;
                case 75: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_15017.xml	"; break;
                case 76: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_43038.xml	"; break;
                case 77: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_03050.xml	"; break;
                case 78: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_38011.xml	"; break;
                case 79: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_30015.xml	"; break;
                case 80: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_15019.xml	"; break;
                case 81: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_46083.xml	"; break;
                case 82: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_41024.xml	"; break;
                case 83: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_30016.xml	"; break;
                case 84: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_29038.xml	"; break;
                case 85: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_08051.xml	"; break;
                case 86: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_12040.xml	"; break;
                case 87: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_33016.xml	"; break;
                case 88: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_39020.xml	"; break;
                case 89: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_46094.xml	"; break;
                case 90: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_51001.xml	"; break;
                case 91: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_11015.xml	"; break;
                case 92: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_28040.xml	"; break;
                case 93: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_30019.xml	"; break;
                case 94: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_13034.xml	"; break;
                case 95: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_29042.xml	"; break;
                case 96: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_28047.xml	"; break;
                case 97: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_28045.xml	"; break;
                case 98: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_11014.xml	"; break;
                case 99: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_14021.xml	"; break;
                case 100: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_41034.xml	"; break;
                case 101: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_08073.xml	"; break;
                case 102: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_28049.xml	"; break;
                case 103: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_16078.xml	"; break;
                case 104: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_46105.xml	"; break;
                case 105: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_15031.xml	"; break;
                case 106: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_03063.xml	"; break;
                case 107: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_06044.xml	"; break;
                case 108: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_41038.xml	"; break;
                case 109: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_48027.xml	"; break;
                case 110: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_41039.xml	"; break;
                case 111: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_20030.xml	"; break;
                case 112: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_04902.xml	"; break;
                case 113: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_08118.xml	"; break;
                case 114: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_08169.xml	"; break;
                case 115: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_11027.xml	"; break;
                case 116: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_03065.xml	"; break;
                case 117: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_03066.xml	"; break;
                case 118: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_48902.xml	"; break;
                case 119: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_29051.xml	"; break;
                case 120: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_15036.xml	"; break;
                case 121: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_29054.xml	"; break;
                case 122: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_28058.xml	"; break;
                case 123: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_28061.xml	"; break;
                case 124: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_35009.xml	"; break;
                case 125: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_46131.xml	"; break;
                case 126: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_08089.xml	"; break;
                case 127: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_17079.xml	"; break;
                case 128: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_28065.xml	"; break;
                case 129: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_33024.xml	"; break;
                case 130: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_18087.xml	"; break;
                case 131: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_38017.xml	"; break;
                case 132: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_08096.xml	"; break;
                case 133: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_19130.xml	"; break;
                case 134: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_18089.xml	"; break;
                case 135: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_38019.xml	"; break;
                case 136: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_02037.xml	"; break;
                case 137: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_08101.xml	"; break;
                case 138: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_21041.xml	"; break;
                case 139: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_22125.xml	"; break;
                case 140: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_03079.xml	"; break;
                case 141: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_07026.xml	"; break;
                case 142: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_38022.xml	"; break;
                case 143: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_08102.xml	"; break;
                case 144: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_45081.xml	"; break;
                case 145: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_07027.xml	"; break;
                case 146: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_35011.xml	"; break;
                case 147: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_20045.xml	"; break;
                case 148: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_21042.xml	"; break;
                case 149: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_23050.xml	"; break;
                case 150: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_11020.xml	"; break;
                case 151: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_30022.xml	"; break;
                case 152: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_15030.xml	"; break;
                case 153: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_36017.xml	"; break;
                case 154: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_11022.xml	"; break;
                case 155: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_35014.xml	"; break;
                case 156: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_38026.xml	"; break;
                case 157: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_41081.xml	"; break;
                case 158: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_47076.xml	"; break;
                case 159: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_36024.xml	"; break;
                case 160: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_33031.xml	"; break;
                case 161: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_35016.xml	"; break;
                case 162: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_28127.xml	"; break;
                case 163: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_30038.xml	"; break;
                case 164: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_41053.xml	"; break;
                case 165: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_28074.xml	"; break;
                case 166: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_24089.xml	"; break;
                case 167: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_21044.xml	"; break;
                case 168: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_25120.xml	"; break;
                case 169: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_23055.xml	"; break;
                case 170: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_17095.xml	"; break;
                case 171: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_26089.xml	"; break;
                case 172: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_18122.xml	"; break;
                case 173: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_30024.xml	"; break;
                case 174: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_11008.xml	"; break;
                case 175: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_38024.xml	"; break;
                case 176: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_41069.xml	"; break;
                case 177: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_38031.xml	"; break;
                case 178: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_14038.xml	"; break;
                case 179: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_27028.xml	"; break;
                case 180: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_28079.xml	"; break;
                case 181: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_07032.xml	"; break;
                case 182: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_41058.xml	"; break;
                case 183: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_41059.xml	"; break;
                case 184: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_28080.xml	"; break;
                case 185: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_29067.xml	"; break;
                case 186: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_07033.xml	"; break;
                case 187: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_46159.xml	"; break;
                case 188: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_08112.xml	"; break;
                case 189: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_08113.xml	"; break;
                case 190: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_18127.xml	"; break;
                case 191: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_29069.xml	"; break;
                case 192: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_36026.xml	"; break;
                case 193: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_08114.xml	"; break;
                case 194: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_23060.xml	"; break;
                case 195: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_08121.xml	"; break;
                case 196: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_30026.xml	"; break;
                case 197: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_47085.xml	"; break;
                case 198: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_28084.xml	"; break;
                case 199: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_52001.xml	"; break;
                case 200: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_06083.xml	"; break;
                case 201: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_17105.xml	"; break;
                case 202: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_29070.xml	"; break;
                case 203: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_09219.xml	"; break;
                case 204: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_46169.xml	"; break;
                case 205: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_35012.xml	"; break;
                case 206: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_21050.xml	"; break;
                case 207: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_30027.xml	"; break;
                case 208: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_08124.xml	"; break;
                case 209: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_46171.xml	"; break;
                case 210: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_20055.xml	"; break;
                case 211: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_10127.xml	"; break;
                case 212: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_14042.xml	"; break;
                case 213: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_41065.xml	"; break;
                case 214: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_28092.xml	"; break;
                case 215: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_18140.xml	"; break;
                case 216: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_30030.xml	"; break;
                case 217: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_15054.xml	"; break;
                case 218: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_28096.xml	"; break;
                case 219: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_29075.xml	"; break;
                case 220: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_04066.xml	"; break;
                case 221: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_03093.xml	"; break;
                case 222: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_15058.xml	"; break;
                case 223: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_08147.xml	"; break;
                case 224: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_46181.xml	"; break;
                case 225: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_17114.xml	"; break;
                case 226: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_12084.xml	"; break;
                case 227: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_32054.xml	"; break;
                case 228: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_03099.xml	"; break;
                case 229: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_33044.xml	"; break;
                case 230: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_46186.xml	"; break;
                case 231: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_35015.xml	"; break;
                case 232: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_17117.xml	"; break;
                case 233: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_34120.xml	"; break;
                case 234: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_07040.xml	"; break;
                case 235: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_14049.xml	"; break;
                case 236: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_31201.xml	"; break;
                case 237: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_28104.xml	"; break;
                case 238: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_28106.xml	"; break;
                case 239: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_46190.xml	"; break;
                case 240: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_39052.xml	"; break;
                case 241: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_03902.xml	"; break;
                case 242: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_08163.xml	"; break;
                case 243: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_28113.xml	"; break;
                case 244: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_10148.xml	"; break;
                case 245: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_24115.xml	"; break;
                case 246: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_36038.xml	"; break;
                case 247: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_48078.xml	"; break;
                case 248: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_28115.xml	"; break;
                case 249: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_08172.xml	"; break;
                case 250: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_14055.xml	"; break;
                case 251: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_14056.xml	"; break;
                case 252: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_38028.xml	"; break;
                case 253: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_35017.xml	"; break;
                case 254: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_11028.xml	"; break;
                case 255: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_13071.xml	"; break;
                case 256: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_36045.xml	"; break;
                case 257: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_46213.xml	"; break;
                case 258: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_43123.xml	"; break;
                case 259: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_29082.xml	"; break;
                case 260: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_08180.xml	"; break;
                case 261: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_28123.xml	"; break;
                case 262: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_03113.xml	"; break;
                case 263: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_29084.xml	"; break;
                case 264: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_04079.xml	"; break;
                case 265: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_11030.xml	"; break;
                case 266: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_08184.xml	"; break;
                case 267: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_35019.xml	"; break;
                case 268: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_08187.xml	"; break;
                case 269: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_46220.xml	"; break;
                case 270: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_37274.xml	"; break;
                case 271: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_43905.xml	"; break;
                case 272: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_17155.xml	"; break;
                case 273: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_38023.xml	"; break;
                case 274: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_11031.xml	"; break;
                case 275: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_28130.xml	"; break;
                case 276: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_30035.xml	"; break;
                case 277: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_11033.xml	"; break;
                case 278: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_20069.xml	"; break;
                case 279: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_28134.xml	"; break;
                case 280: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_11032.xml	"; break;
                case 281: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_38038.xml	"; break;
                case 282: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_03121.xml	"; break;
                case 283: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_39075.xml	"; break;
                case 284: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_15078.xml	"; break;
                case 285: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_40194.xml	"; break;
                case 286: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_48084.xml	"; break;
                case 287: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_41091.xml	"; break;
                case 288: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_08270.xml	"; break;
                case 289: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_42173.xml	"; break;
                case 290: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_45165.xml	"; break;
                case 291: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_43148.xml	"; break;
                case 292: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_44216.xml	"; break;
                case 293: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_45168.xml	"; break;
                case 294: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_41093.xml	"; break;
                case 295: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_13082.xml	"; break;
                case 296: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_28148.xml	"; break;
                case 297: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_29901.xml	"; break;
                case 298: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_03133.xml	"; break;
                case 299: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_43155.xml	"; break;
                case 300: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_28903.xml	"; break;
                case 301: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_31232.xml	"; break;
                case 302: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_23092.xml	"; break;
                case 303: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_41095.xml	"; break;
                case 304: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_28161.xml	"; break;
                case 305: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_13087.xml	"; break;
                case 306: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_46250.xml	"; break;
                case 307: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_47186.xml	"; break;
                case 308: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_43161.xml	"; break;
                case 309: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_36057.xml	"; break;
                case 310: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_08301.xml	"; break;
                case 311: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_03139.xml	"; break;
                case 312: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_06153.xml	"; break;
                case 313: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_01059.xml	"; break;
                case 314: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_49275.xml	"; break;
                case 315: urlCiudad = "	http://www.aemet.es/xml/municipios/localidad_50297.xml	"; break;
                default:
                    urlCiudad = null;
                    break;
                    #endregion
            }

            return urlCiudad;
        }

        //Metodo que comprueba si dispone de conexión y es posible acceder y leer datos del XML de la ciudad correspondiente.
        public Boolean Conexion(int indice)
        {
            try
            {
                string ciudad = Ciudad(indice);
                XmlReader reader = XmlReader.Create(ciudad);
                return true;
            }
            catch (System.Net.WebException exc)
            {
                return false;
            }
        }
        
        #region metodo para obtener la franja horaria 24/4
        public String getFranjaHoraria(DateTime DT)
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
