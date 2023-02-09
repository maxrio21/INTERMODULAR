using INTERMODULAR.MVVM.Model;
using INTERMODULAR.MVVM.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INTERMODULAR.MVVM.ViewModel
{
    class MainViewModel : ViewModelBase
    {
        IUserRepository userRepository;
        public ViewModelCommand HomeVC{ get; set; }
        public ViewModelCommand UserVC { get; set; }

        public HomeViewModel HomeVM { get; set; }
        public UserViewModel UserVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; 
            OnPropertyChanged();}
        }

        public MainViewModel()
        {
            userRepository = new UserRepository();
            HomeVM = new HomeViewModel();
            UserVM = new UserViewModel();
            CurrentView = HomeVM;

            HomeVC = new ViewModelCommand(o => 
            {
                CurrentView = HomeVM;
            });

            UserVC = new ViewModelCommand(o =>
            {
                CurrentView = UserVM;
            });
        }

        public ObservableCollection<DGUserModel> RellenarTablaUsuarios()
        {
            ObservableCollection<DGUserModel> usuarios = new ObservableCollection<DGUserModel>();
            foreach (var user in userRepository.GetByAll().Result)
            {
                usuarios.Add(new DGUserModel 
                { 
                    Id = user._id, 
                    Persona = (user.nombre + "" + user.apellido),
                    Ingreso = user.fecha,
                    Correo = user.email
                });
            }
            return usuarios;
        }
    }
}
