using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TallerGMaps.Modelo;

namespace TallerGMaps
{
    public partial class VistaMapa : Form
    {
        public ModeloTallerGMaps Modelo { get; set; }
        public GMapOverlay MarkersOverlay { get; set; }
        public VistaMapa()
        {
            InitializeComponent();
            Modelo = new ModeloTallerGMaps();
            CargarMapa();
        }

        /// <summary>
        /// Inicializa el Mapa, sus marcadores y los eventos relacionados a sus marcadores.
        /// </summary>
        public void CargarMapa() {
            gmap.MapProvider = GMap.NET.MapProviders.BingMapProvider.Instance;
            GMaps.Instance.Mode = AccessMode.ServerOnly;
            gmap.Position = new PointLatLng(3.5089844, -76.4560516);
            MarkersOverlay = new GMapOverlay("markers");
            Modelo.ZonasWifi.ForEach(n => CrearZonaWifi(n.Lat, n.Lon, n.Gestor, n.NombreDelSitio, n.Direccion));
            gmap.Overlays.Add(MarkersOverlay);
            gmap.OnMarkerEnter += new MarkerEnter(MapMarkerEnter);
            gmap.OnMarkerLeave += new MarkerLeave(MapMarkerleave);
        }

        /// <summary>
        /// Crea un nuevo marcador para una zona Wi-Fi.
        /// </summary>
        /// <param name="lat">Latitud de la zona Wi-Fi</param>
        /// <param name="lon">Longitud  de la zona Wi-Fi</param>
        /// <param name="gestor">Nombre del gestor de la zona Wi-Fi</param>
        /// <param name="nombre">Nombre del lugar donde se encuentra la zona Wi-Fi</param>
        /// <param name="direccion">Dirección del lugar</param>
        public void CrearZonaWifi(double lat, double lon, string gestor, string nombre, string direccion) {
            GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(lat, lon),
              GMarkerGoogleType.green);
            MarkersOverlay.Markers.Add(marker);
            marker.ToolTipText = nombre + "_" + gestor + "_" + direccion;
            marker.ToolTipMode = MarkerTooltipMode.Never;
            // Console.WriteLine("Zona creada: ({0}, {1}) {2} {3} {4}",lat, lon, nombre, gestor, direccion);
        }

        /// <summary>
        /// Actualiza la información de la interfaz con la información del marcador seleccionado.
        /// </summary>
        /// <param name="marker">Marcador del que se mostrará la información</param>
        public void MapMarkerEnter(GMapMarker marker) {
            string[] info = marker.ToolTipText.Split('_');
            lbNombre.Text = info[0];
            lbGestor.Text = "Gestor: " + info[1];
            lbDireccion.Text = "Dirección: " + info[2];
        }

        /// <summary>
        /// Deja de mostrar la información del marcador que ya no está seleccionado.
        /// </summary>
        /// <param name="marker">Marcador que dejó de ser seleccionado.</param>
        public void MapMarkerleave(GMapMarker marker) {
            if (marker.ToolTipText.StartsWith(lbNombre.Text)) {
                lbNombre.Text = "";
                lbGestor.Text = "";
                lbDireccion.Text = "";
            }
        }
        
    }
}
