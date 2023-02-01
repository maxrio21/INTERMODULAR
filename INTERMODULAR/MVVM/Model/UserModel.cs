using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INTERMODULAR.MVVM.Model
{
    public class UserModel
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        //public string FechaAlta { get; set; }
        //public string[] Siguiendo { get; set; }
        //public string Foto { get; set; }
        //public bool Admin { get; set; }
    }
}
