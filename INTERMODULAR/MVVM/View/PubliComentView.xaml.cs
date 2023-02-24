using INTERMODULAR.MVVM.Model;
using INTERMODULAR.MVVM.Repositories;
using INTERMODULAR.MVVM.ViewModel;
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

namespace INTERMODULAR.MVVM.View
{

    public partial class PubliComentView : UserControl
    {
        IUserRepository userRepository;
        ICommRepository commRepository;

        int fotoActual = 0;
        PostModel post = Application.Current.Properties["POST"] as PostModel;

        public PubliComentView()
        {

            commRepository = new CommRepository();

            InitializeComponent();
            this.DataContext = new PubliComentViewModel();

            
            var comp_usu = post.usuario_id;

            var user_foto = ((PubliComentViewModel)this.DataContext).GetPostPhoto(post.usuario_id);

            if (user_foto == null)
            {
                comp_usu = "Desconocido";
            }   

            this.post_title.Text = post.nombre.ToUpper();
            this.post_user_username.Text = comp_usu;
            this.post_user_date.Text = post.fecha + " " + post.hora;
            this.post_comment.Text = post.contenido;
            this.post_distance.Text = post.km_distancia.ToString();
            this.post_duration.Text = post.min_duracion.ToString();
            this.post_dificulty.Text = post.dificultad;
            this.post_category.Text = post.cat;

            ImageBrush ib = new ImageBrush();

            Uri rute;
            rute = new Uri(@"http://localhost:3000/" + user_foto);

            if (comp_usu == "Desconocido")
            {
                rute = new Uri(@"http://localhost:3000/uploads/users/default.jpg");
            }

            ib.Stretch = Stretch.Uniform;
            ib.ImageSource = new System.Windows.Media.Imaging.BitmapImage(rute);
            this.post_user_img.Background = ib;

            fotoSlider();

            CommModel[] comentarios = commRepository.GetByAll().Result.ToArray();            

            foreach(var comentario in comentarios)
            {
                if (comentario.publicacion_id == post.nombre)
                {
                    comments_panel.Children.Add(new Comentario(comentario._id,comentario.usuario_id, comentario.fecha + " " + comentario.hora, comentario.contenido));
                }
            }
        }

        public void fotoSlider()
        {
            string[] fotos = post.fotos;

            if (this.fotoActual == fotos.Length)
            {
                this.fotoActual = 0;
            }

            if (this.fotoActual < 0)
            {
                this.fotoActual = fotos.Length - 1;
            }

            ImageBrush ib = new ImageBrush();

            Uri rute;

            try
            {
                rute = new Uri(@"http://localhost:3000/" + fotos[this.fotoActual]);
            }
            catch (IndexOutOfRangeException ex)
            {
                return;
            }

            ib.Stretch = Stretch.UniformToFill;
            ib.ImageSource = new System.Windows.Media.Imaging.BitmapImage(rute);

            post_img.Background = ib;
        }

        private void slider_back(object sender, RoutedEventArgs e)
        {
            fotoActual--;
            fotoSlider();
        }

        private void slider_next(object sender, RoutedEventArgs e)
        {
            fotoActual++;
            fotoSlider();
        }
    }
}
