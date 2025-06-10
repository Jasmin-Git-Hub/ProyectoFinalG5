using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Actividad
    {
        public string titulo;
        public string fechaDeEntrega;
        public int estado;
        public override string ToString()
        {
            return "(" + titulo + "|" + fechaDeEntrega + "|" + estado + ")";
        }
    }
}
