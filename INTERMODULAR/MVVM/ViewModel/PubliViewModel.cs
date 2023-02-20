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
    public class PubliViewModel : ViewModelBase
    {
        IPostRepository postRepository;
        IUserRepository userRepository;
        public ViewModelCommand EditVC { get; set; }
        public ViewModelCommand DeleteVC { get; set; }

        public object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }
        public PubliViewModel()
        {
            postRepository = new PostRepository();

            EditVC = new ViewModelCommand(o =>
            {
                MessageBox.Show("Hola!");
            });
        }

        public PostModel[] generarPublicaiones()
        {
            return (PostModel[])postRepository.GetByAll().Result;
        }

        public UserModel getUsuario(string id)
        {
            userRepository = new UserRepository();
            return (UserModel)userRepository.GetByID(id).Result;
        }
    }
}
