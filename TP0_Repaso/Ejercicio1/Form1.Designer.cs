namespace Ejercicio1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            grillaClientes = new DataGridView();
            grillaCuentas = new DataGridView();
            btnAltaCliente = new Button();
            btnBajaCliente = new Button();
            btnModificarCliente = new Button();
            btnModificarCuenta = new Button();
            btnBajaCuenta = new Button();
            btnAltaCuenta = new Button();
            label1 = new Label();
            label2 = new Label();
            groupBox1 = new GroupBox();
            radCuentaCorriente = new RadioButton();
            radCajaAhorro = new RadioButton();
            btnDepositar = new Button();
            btnExtraer = new Button();
            grillaOperaciones = new DataGridView();
            label3 = new Label();
            grillaClientesFiltrados = new DataGridView();
            label4 = new Label();
            txtDni = new TextBox();
            txtNombre = new TextBox();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)grillaClientes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grillaCuentas).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grillaOperaciones).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grillaClientesFiltrados).BeginInit();
            SuspendLayout();
            // 
            // grillaClientes
            // 
            grillaClientes.AllowUserToAddRows = false;
            grillaClientes.AllowUserToDeleteRows = false;
            grillaClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaClientes.Location = new Point(32, 62);
            grillaClientes.Name = "grillaClientes";
            grillaClientes.ReadOnly = true;
            grillaClientes.Size = new Size(807, 181);
            grillaClientes.TabIndex = 0;
            grillaClientes.RowEnter += grillaClientes_RowEnter;
            // 
            // grillaCuentas
            // 
            grillaCuentas.AllowUserToAddRows = false;
            grillaCuentas.AllowUserToDeleteRows = false;
            grillaCuentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaCuentas.Location = new Point(32, 334);
            grillaCuentas.Name = "grillaCuentas";
            grillaCuentas.ReadOnly = true;
            grillaCuentas.Size = new Size(366, 181);
            grillaCuentas.TabIndex = 1;
            // 
            // btnAltaCliente
            // 
            btnAltaCliente.Location = new Point(32, 249);
            btnAltaCliente.Name = "btnAltaCliente";
            btnAltaCliente.Size = new Size(99, 36);
            btnAltaCliente.TabIndex = 2;
            btnAltaCliente.Text = "Alta";
            btnAltaCliente.UseVisualStyleBackColor = true;
            btnAltaCliente.Click += btnAltaCliente_Click;
            // 
            // btnBajaCliente
            // 
            btnBajaCliente.Location = new Point(164, 249);
            btnBajaCliente.Name = "btnBajaCliente";
            btnBajaCliente.Size = new Size(99, 36);
            btnBajaCliente.TabIndex = 3;
            btnBajaCliente.Text = "Baja";
            btnBajaCliente.UseVisualStyleBackColor = true;
            btnBajaCliente.Click += btnBajaCliente_Click;
            // 
            // btnModificarCliente
            // 
            btnModificarCliente.Location = new Point(299, 249);
            btnModificarCliente.Name = "btnModificarCliente";
            btnModificarCliente.Size = new Size(99, 36);
            btnModificarCliente.TabIndex = 4;
            btnModificarCliente.Text = "Modificación";
            btnModificarCliente.UseVisualStyleBackColor = true;
            btnModificarCliente.Click += btnModificarCliente_Click;
            // 
            // btnModificarCuenta
            // 
            btnModificarCuenta.Location = new Point(299, 521);
            btnModificarCuenta.Name = "btnModificarCuenta";
            btnModificarCuenta.Size = new Size(99, 36);
            btnModificarCuenta.TabIndex = 7;
            btnModificarCuenta.Text = "Modificación";
            btnModificarCuenta.UseVisualStyleBackColor = true;
            btnModificarCuenta.Click += btnModificarCuenta_Click;
            // 
            // btnBajaCuenta
            // 
            btnBajaCuenta.Location = new Point(164, 521);
            btnBajaCuenta.Name = "btnBajaCuenta";
            btnBajaCuenta.Size = new Size(99, 36);
            btnBajaCuenta.TabIndex = 6;
            btnBajaCuenta.Text = "Baja";
            btnBajaCuenta.UseVisualStyleBackColor = true;
            btnBajaCuenta.Click += btnBajaCuenta_Click;
            // 
            // btnAltaCuenta
            // 
            btnAltaCuenta.Location = new Point(32, 521);
            btnAltaCuenta.Name = "btnAltaCuenta";
            btnAltaCuenta.Size = new Size(99, 36);
            btnAltaCuenta.TabIndex = 5;
            btnAltaCuenta.Text = "Alta";
            btnAltaCuenta.UseVisualStyleBackColor = true;
            btnAltaCuenta.Click += btnAltaCuenta_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(32, 34);
            label1.Name = "label1";
            label1.Size = new Size(81, 25);
            label1.TabIndex = 8;
            label1.Text = "Clientes";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(32, 306);
            label2.Name = "label2";
            label2.Size = new Size(83, 25);
            label2.TabIndex = 9;
            label2.Text = "Cuentas";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radCuentaCorriente);
            groupBox1.Controls.Add(radCajaAhorro);
            groupBox1.Location = new Point(426, 447);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(151, 82);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "Tipo de cuenta";
            // 
            // radCuentaCorriente
            // 
            radCuentaCorriente.AutoSize = true;
            radCuentaCorriente.Location = new Point(18, 47);
            radCuentaCorriente.Name = "radCuentaCorriente";
            radCuentaCorriente.Size = new Size(113, 19);
            radCuentaCorriente.TabIndex = 1;
            radCuentaCorriente.Text = "Cuenta corriente";
            radCuentaCorriente.UseVisualStyleBackColor = true;
            // 
            // radCajaAhorro
            // 
            radCajaAhorro.AutoSize = true;
            radCajaAhorro.Checked = true;
            radCajaAhorro.Location = new Point(18, 22);
            radCajaAhorro.Name = "radCajaAhorro";
            radCajaAhorro.Size = new Size(102, 19);
            radCajaAhorro.TabIndex = 0;
            radCajaAhorro.TabStop = true;
            radCajaAhorro.Text = "Caja de ahorro";
            radCajaAhorro.UseVisualStyleBackColor = true;
            // 
            // btnDepositar
            // 
            btnDepositar.Location = new Point(426, 334);
            btnDepositar.Name = "btnDepositar";
            btnDepositar.Size = new Size(99, 36);
            btnDepositar.TabIndex = 11;
            btnDepositar.Text = "Depositar";
            btnDepositar.UseVisualStyleBackColor = true;
            btnDepositar.Click += btnDepositar_Click;
            // 
            // btnExtraer
            // 
            btnExtraer.Location = new Point(426, 385);
            btnExtraer.Name = "btnExtraer";
            btnExtraer.Size = new Size(99, 36);
            btnExtraer.TabIndex = 12;
            btnExtraer.Text = "Extraer";
            btnExtraer.UseVisualStyleBackColor = true;
            btnExtraer.Click += btnExtraer_Click;
            // 
            // grillaOperaciones
            // 
            grillaOperaciones.AllowUserToAddRows = false;
            grillaOperaciones.AllowUserToDeleteRows = false;
            grillaOperaciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaOperaciones.Location = new Point(859, 62);
            grillaOperaciones.Name = "grillaOperaciones";
            grillaOperaciones.ReadOnly = true;
            grillaOperaciones.Size = new Size(535, 181);
            grillaOperaciones.TabIndex = 13;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(859, 34);
            label3.Name = "label3";
            label3.Size = new Size(122, 25);
            label3.TabIndex = 14;
            label3.Text = "Operaciones";
            // 
            // grillaClientesFiltrados
            // 
            grillaClientesFiltrados.AllowUserToAddRows = false;
            grillaClientesFiltrados.AllowUserToDeleteRows = false;
            grillaClientesFiltrados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaClientesFiltrados.Location = new Point(859, 363);
            grillaClientesFiltrados.Name = "grillaClientesFiltrados";
            grillaClientesFiltrados.ReadOnly = true;
            grillaClientesFiltrados.Size = new Size(535, 181);
            grillaClientesFiltrados.TabIndex = 15;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(859, 327);
            label4.Name = "label4";
            label4.Size = new Size(198, 25);
            label4.TabIndex = 16;
            label4.Text = "Búsqueda de clientes";
            // 
            // txtDni
            // 
            txtDni.Location = new Point(1159, 307);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(235, 23);
            txtDni.TabIndex = 17;
            txtDni.TextChanged += txtDni_TextChanged;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(1159, 334);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(235, 23);
            txtNombre.TabIndex = 18;
            txtNombre.TextChanged += txtNombre_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(1126, 310);
            label5.Name = "label5";
            label5.Size = new Size(27, 15);
            label5.TabIndex = 19;
            label5.Text = "DNI";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(1102, 337);
            label6.Name = "label6";
            label6.Size = new Size(51, 15);
            label6.TabIndex = 20;
            label6.Text = "Nombre";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(33, 565);
            label7.Name = "label7";
            label7.Size = new Size(595, 15);
            label7.TabIndex = 21;
            label7.Text = "Modificación: cambiar el cliente asociado a la cuenta selccionando un cliente de la grilla \"Búsqueda de clientes\"";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1458, 589);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(txtNombre);
            Controls.Add(txtDni);
            Controls.Add(label4);
            Controls.Add(grillaClientesFiltrados);
            Controls.Add(label3);
            Controls.Add(grillaOperaciones);
            Controls.Add(btnExtraer);
            Controls.Add(btnDepositar);
            Controls.Add(groupBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnModificarCuenta);
            Controls.Add(btnBajaCuenta);
            Controls.Add(btnAltaCuenta);
            Controls.Add(btnModificarCliente);
            Controls.Add(btnBajaCliente);
            Controls.Add(btnAltaCliente);
            Controls.Add(grillaCuentas);
            Controls.Add(grillaClientes);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)grillaClientes).EndInit();
            ((System.ComponentModel.ISupportInitialize)grillaCuentas).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)grillaOperaciones).EndInit();
            ((System.ComponentModel.ISupportInitialize)grillaClientesFiltrados).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView grillaClientes;
        private DataGridView grillaCuentas;
        private Button btnAltaCliente;
        private Button btnBajaCliente;
        private Button btnModificarCliente;
        private Button btnModificarCuenta;
        private Button btnBajaCuenta;
        private Button btnAltaCuenta;
        private Label label1;
        private Label label2;
        private GroupBox groupBox1;
        private RadioButton radCuentaCorriente;
        private RadioButton radCajaAhorro;
        private Button btnDepositar;
        private Button btnExtraer;
        private DataGridView grillaOperaciones;
        private Label label3;
        private DataGridView grillaClientesFiltrados;
        private Label label4;
        private TextBox txtDni;
        private TextBox txtNombre;
        private Label label5;
        private Label label6;
        private Label label7;
    }
}
