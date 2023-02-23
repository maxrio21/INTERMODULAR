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
    /// Lógica de interacción para Publicacion.xaml
    /// </summary>
    public partial class Publicacion : UserControl
    {
        public string Id { set; get; }
        public string Titulo { set; get; }
        public string Foto { set; get; }
        public string Usuario { set; get; }
        public string Fecha { set; get; }
        public string Descripcion { set; get; }
        public string Categoria { set; get; }
        public Publicacion(string id, string titulo, string foto, string usuario, string fecha, string descripcion, string categoria)
        {
            InitializeComponent();

            this.DataContext = new PubliComentViewModel();

            this.Id = id;
            this.Titulo = titulo;
            this.Foto = foto;
            this.Usuario = usuario;
            this.Fecha = fecha;
            this.Descripcion = descripcion;
            this.Categoria = categoria;

            b_titulo.Text = this.Titulo;
            b_usuario.Text = this.Usuario;
            b_fecha.Text = this.Fecha;
            b_descripcion.Text = this.Descripcion;
            b_categoria.Text = this.Categoria;

            showPubBtn.CommandParameter = this.Id;
            delBtn.CommandParameter = this.Id;

        }
    }
}
