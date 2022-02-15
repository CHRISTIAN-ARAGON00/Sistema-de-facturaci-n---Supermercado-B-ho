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
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

        private void Form1_Load(object sender, EventArgs e)
        {
			btnIngresar.Enabled = false;
        }
        private void controlBotones()
        {
            if(txtContraseña.Text.Trim() != string.Empty )
            {
                btnIngresar.Enabled = true;
                errorProvider1.SetError(txtContraseña, "");
            }
        }
        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {
            controlBotones();

        }
    }
}
