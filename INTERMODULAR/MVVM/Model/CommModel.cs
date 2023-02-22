using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INTERMODULAR.MVVM.Model
{
    public class CommModel
    {
        public string _id { set; get; }
        public string fecha { set; get; }
        public string hora { set; get; }
        public string contenido { set; get; }
        public string usuario_id { set; get; }
        public string publicacion_id { set; get; }
        public int __v { set; get; }
    }
}
