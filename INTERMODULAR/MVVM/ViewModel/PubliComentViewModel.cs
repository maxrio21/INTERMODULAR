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
        IPostRepository postRepository;
        IUserRepository userRepository;
        public ViewModelCommand EditVC { get; set; }
        public ViewModelCommand DeleteVC { get; set; }

        public PubliComentViewModel()
        {

            postRepository = new PostRepository();

            EditVC = new ViewModelCommand(o =>
            {
                MessageBox.Show("Hola!");
            });
        }
    }
}
