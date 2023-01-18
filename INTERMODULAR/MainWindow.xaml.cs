using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System.Data;
using INTERMODULAR.API;

namespace INTERMODULAR
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Api api = new Api();

        GMarkerGoogle marker;
        GMapOverlay markerOverlay;
        DataTable dt;

        bool trazarRuta = false;
        int contadorIndicadoresRuta = 0;
        PointLatLng inicio;
        PointLatLng final;

        int filaSeleccionada = 0;
        double LatInicial = 38.6447000;
        double LngInicial = 0.0445000;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            dt = new DataTable();
            dt.Columns.Add(new DataColumn("Descripción", typeof(string)));
            dt.Columns.Add(new DataColumn("Lat", typeof(double)));
            dt.Columns.Add(new DataColumn("Long", typeof(double)));

            dt.Rows.Add("Ubicación", LatInicial, LngInicial);
            tabla_datos.ItemsSource = dt.DefaultView;

            tabla_datos.Columns[1].Visibility = Visibility.Collapsed;
            tabla_datos.Columns[2].Visibility = Visibility.Collapsed;

            mapView.DragButton = MouseButton.Left;
            mapView.CanDragMap = true;
            mapView.MapProvider = GMapProviders.GoogleMap;
            mapView.MinZoom = 0;

            markerOverlay = new GMapOverlay("Marcador");
            marker = new GMarkerGoogle(new PointLatLng(LatInicial, LngInicial), GMarkerGoogleType.blue);
            markerOverlay.Markers.Add(marker);

            marker.ToolTipMode = MarkerTooltipMode.Always;
            marker.ToolTipText = string.Format("ubicación\n Latitud:{0}\n Longitud:{1}", LatInicial, LngInicial);
        
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dynamic res = api.Get("http://localhost:8080/prueba");
            tb_DATA.Text = res.ToString();
        }
    }
}
