using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INTERMODULAR.MVVM.Model
{
    public class UserModel
    {
        public string _id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string fecha { get; set; }
        public string hora { get; set; }
        public string[] siguiendo { get; set; }
        public string foto { get; set; }
        public bool admin { get; set; }
        public int __v {get; set;}
    }

    public class RemoveImgModel
    {
        public string _id { get; set; }

    }
}
