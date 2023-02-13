using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace INTERMODULAR.MVVM.Model
{
    public interface IUserRepository
    {
        Task<bool> AuthenticateUser(NetworkCredential credential);
        void Add(UserModel userModel);
        void Edit(UserModel userModel);
        Task Remove(string id);
        Task<UserModel> GetByID(string id);
        UserModel GetByUsername(string username);
        Task<IEnumerable<UserModel>> GetByAll();
    }
}
