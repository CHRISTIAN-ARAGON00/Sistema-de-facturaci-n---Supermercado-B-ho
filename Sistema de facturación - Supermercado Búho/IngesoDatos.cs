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
    public partial class frmIngesoDatos : Form
    {
        
        String selecCajero;
        string contra1 = "202020";
        string contra2 = "212121";
        string d ;
        string m ;
        string a ;
        double precio = 0;
        double porcentaje = 0;
        double precioSinIva = 0;

        List<clsProducto> ListaProductos = new List<clsProducto>();
        List<clsDatosCliente> ListaClientes = new List<clsDatosCliente>();


        public frmIngesoDatos(string fechaDia, string fechaMes, string fechaAño, string cajeroId, string cajeroNombre, string cajeroCi,string seleccionarCajero)
        {
            InitializeComponent();
            fechaDia = d;
            fechaMes = m;
            fechaAño = a;

            selecCajero = seleccionarCajero;

            if (seleccionarCajero != contra1)
            {

                txtDatosCajero.Text = "Cajero:  "+cajeroNombre+"\t\tCI:   " + cajeroCi + "\t\t#id:   " + cajeroId;
            }
            if (seleccionarCajero != contra2)
            {

                txtDatosCajero.Text = "Cajero:   "+ cajeroNombre + "\t\tCI:   "+ cajeroCi + "\t\t#id:   "+ cajeroId;
            }
            txtFecha.Text = "Fecha : ";

            lblDia.Text = ""+fechaDia;
            lblMes.Text = "" + fechaMes;
            lblAño.Text = "" + fechaAño;

            btnConsultar.Enabled = false;
  
            btnEliminarCliente.Enabled = false;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (ValidarCedula() == false)
            {
                return;
            }
            if (ValidarNombre() == false)
            {
                return;
            }
            if (ValidarApellido() == false)
            {
                return;
            }
            if (ValidarDirección() == false)
            {
                return;
            }
            if (ValidarTelefono() == false)
            {
                return;
            }
            if (Existe(txtCedula.Text))
            {
                erpError.SetError(txtCedula, "El Cliente, ya está registrado");
                txtCedula.Focus();
                return;
            }
            erpError.SetError(txtCedula, "");


            //Creamos el objeto de la clase lista 
            clsDatosCliente clientes = new clsDatosCliente();   
            clientes.Nombre = txtNombre.Text;
            clientes.Apellido = txtApellido.Text;
            clientes.Cedula = txtCedula.Text;
            clientes.Direccion = txtDireccion.Text;
            clientes.NumeroDeTelefono = txtTelefono.Text;
            ListaClientes.Add(clientes);
            dgvClientes.DataSource = null;
            dgvClientes.DataSource = ListaClientes;

            LimpiarControles();
            txtCedula.Focus();
            btnConsultar.Enabled = true;
            btnEliminarCliente.Enabled = true;

        }
        //Validar que no ingresen Clientes con el mismo número de cedula
        private bool Existe(string Cedula)
        {
            foreach (clsDatosCliente clientes in ListaClientes)
            {
                if (clientes.Cedula == txtCedula.Text)
                {
                    return true;
                }
            }
            return false;
        }

        //validar telefono

        private bool ValidarTelefono()
        {
            long telefono;

            if (!long.TryParse(txtTelefono.Text, out telefono) || txtTelefono.Text == "")
            {
                erpError.SetError(txtTelefono, "Debe ingresar un numero de telefono.");
                txtTelefono.Clear();
                txtTelefono.Focus(); 
                return false;
            }
            else
            {
                erpError.SetError(txtTelefono, "");
                return true;
            }
        }
        //validar direccion

        private bool ValidarDirección()
        {
            if (string.IsNullOrEmpty(txtDireccion.Text))
            {
                erpError.SetError(txtDireccion, "Debe ingresar una ciudad o direccion.");
                return false;
            }
            else
            {
                return true;
            }
        }
        //validar apellido

        private bool ValidarApellido()
        {
            if (string.IsNullOrEmpty(txtApellido.Text))
            {
                erpError.SetError(txtApellido, "Debe ingresar un apellido.");
                return false;
            }
            else
            {
                return true;
            }
        }
        //validar nombre

        private bool ValidarNombre()
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                erpError.SetError(txtNombre, "Debe ingresar un nombre.");
                return false;
            }
            else
            {
                return true;
            }
        }

        //validar cedula 
        
        private bool ValidarCedula()
        {
            long cedula;

            if (!long.TryParse(txtCedula.Text,out cedula) || txtCedula.Text == "" )
            {
                erpError.SetError(txtCedula, "Ingrese un número de cédula valido.");
                txtCedula.Clear();
                txtCedula.Focus();  
                return false;
            }
            else
            {
                erpError.SetError(txtCedula, "");
                return true;
            }
        }

        private void LimpiarControles()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtCedula.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
        }
        //Evento de la opción consultar
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (ValidarCedula()==false)
            {
                return;
            }
            clsDatosCliente clientes = GetCliente(txtCedula.Text);
            
            if(clientes == null)
            {
                erpError.SetError(txtCedula, "Cliente no registrado.");
                LimpiarControles();
                txtCedula.Focus();
                return;
            }
            else
            {
                erpError.SetError(txtCedula, "");
                txtCedula.Text = clientes.Cedula;
                txtNombre.Text = clientes.Nombre;
                txtApellido.Text = clientes.Apellido;
                txtDireccion.Text = clientes.Direccion;
                txtTelefono.Text = clientes.NumeroDeTelefono;
            } 
        }

        //Obtener cliente

        private clsDatosCliente GetCliente(string text)
        {
           return ListaClientes.Find(clientes => clientes.Cedula.Contains(txtCedula.Text));

           
        }
        //Evento  Eliminar Cliente
        private void btnEliminarCliente_Click(object sender, EventArgs e)
        {
            if (txtCedula.Text == "")
            {
                erpError.SetError(txtCedula, "INGRESE EL NUMERO DE CEDULA PARA ELIMINAR LOS DATOS");
                LimpiarControles();
                txtCedula.Focus();
                btnEliminarCliente.Enabled = false;
                return;
            }
            else
            {
                erpError.SetError(txtCedula, "");
                DialogResult Respuesta = MessageBox.Show("¿Está seguro de eliminar el registro?","Confirmación",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2);
                if(Respuesta == DialogResult.Yes)
                {
                    foreach (clsDatosCliente clientes  in ListaClientes)
                    {
                        if (clientes.Cedula == txtCedula.Text)
                        {
                            ListaClientes.Remove(clientes);
                            break;
                        }
                    }
                    LimpiarControles();
                    dgvClientes.DataSource = null;
                    dgvClientes.DataSource = ListaClientes;

                }
            
            }

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmInicio Form = new frmInicio();
            Form.ShowDialog();
        }
        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            clsProducto producto = new clsProducto();
            producto.Nombre = productos.SelectedItem.ToString();
            producto.Cantidad = txtCantidad.Text;
            producto.PrecioSinIva = lblPrecioSinIva.Text;
            producto.PrecioFinal = lblPrecioFinal.Text;
            ListaProductos.Add(producto);

            if (productos.SelectedIndex == -1)
            {
                MessageBox.Show("Debe selccionar un producto !!!");
            }
            else
            {
                if (txtCantidad.Text == "")
                {
                    MessageBox.Show("Debe ingresar una cantidad !!!");
                }
                else
                {
                    string product = productos.Text;
                    int Cantidad = Convert.ToInt32(txtCantidad.Text);

                    double pSinIva = Cantidad * precioSinIva;

                    double pFinal = Cantidad * precio;

                    ListViewItem fila = new ListViewItem(product);
                    fila.SubItems.Add(Cantidad.ToString());
                    fila.SubItems.Add(pSinIva.ToString());
                    fila.SubItems.Add(pFinal.ToString());

                    listaSeleccionados.Items.Add(fila);

                }

            }
        }
        private void listaSeleccionados_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblPrecioFinal.Text = (0).ToString("C");
        }

        private void productos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string producto = productos.Text;
            if (producto.Equals("Leche"))
            {
                precio = 0.75;
                porcentaje = precio * 0.12;
                precioSinIva = precio - porcentaje;
            }
            if (producto.Equals("Pan"))
            {
                precio = 0.15;
                porcentaje = precio * 0.12;
                precioSinIva = precio - porcentaje;
            }
            if (producto.Equals("Queso"))
            {
                precio = 2.00;
                porcentaje = precio * 0.12;
                precioSinIva = precio - porcentaje;
            }
            if (producto.Equals("Huevos"))
            {
                precio = 00.15;
                porcentaje = precio * 0.12;
                precioSinIva = precio - porcentaje;
            }
            if (producto.Equals("Shampoo"))
            {
                precio = 10.00;
                porcentaje = precio * 0.12;
                precioSinIva = precio - porcentaje;
            }
            if (producto.Equals("Jabón"))
            {
                precio = 3;
                porcentaje = precio * 0.12;
                precioSinIva = precio - porcentaje;
            }
            if (producto.Equals("Detergente"))
            {
                precio = 0.75;
                porcentaje = precio * 0.12;
                precioSinIva = precio - porcentaje;
            }
            if (producto.Equals("Pilas"))
            {
                precio = 0.75;
                porcentaje = precio * 0.12;
                precioSinIva = precio - porcentaje;
            }
            lblPrecioFinal.Text = precio.ToString();
            lblPrecioSinIva.Text = precioSinIva.ToString();
        }
        private void btnMostrarFactura_Click(object sender, EventArgs e)
        {
            int i = 0;
            i++;


            this.Hide();
            factura Form = new factura(i.ToString());
            Form.ShowDialog();
        }
    }

}
