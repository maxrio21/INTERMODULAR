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
            userRepository = new UserRepository();

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

        public void generate(string id, string titulo, string foto, string usuario, string fecha, string descripcion, string categoria)
        {
            //Dispatcher.BeginInvoke(new Action(() => MessageBox.Show(foto)));

            var comp_usu = usuario;

            if(userRepository.GetByID(usuario).Result.foto == null)
            {
                comp_usu = "Desconocido";
            }


            panel_rutas.Children.Add(new Publicacion(id,titulo,foto, comp_usu, fecha,descripcion,categoria));
        }

            //Herencia de objetos
            /*
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
            */  
    }
}


