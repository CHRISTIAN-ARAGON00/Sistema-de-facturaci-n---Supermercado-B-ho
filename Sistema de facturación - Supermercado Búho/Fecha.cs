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
    public partial class frmFecha : Form
    {
        String seleccionarCajero;
        string contra1 = "202020";
        string contra2 = "212121";

        string[]dias;
        string[]meses;
        string[]años;


        List<clsFecha> Listafecha = new List<clsFecha>();
        List<clsCajero> ListaCajero = new List<clsCajero>();

        public frmFecha(string txtContraseña)
        {
            InitializeComponent();

            seleccionarCajero = txtContraseña;

            if (seleccionarCajero != contra1)
            {
                txtBienvenida.Text = "¡Bienvenido! :\t" + "Cristhian Martinez";
            }
            if (seleccionarCajero != contra2)
            {

                txtBienvenida.Text = "¡Bienvenido! :\t" + "Christian Aragón ";
            }

            string listado_dia = Properties.Resources.DIAS.ToString();
            dias = listado_dia.Split(new[] {"\r\n" },StringSplitOptions.RemoveEmptyEntries);
            string listado_mes = Properties.Resources.meses.ToString();
            meses = listado_mes.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            string listado_año = Properties.Resources.años.ToString();
            años = listado_año.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
       
        
        
        }


        private void Fecha_Load(object sender, EventArgs e)
        {
            popularDia();
            popularMes();
            popularAño();

        void popularDia()
            {
                for(int i = 0; i< dias.Length;i++ ){
                    dia.Items.Add(dias[i]);
                }
            }
            void popularMes()
            {
                for(int i = 0; i< meses.Length;i++ ){
                    mes.Items.Add(meses[i]);
                }
            }
            void popularAño()
            {
                for (int i = 0; i < años.Length; i++)
                {
                    año.Items.Add(años[i]);
                }
            }

        }

        private string GetSeleccionarCajero()
        {
            return seleccionarCajero;
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmInicio Form = new frmInicio() ;
            Form.ShowDialog();  
            
        }

        private void btnComenzar_Click(object sender, EventArgs e)
        {
            if (dia.SelectedItem != null && mes.SelectedItem != null && año.SelectedItem != null)
            {

                clsFecha fecha = new clsFecha();
                fecha.Dia = dia.SelectedItem.ToString();
                fecha.Mes = mes.SelectedItem.ToString();
                fecha.Año = año.SelectedItem.ToString();
                Listafecha.Add(fecha);


                fecha.Dia = dia.Text;
                fecha.Mes = mes.Text;
                fecha.Año = año.Text;


                clsCajero cajero = new clsCajero();
                cajero.Ci = dia.SelectedItem.ToString();
                cajero.Nombre = mes.SelectedItem.ToString();
                cajero.Id = año.SelectedItem.ToString();
                ListaCajero.Add(cajero);

                if (seleccionarCajero != contra1)
                {
                    cajero.Nombre = "Cristhian Martínez";
                    cajero.Ci = "1234567890";
                    cajero.Id = " 7410 ";
                }
                if (seleccionarCajero != contra2)
                {
                    cajero.Nombre = "Christian Aragón";
                    cajero.Ci = "1234567890";
                    cajero.Id = " 8520 ";
                }

                this.Hide();
                frmIngesoDatos Form = new frmIngesoDatos(fecha.Dia, fecha.Mes, fecha.Año, cajero.Id, cajero.Nombre, cajero.Ci, seleccionarCajero);
                Form.ShowDialog();

            }
            else
            {
                MessageBox.Show("DEBE LLENAR TODOS LOS CAMPOS");
            }
        }
    }
}
