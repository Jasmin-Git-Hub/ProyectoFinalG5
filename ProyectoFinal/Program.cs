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
            ColaAgenda cola = new ColaAgenda();
            int op;
            do
            {
                Console.Clear();
                Console.WriteLine("LISTA DE TAREAS: ");
                Console.WriteLine("(1)Inserte tareas a registrar:");
                Console.WriteLine("(2) Mostrar las tareas registradas ordenadas por prioridad:");
                Console.WriteLine("(3)Marcar tareas como completadas:");
                Console.WriteLine("(4) Ver historial de tareas completadas: ");
                Console.WriteLine("(5) Cursos");
                Console.WriteLine("(6) Notas");
                Console.WriteLine("(7) Agenda diaria");
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

                            default:
                        Console.WriteLine("Opción no válida"); break;
                    case 7:
                        cola.mostrarCola();
                        Actividad nu = new Actividad();
                        Console.WriteLine("Agendar nueva actividad:");
                        Console.WriteLine("Ingresa el título de la actividad:");
                        nu.titulo = Console.ReadLine();
                        Console.WriteLine("Detalle su actividad:");
                        nu.descripcion= Console.ReadLine();
                        cola.encolar(nu);
                        Console.WriteLine("La activiad ha sido integrada");
                        Console.ReadKey();
                        Console.WriteLine("Cumplió con alguna actividad: (1) Si (2) No"); 
                        int n2 = int.Parse(Console.ReadLine());
                        switch (n2)
                        {
                            case 1:
                                Console.WriteLine("Indique el titulo de la actividad completada"); 
                                cola sig = cola.desencolar();
                        }
                        break; 
                }
                
            }while (op!=0);
           
        }
    }
}
