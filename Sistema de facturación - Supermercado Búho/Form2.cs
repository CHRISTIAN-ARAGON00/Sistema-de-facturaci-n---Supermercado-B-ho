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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void txtIdentidad_TextChanged(object sender, EventArgs e)
        {
            int cedula = txtIdentidad.Text.Length;  //ingresa cedula del cliente
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            string nombre=txtNombre.Text.Trim();    //ingresa nombre del cliente
        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {
            string apellido=txtApellido.Text.Trim();//ingresa apellido del cliente
        }

        private void TxtDireccion_TextChanged(object sender, EventArgs e)
        {
            string direccion = TxtDireccion.Text.Trim();//ingresa direccion del cliente
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            int telefono = txtTelefono.Text.Length;//ingresa telefono del cliente
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
