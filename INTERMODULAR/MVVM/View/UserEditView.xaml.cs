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
    /// <summary>
    /// Lógica de interacción para UserEditView.xaml
    /// </summary>
    public partial class UserEditView : UserControl
    {
        IUserRepository userRepository;

        
        public UserEditView()
        {
            InitializeComponent();
            this.DataContext = new UserEditViewModel();

            var usuario = Application.Current.Properties["EDITUSER"] as UserModel;

            name.Text = usuario.nombre;
            lastname.Text = usuario.apellido;
            email.Text = usuario.email;

            ImageBrush ib = new ImageBrush();
            Uri rute = new Uri(@"http://localhost:3000/" + usuario.foto);

            ib.Stretch = Stretch.Uniform;
            ib.ImageSource = new System.Windows.Media.Imaging.BitmapImage(rute);
            profile_img.Background = ib;

        }
    }
}
