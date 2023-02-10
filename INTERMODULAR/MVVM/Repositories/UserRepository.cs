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
using System.Collections.ObjectModel;

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

        public async Task<IEnumerable<UserModel>> GetByAll()
        {
            var hola = "Borrame es para que se suban los cambios a git";
            UserModel userModel = new UserModel();
            ObservableCollection<UserModel> usuarios = new ObservableCollection<UserModel>();

            var client = new RestClient("http://localhost:3000/");
            var req = new RestRequest("api/users", Method.Get);
            req.RequestFormat = RestSharp.DataFormat.Json;

            var res = client.Execute(req);

            if (!res.IsSuccessStatusCode)
            {
                return usuarios;
            }

            var json = res.Content;

            var usuarios_get = JsonConvert.DeserializeObject<ResponseModel>(json);
            /*for (int i = 0; i < usuarios_get.data.Length ; i++)
            {
                usuarios.Add(JsonConvert.DeserializeObject<UserModel>(JsonConvert.SerializeObject(usuarios_get.data[i])));
            }*/
            foreach (var item in usuarios_get.data)
            {
                usuarios.Add(JsonConvert.DeserializeObject<UserModel>(JsonConvert.SerializeObject(item)));
            }

            return usuarios;
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
