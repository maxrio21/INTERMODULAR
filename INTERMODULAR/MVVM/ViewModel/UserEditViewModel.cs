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
        //readonly UserModel usuario = new UserModel();

        IUserRepository userRepository;
        public UserModel usuario { get; set; }
        
        public ViewModelCommand DeleteVC { get; set; }

        public UserEditViewModel()
        {
            userRepository = new UserRepository();
            this.usuario = Application.Current.Properties["EDITUSER"] as UserModel;

            DeleteVC = new ViewModelCommand(o =>
            {
                MessageBox.Show("Intentando borrar el usuario: " + usuario._id.ToString());
                userRepository.Remove(usuario._id.ToString());
            });
        }
    }
}
