using Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfaz
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Sirve para cerrar el formulario una vez que el usuario seleccione el botón
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //El botón ingrear en su propiedad enabled (habilitado) va a tener el valor falso, es decir, va a estar deshabilitado al inicio
            btnIngresar.Enabled = false;
        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {
            //En este caso se va a habilitar el botón una vez el usuario ingrese un texto 
            
            controlarBotones(); 
        }
        private void controlarBotones()
        {
            //para eliminar espacios adelante o atrás usamos TRIM 
            string correo = txtCorreo.Text.Trim();
            if (correo.Length != 16)
            {
                errorProvider1.SetError(txtCorreo, "El correo debe tener 16 carácteres");
                btnIngresar.Enabled=false;
                return;
            }
            else
            {
                if (!(correo[0] == 'N' || correo[0] == 'n'))
                {
                    errorProvider1.SetError(txtCorreo, "El correo debe empezar con 'N'.");
                    btnIngresar.Enabled = false;
                    return;
                }
                int i = 1;
                while (i <= 8)
                {
                    char c = correo[1];
                    if (c < '0' || c > '9')
                    {
                        errorProvider1.SetError(txtCorreo, "Debe haber 8 números despues de la 'N'");
                        btnIngresar.Enabled = false;
                        return;
                    }
                    i = i + 1;
                }

                //Validamos que termine en @upn.pe 
                string dom = correo.Substring(9);
                if (dom != "@upn.pe")
                {
                    //res.mensaje = "El correo debe terminar en @upn.pe";
                    errorProvider1.SetError(txtCorreo, "El correo debe terminar en @upn.pe");
                    btnIngresar.Enabled = false;
                    return;
                }
            }
            btnIngresar.Enabled = true;
            txtCorreo.Focus(); 
            
            errorProvider1.Clear(); 
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            Inicio form = new Inicio();
            this.Hide(); 
            form.ShowDialog();
            this.Show(); 
        }
    }
}
