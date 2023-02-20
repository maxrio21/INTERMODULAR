using INTERMODULAR.MVVM.Model;
using INTERMODULAR.MVVM.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace INTERMODULAR.MVVM.ViewModel
{
    class UserViewModel : ViewModelBase
    {
        IUserRepository userRepository;
        public ViewModelCommand UserEditVC { get; set; }
        public UserEditViewModel UserEditVM { get; set; }

        public MainViewModel MainVM { get; set; }
              
        public UserViewModel()
        {
            userRepository = new UserRepository();

            //UserEditVM = new UserEditViewModel(userRepository.GetByID(id).Result);
        }

        public ObservableCollection<DGUserModel> RellenarTablaUsuarios()
        {
            ObservableCollection<DGUserModel> usuarios = new ObservableCollection<DGUserModel>();
            foreach (var user in userRepository.GetByAll().Result)
            {
                usuarios.Add(new DGUserModel
                {
                    Id = user._id,
                    Persona = (user.nombre + " " + user.apellido),
                    Imagen = new Uri(@"http://localhost:3000/" + user.foto),
                    Ingreso = user.fecha,
                    Correo = user.email
                });
            }
            return usuarios;
        }
    }
}
