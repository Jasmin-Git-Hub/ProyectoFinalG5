using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class ListaSimpleActividad
    {
        public NodoActividad primero = null; 
        public void Insertar(Actividad d)
        {
            //1. Creamos el primer nodo 
            NodoActividad nuevo = new NodoActividad();
            nuevo.dato = d;

            if (primero == null)
            {
                //La lista está vacía 
                //Le nuevo nodo debe guardarse como el primero 
                primero = nuevo;
            }
            else
            {
                //2. Buscamos al último Nodo
                NodoActividad temp = primero;
                while (temp.sig != null)
                {
                    temp = temp.sig;
                }
                //temp esá  ubicado al final 
                //3. último.sig va a ser el nuevo
                temp.sig = nuevo;
            }
        }
        public void mostrar()
        {
            NodoActividad temp = primero;
            while (temp !=  null)
            {
                Console.WriteLine("Título: " + temp.dato.titulo);
                Console.WriteLine("Fecha de Entrega: " + temp.dato.fechaDeEntrega);
                Console.WriteLine("Prioridad: " + temp.dato.estado);
                Console.WriteLine("-------------------------");
                temp = temp.sig;

            }

        }
        public void OrdenarPrioridad()
        {
            
            if(primero == null || primero.sig == null)
            {
                return;
            }
            NodoActividad act, sigui; 
            int cambio;
            do
            {
                cambio = 0;
                act = primero; 
                sigui = primero.sig;
                while(sigui != null)
                {
                    if (act.dato.estado > sigui.dato.estado)
                    {
                        Actividad primero = act.dato;
                        act.dato = sigui.dato; 
                        sigui.dato = primero;
                        cambio = 1;   
                    }
                    act = sigui; 
                    sigui = sigui.sig;
                }

            } while (cambio == 1); 
            
        }
    }
}
