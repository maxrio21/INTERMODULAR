using INTERMODULAR.MVVM.Model;
using INTERMODULAR.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
    /// Lógica de interacción para UserView.xaml
    /// </summary>
    public partial class UserView : UserControl
    {
        public UserView()
        {
            InitializeComponent();

            this.DataContext = new UserViewModel();
            usuariosDataGrid.ItemsSource = ((UserViewModel)this.DataContext).RellenarTablaUsuarios();
        }

       
        private void DeleteUserEvent(object sender, RoutedEventArgs e)
        {
            
        }
    }

    public class PruebaModel
    {
        public string Id { get; set; }
        public string Persona { get; set; }
        public string Ingreso { get; set; }
        public string Correo { get; set; }
    }
}
