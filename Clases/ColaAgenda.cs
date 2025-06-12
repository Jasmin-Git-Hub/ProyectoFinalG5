using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class ColaAgenda
    {
        public NodoActividad frente = null;
        public NodoActividad final = null; 
        public void encolar(Actividad pendiente)
        {
            //1. Crear el nuevo nodo 
            NodoActividad reciente = new NodoActividad(); 
            reciente.dato = pendiente;
            if (frente == null)
            {
                frente = reciente; 
            }
            else
            {
                final.sig = reciente; 
            }
            final = reciente;  
        }
        public Actividad desencolar()
        {
            if (frente == null)
            {
                return null;
            }
            Actividad t = frente.dato;
            frente = frente.sig; 
            return t;
        }
        public void mostrarCola()
        {
            NodoActividad temp = frente;
            Console.WriteLine("Actividades agendadas en orden:");
            while (temp != null)
            {
                Console.WriteLine(temp.dato.titulo+ " -> " + temp.dato.estado);
                temp = temp.sig; 
            }
        }

    }
}
