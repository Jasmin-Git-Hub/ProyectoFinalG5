using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Grafo
    {
        public Vertice inicio_lista = null;
        public int[,] ma;

        public Grafo(int n)
        {
            ma = new int[n, n];
        }
        //METODOS PARA LISTA (insertar y mostrar)
        public void RegistrarVertices()
        {
            insertar("IIS"); //0-Introducción a la ingenieria de sistemas 
            insertar("FA"); //1-Fundamentos de de algoritmos 
            insertar("FP"); //2-Fundamentos de porgramacion 
            insertar("EDA"); //3- Estructura de datos
            insertar("BD"); // 4- Base de datos 
            insertar("TDPOO"); //5-tecnicas de prohramacion orientada a objetos 
            insertar("BDAyBD");// 6 base de datos avanzado y big data 
            insertar("MyAS");// 7 modelo y analisis de software
            insertar("ED");// 8 eleltronica digital 
            insertar("AC"); // 9 arquitectura del computador 


        }

        public void insertar(string nombre)
        {
            //1.Crear el nuevo nodo
            Vertice nuevo = new Vertice();
            nuevo.nombre = nombre;

            if (inicio_lista == null)
            {
                //la lista esta vacia
                //el nuevo debe guardarse en el primero
                inicio_lista = nuevo;
            }
            else
            {
                //2. buscar el ultimo
                Vertice temp = inicio_lista;
                while (temp.sig != null)
                {
                    temp = temp.sig;
                }
                //temp esta ubicado en el ultimo
                //3. ultimo.sig el nuevo
                temp.sig = nuevo;

            }
        }
        //mostrar
        public void Mostrar()
        {
            Vertice temp = inicio_lista;
            while (temp != null)
            {
                Console.WriteLine(temp.nombre);
                temp = temp.sig;
            }
        }
        //METODOS PARA MATRIZ 
        public void llenarMatriz()
        {
            Random r = new Random();
            for (int i = 0; i < ma.GetLength(0); i++)
            {
                for (int j = 0; j < ma.GetLength(1); j++)
                {

                    ma[i, j] = 0;

                }
            }
            ma[0, 1] = 1;
            ma[1, 2] = 1;
            ma[2, 3] = 1;
            ma[2, 5] = 1;
            ma[3, 4] = 1;
            ma[4, 6] = 1;
            ma[5, 7] = 1;
            ma[8, 9] = 1;
            //ma[9, 3] = 1;
            //ma[3, 1] = 1;
            //ma[4, 2] = 1;
            //ma[5, 0] = 1;
            //ma[7, 4] = 1;
            //ma[8, 6] = 1;
            //ma[10, 5] = 1;
            //ma[11, 3] = 1;
            //ma[12, 1] = 1;
        }
        public void mostrarMatriz()
        {
            int ancho = 12;
            Vertice temp = inicio_lista;
            Console.Write("".PadRight(ancho));

            while (temp != null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(temp.nombre.PadRight(ancho));
                temp = temp.sig;
            }
            Console.WriteLine();
            Console.ResetColor();

            // Imprimir filas de la matriz
            temp = inicio_lista;
            for (int i = 0; i < ma.GetLength(0); i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(temp.nombre.PadRight(ancho));
                Console.ResetColor();

                for (int j = 0; j < ma.GetLength(1); j++)
                {
                    Console.Write(ma[i, j].ToString().PadRight(ancho));
                }
                Console.WriteLine();
                temp = temp.sig;
            }
        }
        //METODOS DE GRAFOS
        public void crearGrafo()
        {
            int[] complejidad =
             {
               2,
               2,
               3,
               4,
               5,
               1,
               2,
               5,
               1,


            };
            string unidad = "complejidad ";
            Vertice tempOrigen = inicio_lista;
            for (int i = 0; i < ma.GetLength(0); i++)
            {

                Vertice tempDestino = inicio_lista;
                for (int j = 0; j < ma.GetLength(1); j++)
                {
                    if (ma[i, j] == 1)
                    {
                        tempOrigen.insertarArista(tempDestino, complejidad[i], unidad);
                    }
                    tempDestino = tempDestino.sig;

                }
                tempOrigen = tempOrigen.sig;

            }
        }

        public void recorrerGrafo(Vertice actual, ref float total)
        {

            Console.Clear();
            Console.WriteLine("Recorrido del grafo");
            Console.WriteLine("Actividad actual :" + actual.nombre);//15
            actual.MostrarArista();

            Console.WriteLine("0. salir");
            Console.WriteLine("Elija curso completado");
            int opcion = int.Parse(Console.ReadLine());

            if (opcion != 0)
            {
                Arista temp = actual.lista_arista;

                for (int i = 1; i < opcion; i++)
                {
                    if (temp.sig != null)
                    {
                        temp = temp.sig;
                    }
                }
                total += temp.costo;
                recorrerGrafo(temp.destino, ref total);
            }
            else
            {
                Console.WriteLine(" complejidad  total " + total);
            }
            Console.ReadKey();
        }
        public Vertice Buscar(string nombre)
        {
            Vertice temp = inicio_lista;
            while (temp != null)
            {
                if (temp.nombre.ToLower() == nombre.ToLower())
                {
                    return temp;
                }
                temp = temp.sig;
            }
            return null;

        }
    }
}
