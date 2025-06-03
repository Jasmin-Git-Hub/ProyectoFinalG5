using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class NodoActividad
    {
        public string titulo;
        public string fechaDeEentrega;
        public string estado; 
        public override string ToString()
        {
            return "(" + titulo + "|" + fechaDeEentrega + "|" + estado + ")";
        }

    }
}
