using INTERMODULAR.MVVM.Model;
using INTERMODULAR.MVVM.Repositories;
using INTERMODULAR.MVVM.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace INTERMODULAR.MVVM.ViewModel
{
    class MainViewModel : ViewModelBase
    {
        IUserRepository userRepository;
        public ViewModelCommand HomeVC{ get; set; }
        public ViewModelCommand UserVC { get; set; }
        public ViewModelCommand UserEditVC { get; set; }   

        public HomeViewModel HomeVM { get; set; }
        public UserViewModel UserVM { get; set; }
        public UserEditViewModel UserEditVM { get; set; }

        public object _currentView;

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
            

            //UserEditVM = new UserEditViewModel(userRepository.GetByID(id).Result);

            CurrentView = HomeVM;

            HomeVC = new ViewModelCommand(o => 
            {
                CurrentView = HomeVM;
            });

            UserVC = new ViewModelCommand(o =>
            {
                CurrentView = UserVM;
            });

            UserEditVC = new ViewModelCommand(o => /*Revisar, probalemente funcione pero la api ha sido cambiada.*/
            {
                var id = o.ToString();

                var usuario = userRepository.GetByID(id).Result;

                UserEditVM = new UserEditViewModel(usuario);
                CurrentView = UserEditVM;
            });
        }
    }
}
