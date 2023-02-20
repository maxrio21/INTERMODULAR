using INTERMODULAR.MVVM.Model;
using INTERMODULAR.MVVM.Repositories;
using INTERMODULAR.MVVM.ViewModel;
using MahApps.Metro.IconPacks;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
        IPostRepository postRepository;
        IUserRepository userRepository;
        public PubliView()
        {

            postRepository = new PostRepository();

            InitializeComponent();
            this.DataContext = new PubliViewModel();

            foreach (var post in postRepository.GetByAll().Result)
            {
                var fotos = post.fotos;

                if (fotos.Length == 0)
                {
                    this.generate(post._id, post.nombre.ToUpper(), "default", post.usuario_id,(post.hora + " " + post.fecha), post.contenido, post.cat);
                }
                else
                {
                    this.generate(post._id, post.nombre.ToUpper(), fotos[0], post.usuario_id, post.fecha, post.contenido, post.cat);
                }
            }
        }
        Border container = new Border();

        public void generate(string id, string titulo, string foto, string usuario, string fecha, string descripcion, string categoria)
        {
            //Contenedor principal de la publicacion
            Border container = new Border();
            BrushConverter bc = new BrushConverter(); //Utilizamos el brush para poner colores personalizados en hexadecimal

            container.Background = (Brush)bc.ConvertFrom("#FFFFFF");
            container.Height = 270;
            container.Width = Double.NaN;
            container.CornerRadius = new CornerRadius(10);
            container.Padding = new Thickness(20);
            container.Margin = new Thickness(0,0,0,15);

            //Sombra del contenedor
            DropShadowBitmapEffect containerEffect = new DropShadowBitmapEffect();

            System.Windows.Media.Color color = new System.Windows.Media.Color();
            color.ScR = 234;
            color.ScG = 234;
            color.ScB = 234;

            UIElement uie = new UIElement();
            uie.Effect = new DropShadowEffect
            {
                Color = new System.Windows.Media.Color { A = 218, R = 218, G = 218, B = 218 },
                Direction = 320,
                ShadowDepth = 0,
                Opacity = 0.5
            };

            containerEffect.Color = color;
            containerEffect.Direction = 0;
            containerEffect.ShadowDepth = 5;
            containerEffect.Opacity = 0.5;
            containerEffect.Softness = 0;
            container.Effect = uie.Effect; 

            //Fin de la sombra del contenedor
            //Fin de contenedor principal de la publicacion

            //Grid del contenedor principal
            Grid main_grid = new Grid();
            
            RowDefinition row1 = new RowDefinition();
            RowDefinition row2 = new RowDefinition();
            RowDefinition row3 = new RowDefinition();
            RowDefinition row4 = new RowDefinition();

            row1.Height = new GridLength(35.0, GridUnitType.Star);   
            row2.Height = new GridLength(45.0, GridUnitType.Star);
            row3.Height = new GridLength(84.0, GridUnitType.Star);
            row4.Height = new GridLength(40.0, GridUnitType.Star);

            main_grid.RowDefinitions.Add(row1);
            main_grid.RowDefinitions.Add(row2);
            main_grid.RowDefinitions.Add(row3);
            main_grid.RowDefinitions.Add(row4);

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
                     
            Ellipse contenedor_perfil = new Ellipse();
            contenedor_perfil.Height = 40;
            contenedor_perfil.Width = 40;
            ImageBrush ib = new ImageBrush();
            Uri rute = new Uri(@"http://localhost:3000" + "/uploads/users/" + usuario + ".jpg");

            if(!File.Exists(rute.LocalPath))
            {
               rute = new Uri(@"http://localhost:3000" + "/uploads/users/default.jpg");
            }

            ib.Stretch = Stretch.Uniform;
            ib.ImageSource = new System.Windows.Media.Imaging.BitmapImage(rute);
            contenedor_perfil.Fill = ib;
            
            //Contenedor de usuario y fecha
            StackPanel sp_usuario_fecha = new StackPanel();
            sp_usuario_fecha.Orientation = Orientation.Vertical;
            sp_usuario_fecha.VerticalAlignment = VerticalAlignment.Center;
            sp_usuario_fecha.Margin = new Thickness(10,0,0,0);

            TextBlock usuario_tb = new TextBlock();
            usuario_tb.Text = usuario;
            usuario_tb.FontWeight = FontWeights.Bold;
            TextBlock fecha_tb = new TextBlock();
            fecha_tb.Text = fecha;

            Border contenedor_cat = new Border();
            contenedor_cat.Background = (Brush)bc.ConvertFrom("#FF81CA46");
            contenedor_cat.HorizontalAlignment = HorizontalAlignment.Right;
            contenedor_cat.CornerRadius = new CornerRadius(7);
            contenedor_cat.VerticalAlignment = VerticalAlignment.Center;
            contenedor_cat.Height = 22;
            Grid.SetRow(contenedor_cat, 3);

            TextBlock categoria_tb = new TextBlock();
            categoria_tb.Text = categoria;
            categoria_tb.HorizontalAlignment = HorizontalAlignment.Center;
            categoria_tb.VerticalAlignment = VerticalAlignment.Center;
            categoria_tb.Foreground = (Brush)bc.ConvertFrom("#FFFFFF");
            categoria_tb.FontWeight = FontWeights.Bold;
            categoria_tb.Padding = new Thickness(5,3,5,3);
                  
            TextBlock descripcion_tb = new TextBlock();
            descripcion_tb.Text = descripcion;
            descripcion_tb.Height = Double.NaN;
            descripcion_tb.TextWrapping = TextWrapping.Wrap;
            descripcion_tb.TextAlignment = TextAlignment.Justify;
            Grid.SetRow(descripcion_tb, 2);
            //Fin cabecera

            Border publicacion_img = new Border();
            publicacion_img.Width = 70;
            publicacion_img.Height = 70;
            publicacion_img.HorizontalAlignment = HorizontalAlignment.Right;
            publicacion_img.CornerRadius = new CornerRadius(7);
            publicacion_img.Background = (Brush)bc.ConvertFrom("#808080"); //Borrar aquí lo cambiaremos por la imagen
            Grid.SetRowSpan(publicacion_img, 2);
            Grid.SetRow(publicacion_img, 0);       
            
            StackPanel opciones = new StackPanel();
            opciones.Orientation = Orientation.Horizontal;

            Grid.SetRow(opciones, 3);

            Button editBtn = new Button();
            Button delBtn = new Button();
            Button openBtn = new Button();

            Style style = new Style(typeof(Border));
            Style openStyle = new Style(typeof(Border));

            style.Setters.Add(new Setter(Border.CornerRadiusProperty, new CornerRadius(3)));
            openStyle.Setters.Add(new Setter(Border.CornerRadiusProperty, new CornerRadius(100)));

            editBtn.Command = ((PubliViewModel)this.DataContext).EditVC;
            editBtn.Background = (Brush)bc.ConvertFrom("#FF81CA46");
            editBtn.BorderThickness = new Thickness(0);
            editBtn.Resources.Add(typeof(Border), style);
            editBtn.Height = 22;
            editBtn.Width = 22;
            editBtn.Padding = new Thickness(5);
            editBtn.HorizontalAlignment = HorizontalAlignment.Left;

            delBtn.Command = ((PubliViewModel)this.DataContext).EditVC;
            delBtn.Background = (Brush)bc.ConvertFrom("#FF81CA46");
            delBtn.BorderThickness = new Thickness(0);
            delBtn.Resources.Add(typeof(Border), style);
            delBtn.Height = 22;
            delBtn.Width = 22;
            delBtn.Padding = new Thickness(5);
            delBtn.Margin = new Thickness(5,0,0,0);
            delBtn.HorizontalAlignment = HorizontalAlignment.Left;

            openBtn.Background = (Brush)bc.ConvertFrom("#FF81CA46");
            openBtn.BorderThickness = new Thickness(0);
            openBtn.Width = 40;
            openBtn.Height = 40;
            openBtn.Margin = new Thickness(319, 17, 319, -16);
            openBtn.Resources.Add(typeof(Border), openStyle);
            openBtn.Click += OpenBtnClick;

            Grid.SetRow(openBtn, 4);

            var edit_icon = new PackIconMaterial()
            {
                Kind = PackIconMaterialKind.PencilOutline,
                VerticalAlignment = VerticalAlignment.Center,
                Foreground = (Brush)bc.ConvertFrom("#FFFFFF"),
                Height = Double.NaN,
                Width = Double.NaN
            };

            var del_icon = new PackIconMaterial()
            {
                Kind = PackIconMaterialKind.DeleteOutline,
                VerticalAlignment = VerticalAlignment.Center,
                Foreground = (Brush)bc.ConvertFrom("#FFFFFF"),
                Height = Double.NaN,
                Width = Double.NaN
            };

            var open_icon = new PackIconMaterial()
            {
                Kind = PackIconMaterialKind.ChevronDoubleDown,
                VerticalAlignment = VerticalAlignment.Center,
                Foreground = (Brush)bc.ConvertFrom("#FFFFFF"),
                Height = 15,
                Width = 15
            };

            openBtn.Effect = uie.Effect;

            editBtn.Content = edit_icon;
            delBtn.Content = del_icon;
            openBtn.Content = open_icon;


            //Fin primera fila

            //Fin de contenido de la publicacion

            //Eventos
            container.MouseLeftButtonDown += new MouseButtonEventHandler(postClick);

            void postClick(object sender, MouseButtonEventArgs e)
            {
                MessageBox.Show(id);
            }

            void OpenBtnClick(object sender, RoutedEventArgs e)
            {
                //this.DataContext = new MainViewModel();
                //openBtn.Command = ((MainViewModel)this.DataContext).PubliCommVC;
                Binding b = new Binding("PubliCommVC");
                //b.Source = this.DataContext;
                b.RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(MainView),2);
                openBtn.SetBinding(Button.CommandProperty, b);
                //b.RelativeSource = new RelativeSource(RelativeSourceMode.Self);
                //openBtn.SetBinding(Button.CommandProperty, b);
                /*
                *  Command = "{Binding DataContext.UserEditVC, 
                *  RelativeSource={RelativeSource AncestorType=local:MainView}}" 
                *  CommandParameter = "{Binding Path=Id}" >
                */
            }

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
            main_grid.Children.Add(publicacion_img);
            main_grid.Children.Add(opciones);
            opciones.Children.Add(editBtn);
            opciones.Children.Add(delBtn);
            main_grid.Children.Add(openBtn);

        }

        
    }
}


