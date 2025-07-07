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
            dgvMalla.Columns[0].Name = "Cursos habilitados:";
            dgvMalla.Rows.Clear();
            dgvMalla.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            //do
            //{
            //    float total = 0;
            //    Console.WriteLine(" \n Cursos Disponibles :");
            //    Vertice temp = gf.inicio_lista;
            //    while (temp != null)
            //    {
            //        Console.WriteLine("-" + temp.nombre);
            //        temp = temp.sig;
            //    }

            //    Console.Write("\n Ingrese el curso desde el que desea iniciar ");
            //    string cursoinicio = Console.ReadLine();

            //    Vertice inicio = gf.Buscar(cursoinicio);

            //    if (inicio != null)
            //    {
            //        gf.recorrerGrafo(inicio, ref total);
            //    }
            //    else
            //    {
            //        Console.WriteLine("curso no encontrado");
            //    }
            //    Console.WriteLine(" desea consultar otro curso ( selecione cualquier número para continuar ) o 0 para salir");
            //    opcion = int.Parse(Console.ReadLine());
            //} while (opcion != 0);
            //break;

            Vertice temp = malla.inicio_lista; 
            while (temp != null)
            {
                dgvMalla.Rows.Add(temp.nombre);
                temp = temp.sig; 
            }

        }

        private void btnIndagar_Click(object sender, EventArgs e)
        {
            string curso = txtIndagar.Text.Trim();
            Vertice curso1 = malla.Buscar(curso); 
            lstListaMalla.Items.Clear();
            if (curso1 != null)
            {
                Arista temp = curso1.lista_arista;
                while (temp != null)
                {
                    lstListaMalla.Items.Add(temp.destino.nombre + "Nivel de complejidad:" + temp.costo);
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
