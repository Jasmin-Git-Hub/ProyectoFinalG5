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
    public partial class Malla : Form
    {
        Grafo malla = new Grafo(10); 
        public Malla()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Malla_Load(object sender, EventArgs e)
        {
            malla.RegistrarVertices();
            malla.llenarMatriz(); 
            malla.crearGrafo();

            dgvMalla.ColumnCount = 1;
            dgvMalla.Columns[0].Name = "Cursos de carrera:";
            dgvMalla.Rows.Clear();
            dgvMalla.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


            Vertice temp = malla.inicio_lista; 
            while (temp != null)
            {
                dgvMalla.Rows.Add(temp.nombre);
                temp = temp.sig; 
            }

            dgvIndagar.ColumnCount = 2;
            dgvIndagar.Columns[0].Name = "Cursos habilitados:";
            dgvIndagar.Columns[1].Name = "Nivel de complejidad";
            dgvIndagar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvIndagar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            
        }

        private void btnIndagar_Click(object sender, EventArgs e)
        {
            string curso = txtIndagar.Text.Trim();
            Vertice curso1 = malla.Buscar(curso);
            dgvIndagar.Rows.Clear(); 
            if (curso1 != null)
            {
                Arista temp = curso1.lista_arista;
                while (temp != null)
                {
                    dgvIndagar.Rows.Add(temp.destino.nombre, temp.costo);
                    temp = temp.sig; 
                }
            }
            else
            {
                MessageBox.Show("Curso no encontrado"); 
            }
            txtIndagar.Clear();
        }
    }
}
