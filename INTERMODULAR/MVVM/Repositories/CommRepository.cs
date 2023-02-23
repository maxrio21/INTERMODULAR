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
using System.Windows.Threading;
using System.Linq;

namespace INTERMODULAR.MVVM.Repositories
{
    public class CommRepository : ICommRepository
    {
        public async Task<IEnumerable<CommModel>> GetAllFromComm(string post)
        {
            List<CommModel> comentarios = new List<CommModel>();

            foreach(CommModel item in this.GetByAll().Result)
            {
                if("ruta media bici" == item.publicacion_id.ToString())
                {
                    comentarios.Add(item);
                }
            }

            return comentarios;
        }

        public async Task<IEnumerable<CommModel>> GetByAll()
        {
            CommModel commModel = new CommModel();
            ObservableCollection<CommModel> comentarios = new ObservableCollection<CommModel>();

            var client = new RestClient("http://localhost:3000/");
            var req = new RestRequest("api/comments", Method.Get);
            req.RequestFormat = RestSharp.DataFormat.Json;

            var res = client.Execute(req);

            if (!res.IsSuccessStatusCode)
            {
                return comentarios;
            }

            var json = res.Content;

            var comentarios_get = JsonConvert.DeserializeObject<ResponseCommModel>(json);

            foreach (var item in comentarios_get.data)
            {
                comentarios.Add(JsonConvert.DeserializeObject<CommModel>(JsonConvert.SerializeObject(item)));
            }

            return comentarios;
        }

        public CommModel GetByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public async Task Remove(string id)
        {
            var client = new RestClient("http://localhost:3000/");
            var req = new RestRequest("api/comments/" + id, Method.Delete);
            req.RequestFormat = RestSharp.DataFormat.Json;

            var res = client.Execute(req);

            if (!res.IsSuccessStatusCode)
            {
                MessageBox.Show("Debug >> No se ha encontrado un usuario con ID: " + id);
            }
        }
    }
}
