﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class PilaActividad
    {
        public NodoPila cima = null;

        public void apilar(Actividad act)
        {
            NodoPila nuevo = new NodoPila();
            nuevo.activ = act;
            nuevo.sig = cima;
            cima = nuevo;
        }
        public Actividad desapilar()
        {
            if (cima == null)
            {
                Console.WriteLine(" El historial de tareas completadas esta vacia ");
                return null;
            }
            Actividad act = cima.activ;
            cima = cima.sig;
            return act;
        }

        public void MostrarHitorial()
        {
            NodoPila act = cima;
            Console.WriteLine("Historial de tareas completadas :");
            while (act != null)
            {
                Console.WriteLine(act.activ.titulo+ " De prioridad :" + act.activ.estado);
                act = act.sig;  
            }
        }
    }
}
