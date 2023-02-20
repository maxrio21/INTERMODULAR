using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using INTERMODULAR.MVVM.Model;

namespace INTERMODULAR.MVVM.Repositories
{
    public interface IUserRepository
    {
        Task<bool> AuthenticateUser(NetworkCredential credential);
        Task Add(UserModel userModel); 
        Task Edit(string username, string name, string lastname);
        Task Remove(string id);
        Task RemoveImg(string id);
        Task<UserModel> GetByID(string id);
        UserModel GetByUsername(string username);
        Task<IEnumerable<UserModel>> GetByAll();
    }
}
