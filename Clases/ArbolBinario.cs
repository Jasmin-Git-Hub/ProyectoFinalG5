using System;
using System.Drawing;

using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Clases
{
    public class ArbolBinario
    {
        public NodoArbol raiz_principal=null;


        public void insertar ( Actividad nuevo)
        {
            Insertar(ref raiz_principal, nuevo);
        }
        private NodoArbol Insertar (ref NodoArbol actual, Actividad nuevo )
        {
            if (actual == null)
            {
                actual = new NodoArbol();
                actual.pendiente = nuevo;
                return actual;
            }
            DateTime fechaNueva = DateTime.Parse(nuevo.fechaDeEntrega);
            DateTime fechaActual = DateTime.Parse(actual.pendiente.fechaDeEntrega);
            if (fechaNueva < fechaActual)
            {
                actual.izq = Insertar(ref actual.izq, nuevo);
                
            }
            else
            {
                actual.der = Insertar(ref actual.der, nuevo);
            }
            return actual;
        }
        public void PreOrden (NodoArbol actual)
        {
            if (actual != null)
            {
                Console.Write(actual.pendiente + "-");
                PreOrden(actual.izq);
                PreOrden (actual.der);
            }
        }
        public void PosOrden(NodoArbol actual)
        {
            if (actual != null)
            {
                
                PosOrden(actual.izq);
                PosOrden(actual.der);
                Console.Write(actual.pendiente + "-");
            }
        }
        public void InOrden(NodoArbol actual, DataGridView dgv) //DataGridView dgv)
        {
            if (actual != null)
            {
               
                InOrden(actual.izq, dgv);
                Console.Write(actual.pendiente + "-");
                dgv.Rows.Add(actual.pendiente.titulo, actual.pendiente.fechaDeEntrega, actual.pendiente.estado);
                InOrden(actual.der, dgv);
               
            }
        }
        public void MostrarInOrden (DataGridView dgv)
        {
            if (raiz_principal==null)
            {
                Console.WriteLine(" NO hay tareas pendientes para mostrar  ");
                return;
            }
            InOrden (raiz_principal, dgv);

        }
        public void dibujararbol()
        {
            DibujarArbol(raiz_principal, 0);
        }
        private void DibujarArbol(NodoArbol nodo, int nivel)
        {
            if (nodo!=null)
            {
                DibujarArbol(nodo.der, nivel+1);
                for (int i = 0; i < nivel; i++)
                {
                    Console.Write("\t");

                }
                Console.WriteLine(nodo.pendiente + " ("+nivel +")");
                DibujarArbol(nodo.izq, nivel + 1);
            }
        }
        public void lista(ListaSimpleActividad lista)
        {
            NodoActividad temp = lista.primero;
            while (temp != null)
            {
                insertar(temp.dato);
                temp = temp.sig;
            }
                

        }
    }

}
