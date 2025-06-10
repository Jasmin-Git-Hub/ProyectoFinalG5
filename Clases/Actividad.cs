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
        public string fechaDeEentrega;
        public int estado;
        public override string ToString()
        {
            return "(" + titulo + "|" + fechaDeEentrega + "|" + estado + ")";
        }
    }
}
