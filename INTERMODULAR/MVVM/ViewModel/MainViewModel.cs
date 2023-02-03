using INTERMODULAR.MVVM.Model;
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
    }
}
