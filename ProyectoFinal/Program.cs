using System;
using System.Collections.Generic;
using System.Globalization;
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
            PilaActividad historial=new PilaActividad();
            ArbolBinario arbol = new ArbolBinario();
            ColaAgenda cola = new ColaAgenda();
            int op;
            do
            {
                Console.Clear();
                Console.WriteLine("LISTA DE TAREAS: ");
                Console.WriteLine("(1) Inserte tareas a registrar: (LISTA SIMPLE)");
                Console.WriteLine("(2) Mostrar las tareas registradas ordenadas por prioridad: (LISTA SIMPLE)");
                Console.WriteLine("(3) Marcar tareas como completadas:(LISTA SIMPLE)");
                Console.WriteLine("(4) Ver historial de tareas completadas: (PILA)");
                Console.WriteLine("(5) Mostrar las tareas en orden por fecha: (ÁRBOLES BINARIOS) ");
                Console.WriteLine("(6) Mostrar actividades en la agenda: (COLA)");
                Console.WriteLine("(7) Completar alguna actividad de la agenda: (COLA)"); 
                Console.WriteLine("(8) Agendar una nueva actividad para hoy (COLA): ");
                Console.WriteLine("(9) Notas"); 
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
                        Console.WriteLine("Ingresa la fecha de entrega, siga el siguiente formato dd/mm/yyyy:"); 
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
                    case 3:
                        ls.mostrar();
                        Console.WriteLine(" Escribe el titulo de la tarea completada :");
                        string completado= Console.ReadLine();
                        Actividad TareaComp = ls.EliminarPorTitulo(completado);
                        if (TareaComp != null)
                        {
                            historial.apilar(TareaComp);
                            Console.WriteLine("tarea completada, se encuentra en el historial");
                        }
                        else
                        {
                            Console.WriteLine("no se encontro la tarea");

                        }
                        Console.ReadKey();
                        break;
                    case 4:
                        historial.MostrarHitorial();
                        Console.WriteLine("presione cualquier tecla paara continuar");
                        Console.ReadKey();
                        break;
                    case 5:
                        arbol.raiz_principal = null;
                        arbol.lista(ls);
                        Console.WriteLine("Tareas ordenadas por fecha:");
                        arbol.dibujararbol();
                        Console.WriteLine("Presione cualquier tecla para continuar ");
                        Console.ReadKey();
                        break;
                    case 6: 
                        Console.WriteLine("Las actividades programadas son las siguientes: ");
                        cola.mostrarCola();
                        Console.WriteLine("Presiona cualquier tecla para continuar:");
                        Console.ReadKey(); 
                        break; 
                    case 7:
                        
                        Actividad sig = cola.desencolar();
                        if (sig != null)
                        {
                            Console.WriteLine("Completando actividad por orden: " + sig.titulo); 
                        }
                        else
                        {
                            Console.WriteLine("No hay actividades por completar");
                        }

                            Console.ReadKey();                     
                        break;
                    case 8:
                        Actividad nu = new Actividad();
                        Console.WriteLine("Agendar nueva actividad:");
                        Console.WriteLine("Ingresa el título de la actividad:");
                        nu.titulo = Console.ReadLine();
                        Console.WriteLine("Detalle su actividad:");
                        nu.descripcion = Console.ReadLine();
                        cola.encolar(nu);
                        Console.WriteLine("La actividad ha sido integrada");
                        break;
                    default:
                        Console.WriteLine("Opción no válida"); break;
                }
                
            }while (op!=0);
           
        }
    }
}
