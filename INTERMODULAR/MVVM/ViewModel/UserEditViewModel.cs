using INTERMODULAR.MVVM.Model;
using INTERMODULAR.MVVM.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace INTERMODULAR.MVVM.ViewModel
{
    public class UserEditViewModel : ViewModelBase
    {
        IUserRepository userRepository;
        private string _correo;
        private string _name;
        private string _lastname;

        public UserModel usuario { get; set; }
        public ViewModelCommand EditVC { get; set; }
        public ViewModelCommand DelImgVC { get; set; }
        public string Correo
        {
            get => _correo;
            set
            {
                _correo = value;
                OnPropertyChanged(nameof(Correo));
            }
        }
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string Lastname
        {
            get => _lastname;
            set
            {
                _lastname = value;
                OnPropertyChanged(nameof(Lastname));
            }
        }
        public UserEditViewModel()
        {
            userRepository = new UserRepository();
            this.usuario = Application.Current.Properties["EDITUSER"] as UserModel;

            EditVC = new ViewModelCommand(o =>
            {
                var modeloForm = (UserModel)o;

                if (MessageBox.Show("¿Deseas editar los datos del usuario?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    userRepository.Edit(Name, Lastname, Correo);
                }
            });

            DelImgVC = new ViewModelCommand(o =>
            {
                if (MessageBox.Show("¿Deseas borrar la imagen de perfil del usuario?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    userRepository.RemoveImg(usuario._id);
                }
            });
        }
    }
}
