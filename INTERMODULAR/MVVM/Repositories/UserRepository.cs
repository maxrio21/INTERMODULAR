using INTERMODULAR.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using System.Net;

namespace INTERMODULAR.MVVM.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public void Add(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AuthenticateUser(NetworkCredential credential)
        {
            
            //LoginView lV = new LoginView();
            LoginModel loginModel = new LoginModel();
            loginModel._id = credential.UserName;
            loginModel.password = credential.Password;

            var client = new RestClient("http://localhost:3000/");
            var req = new RestRequest("api/login", Method.Post);
            req.RequestFormat = DataFormat.Json;
            req.AddBody(loginModel);
            /*
            req.AddParameter("_id", loginModel._id);
            req.AddParameter("password",loginModel.password);
            req.AddHeader("Content-Type", "application/json");
            */

            var res = client.Execute(req);
            var content = res.Content;

            if(res.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                //lV.txt_prueba.Text = JsonSerializer.Serialize(loginModel);
                return false;
            }
        }

        public void Edit(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserModel> GetByAll()
        {
            throw new NotImplementedException();
        }

        public UserModel GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public UserModel GetByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
