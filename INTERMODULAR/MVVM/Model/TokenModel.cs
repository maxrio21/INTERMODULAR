using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INTERMODULAR.MVVM.Model
{
    public class TokenModel
    {
        public string status { get; set; }
        public string[] data { get; set; }
    }

    public class ResponseModel
    {
        public string status { get; set; }
        public UserModel[] data { get; set; }
    }

    public class ResponsePostModel
    {
        public string status { get; set; }
        public PostModel[] data { get; set; }
    }

    public class ResponseCommModel
    {
        public string status { get; set; }
        public CommModel[] data { get; set; }
    }
}