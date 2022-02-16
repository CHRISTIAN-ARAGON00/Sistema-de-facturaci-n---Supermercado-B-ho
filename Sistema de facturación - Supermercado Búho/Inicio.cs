using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_facturación___Supermercado_Búho
{
	public partial class frmInicio : Form
	{
        string contra1 = "202020";
        string contra2 = "212121";
        public frmInicio()
		{
			InitializeComponent();
		}

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {

            if (txtContraseña.Text != contra1)
            {
                MessageBox.Show("CONTRASEÑA INCORRECTA");
                txtContraseña.Clear();
                txtContraseña.Focus();
            }
            else
            {
         
                frmIngesoDatos Form = new frmIngesoDatos();
                Form.ShowDialog();

            }
            if (txtContraseña.Text != contra2)
            {
                MessageBox.Show("CONTRASEÑA INCORRECTA");
                txtContraseña.Clear();
                txtContraseña.Focus();
            }
            else
            {

                frmIngesoDatos Form = new frmIngesoDatos(txtContraseña.Text);
                Form.ShowDialog();

            }
        }
    }
}