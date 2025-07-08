using Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfaz
{
    public partial class Agenda : Form
    {
        ListaSimpleActividad ls2=new ListaSimpleActividad();
        ColaAgenda cola=new ColaAgenda();
        public Agenda()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Agenda_Load(object sender, EventArgs e)
        {
            dgvActividades.ColumnCount = 1;
            dgvActividades.Columns[0].Name = "Actividad";
            dgvActividades.Rows.Clear();
            dgvActividades.Columns[0].AutoSizeMode= DataGridViewAutoSizeColumnMode.Fill;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string titulo=txtAgendar.Text.Trim();

            if ( string.IsNullOrEmpty(titulo))
            {
                MessageBox.Show("La actividad no puede estar vacía");
                return;
            }

            Actividad act=new Actividad();
            act.titulo=txtAgendar.Text.Trim();
            cola.encolar(act);
            MessageBox.Show(" Actividad agendada correctamente");
            mostrar(cola);
            txtAgendar.Clear();



            
        }
        private void mostrar(ColaAgenda cola)

        {
            dgvActividades.Rows.Clear();
            NodoActividad temp = cola.frente;
            while (temp != null)
            {
                string titulo =temp.dato.titulo;
                dgvActividades.Rows.Add(titulo);
                temp = temp.sig;
            }
        }

        private void btnCompletar_Click(object sender, EventArgs e)
        {
            string completado = txtCompletar.Text.Trim();
            if (string .IsNullOrEmpty(completado))
            {
                MessageBox.Show(" El nombre de la actividad a completar no puede estar vacía");
                return;
            }
            
            if (cola.frente!=null)
            {
                string tituloFrente=cola.frente.dato.titulo;

                if (tituloFrente.ToLower() == completado.ToLower())
                {
                    cola.desencolar();
                    mostrar(cola);
                    MessageBox.Show("Actividad completada");
                    txtCompletar.Clear();
                }
                else

                {
                    MessageBox.Show("Las actividades debden ser completadas en orden, verifique por favor...");
                }
            }
            else
            {
                MessageBox.Show("No hay actividades pendientes");
            }

        }
    }
}
