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
            if (frente == null)
            {
                Console.WriteLine("No tienes actividades pendientes en tu agenda. Agrega unao tómate un descanso..."); 
            }
            NodoActividad temp = frente;
            int cont = 0;
            int cont2 = 0; 
           
            while (temp != null)
            {
                cont2++;
                if (cont == 0)
                {
                    
                    Console.WriteLine("Actividades agendadas en orden:");
                    cont = 1;
                    
                }
                Console.WriteLine(cont2 + ". " + temp.dato.titulo+ " -> " + temp.dato.descripcion);
                temp = temp.sig; 
            }
           
        }

    }
}
