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
    /// <summary>
    /// Lógica de interacción para Comentario.xaml
    /// </summary>
    public partial class Comentario : UserControl
    {
        public string Id { get; set; }
        public string Id_Usu { get; set; }
        public string Fecha { get; set; }
        public string Contenido { get; set; }

        IUserRepository userRepository;

        public Comentario(string id, string id_usu, string fecha, string contenido)
        {
            InitializeComponent();

            this.DataContext = new PubliComentViewModel();

            userRepository = new UserRepository();

            this.Id = id;
            this.Id_Usu = id_usu;
            this.Fecha = fecha;
            this.Contenido = contenido;

            comm_usuario.Text = this.Id_Usu;
            comm_contenido.Text = this.Contenido;
            comm_fecha.Text = this.Fecha;

            ImageBrush ib = new ImageBrush();
            Uri rute = new Uri(@"http://localhost:3000/" + userRepository.GetByID(id_usu).Result.foto);
            ib.Stretch = Stretch.Uniform;
            ib.ImageSource = new System.Windows.Media.Imaging.BitmapImage(rute);

            comm_foto.Background = ib;

            delBtn.CommandParameter = this.Id;

        }
    }
}
