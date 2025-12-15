namespace UI
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
            grillaCuentas = new DataGridView();
            btnAgregarCuenta = new Button();
            btnBorrarCuenta = new Button();
            btnModificarCuenta = new Button();
            label1 = new Label();
            groupBox1 = new GroupBox();
            radCajaAhorro = new RadioButton();
            radCuentaCorriente = new RadioButton();
            label2 = new Label();
            btnModificarTitular = new Button();
            btnBorrarTitular = new Button();
            btnAgregarTitular = new Button();
            grillaTitulares = new DataGridView();
            btnAsignar = new Button();
            grillaTitularesDeCuenta = new DataGridView();
            grillaCuentasDelTitular = new DataGridView();
            label3 = new Label();
            label4 = new Label();
            btnDepositar = new Button();
            btnExtraer = new Button();
            btnTransferir = new Button();
            ucMonto1 = new ControlesPersonalizados.ucMonto();
            label5 = new Label();
            grillaSaldoPersonalizado = new DataGridView();
            grillaSaldoDesdeHasta = new DataGridView();
            grillaCodigoIncremental = new DataGridView();
            txtBusquedaIncrementalPorCodigo = new TextBox();
            label6 = new Label();
            btnDesdeHastaSaldo = new Button();
            btnGuardarXml = new Button();
            btnAbrirXml = new Button();
            ((System.ComponentModel.ISupportInitialize)grillaCuentas).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grillaTitulares).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grillaTitularesDeCuenta).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grillaCuentasDelTitular).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grillaSaldoPersonalizado).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grillaSaldoDesdeHasta).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grillaCodigoIncremental).BeginInit();
            SuspendLayout();
            // 
            // grillaCuentas
            // 
            grillaCuentas.AllowUserToAddRows = false;
            grillaCuentas.AllowUserToDeleteRows = false;
            grillaCuentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaCuentas.Location = new Point(39, 53);
            grillaCuentas.Name = "grillaCuentas";
            grillaCuentas.ReadOnly = true;
            grillaCuentas.Size = new Size(448, 166);
            grillaCuentas.TabIndex = 0;
            grillaCuentas.RowEnter += grillaCuentas_RowEnter;
            // 
            // btnAgregarCuenta
            // 
            btnAgregarCuenta.Location = new Point(39, 225);
            btnAgregarCuenta.Name = "btnAgregarCuenta";
            btnAgregarCuenta.Size = new Size(75, 23);
            btnAgregarCuenta.TabIndex = 1;
            btnAgregarCuenta.Text = "Agregar";
            btnAgregarCuenta.UseVisualStyleBackColor = true;
            btnAgregarCuenta.Click += btnAgregarCuenta_Click;
            // 
            // btnBorrarCuenta
            // 
            btnBorrarCuenta.Location = new Point(120, 225);
            btnBorrarCuenta.Name = "btnBorrarCuenta";
            btnBorrarCuenta.Size = new Size(75, 23);
            btnBorrarCuenta.TabIndex = 2;
            btnBorrarCuenta.Text = "Borrar";
            btnBorrarCuenta.UseVisualStyleBackColor = true;
            btnBorrarCuenta.Click += btnBorrarCuenta_Click;
            // 
            // btnModificarCuenta
            // 
            btnModificarCuenta.Location = new Point(201, 225);
            btnModificarCuenta.Name = "btnModificarCuenta";
            btnModificarCuenta.Size = new Size(75, 23);
            btnModificarCuenta.TabIndex = 3;
            btnModificarCuenta.Text = "Modificar";
            btnModificarCuenta.UseVisualStyleBackColor = true;
            btnModificarCuenta.Click += btnModificarCuenta_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(39, 25);
            label1.Name = "label1";
            label1.Size = new Size(83, 25);
            label1.TabIndex = 4;
            label1.Text = "Cuentas";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radCajaAhorro);
            groupBox1.Controls.Add(radCuentaCorriente);
            groupBox1.Location = new Point(39, 254);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(239, 56);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Tipo de cuenta";
            // 
            // radCajaAhorro
            // 
            radCajaAhorro.AutoSize = true;
            radCajaAhorro.Checked = true;
            radCajaAhorro.Location = new Point(128, 22);
            radCajaAhorro.Name = "radCajaAhorro";
            radCajaAhorro.Size = new Size(102, 19);
            radCajaAhorro.TabIndex = 1;
            radCajaAhorro.TabStop = true;
            radCajaAhorro.Text = "Caja de ahorro";
            radCajaAhorro.UseVisualStyleBackColor = true;
            // 
            // radCuentaCorriente
            // 
            radCuentaCorriente.AutoSize = true;
            radCuentaCorriente.Location = new Point(6, 22);
            radCuentaCorriente.Name = "radCuentaCorriente";
            radCuentaCorriente.Size = new Size(113, 19);
            radCuentaCorriente.TabIndex = 0;
            radCuentaCorriente.TabStop = true;
            radCuentaCorriente.Text = "Cuenta corriente";
            radCuentaCorriente.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(626, 25);
            label2.Name = "label2";
            label2.Size = new Size(88, 25);
            label2.TabIndex = 10;
            label2.Text = "Titulares";
            // 
            // btnModificarTitular
            // 
            btnModificarTitular.Location = new Point(788, 225);
            btnModificarTitular.Name = "btnModificarTitular";
            btnModificarTitular.Size = new Size(75, 23);
            btnModificarTitular.TabIndex = 9;
            btnModificarTitular.Text = "Modificar";
            btnModificarTitular.UseVisualStyleBackColor = true;
            btnModificarTitular.Click += btnModificarTitular_Click;
            // 
            // btnBorrarTitular
            // 
            btnBorrarTitular.Location = new Point(707, 225);
            btnBorrarTitular.Name = "btnBorrarTitular";
            btnBorrarTitular.Size = new Size(75, 23);
            btnBorrarTitular.TabIndex = 8;
            btnBorrarTitular.Text = "Borrar";
            btnBorrarTitular.UseVisualStyleBackColor = true;
            btnBorrarTitular.Click += btnBorrarTitular_Click;
            // 
            // btnAgregarTitular
            // 
            btnAgregarTitular.Location = new Point(626, 225);
            btnAgregarTitular.Name = "btnAgregarTitular";
            btnAgregarTitular.Size = new Size(75, 23);
            btnAgregarTitular.TabIndex = 7;
            btnAgregarTitular.Text = "Agregar";
            btnAgregarTitular.UseVisualStyleBackColor = true;
            btnAgregarTitular.Click += btnAgregarTitular_Click;
            // 
            // grillaTitulares
            // 
            grillaTitulares.AllowUserToAddRows = false;
            grillaTitulares.AllowUserToDeleteRows = false;
            grillaTitulares.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaTitulares.Location = new Point(626, 53);
            grillaTitulares.Name = "grillaTitulares";
            grillaTitulares.ReadOnly = true;
            grillaTitulares.Size = new Size(448, 166);
            grillaTitulares.TabIndex = 6;
            grillaTitulares.RowEnter += grillaTitulares_RowEnter;
            // 
            // btnAsignar
            // 
            btnAsignar.Location = new Point(504, 99);
            btnAsignar.Name = "btnAsignar";
            btnAsignar.Size = new Size(103, 43);
            btnAsignar.TabIndex = 11;
            btnAsignar.Text = "Asignar";
            btnAsignar.UseVisualStyleBackColor = true;
            btnAsignar.Click += btnAsignar_Click;
            // 
            // grillaTitularesDeCuenta
            // 
            grillaTitularesDeCuenta.AllowUserToAddRows = false;
            grillaTitularesDeCuenta.AllowUserToDeleteRows = false;
            grillaTitularesDeCuenta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaTitularesDeCuenta.Location = new Point(39, 338);
            grillaTitularesDeCuenta.Name = "grillaTitularesDeCuenta";
            grillaTitularesDeCuenta.ReadOnly = true;
            grillaTitularesDeCuenta.Size = new Size(448, 166);
            grillaTitularesDeCuenta.TabIndex = 12;
            // 
            // grillaCuentasDelTitular
            // 
            grillaCuentasDelTitular.AllowUserToAddRows = false;
            grillaCuentasDelTitular.AllowUserToDeleteRows = false;
            grillaCuentasDelTitular.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaCuentasDelTitular.Location = new Point(626, 338);
            grillaCuentasDelTitular.Name = "grillaCuentasDelTitular";
            grillaCuentasDelTitular.ReadOnly = true;
            grillaCuentasDelTitular.Size = new Size(448, 166);
            grillaCuentasDelTitular.TabIndex = 13;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(39, 310);
            label3.Name = "label3";
            label3.Size = new Size(200, 25);
            label3.TabIndex = 14;
            label3.Text = "Titulares de la cuenta";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(626, 310);
            label4.Name = "label4";
            label4.Size = new Size(174, 25);
            label4.TabIndex = 15;
            label4.Text = "Cuentas del titular";
            // 
            // btnDepositar
            // 
            btnDepositar.Location = new Point(366, 225);
            btnDepositar.Name = "btnDepositar";
            btnDepositar.Size = new Size(142, 23);
            btnDepositar.TabIndex = 16;
            btnDepositar.Text = "Depositar";
            btnDepositar.UseVisualStyleBackColor = true;
            btnDepositar.Click += btnDepositar_Click;
            // 
            // btnExtraer
            // 
            btnExtraer.Location = new Point(366, 254);
            btnExtraer.Name = "btnExtraer";
            btnExtraer.Size = new Size(67, 23);
            btnExtraer.TabIndex = 17;
            btnExtraer.Text = "Extraer";
            btnExtraer.UseVisualStyleBackColor = true;
            btnExtraer.Click += btnExtraer_Click;
            // 
            // btnTransferir
            // 
            btnTransferir.Location = new Point(433, 254);
            btnTransferir.Name = "btnTransferir";
            btnTransferir.Size = new Size(75, 23);
            btnTransferir.TabIndex = 18;
            btnTransferir.Text = "Transferir";
            btnTransferir.UseVisualStyleBackColor = true;
            btnTransferir.Click += btnTransferir_Click;
            // 
            // ucMonto1
            // 
            ucMonto1.Location = new Point(366, 283);
            ucMonto1.Name = "ucMonto1";
            ucMonto1.Size = new Size(142, 30);
            ucMonto1.TabIndex = 19;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(39, 527);
            label5.Name = "label5";
            label5.Size = new Size(190, 25);
            label5.TabIndex = 20;
            label5.Text = "Consultas de cuenta";
            // 
            // grillaSaldoPersonalizado
            // 
            grillaSaldoPersonalizado.AllowUserToAddRows = false;
            grillaSaldoPersonalizado.AllowUserToDeleteRows = false;
            grillaSaldoPersonalizado.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaSaldoPersonalizado.Location = new Point(39, 555);
            grillaSaldoPersonalizado.Name = "grillaSaldoPersonalizado";
            grillaSaldoPersonalizado.ReadOnly = true;
            grillaSaldoPersonalizado.Size = new Size(448, 166);
            grillaSaldoPersonalizado.TabIndex = 21;
            // 
            // grillaSaldoDesdeHasta
            // 
            grillaSaldoDesdeHasta.AllowUserToAddRows = false;
            grillaSaldoDesdeHasta.AllowUserToDeleteRows = false;
            grillaSaldoDesdeHasta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaSaldoDesdeHasta.Location = new Point(626, 555);
            grillaSaldoDesdeHasta.Name = "grillaSaldoDesdeHasta";
            grillaSaldoDesdeHasta.ReadOnly = true;
            grillaSaldoDesdeHasta.Size = new Size(448, 166);
            grillaSaldoDesdeHasta.TabIndex = 22;
            // 
            // grillaCodigoIncremental
            // 
            grillaCodigoIncremental.AllowUserToAddRows = false;
            grillaCodigoIncremental.AllowUserToDeleteRows = false;
            grillaCodigoIncremental.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaCodigoIncremental.Location = new Point(39, 745);
            grillaCodigoIncremental.Name = "grillaCodigoIncremental";
            grillaCodigoIncremental.ReadOnly = true;
            grillaCodigoIncremental.Size = new Size(448, 166);
            grillaCodigoIncremental.TabIndex = 23;
            // 
            // txtBusquedaIncrementalPorCodigo
            // 
            txtBusquedaIncrementalPorCodigo.Location = new Point(39, 938);
            txtBusquedaIncrementalPorCodigo.Name = "txtBusquedaIncrementalPorCodigo";
            txtBusquedaIncrementalPorCodigo.Size = new Size(186, 23);
            txtBusquedaIncrementalPorCodigo.TabIndex = 24;
            txtBusquedaIncrementalPorCodigo.TextChanged += txtBusquedaIncrementalPorCodigo_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(39, 920);
            label6.Name = "label6";
            label6.Size = new Size(186, 15);
            label6.TabIndex = 25;
            label6.Text = "Búsqueda incremental por código";
            // 
            // btnDesdeHastaSaldo
            // 
            btnDesdeHastaSaldo.Location = new Point(626, 727);
            btnDesdeHastaSaldo.Name = "btnDesdeHastaSaldo";
            btnDesdeHastaSaldo.Size = new Size(145, 46);
            btnDesdeHastaSaldo.TabIndex = 26;
            btnDesdeHastaSaldo.Text = "Buscar por saldo (Desde-Hasta)";
            btnDesdeHastaSaldo.UseVisualStyleBackColor = true;
            btnDesdeHastaSaldo.Click += btnDesdeHastaSaldo_Click;
            // 
            // btnGuardarXml
            // 
            btnGuardarXml.Location = new Point(932, 859);
            btnGuardarXml.Name = "btnGuardarXml";
            btnGuardarXml.Size = new Size(142, 23);
            btnGuardarXml.TabIndex = 27;
            btnGuardarXml.Text = "Guardar en XML";
            btnGuardarXml.UseVisualStyleBackColor = true;
            btnGuardarXml.Click += btnGuardarXml_Click;
            // 
            // btnAbrirXml
            // 
            btnAbrirXml.Location = new Point(932, 888);
            btnAbrirXml.Name = "btnAbrirXml";
            btnAbrirXml.Size = new Size(142, 23);
            btnAbrirXml.TabIndex = 28;
            btnAbrirXml.Text = "Abrir XML";
            btnAbrirXml.UseVisualStyleBackColor = true;
            btnAbrirXml.Click += btnAbrirXml_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1116, 973);
            Controls.Add(btnAbrirXml);
            Controls.Add(btnGuardarXml);
            Controls.Add(btnDesdeHastaSaldo);
            Controls.Add(label6);
            Controls.Add(txtBusquedaIncrementalPorCodigo);
            Controls.Add(grillaCodigoIncremental);
            Controls.Add(grillaSaldoDesdeHasta);
            Controls.Add(grillaSaldoPersonalizado);
            Controls.Add(label5);
            Controls.Add(ucMonto1);
            Controls.Add(btnTransferir);
            Controls.Add(btnExtraer);
            Controls.Add(btnDepositar);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(grillaCuentasDelTitular);
            Controls.Add(grillaTitularesDeCuenta);
            Controls.Add(btnAsignar);
            Controls.Add(label2);
            Controls.Add(btnModificarTitular);
            Controls.Add(btnBorrarTitular);
            Controls.Add(btnAgregarTitular);
            Controls.Add(grillaTitulares);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Controls.Add(btnModificarCuenta);
            Controls.Add(btnBorrarCuenta);
            Controls.Add(btnAgregarCuenta);
            Controls.Add(grillaCuentas);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)grillaCuentas).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)grillaTitulares).EndInit();
            ((System.ComponentModel.ISupportInitialize)grillaTitularesDeCuenta).EndInit();
            ((System.ComponentModel.ISupportInitialize)grillaCuentasDelTitular).EndInit();
            ((System.ComponentModel.ISupportInitialize)grillaSaldoPersonalizado).EndInit();
            ((System.ComponentModel.ISupportInitialize)grillaSaldoDesdeHasta).EndInit();
            ((System.ComponentModel.ISupportInitialize)grillaCodigoIncremental).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView grillaCuentas;
        private Button btnAgregarCuenta;
        private Button btnBorrarCuenta;
        private Button btnModificarCuenta;
        private Label label1;
        private GroupBox groupBox1;
        private RadioButton radCajaAhorro;
        private RadioButton radCuentaCorriente;
        private Label label2;
        private Button btnModificarTitular;
        private Button btnBorrarTitular;
        private Button btnAgregarTitular;
        private DataGridView grillaTitulares;
        private Button btnAsignar;
        private DataGridView grillaTitularesDeCuenta;
        private DataGridView grillaCuentasDelTitular;
        private Label label3;
        private Label label4;
        private Button btnDepositar;
        private Button btnExtraer;
        private Button btnTransferir;
        private ControlesPersonalizados.ucMonto ucMonto1;
        private Label label5;
        private DataGridView grillaSaldoPersonalizado;
        private DataGridView grillaSaldoDesdeHasta;
        private DataGridView grillaCodigoIncremental;
        private TextBox txtBusquedaIncrementalPorCodigo;
        private Label label6;
        private Button btnDesdeHastaSaldo;
        private Button btnGuardarXml;
        private Button btnAbrirXml;
    }
}
