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
                Application.Current.Properties["LOGEDUSER"] = loginModel._id;
                return true;
            }
            else
            {
                return false;
            }

        }

        public async Task Edit(string name, string lastname, string email)
        {
            PutModel put = new PutModel();
            put.nombre = name;
            put.apellido = lastname;
            put.email = email;

            var usuario = (UserModel)Application.Current.Properties["EDITUSER"];

            var client = new RestClient("http://localhost:3000/");
            var req = new RestRequest("api/users/" + usuario._id, Method.Put);
            req.AddHeader("Accept", "application/json");
            req.AddJsonBody(JsonConvert.SerializeObject(put));

            var res = client.Execute(req);

            if (!res.IsSuccessStatusCode)
            {
                MessageBox.Show("No se ha podido modificar el usuario. " + res.StatusCode.ToString());
                return;
            }

            MessageBox.Show("Usuario " + usuario._id + " modificado con éxito.");

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
                return usuario;
            }

            var json = res.Content;

            //Obtiene el data del modelo
            var usuarios_get = JsonConvert.DeserializeObject<ResponseModel>(json);

            //Obtiene el modelo del usuario
            return usuario = JsonConvert.DeserializeObject<UserModel>(JsonConvert.SerializeObject(usuarios_get.data[0]));
        }

        public async Task RemoveImg(string id)
        {
        
            var usuario = Application.Current.Properties["EDITUSER"] as UserModel;

            RemoveImgModel removeImgModel = new RemoveImgModel();
            removeImgModel.user = usuario._id;

            var client = new RestClient("http://localhost:3000/");
            var req = new RestRequest("api/images/remove/", Method.Post);
            req.RequestFormat = RestSharp.DataFormat.Json;
            
            req.AddBody(removeImgModel);

            var res = client.Execute(req);

            if (!res.IsSuccessStatusCode)
            {
                MessageBox.Show("No se ha podido borrar la imagen asociada al usuario" + res.StatusCode.ToString());
                return;
            }

            MessageBox.Show("Se ha borrado correctamente la imagen del usuario: " + removeImgModel.user);

        }

        public async Task Remove(string id)
        {
            var client = new RestClient("http://localhost:3000/");
            var req = new RestRequest("api/users/" + id, Method.Delete);
            req.RequestFormat = RestSharp.DataFormat.Json;

            var res = client.Execute(req);

            if (!res.IsSuccessStatusCode)
            {
                MessageBox.Show("No se ha encontrado un usuario con ID: " + id);
            }

            MessageBox.Show("Se ha borrado con éxito el usuario: " + id);
        }
    }
}
