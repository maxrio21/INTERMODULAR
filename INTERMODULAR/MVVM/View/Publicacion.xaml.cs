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
    /// Lógica de interacción para Publicacion.xaml
    /// </summary>
    public partial class Publicacion : UserControl
    {
        public Publicacion(string id, string titulo, string foto, string usuario, string fecha, string descripcion, string categoria)
        {
            InitializeComponent();
            b_titulo.Text = titulo;
            b_usuario.Text = usuario;
            b_fecha.Text = fecha;
            b_descripcion.Text = descripcion;
            b_categoria.Text = categoria;
        }
    }
}
