using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace Sistema_de_facturación___Supermercado_Búho
{
    public partial class frmIngesoDatos : Form
    {
        
        String selecCajero;
        string contra1 = "202020";
        string contra2 = "212121";

        double precio = 0;
        double porcentaje = 0;
        double precioSinIva = 0;


        List<clsProducto> ListaProductos = new List<clsProducto>();
        List<clsDatosCliente> ListaClientes = new List<clsDatosCliente>();


        public frmIngesoDatos(string dia, string mes,string año, string cajeroId, string cajeroNombre, string cajeroCi,string seleccionarCajero)
        {
            InitializeComponent();


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
            lblDia.Text = dia;
            lblMes.Text = mes;
            lblAño.Text = año;

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
        //Valodar cantidad
        private bool ValidarCantidad()
        {
            int c;
            if (!int.TryParse(txtCantidad.Text,out c) || txtCantidad.Text == "")
            {
                erpError.SetError(txtCantidad, "Debe ingresar la cantidad de productos.");
                txtCantidad.Clear();
                txtCantidad.Focus();
                return false;
            }
            else
            {
                if (txtCantidad.Text == "0")
                {
                    erpError.SetError(txtCantidad, "La cantidad de productos no puede ser 0");
                    txtCantidad.Clear();
                    txtCantidad.Focus();
                    return false;
                }
                else {
                    erpError.SetError(txtCantidad, "");
                    return true;
                }

            }
        }

        //validar producto
        private bool ValidarProducto()
        {
            if (string.IsNullOrEmpty(productos.Text))
            {
                erpError.SetError(productos, "Debe Seleccionar Un Producto.");
                return false;
            }
            else
            {
                erpError.SetError(productos, "");
                return true;
            }
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
        private bool Datas()
        {
            clsProducto producto = GetProducto(productos.Text);
            if(producto == null){

                MessageBox.Show("DEBE AGREGAR AL MENOS UN PRODUCTO");
                return false;
            }
            else
            {
                return true;
            }
        }

        private clsProducto GetProducto(string text)
        {
            return ListaProductos.Find(produ => produ.Producto.Contains(productos.Text));


        }
        private void LimpiarControles()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtCedula.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtCantidad.Clear();    

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





        private void btnMostrarFactura_Click(object sender, EventArgs e)
        {
            if (ValidarCedula() == false)
            {
                return;
            }
            else { 
            if (ValidarNombre() == false)
            {
                return;
            }else
                {
                    if (ValidarApellido() == false)
            {
                return;
            }else
                    {
                        if (ValidarDirección() == false)
            {
                return;
            }
            else
                        {
                            if (ValidarTelefono() == false)
            {
                return;
                            }
                            else
                            {
                                if (Datas() == false)
                                {
                                    return ;
                                } else { 

                                printDocument1 = new PrintDocument();
                                PrinterSettings ps = new PrinterSettings();
                                printDocument1.PrinterSettings = ps;
                                printDocument1.PrintPage += Imprimir;
                                printDocument1.Print();

                                }
                            }
                        }
                    }
                }
            }

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            productos.SelectedIndex = -1;
            lblTotalAPagar.Text = "";
            dgvProductos.DataSource = null;
            txtEfectvo.Text = "";


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
                precio = 1.50;
                porcentaje = precio * 0.12;
                precioSinIva = precio - porcentaje;

            }

            txtPrecioFinal.Text = precio.ToString("c");
            txtPrecioSinIva.Text = precioSinIva.ToString("c");
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (ValidarProducto() == false)
            {
                return;
            }
            else
            {
                if (ValidarCantidad() == false)
                {
                    return;
                }
                else
                {
                    double precio = 0;
                    double porcentaje = 0;
                    double precioSinIva = 0;

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
                        precio = 0.15;
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
                        precio = 1.50;
                        porcentaje = precio * 0.12;
                        precioSinIva = precio - porcentaje;

                    }

                    txtPrecioFinal.Text = precio.ToString("c");
                    txtPrecioSinIva.Text = precioSinIva.ToString("c");

                    int c = Convert.ToInt32(txtCantidad.Text);
                    double preS = c * precioSinIva;
                    double pref = c * precio;

                    txtPrecioS.Text = preS.ToString("c");
                    txtPrecioF.Text = pref.ToString("c");

                    //Creamos el objeto de la clase lista 
                    clsProducto produ = new clsProducto();
                    produ.Producto = productos.Text;
                    produ.Cantidad = txtCantidad.Text;
                    produ.PrecioSinIva = preS;
                    produ.PrecioFinal = pref ;
                    ListaProductos.Add(produ);
                    dgvProductos.DataSource = null;
                    dgvProductos.DataSource = ListaProductos;

                    productos.SelectedIndex = -1;
                    txtCantidad.Text = ""; 

                    TotalAPagar();
                    TotalAPagarS();



            }
        }
        }
        private void TotalAPagarS()
        {
            double TotalVenta = 0;
            foreach (DataGridViewRow row in dgvProductos.Rows)
            {
                TotalVenta += Convert.ToDouble(row.Cells["PrecioSinIva"].Value.ToString());

            }

            lblSubtotal.Text = TotalVenta.ToString();
        }
        private void TotalAPagar()
        {
            double TotalVenta = 0;
            foreach (DataGridViewRow row in dgvProductos.Rows)
            {
                TotalVenta += Convert.ToDouble(row.Cells["PrecioFinal"].Value.ToString());

            }

            lblTotalAPagar.Text = TotalVenta.ToString();
        }

        private void txtEfectvo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lblCambio.Text = (double.Parse(txtEfectvo.Text) - double.Parse(lblTotalAPagar.Text)).ToString();


            }
            catch 
            {

                lblCambio.Text = "0.00";
            }

        }

        private void Imprimir(object sender,PrintPageEventArgs e)
        {
            Font font = new Font("Arial", 14);
            Font f = new Font("Arial", 8);
            Font fo = new Font("Arial", 10);
            int ancho = 900;
            int y = 20;

            e.Graphics.DrawString("- - - - - - - -Super Mercado Búho - - - - - - - -",font,Brushes.Black ,new RectangleF(0,y+=20,ancho,20));
            e.Graphics.DrawString("***Datos Cliente***", font, Brushes.Black, new RectangleF(50, y += 40, ancho, 20));
            e.Graphics.DrawString("Nombre:  "+txtNombre.Text+"   "+txtApellido.Text, font, Brushes.Black, new RectangleF(0, y += 30, ancho, 20));
            e.Graphics.DrawString("#Cedula:  "+txtCedula.Text, font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            e.Graphics.DrawString("Dirección:  "+txtDireccion.Text, font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            e.Graphics.DrawString("Telefono:  "+txtTelefono.Text, font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            e.Graphics.DrawString("***Productos***", font, Brushes.Black, new RectangleF(50, y += 40, ancho, 20));
            e.Graphics.DrawString("PRODUCTO               CANT       P.SINIVA       P.FINAL", f, Brushes.Black, new RectangleF(0, y += 30, ancho, 20));

            foreach (DataGridViewRow row in dgvProductos.Rows)
            {
                if (row.Cells["Producto"].Value.ToString() == "Leche")
                {
                    e.Graphics.DrawString(row.Cells["Producto"].Value.ToString() + "               " +
                    row.Cells["Cantidad"].Value.ToString() + "       " +
                    row.Cells["PrecioSinIva"].Value.ToString() + "       " + "$" +
                     row.Cells["PrecioFinal"].Value.ToString(),

                    font, Brushes.Black, new RectangleF(0, y += 30, ancho, 20));
                }
                if (row.Cells["Producto"].Value.ToString() == "Pan")
                {
                    e.Graphics.DrawString(row.Cells["Producto"].Value.ToString() + "                 " +
                    row.Cells["Cantidad"].Value.ToString() + "       " +
                    row.Cells["PrecioSinIva"].Value.ToString() + "       " + "$" +
                     row.Cells["PrecioFinal"].Value.ToString(),

                    font, Brushes.Black, new RectangleF(0, y += 30, ancho, 20));
                }
                if (row.Cells["Producto"].Value.ToString() == "Queso")
                {
                    e.Graphics.DrawString(row.Cells["Producto"].Value.ToString() + "            " +
                    row.Cells["Cantidad"].Value.ToString() + "       " +
                    row.Cells["PrecioSinIva"].Value.ToString() + "       " + "$" +
                     row.Cells["PrecioFinal"].Value.ToString(),

                    font, Brushes.Black, new RectangleF(0, y += 30, ancho, 20));
                }
                if (row.Cells["Producto"].Value.ToString() == "Shampoo")
                {
                    e.Graphics.DrawString(row.Cells["Producto"].Value.ToString() + "          " +
                    row.Cells["Cantidad"].Value.ToString() + "       " +
                    row.Cells["PrecioSinIva"].Value.ToString() + "       " + "$" +
                     row.Cells["PrecioFinal"].Value.ToString(),

                    font, Brushes.Black, new RectangleF(0, y += 30, ancho, 20));
                }
                if (row.Cells["Producto"].Value.ToString() == "Jabón")
                {
                    e.Graphics.DrawString(row.Cells["Producto"].Value.ToString() + "              " +
                    row.Cells["Cantidad"].Value.ToString() + "       " +
                    row.Cells["PrecioSinIva"].Value.ToString() + "       " + "$" +
                     row.Cells["PrecioFinal"].Value.ToString(),

                    font, Brushes.Black, new RectangleF(0, y += 30, ancho, 20));
                }
                if (row.Cells["Producto"].Value.ToString() == "Detergente")
                {
                    e.Graphics.DrawString(row.Cells["Producto"].Value.ToString() + "       " +
                    row.Cells["Cantidad"].Value.ToString() + "       " +
                    row.Cells["PrecioSinIva"].Value.ToString() + "       " + "$" +
                     row.Cells["PrecioFinal"].Value.ToString(),

                    font, Brushes.Black, new RectangleF(0, y += 30, ancho, 20));
                }
                if (row.Cells["Producto"].Value.ToString() == "Huevos")
                {
                    e.Graphics.DrawString(row.Cells["Producto"].Value.ToString() + "           " +
                    row.Cells["Cantidad"].Value.ToString() + "       " +
                    row.Cells["PrecioSinIva"].Value.ToString() + "       " + "$" +
                     row.Cells["PrecioFinal"].Value.ToString(),

                    font, Brushes.Black, new RectangleF(0, y += 30, ancho, 20));
                }

            }
            e.Graphics.DrawString("-------------------------------------------------" , font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                                
            e.Graphics.DrawString("Subtotal:  "+lblSubtotal.Text, font, Brushes.Black, new RectangleF(0, y += 30, ancho, 20));
            e.Graphics.DrawString("Total a Pagar :  " + lblTotalAPagar.Text, font, Brushes.Black, new RectangleF(0, y += 30, ancho, 20));
            e.Graphics.DrawString("-------------------------------------------------", font, Brushes.Black, new RectangleF(0, y += 30, ancho, 20));
            e.Graphics.DrawString(""+txtDatosCajero.Text, f, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            e.Graphics.DrawString("***GRACIAS POR SU COMPRA***", fo, Brushes.Black, new RectangleF(50, y += 30, ancho, 20));
            e.Graphics.DrawString("***VUELVA PRONTO***", fo, Brushes.Black, new RectangleF(60, y += 30, ancho, 20));


        }
    }


}
