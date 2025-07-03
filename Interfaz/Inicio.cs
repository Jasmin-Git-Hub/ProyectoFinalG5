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
    public partial class Inicio : Form
    {
        ListaSimpleActividad ls = new ListaSimpleActividad();
        ArbolBinario arbol1 = new ArbolBinario();
        public Inicio()
        {
            InitializeComponent();
        }
        private void Inicio_Load(object sender, EventArgs e)
        {
            ComboBoxPrioridad.Items.Add("1. Alta");
            ComboBoxPrioridad.Items.Add("2. Media");
            ComboBoxPrioridad.Items.Add("3. Baja");
            ComboBoxPrioridad.SelectedIndex = 0;

            dgvOrdenar.ColumnCount = 3;
            dgvOrdenar.Columns[0].Name = "Título:";
            dgvOrdenar.Columns[1].Name = "Fecha de entrega:";
            dgvOrdenar.Columns[2].Name = "Prioridad";
            dgvOrdenar.Rows.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private  string convertirPrioridad(int estado)
        {
            switch (estado)
            {
                case 1: return "Alta";
                case 2: return "Media";
                case 3: return "Baja";
                default: return "No exixte"; 
            }
        }
        private void MostrarActivdiades(ListaSimpleActividad lista)
        {
            dgvOrdenar.Rows.Clear();
            NodoActividad temp = lista.primero; 
            while (temp != null)
            {
                string titulo = temp.dato.titulo;
                string fecha = temp.dato.fechaDeEntrega;
                string prioridad = convertirPrioridad(temp.dato.estado); 
                dgvOrdenar.Rows.Add(titulo, fecha, prioridad);
                temp = temp.sig; 
            }
        }
        private void btnRegistrar1_Click(object sender, EventArgs e)
        {
            Actividad n1 = new Actividad();
            n1.titulo = txtBoxActividad.Text.Trim();
            n1.fechaDeEntrega = txtBoxLimite.Text.Trim(); 

            string prioridad = ComboBoxPrioridad.SelectedItem.ToString();
            
            if (prioridad.StartsWith ("1"))
            {
                n1.estado = 1;
            }
            else if (prioridad.StartsWith("2"))
            {
                n1.estado = 2;
            }
            else if (prioridad.StartsWith("3"))
            {
                n1.estado = 3;
            }
            
            ls.Insertar(n1);
            ls.OrdenarPrioridad();
            MostrarActivdiades(ls); 
            txtBoxActividad.Clear();
            txtBoxLimite.Clear();
            ComboBoxPrioridad.SelectedIndex = 0;
            MessageBox.Show("Actividad registrada correctamente");
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
