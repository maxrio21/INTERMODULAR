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
    public class PubliViewModel
    {
        IPostRepository postRepository;
        public ViewModelCommand ShowVC { get; set; }
        public PubliViewModel()
        {

            postRepository = new PostRepository();

            ShowVC = new ViewModelCommand(o =>
            {
                foreach (var post in postRepository.GetByAll().Result)
                {
                    MessageBox.Show(post._id);
                }
            });
        }

        public PostModel[] generarPublicaiones()
        {
            return (PostModel[])postRepository.GetByAll().Result;
        }
    }
}
