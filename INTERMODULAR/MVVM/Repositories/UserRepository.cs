using INTERMODULAR.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using System.Net;
using System.Windows;
using Newtonsoft.Json;
using System.Net.Http;
using System.Security.Policy;
using System.Text.Json.Nodes;
using System.Text;

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
            LoginModel loginModel = new LoginModel();
            loginModel._id = credential.UserName;
            loginModel.password = credential.Password;

            var client = new RestClient("http://localhost:3000/");
            var req = new RestRequest("api/auth/login/", Method.Post);
            req.RequestFormat = RestSharp.DataFormat.Json;
            req.AddBody(loginModel);
           

            var res = client.Execute(req);
            var content = res.Content;

            if(res.IsSuccessStatusCode)
            {
                var json = res.Content.ToString();
                string token = JsonConvert.DeserializeObject<TokenModel>(json).data[0];
                Application.Current.Properties["TOKEN"] = token;
                return true;
            }
            else
            {
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
