using INTERMODULAR.MVVM.Model;
using INTERMODULAR.MVVM.Repositories;
using INTERMODULAR.MVVM.View;
using Newtonsoft.Json.Linq;
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
        public ViewModelCommand HomeVC { get; set; }
        public ViewModelCommand UserVC { get; set; }
        public ViewModelCommand UserEditVC { get; set; }
        public ViewModelCommand PubliVC { get; set; }
        public ViewModelCommand PubliCommVC { get; set; }
        public ViewModelCommand DeleteUserVC { get; set; }


        public HomeViewModel HomeVM { get; set; }
        public UserViewModel UserVM { get; set; }
        public UserEditViewModel UserEditVM { get; set; }
        public PubliViewModel PubliVM { get; set; }
        public PubliComentViewModel PubliCommVM { get; set; }

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
            PubliVM = new PubliViewModel();
            PubliCommVM = new PubliComentViewModel();

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

                Application.Current.Properties["EDITUSER"] = usuario;
                //var rec_usuario = Application.Current.Properties["EDITUSER"] as UserModel;
                //MessageBox.Show(rec_usuario._id);

                UserEditVM = new UserEditViewModel();
                CurrentView = UserEditVM;
            });

            PubliVC = new ViewModelCommand(o =>
            {
                CurrentView = PubliVM;
            });

            PubliCommVC = new ViewModelCommand(o =>
            {
                MessageBox.Show("Ha llegado aquí");
                CurrentView = PubliCommVM;
            });

            //Utilizamos este comando para editar el usuario en la base de datos con un put

            DeleteUserVC = new ViewModelCommand(o => 
            {
                var id = o.ToString();

                if (MessageBox.Show("¿Deseas borrar al usuario?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    userRepository.Remove(id);
                }
            });
        }
    }
}
