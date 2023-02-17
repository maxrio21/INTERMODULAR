using INTERMODULAR.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace INTERMODULAR.MVVM.View
{
    /// <summary>
    /// Lógica de interacción para PubliView.xaml
    /// </summary>
    public partial class PubliView : UserControl
    {
        public PubliView()
        {
            InitializeComponent();
            this.DataContext = new PubliViewModel();
            this.generate("Titulo","introducza foto","register","17/02/2023","lorem ipsum papa","alguna");
        }

        public void generate(string titulo, string foto, string usuario, string fecha, string descripcion, string categoria)
        { 
            //Contenedor principal de la publicacion
            Border container = new Border();

            BrushConverter bc = new BrushConverter(); //Utilizamos el brush para poner colores personalizados en hexadecimal

            container.Background = (Brush)bc.ConvertFrom("#FFFFFF");
            container.Height = 250;
            container.Width = Double.NaN;
            container.CornerRadius = new CornerRadius(10);
            container.Padding = new Thickness(20);

            //Sombra del contenedor
            DropShadowBitmapEffect containerEffect = new DropShadowBitmapEffect();

            System.Windows.Media.Color color = new System.Windows.Media.Color();
            color.ScR = 255;
            color.ScG = 183;
            color.ScB = 183;

            containerEffect.Color = color;
            containerEffect.ShadowDepth = 0;
            container.BitmapEffect = containerEffect;
            //Fin de la sombra del contenedor
            //Fin de contenedor principal de la publicacion

            //Grid del contenedor principal
            Grid main_grid = new Grid();

            main_grid.ShowGridLines = false;

            RowDefinition row1 = new RowDefinition();
            row1.Height = new GridLength(35.0, GridUnitType.Star);
            
            RowDefinition row2 = new RowDefinition();
            row2.Height = new GridLength(45.0, GridUnitType.Star);

            RowDefinition row3 = new RowDefinition();
            row3.Height = new GridLength(84.0, GridUnitType.Star);

            RowDefinition row4 = new RowDefinition();
            row4.Height = new GridLength(6.0, GridUnitType.Star);

            RowDefinition row5 = new RowDefinition();
            row5.Height = new GridLength(40.0, GridUnitType.Star);

            main_grid.RowDefinitions.Add(row1);
            main_grid.RowDefinitions.Add(row2);
            main_grid.RowDefinitions.Add(row3);
            main_grid.RowDefinitions.Add(row4);
            main_grid.RowDefinitions.Add(row5);

            //Fin del grid del contenedor principal

            //Contenido de la publicación

            //Primera fila
            TextBlock titulo_tb = new TextBlock();
            
            titulo_tb.Text = titulo;
            titulo_tb.FontSize = 21;
            titulo_tb.FontFamily = new FontFamily("DM Sans");
            titulo_tb.FontWeight = FontWeights.Bold;
            titulo_tb.VerticalAlignment = VerticalAlignment.Center;
            titulo_tb.Height = 26;

            Grid.SetRow(titulo_tb, 0);

            //Cabecera
            StackPanel sp_cabecera = new StackPanel();
            sp_cabecera.Orientation = Orientation.Horizontal;
            sp_cabecera.VerticalAlignment = VerticalAlignment.Center;
            sp_cabecera.Height = 68;

            Grid.SetRow(sp_cabecera, 1);

            //Imagen del usuario
            Ellipse contenedor_perfil = new Ellipse();
            contenedor_perfil.Height = 40;
            contenedor_perfil.Width = 40;
            ImageBrush ib = new ImageBrush();
            ib.ImageSource = new BitmapImage(new Uri("./Images/left_login.jpg", UriKind.RelativeOrAbsolute));
            //contenedor_perfil.Fill = ib;

            //Contenedor de usuario y fecha
            StackPanel sp_usuario_fecha = new StackPanel();
            sp_usuario_fecha.Orientation = Orientation.Vertical;
            sp_usuario_fecha.VerticalAlignment = VerticalAlignment.Center;
            sp_usuario_fecha.Margin = new Thickness(10,0,0,0);

            TextBlock usuario_tb = new TextBlock();
            usuario_tb.Text = usuario;
            TextBlock fecha_tb = new TextBlock();
            fecha_tb.Text = fecha;

            Border contenedor_cat = new Border();
            contenedor_cat.Background = (Brush)bc.ConvertFrom("#FF81CA46");
            contenedor_cat.HorizontalAlignment = HorizontalAlignment.Right;
            contenedor_cat.CornerRadius = new CornerRadius(7);
            contenedor_cat.VerticalAlignment = VerticalAlignment.Center;
            contenedor_cat.Height = 22;
            contenedor_cat.Width = 66;
            Grid.SetRow(contenedor_cat, 3);

            TextBlock categoria_tb = new TextBlock();
            categoria_tb.Text = categoria;
            categoria_tb.HorizontalAlignment = HorizontalAlignment.Center;
            categoria_tb.VerticalAlignment = VerticalAlignment.Center;
            categoria_tb.Foreground = (Brush)bc.ConvertFrom("#FFFFFF");
            categoria_tb.FontWeight = FontWeights.Bold;
            categoria_tb.Margin = new Thickness(5,3,5,3);

            TextBlock descripcion_tb = new TextBlock();
            descripcion_tb.Text = descripcion;
            descripcion_tb.Height = Double.NaN;
            descripcion_tb.TextWrapping = TextWrapping.Wrap;
            descripcion_tb.TextAlignment = TextAlignment.Justify;
            Grid.SetRow(descripcion_tb, 2);
            //Fin cabecera

            /*
             
            <TextBlock Height="Auto" 
                        TextWrapping="Wrap"
                        TextAlignment="Justify"
                        Text="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum. Sed ut perspiciatis unde omnis iste natus error sit vo" Grid.Row="2" Margin="0,12,0,0" Grid.RowSpan="2"/>
            <Border Grid.Row="0" 
                    Grid.RowSpan="2" 
                    Width="70" 
                    HorizontalAlignment="Left"
                    CornerRadius="6" Margin="568,5,0,5">
                <Border.Background>
                    <ImageBrush ImageSource="../../Images/left_login.jpg"/>
                </Border.Background>
            </Border>
            */

            //Fin primera fila

            //Fin de contenido de la publicacion

            //Herencia de objetos
            panel_rutas.Children.Add(container);
            container.Child = main_grid;
            main_grid.Children.Add(titulo_tb);
            main_grid.Children.Add(sp_cabecera);
            sp_cabecera.Children.Add(contenedor_perfil);
            sp_cabecera.Children.Add(sp_usuario_fecha);
            sp_usuario_fecha.Children.Add(usuario_tb);
            sp_usuario_fecha.Children.Add(fecha_tb);
            main_grid.Children.Add(contenedor_cat);
            contenedor_cat.Child = categoria_tb;
            main_grid.Children.Add(descripcion_tb);
        }
    }
}


