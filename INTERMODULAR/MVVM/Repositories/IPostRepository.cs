using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using INTERMODULAR.MVVM.Model;

namespace INTERMODULAR.MVVM.Repositories
{
    public interface IPostRepository
    {
        void Add(PostModel userModel);
        void Edit(PostModel userModel);
        Task Remove(string id);
        Task<PostModel> GetByID(string id);
        UserModel GetByUsername(string username);
        Task<IEnumerable<PostModel>> GetByAll();
    }
}
