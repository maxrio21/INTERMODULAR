﻿using INTERMODULAR.MVVM.Model;
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
    public class UserRepository : IUserRepository
    {
        public async Task Add(UserModel userModel)
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

        public async Task Edit(string username, string name, string lastname)
        {
            /*
            var user = this.GetByID(username).Result;
            user.nombre = name;
            user.apellido = lastname;

            var client = new RestClient("http://localhost:3000/");
            var req = new RestRequest("api/users/" + username, Method.Put);
            var json = JsonConvert.SerializeObject(user);
            req.AddJsonBody(json);
            MessageBox.Show(json);
            var res = client.Execute(req);

            req.AddParameter("nombre",name, ParameterType.RequestBody);
            req.AddParameter("apellido",lastname, ParameterType.RequestBody);
            */

            PutModel put = new PutModel();
            put.nombre = name;
            put.apellido = lastname;

            var client = new RestClient("http://localhost:3000/");
            var req = new RestRequest("api/users/" + username, Method.Put);
            req.AddHeader("Accept", "application/json");
            req.AddJsonBody(JsonConvert.SerializeObject(put));

            var res = client.Execute(req);


            foreach(var i in req.Parameters)
            {
                MessageBox.Show(i.ToString());
            }
            //MessageBox.Show(user._id);
            MessageBox.Show(username);

            if (!res.IsSuccessStatusCode)
            {
                MessageBox.Show("No se ha podido modificar el usuario. " + res.StatusCode.ToString());
                return;
            }
        }

        public async Task<IEnumerable<UserModel>> GetByAll()
        {
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

            foreach (var item in usuarios_get.data)
            {
                usuarios.Add(JsonConvert.DeserializeObject<UserModel>(JsonConvert.SerializeObject(item)));
            }

            return usuarios;
        }

        public async Task<UserModel> GetByID(string id)
        {
            UserModel usuario = new UserModel();

            var client = new RestClient("http://localhost:3000/");
            var req = new RestRequest("api/users/" + id, Method.Get);
            req.RequestFormat = RestSharp.DataFormat.Json;

            var res = client.Execute(req);

            if (!res.IsSuccessStatusCode)
            {
                MessageBox.Show("Debug >> No se ha encontrado un usuario con ID: " + id);
                return usuario;
            }

            var json = res.Content;

            //Obtiene el data del modelo
            var usuarios_get = JsonConvert.DeserializeObject<ResponseModel>(json);

            //Obtiene el modelo del usuario
            return usuario = JsonConvert.DeserializeObject<UserModel>(JsonConvert.SerializeObject(usuarios_get.data[0]));
        }

        public UserModel GetByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public async Task Remove(string id)
        {
            var client = new RestClient("http://localhost:3000/");
            var req = new RestRequest("api/users/" + id, Method.Delete);
            req.RequestFormat = RestSharp.DataFormat.Json;

            var res = client.Execute(req);

            if (!res.IsSuccessStatusCode)
            {
                MessageBox.Show("Debug >> No se ha encontrado un usuario con ID: " + id);
            }

            throw new NotImplementedException();
        }
    }
}
