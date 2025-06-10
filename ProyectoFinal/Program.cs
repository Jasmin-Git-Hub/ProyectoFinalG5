using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases; 

namespace ProyectoFinal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ListaSimpleActividad ls = new ListaSimpleActividad();
            int op;
            do
            {
                Console.Clear();
                Console.WriteLine("LISTA DE TAREAS: ");
                Console.WriteLine("(1)Inserte tareas a registrar:");
                Console.WriteLine("(2) Mostrar las tareas registradas ordenadas por prioridad:");
                Console.WriteLine("(3) Cursos");
                Console.WriteLine("(4) Notas");
                Console.WriteLine("(0) Salir");
                Console.WriteLine("Elija una opción"); 
                op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 0: 
                        Console.WriteLine("Saliendo....");
                        break;
                    case 1: 
                        Actividad n1 = new Actividad();
                        Console.WriteLine("Ingresa un título:");
                        n1.titulo = Console.ReadLine();
                        Console.WriteLine("Ingresa la fecha de entrega:"); 
                        n1.fechaDeEntrega = Console.ReadLine();
                        Console.WriteLine("Selecciona la prioridad de la tarea: (1) Alta (2) Media (3) Baja"); 
                        n1.estado = int.Parse(Console.ReadLine());
                        ls.Insertar(n1);
                        break;
                    case 2:
                        
                        Console.WriteLine("Mostrando lista ordenada por prioridad...");
                        ls.OrdenarPrioridad();
                        
                        ls.mostrar();
                        
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Opción no válida"); break;
                }
                
            }while (op!=0);
           
        }
    }
}
