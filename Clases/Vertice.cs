using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    //VERTICE == NODO
    public class Vertice
    {
        public string nombre;

        //trabajar la lista temp
        public Vertice sig = null;

        //trabajar el grafo permanente

        public Arista lista_arista = null;

        //insertar arista
        public void insertarArista(Vertice d, float c, string um)
        {
            //1.Crear el nuevo nodo
            Arista nuevo = new Arista();
            nuevo.destino = d;
            nuevo.costo = c;
            nuevo.um = um;

            if (lista_arista == null)
            {
                //la lista esta vacia
                //el nuevo debe guardarse en el primero
                lista_arista = nuevo;
            }
            else
            {
                //2. buscar el ultimo
                Arista temp = lista_arista;
                while (temp.sig != null)
                {
                    temp = temp.sig;
                }
                //temp esta ubicado en el ultimo
                //3. ultimo.sig el nuevo
                temp.sig = nuevo;

            }
        }
        //mostrar aristas
        public void MostrarArista()
        {
            Arista temp = lista_arista;
            int i = 1;
            while (temp != null)
            {
                Arista v = temp;
                Console.WriteLine(i + ". Ir hacia v" + v.destino.nombre + " - " + v.costo + " " + v.um
                    );
                temp = temp.sig;
                i++;
            }
        }
    }
}
