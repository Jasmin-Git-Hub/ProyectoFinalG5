using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Curso
    {
        public string nombre; 
        public string docente;
        public int creditos;
        public override string ToString()
        {
            return "(" + nombre + "|" + docente + "|" + creditos + ")";
        }

    }
}
