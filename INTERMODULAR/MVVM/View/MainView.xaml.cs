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
    /// Lógica de interacción para MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        
        public MainView()
        {
            InitializeComponent();
            var logged_user = ((MainViewModel)this.DataContext).getLoggedUser(Application.Current.Properties["LOGEDUSER"].ToString());



            ImageBrush ib = new ImageBrush();
            ib.Stretch = Stretch.Uniform;
            ib.ImageSource = new System.Windows.Media.Imaging.BitmapImage(new Uri(@"http://localhost:3000/" + logged_user.foto));
            logged_user_name.Text = logged_user.nombre;
            logged_user_lastname.Text = logged_user.apellido;
            profile_img.Background = ib;
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
