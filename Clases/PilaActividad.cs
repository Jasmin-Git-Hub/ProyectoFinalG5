using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public void MostrarHitorial(ListBox lista)
        {
            NodoPila act = cima;
            Console.WriteLine("Historial de tareas completadas :");
            while (act != null)
            {
              lista.Items.Add(act.activ.titulo+ " De prioridad :" + act.activ.estado);
                act = act.sig;  
            }
        }
    }
}
