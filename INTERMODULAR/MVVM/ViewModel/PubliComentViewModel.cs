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
    public class PubliComentViewModel
    {
        IUserRepository userRepository;
        IPostRepository postRepository;
        ICommRepository commRepository;
        public ViewModelCommand EditPubliVC { get; set; }
        public ViewModelCommand EditCommVC { get; set; }
        public ViewModelCommand DelPubliVC { get; set; }
        public ViewModelCommand DelCommVC { get; set; }

        public PubliComentViewModel()
        {
            postRepository = new PostRepository();
            commRepository = new CommRepository();

            EditPubliVC = new ViewModelCommand(o =>
            {
                MessageBox.Show("Editar publicacion");
            });
            EditCommVC = new ViewModelCommand(o =>
            {
                MessageBox.Show("Editar comentario");
            });
            DelPubliVC = new ViewModelCommand(o =>
            {
                if (MessageBox.Show("¿Estas seguro que deseas borrar esta publicacion?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    postRepository.Remove(o.ToString());
                }
            });
            DelCommVC = new ViewModelCommand(o =>
            {
                if (MessageBox.Show("¿Estas seguro que deseas borrar este comentario?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    commRepository.Remove(o.ToString());
                }
            });

        }

        public string GetPostPhoto(string id)
        {
            userRepository = new UserRepository();
            return userRepository.GetByID(id).Result.foto;
        }
    }
}
