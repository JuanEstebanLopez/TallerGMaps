using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
//using SODA;

namespace TallerGMaps.Modelo
{
    public class ModeloTallerGMaps
    {
        public List<ZonaWifi> ZonasWifi { get; set; }

        public ModeloTallerGMaps() {
            Cargar();
        }
        /// <summary>
        /// Carga la lista de zonas wi-fi.
        /// </summary>
        public void Cargar() {
            ZonasWifi = JsonConvert.DeserializeObject<List<ZonaWifi>>(File.ReadAllText(@"..\\..\\data/zonas-wifi.txt"));
            // Console.WriteLine(list);            
            // list.ToList<ZonaWifi>().ForEach(z => Console.WriteLine(z));

            /* CARGA DE DATOS DESDE LA BASE DE DATOS
            // https://www.datos.gov.co/resource/r465-9mer.json
            var client = new SodaClient("https://www.datos.gov.co", "ZrX3PN9yQpnvFeRURPM8AuI75");
            var dataset = client.GetResource<Dictionary<string, object>>("r465-9mer");
            var rows = dataset.GetRows();
            Console.WriteLine("Got {0} results. Dumping first results:", rows.Count());
            foreach (var field in rows)
            {
                //Console.WriteLine(field);
            }
            */
        }

    }
}
