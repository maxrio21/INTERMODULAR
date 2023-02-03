using INTERMODULAR.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

            List<PruebaModel> usuarios = new List<PruebaModel>();
            usuarios.Add(new PruebaModel("1", "algun dia", "example@gmail.com"));
            usuarios.Add(new PruebaModel("2", "algun dia", "example@gmail.com"));
            usuarios.Add(new PruebaModel("3", "algun dia", "example@gmail.com"));
            usuarios.Add(new PruebaModel("4", "algun dia", "example@gmail.com"));
            usuarios.Add(new PruebaModel("5", "algun dia", "example@gmail.com"));
            usuarios.Add(new PruebaModel("6", "algun dia", "example@gmail.com"));
            usuarios.Add(new PruebaModel("7", "algun dia", "example@gmail.com"));
            usuarios.Add(new PruebaModel("8", "algun dia", "example@gmail.com"));
            usuarios.Add(new PruebaModel("9", "algun dia", "example@gmail.com"));
            usuarios.Add(new PruebaModel("10", "algun dia", "example@gmail.com"));

            usuariosDataGrid.ItemsSource = usuarios;
        }
    }

    public class PruebaModel
    {
        private string id;
        private string ingreso;
        private string correo;
        
        public string Id { get => id; set => id = value; }
        public string Ingreso { get => ingreso; set => ingreso = value; }
        public string Correo { get => correo; set => correo = value; }

        public PruebaModel(string id, string ingreso, string correo)
        {
            this.id = id;
            this.ingreso = ingreso;
            this.correo = correo;
        }
    }
}
