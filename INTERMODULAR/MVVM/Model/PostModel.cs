using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace INTERMODULAR.MVVM.Model
{
    public class PostModel
    {
        public string _id { set; get; }
        public string fecha { set; get; }
        public string hora { set; get; }
        public string nombre { set; get; }
        public string cat { set; get; }
        public double km_distancia { set; get; }
        public string dificultad { set; get; }
        public int min_duracion { set; get; }
        public string contenido { set; get; }
        public string[] fotos { set; get; }
        public string privacidad { set; get; }
        public double[,] coordenadas { set; get; }
        public string usuario_id { set; get; }
        public int __v { set; get; }
    }
}
