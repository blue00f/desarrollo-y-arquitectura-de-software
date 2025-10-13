namespace Reso_PrimerParcial
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
            grillaEquipos = new DataGridView();
            btnAgregarEquipo = new Button();
            grillaEquiposDadosDeBaja = new DataGridView();
            btnModificarEquipo = new Button();
            btnBorrarEquipo = new Button();
            btnGuardarEquipo = new Button();
            btnVerXml = new Button();
            label1 = new Label();
            label2 = new Label();
            txtDesde = new TextBox();
            txtHasta = new TextBox();
            txtBusquedaPorCodigo = new TextBox();
            txtProveedoresDelEquipo = new TextBox();
            label3 = new Label();
            label4 = new Label();
            grillaEquiposPorValorResidual = new DataGridView();
            label5 = new Label();
            grillaEquiposPorCodigo = new DataGridView();
            label6 = new Label();
            label7 = new Label();
            grillaEquiposDelete = new DataGridView();
            label8 = new Label();
            grillaEquiposUpdate = new DataGridView();
            label9 = new Label();
            grillaEquipoInsert = new DataGridView();
            label10 = new Label();
            grillaProveedores = new DataGridView();
            btnAgregarProveedor = new Button();
            btnBorrarProveedor = new Button();
            btnModificarProveedor = new Button();
            label11 = new Label();
            btnAsignarProveedorAlEquipo = new Button();
            ((System.ComponentModel.ISupportInitialize)grillaEquipos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grillaEquiposDadosDeBaja).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grillaEquiposPorValorResidual).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grillaEquiposPorCodigo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grillaEquiposDelete).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grillaEquiposUpdate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grillaEquipoInsert).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grillaProveedores).BeginInit();
            SuspendLayout();
            // 
            // grillaEquipos
            // 
            grillaEquipos.AllowUserToAddRows = false;
            grillaEquipos.AllowUserToDeleteRows = false;
            grillaEquipos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaEquipos.Location = new Point(17, 35);
            grillaEquipos.Margin = new Padding(2, 1, 2, 1);
            grillaEquipos.Name = "grillaEquipos";
            grillaEquipos.ReadOnly = true;
            grillaEquipos.RowHeadersWidth = 82;
            grillaEquipos.Size = new Size(929, 153);
            grillaEquipos.TabIndex = 0;
            grillaEquipos.RowEnter += grillaEquipos_RowEnter;
            // 
            // btnAgregarEquipo
            // 
            btnAgregarEquipo.Location = new Point(951, 33);
            btnAgregarEquipo.Margin = new Padding(2, 1, 2, 1);
            btnAgregarEquipo.Name = "btnAgregarEquipo";
            btnAgregarEquipo.Size = new Size(81, 22);
            btnAgregarEquipo.TabIndex = 1;
            btnAgregarEquipo.Text = "Agregar";
            btnAgregarEquipo.UseVisualStyleBackColor = true;
            btnAgregarEquipo.Click += btnAgregarEquipo_Click;
            // 
            // grillaEquiposDadosDeBaja
            // 
            grillaEquiposDadosDeBaja.AllowUserToAddRows = false;
            grillaEquiposDadosDeBaja.AllowUserToDeleteRows = false;
            grillaEquiposDadosDeBaja.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaEquiposDadosDeBaja.Location = new Point(17, 236);
            grillaEquiposDadosDeBaja.Margin = new Padding(2, 1, 2, 1);
            grillaEquiposDadosDeBaja.Name = "grillaEquiposDadosDeBaja";
            grillaEquiposDadosDeBaja.ReadOnly = true;
            grillaEquiposDadosDeBaja.RowHeadersWidth = 82;
            grillaEquiposDadosDeBaja.Size = new Size(929, 89);
            grillaEquiposDadosDeBaja.TabIndex = 2;
            // 
            // btnModificarEquipo
            // 
            btnModificarEquipo.Location = new Point(951, 88);
            btnModificarEquipo.Name = "btnModificarEquipo";
            btnModificarEquipo.Size = new Size(81, 23);
            btnModificarEquipo.TabIndex = 3;
            btnModificarEquipo.Text = "Modificar";
            btnModificarEquipo.UseVisualStyleBackColor = true;
            btnModificarEquipo.Click += btnModificarEquipo_Click;
            // 
            // btnBorrarEquipo
            // 
            btnBorrarEquipo.Location = new Point(951, 59);
            btnBorrarEquipo.Name = "btnBorrarEquipo";
            btnBorrarEquipo.Size = new Size(81, 23);
            btnBorrarEquipo.TabIndex = 4;
            btnBorrarEquipo.Text = "Borrar";
            btnBorrarEquipo.UseVisualStyleBackColor = true;
            btnBorrarEquipo.Click += btnBorrarEquipo_Click;
            // 
            // btnGuardarEquipo
            // 
            btnGuardarEquipo.Location = new Point(951, 136);
            btnGuardarEquipo.Name = "btnGuardarEquipo";
            btnGuardarEquipo.Size = new Size(81, 23);
            btnGuardarEquipo.TabIndex = 5;
            btnGuardarEquipo.Text = "Guardar";
            btnGuardarEquipo.UseVisualStyleBackColor = true;
            btnGuardarEquipo.Click += btnGuardarEquipo_Click;
            // 
            // btnVerXml
            // 
            btnVerXml.Location = new Point(951, 165);
            btnVerXml.Name = "btnVerXml";
            btnVerXml.Size = new Size(81, 23);
            btnVerXml.TabIndex = 6;
            btnVerXml.Text = "Ver XML";
            btnVerXml.UseVisualStyleBackColor = true;
            btnVerXml.Click += btnVerXml_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(956, 360);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 7;
            label1.Text = "Desde:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(958, 389);
            label2.Name = "label2";
            label2.Size = new Size(40, 15);
            label2.TabIndex = 8;
            label2.Text = "Hasta:";
            // 
            // txtDesde
            // 
            txtDesde.Location = new Point(1004, 357);
            txtDesde.Name = "txtDesde";
            txtDesde.Size = new Size(100, 23);
            txtDesde.TabIndex = 9;
            txtDesde.Text = "0";
            txtDesde.TextAlign = HorizontalAlignment.Right;
            txtDesde.TextChanged += txtDesde_TextChanged;
            // 
            // txtHasta
            // 
            txtHasta.Location = new Point(1004, 386);
            txtHasta.Name = "txtHasta";
            txtHasta.Size = new Size(100, 23);
            txtHasta.TabIndex = 10;
            txtHasta.Text = "0";
            txtHasta.TextAlign = HorizontalAlignment.Right;
            txtHasta.TextChanged += txtHasta_TextChanged;
            // 
            // txtBusquedaPorCodigo
            // 
            txtBusquedaPorCodigo.Location = new Point(958, 478);
            txtBusquedaPorCodigo.Name = "txtBusquedaPorCodigo";
            txtBusquedaPorCodigo.Size = new Size(148, 23);
            txtBusquedaPorCodigo.TabIndex = 11;
            txtBusquedaPorCodigo.TextChanged += txtBusquedaPorCodigo_TextChanged;
            // 
            // txtProveedoresDelEquipo
            // 
            txtProveedoresDelEquipo.Location = new Point(1137, 35);
            txtProveedoresDelEquipo.Multiline = true;
            txtProveedoresDelEquipo.Name = "txtProveedoresDelEquipo";
            txtProveedoresDelEquipo.Size = new Size(309, 466);
            txtProveedoresDelEquipo.TabIndex = 12;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(17, 210);
            label3.Name = "label3";
            label3.Size = new Size(338, 25);
            label3.TabIndex = 13;
            label3.Text = "Equipos dados de baja de la empresa";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(17, 331);
            label4.Name = "label4";
            label4.Size = new Size(296, 25);
            label4.TabIndex = 15;
            label4.Text = "Desde - Hasta por valor residual";
            // 
            // grillaEquiposPorValorResidual
            // 
            grillaEquiposPorValorResidual.AllowUserToAddRows = false;
            grillaEquiposPorValorResidual.AllowUserToDeleteRows = false;
            grillaEquiposPorValorResidual.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaEquiposPorValorResidual.Location = new Point(17, 357);
            grillaEquiposPorValorResidual.Margin = new Padding(2, 1, 2, 1);
            grillaEquiposPorValorResidual.Name = "grillaEquiposPorValorResidual";
            grillaEquiposPorValorResidual.ReadOnly = true;
            grillaEquiposPorValorResidual.RowHeadersWidth = 82;
            grillaEquiposPorValorResidual.Size = new Size(929, 82);
            grillaEquiposPorValorResidual.TabIndex = 14;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(17, 452);
            label5.Name = "label5";
            label5.Size = new Size(222, 25);
            label5.TabIndex = 17;
            label5.Text = "Incremental por código";
            // 
            // grillaEquiposPorCodigo
            // 
            grillaEquiposPorCodigo.AllowUserToAddRows = false;
            grillaEquiposPorCodigo.AllowUserToDeleteRows = false;
            grillaEquiposPorCodigo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaEquiposPorCodigo.Location = new Point(17, 478);
            grillaEquiposPorCodigo.Margin = new Padding(2, 1, 2, 1);
            grillaEquiposPorCodigo.Name = "grillaEquiposPorCodigo";
            grillaEquiposPorCodigo.ReadOnly = true;
            grillaEquiposPorCodigo.RowHeadersWidth = 82;
            grillaEquiposPorCodigo.Size = new Size(929, 75);
            grillaEquiposPorCodigo.TabIndex = 16;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(17, 9);
            label6.Name = "label6";
            label6.Size = new Size(83, 25);
            label6.TabIndex = 18;
            label6.Text = "Equipos";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(17, 675);
            label7.Name = "label7";
            label7.Size = new Size(77, 25);
            label7.TabIndex = 20;
            label7.Text = "DELETE";
            // 
            // grillaEquiposDelete
            // 
            grillaEquiposDelete.AllowUserToAddRows = false;
            grillaEquiposDelete.AllowUserToDeleteRows = false;
            grillaEquiposDelete.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaEquiposDelete.Location = new Point(17, 701);
            grillaEquiposDelete.Margin = new Padding(2, 1, 2, 1);
            grillaEquiposDelete.Name = "grillaEquiposDelete";
            grillaEquiposDelete.ReadOnly = true;
            grillaEquiposDelete.RowHeadersWidth = 82;
            grillaEquiposDelete.Size = new Size(929, 75);
            grillaEquiposDelete.TabIndex = 19;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(17, 777);
            label8.Name = "label8";
            label8.Size = new Size(85, 25);
            label8.TabIndex = 22;
            label8.Text = "UPDATE";
            // 
            // grillaEquiposUpdate
            // 
            grillaEquiposUpdate.AllowUserToAddRows = false;
            grillaEquiposUpdate.AllowUserToDeleteRows = false;
            grillaEquiposUpdate.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaEquiposUpdate.Location = new Point(17, 803);
            grillaEquiposUpdate.Margin = new Padding(2, 1, 2, 1);
            grillaEquiposUpdate.Name = "grillaEquiposUpdate";
            grillaEquiposUpdate.ReadOnly = true;
            grillaEquiposUpdate.RowHeadersWidth = 82;
            grillaEquiposUpdate.Size = new Size(929, 75);
            grillaEquiposUpdate.TabIndex = 21;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(17, 573);
            label9.Name = "label9";
            label9.Size = new Size(77, 25);
            label9.TabIndex = 24;
            label9.Text = "INSERT";
            // 
            // grillaEquipoInsert
            // 
            grillaEquipoInsert.AllowUserToAddRows = false;
            grillaEquipoInsert.AllowUserToDeleteRows = false;
            grillaEquipoInsert.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaEquipoInsert.Location = new Point(17, 599);
            grillaEquipoInsert.Margin = new Padding(2, 1, 2, 1);
            grillaEquipoInsert.Name = "grillaEquipoInsert";
            grillaEquipoInsert.ReadOnly = true;
            grillaEquipoInsert.RowHeadersWidth = 82;
            grillaEquipoInsert.Size = new Size(929, 75);
            grillaEquipoInsert.TabIndex = 23;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(967, 573);
            label10.Name = "label10";
            label10.Size = new Size(124, 25);
            label10.TabIndex = 26;
            label10.Text = "Proveedores";
            // 
            // grillaProveedores
            // 
            grillaProveedores.AllowUserToAddRows = false;
            grillaProveedores.AllowUserToDeleteRows = false;
            grillaProveedores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaProveedores.Location = new Point(967, 599);
            grillaProveedores.Margin = new Padding(2, 1, 2, 1);
            grillaProveedores.Name = "grillaProveedores";
            grillaProveedores.ReadOnly = true;
            grillaProveedores.RowHeadersWidth = 82;
            grillaProveedores.Size = new Size(480, 279);
            grillaProveedores.TabIndex = 25;
            // 
            // btnAgregarProveedor
            // 
            btnAgregarProveedor.Location = new Point(967, 880);
            btnAgregarProveedor.Margin = new Padding(2, 1, 2, 1);
            btnAgregarProveedor.Name = "btnAgregarProveedor";
            btnAgregarProveedor.Size = new Size(81, 22);
            btnAgregarProveedor.TabIndex = 27;
            btnAgregarProveedor.Text = "Agregar";
            btnAgregarProveedor.UseVisualStyleBackColor = true;
            btnAgregarProveedor.Click += btnAgregarProveedor_Click;
            // 
            // btnBorrarProveedor
            // 
            btnBorrarProveedor.Location = new Point(1052, 880);
            btnBorrarProveedor.Margin = new Padding(2, 1, 2, 1);
            btnBorrarProveedor.Name = "btnBorrarProveedor";
            btnBorrarProveedor.Size = new Size(81, 22);
            btnBorrarProveedor.TabIndex = 28;
            btnBorrarProveedor.Text = "Borrar";
            btnBorrarProveedor.UseVisualStyleBackColor = true;
            btnBorrarProveedor.Click += btnBorrarProveedor_Click;
            // 
            // btnModificarProveedor
            // 
            btnModificarProveedor.Location = new Point(1137, 880);
            btnModificarProveedor.Margin = new Padding(2, 1, 2, 1);
            btnModificarProveedor.Name = "btnModificarProveedor";
            btnModificarProveedor.Size = new Size(81, 22);
            btnModificarProveedor.TabIndex = 29;
            btnModificarProveedor.Text = "Modificar";
            btnModificarProveedor.UseVisualStyleBackColor = true;
            btnModificarProveedor.Click += btnModificarProveedor_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(1137, 9);
            label11.Name = "label11";
            label11.Size = new Size(224, 25);
            label11.TabIndex = 30;
            label11.Text = "Proveedores del equipo";
            // 
            // btnAsignarProveedorAlEquipo
            // 
            btnAsignarProveedorAlEquipo.Location = new Point(1137, 505);
            btnAsignarProveedorAlEquipo.Margin = new Padding(2, 1, 2, 1);
            btnAsignarProveedorAlEquipo.Name = "btnAsignarProveedorAlEquipo";
            btnAsignarProveedorAlEquipo.Size = new Size(309, 22);
            btnAsignarProveedorAlEquipo.TabIndex = 31;
            btnAsignarProveedorAlEquipo.Text = "Asignar proveedor al equipo seleccionado";
            btnAsignarProveedorAlEquipo.UseVisualStyleBackColor = true;
            btnAsignarProveedorAlEquipo.Click += btnAsignarProveedorAlEquipo_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1466, 916);
            Controls.Add(btnAsignarProveedorAlEquipo);
            Controls.Add(label11);
            Controls.Add(btnModificarProveedor);
            Controls.Add(btnBorrarProveedor);
            Controls.Add(btnAgregarProveedor);
            Controls.Add(label10);
            Controls.Add(grillaProveedores);
            Controls.Add(label9);
            Controls.Add(grillaEquipoInsert);
            Controls.Add(label8);
            Controls.Add(grillaEquiposUpdate);
            Controls.Add(label7);
            Controls.Add(grillaEquiposDelete);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(grillaEquiposPorCodigo);
            Controls.Add(label4);
            Controls.Add(grillaEquiposPorValorResidual);
            Controls.Add(label3);
            Controls.Add(txtProveedoresDelEquipo);
            Controls.Add(txtBusquedaPorCodigo);
            Controls.Add(txtHasta);
            Controls.Add(txtDesde);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnVerXml);
            Controls.Add(btnGuardarEquipo);
            Controls.Add(btnBorrarEquipo);
            Controls.Add(btnModificarEquipo);
            Controls.Add(grillaEquiposDadosDeBaja);
            Controls.Add(btnAgregarEquipo);
            Controls.Add(grillaEquipos);
            Margin = new Padding(2, 1, 2, 1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)grillaEquipos).EndInit();
            ((System.ComponentModel.ISupportInitialize)grillaEquiposDadosDeBaja).EndInit();
            ((System.ComponentModel.ISupportInitialize)grillaEquiposPorValorResidual).EndInit();
            ((System.ComponentModel.ISupportInitialize)grillaEquiposPorCodigo).EndInit();
            ((System.ComponentModel.ISupportInitialize)grillaEquiposDelete).EndInit();
            ((System.ComponentModel.ISupportInitialize)grillaEquiposUpdate).EndInit();
            ((System.ComponentModel.ISupportInitialize)grillaEquipoInsert).EndInit();
            ((System.ComponentModel.ISupportInitialize)grillaProveedores).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView grillaEquipos;
        private Button btnAgregarEquipo;
        private DataGridView grillaEquiposDadosDeBaja;
        private Button btnModificarEquipo;
        private Button btnBorrarEquipo;
        private Button btnGuardarEquipo;
        private Button btnVerXml;
        private Label label1;
        private Label label2;
        private TextBox txtDesde;
        private TextBox txtHasta;
        private TextBox txtBusquedaPorCodigo;
        private TextBox txtProveedoresDelEquipo;
        private Label label3;
        private Label label4;
        private DataGridView grillaEquiposPorValorResidual;
        private Label label5;
        private DataGridView grillaEquiposPorCodigo;
        private Label label6;
        private Label label7;
        private DataGridView grillaEquiposDelete;
        private Label label8;
        private DataGridView grillaEquiposUpdate;
        private Label label9;
        private DataGridView grillaEquipoInsert;
        private Label label10;
        private DataGridView grillaProveedores;
        private Button btnAgregarProveedor;
        private Button btnBorrarProveedor;
        private Button btnModificarProveedor;
        private Label label11;
        private Button btnAsignarProveedorAlEquipo;
    }
}
