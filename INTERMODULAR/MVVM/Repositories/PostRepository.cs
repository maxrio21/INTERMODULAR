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
    public class PostRepository : IPostRepository
    {
        public void Add(PostModel userModel)
        {
            throw new NotImplementedException();
        }

        public void Edit(PostModel userModel)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PostModel>> GetByAll()
        {
            PostModel postModel = new PostModel();
            ObservableCollection<PostModel> posts = new ObservableCollection<PostModel>();

            var client = new RestClient("http://localhost:3000/");
            var req = new RestRequest("api/posts", Method.Get);
            req.RequestFormat = RestSharp.DataFormat.Json;

            var res = client.Execute(req);

            if (!res.IsSuccessStatusCode)
            {
                return posts;
            }

            var json = res.Content;

            var posts_get = JsonConvert.DeserializeObject<ResponsePostModel>(json);

            foreach (var item in posts_get.data)
            {
                posts.Add(JsonConvert.DeserializeObject<PostModel>(JsonConvert.SerializeObject(item)));
            }

            return posts;
        }

        public async Task<PostModel> GetByID(string id)
        {
            PostModel post = new PostModel();

            var client = new RestClient("http://localhost:3000/");
            var req = new RestRequest("api/posts/" + id, Method.Get);
            req.RequestFormat = RestSharp.DataFormat.Json;

            var res = client.Execute(req);

            if (!res.IsSuccessStatusCode)
            {
                MessageBox.Show("Debug >> No se ha encontrado un usuario con ID: " + id);
                return post;
            }

            var json = res.Content;

            //Obtiene el data del modelo
            var post_get = JsonConvert.DeserializeObject<ResponsePostModel>(json);

            //Obtiene el modelo del usuario
            return post = JsonConvert.DeserializeObject<PostModel>(JsonConvert.SerializeObject(post_get.data[0]));
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
