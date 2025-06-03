using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Usuario
    {
        public string nombre;
        public string curso;
        public int correoUPN;
        public override string ToString()
        {
            return "(" + nombre + "|" + curso + "|" + correoUPN + ")";
        }
    }
}
