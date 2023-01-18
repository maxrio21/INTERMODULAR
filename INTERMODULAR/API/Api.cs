using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace INTERMODULAR.API
{
    public class Api
    {
        
        public dynamic Get(string URL)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(URL);
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();

            Stream stream = res.GetResponseStream();
            StreamReader sr = new StreamReader(stream);

            string datos = HttpUtility.HtmlDecode(sr.ReadToEnd());

            dynamic data = JsonConvert.DeserializeObject(datos);

            return data;
        }

    }
}
