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
                Console.WriteLine(temp.dato); 
                temp = temp.sig;

            }

        }
        public void OrdenarPrioridad(string fechaDeEntrega, int estado)
        {
            NodoActividad nuevoNodo = new NodoActividad();
            NodoActividad temp = primero; 
            if(temp == null || estado < temp.dato.estado)
            {
                nuevoNodo.sig = temp;
                temp = nuevoNodo;
            }
            else
            {
                NodoActividad act = temp;
                while(act.sig != null && act.sig.dato.estado <= estado)
                {
                    act = act.sig;
                }
                nuevoNodo.sig = act.sig;
                act.sig = nuevoNodo;    
            }
        }
    }
}
