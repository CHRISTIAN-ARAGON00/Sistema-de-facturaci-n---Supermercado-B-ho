namespace Sistema_de_facturación___Supermercado_Búho
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.TxtDireccion = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtIdentidad = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txaInformacion = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(231, 231);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(188, 20);
            this.txtTelefono.TabIndex = 38;
            this.txtTelefono.TextChanged += new System.EventHandler(this.txtTelefono_TextChanged);
            // 
            // TxtDireccion
            // 
            this.TxtDireccion.Location = new System.Drawing.Point(231, 202);
            this.TxtDireccion.Name = "TxtDireccion";
            this.TxtDireccion.Size = new System.Drawing.Size(365, 20);
            this.TxtDireccion.TabIndex = 37;
            this.TxtDireccion.TextChanged += new System.EventHandler(this.TxtDireccion_TextChanged);
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(231, 176);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(188, 20);
            this.txtApellido.TabIndex = 36;
            this.txtApellido.TextChanged += new System.EventHandler(this.txtApellido_TextChanged);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(231, 149);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(188, 20);
            this.txtNombre.TabIndex = 35;
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            // 
            // txtIdentidad
            // 
            this.txtIdentidad.Location = new System.Drawing.Point(231, 124);
            this.txtIdentidad.Name = "txtIdentidad";
            this.txtIdentidad.Size = new System.Drawing.Size(188, 20);
            this.txtIdentidad.TabIndex = 34;
            this.txtIdentidad.TextChanged += new System.EventHandler(this.txtIdentidad_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(41, 182);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 14);
            this.label7.TabIndex = 33;
            this.label7.Text = "Apellido Del Cliente :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(41, 234);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 14);
            this.label6.TabIndex = 32;
            this.label6.Text = "Número De Telefono :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(41, 206);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 14);
            this.label5.TabIndex = 31;
            this.label5.Text = "Dirección :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(41, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 14);
            this.label4.TabIndex = 30;
            this.label4.Text = "Nombre Del Cliente :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(41, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(184, 14);
            this.label3.TabIndex = 29;
            this.label3.Text = "Número de Identidad Del Cliente :";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Sistema_de_facturación___Supermercado_Búho.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(479, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(81, 87);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(135, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(338, 49);
            this.label2.TabIndex = 27;
            this.label2.Text = "Supermecado Búho";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(324, 38);
            this.label1.TabIndex = 26;
            this.label1.Text = "Sistema De Facturación";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(56, 281);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 39;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.txtIdentidad_TextChanged);
            // 
            // txaInformacion
            // 
            this.txaInformacion.Location = new System.Drawing.Point(231, 316);
            this.txaInformacion.Multiline = true;
            this.txaInformacion.Name = "txaInformacion";
            this.txaInformacion.Size = new System.Drawing.Size(238, 122);
            this.txaInformacion.TabIndex = 40;
            this.txaInformacion.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txaInformacion);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.TxtDireccion);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtIdentidad);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Click += new System.EventHandler(this.txtIdentidad_TextChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox TxtDireccion;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtIdentidad;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txaInformacion;
    }
}