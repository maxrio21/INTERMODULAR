using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using INTERMODULAR.MVVM.Model;

namespace INTERMODULAR.MVVM.Repositories
{
    public interface ICommRepository
    {
        Task Remove(string id);
        //Task<UserModel> GetByID(string id);
        CommModel GetByUsername(string username);
        Task<IEnumerable<CommModel>> GetByAll();
        Task<IEnumerable<CommModel>> GetAllFromComm(string post);
    }
}
