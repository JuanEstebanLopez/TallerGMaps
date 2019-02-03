using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TallerGMaps.Modelo
{
    public class ZonaWifi
    {
        private string _coordenadas;

        public string Gestor { get; set; }
        public string Departamento { get; set; }
        public string Municipio { get; set; }
        public string Direccion { get; set; }
        public int ZonasWifi { get; set; }
        public string NombreDelSitio { get; set; }

        public double Lat { get; set; }
        public double Lon { get; set; }
        /// <summary>
        /// Coordenadas de la Zona Wi-Fi, Actualiza la las propiedades Lat y Lon cuando es actualizada.
        /// </summary>
        public string Coordenadas {
            get { return _coordenadas; }
             set{
                _coordenadas = Regex.Replace(value, @"[-()\s]", "");
                string[] cor = _coordenadas.Split(',');
                var style = System.Globalization.NumberStyles.AllowDecimalPoint;
                var culture = System.Globalization.CultureInfo.InvariantCulture;
                decimal n;
                bool s = Decimal.TryParse(cor.Last(), style, culture, out n);
                Lat = (double)n;
                s = Decimal.TryParse(cor.First(), style, culture, out n);
                Lon = (double)n * -1;
            }
        }

        /// <summary>
        /// Devuelve un String que representa la zona Wi-Fi
        /// </summary>
        /// <returns>Representación de la zona Wi-Fi</returns>
        public override string ToString() => String.Format("{0} {1} ({2},{3}): {4}", Gestor, Municipio, Lat, Lon, NombreDelSitio);
    }
}
