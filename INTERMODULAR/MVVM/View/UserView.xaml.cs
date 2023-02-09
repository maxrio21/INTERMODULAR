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

            ObservableCollection<PruebaModel> usuarios = new ObservableCollection<PruebaModel>();
            usuarios.Add(new PruebaModel { Id = "1", Persona = "Hajar Oviedo", Ingreso = "03/02/2023", Correo="example@gmail.com" });
            usuarios.Add(new PruebaModel { Id = "2", Persona = "Josue Yuste", Ingreso = "03/02/2023", Correo = "example@gmail.com" });
            usuarios.Add(new PruebaModel { Id = "3", Persona = "Felix Paz", Ingreso = "03/02/2023", Correo = "example@gmail.com" });
            usuarios.Add(new PruebaModel { Id = "4", Persona = "Francesc Checa", Ingreso = "03/02/2023", Correo = "example@gmail.com" });
            usuarios.Add(new PruebaModel { Id = "5", Persona = "Judit Berenguer", Ingreso = "03/02/2023", Correo = "example@gmail.com" });
            usuarios.Add(new PruebaModel { Id = "6", Persona = "Delia Batista", Ingreso = "03/02/2023", Correo = "example@gmail.com" });
            usuarios.Add(new PruebaModel { Id = "7", Persona = "Teresa de Leon", Ingreso = "03/02/2023", Correo = "example@gmail.com" });
            usuarios.Add(new PruebaModel { Id = "8", Persona = "Noel Arnaiz", Ingreso = "03/02/2023", Correo = "example@gmail.com" });
            usuarios.Add(new PruebaModel { Id = "9", Persona = "Clotilde Barrios", Ingreso = "03/02/2023", Correo = "example@gmail.com" });
            usuarios.Add(new PruebaModel { Id = "10", Persona = "Estela Solana", Ingreso = "03/02/2023", Correo = "example@gmail.com" });
            usuarios.Add(new PruebaModel { Id = "1", Persona = "Hajar Oviedo", Ingreso = "03/02/2023", Correo = "example@gmail.com" });
            usuarios.Add(new PruebaModel { Id = "2", Persona = "Josue Yuste", Ingreso = "03/02/2023", Correo = "example@gmail.com" });
            usuarios.Add(new PruebaModel { Id = "3", Persona = "Felix Paz", Ingreso = "03/02/2023", Correo = "example@gmail.com" });
            usuarios.Add(new PruebaModel { Id = "4", Persona = "Francesc Checa", Ingreso = "03/02/2023", Correo = "example@gmail.com" });
            usuarios.Add(new PruebaModel { Id = "5", Persona = "Judit Berenguer", Ingreso = "03/02/2023", Correo = "example@gmail.com" });
            usuarios.Add(new PruebaModel { Id = "6", Persona = "Delia Batista", Ingreso = "03/02/2023", Correo = "example@gmail.com" });
            usuarios.Add(new PruebaModel { Id = "7", Persona = "Teresa de Leon", Ingreso = "03/02/2023", Correo = "example@gmail.com" });
            usuarios.Add(new PruebaModel { Id = "8", Persona = "Noel Arnaiz", Ingreso = "03/02/2023", Correo = "example@gmail.com" });
            usuarios.Add(new PruebaModel { Id = "9", Persona = "Clotilde Barrios", Ingreso = "03/02/2023", Correo = "example@gmail.com" });
            usuarios.Add(new PruebaModel { Id = "10", Persona = "Estela Solana", Ingreso = "03/02/2023", Correo = "example@gmail.com" }); usuarios.Add(new PruebaModel { Id = "1", Persona = "Hajar Oviedo", Ingreso = "03/02/2023", Correo = "example@gmail.com" });
            usuarios.Add(new PruebaModel { Id = "2", Persona = "Josue Yuste", Ingreso = "03/02/2023", Correo = "example@gmail.com" });
            usuarios.Add(new PruebaModel { Id = "3", Persona = "Felix Paz", Ingreso = "03/02/2023", Correo = "example@gmail.com" });
            usuarios.Add(new PruebaModel { Id = "4", Persona = "Francesc Checa", Ingreso = "03/02/2023", Correo = "example@gmail.com" });
            usuarios.Add(new PruebaModel { Id = "5", Persona = "Judit Berenguer", Ingreso = "03/02/2023", Correo = "example@gmail.com" });
            usuarios.Add(new PruebaModel { Id = "6", Persona = "Delia Batista", Ingreso = "03/02/2023", Correo = "example@gmail.com" });
            usuarios.Add(new PruebaModel { Id = "7", Persona = "Teresa de Leon", Ingreso = "03/02/2023", Correo = "example@gmail.com" });
            usuarios.Add(new PruebaModel { Id = "8", Persona = "Noel Arnaiz", Ingreso = "03/02/2023", Correo = "example@gmail.com" });
            usuarios.Add(new PruebaModel { Id = "9", Persona = "Clotilde Barrios", Ingreso = "03/02/2023", Correo = "example@gmail.com" });
            usuarios.Add(new PruebaModel { Id = "10", Persona = "Estela Solana", Ingreso = "03/02/2023", Correo = "example@gmail.com" }); usuarios.Add(new PruebaModel { Id = "1", Persona = "Hajar Oviedo", Ingreso = "03/02/2023", Correo = "example@gmail.com" });
            usuarios.Add(new PruebaModel { Id = "2", Persona = "Josue Yuste", Ingreso = "03/02/2023", Correo = "example@gmail.com" });
            usuarios.Add(new PruebaModel { Id = "3", Persona = "Felix Paz", Ingreso = "03/02/2023", Correo = "example@gmail.com" });
            usuarios.Add(new PruebaModel { Id = "4", Persona = "Francesc Checa", Ingreso = "03/02/2023", Correo = "example@gmail.com" });
            usuarios.Add(new PruebaModel { Id = "5", Persona = "Judit Berenguer", Ingreso = "03/02/2023", Correo = "example@gmail.com" });
            usuarios.Add(new PruebaModel { Id = "6", Persona = "Delia Batista", Ingreso = "03/02/2023", Correo = "example@gmail.com" });
            usuarios.Add(new PruebaModel { Id = "7", Persona = "Teresa de Leon", Ingreso = "03/02/2023", Correo = "example@gmail.com" });
            usuarios.Add(new PruebaModel { Id = "8", Persona = "Noel Arnaiz", Ingreso = "03/02/2023", Correo = "example@gmail.com" });
            usuarios.Add(new PruebaModel { Id = "9", Persona = "Clotilde Barrios", Ingreso = "03/02/2023", Correo = "example@gmail.com" });
            usuarios.Add(new PruebaModel { Id = "10", Persona = "Estela Solana", Ingreso = "03/02/2023", Correo = "example@gmail.com" });
            usuariosDataGrid.ItemsSource = usuarios;
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
