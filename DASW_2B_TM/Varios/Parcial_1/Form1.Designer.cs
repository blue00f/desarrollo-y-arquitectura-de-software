namespace GestionEquipos
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
            btnAgregar = new Button();
            btnBorrar = new Button();
            btnModificar = new Button();
            label1 = new Label();
            grillaEquiposDadosDeBaja = new DataGridView();
            grillaConsultaIncrementalCodigo = new DataGridView();
            grillaEquiposValorResidual = new DataGridView();
            label2 = new Label();
            txtBusquedaPorCodigo = new TextBox();
            label3 = new Label();
            txtValorResidualDesde = new TextBox();
            txtValorResidualHasta = new TextBox();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            btnBuscarValorResidualDesdeHasta = new Button();
            btnGuardarEnXml = new Button();
            ((System.ComponentModel.ISupportInitialize)grillaEquipos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grillaEquiposDadosDeBaja).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grillaConsultaIncrementalCodigo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grillaEquiposValorResidual).BeginInit();
            SuspendLayout();
            // 
            // grillaEquipos
            // 
            grillaEquipos.AllowUserToAddRows = false;
            grillaEquipos.AllowUserToDeleteRows = false;
            grillaEquipos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaEquipos.Location = new Point(12, 51);
            grillaEquipos.Name = "grillaEquipos";
            grillaEquipos.ReadOnly = true;
            grillaEquipos.Size = new Size(889, 150);
            grillaEquipos.TabIndex = 0;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(12, 207);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 1;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnBorrar
            // 
            btnBorrar.Location = new Point(93, 207);
            btnBorrar.Name = "btnBorrar";
            btnBorrar.Size = new Size(75, 23);
            btnBorrar.TabIndex = 2;
            btnBorrar.Text = "Borrar";
            btnBorrar.UseVisualStyleBackColor = true;
            btnBorrar.Click += btnBorrar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(174, 207);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(75, 23);
            btnModificar.TabIndex = 3;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 23);
            label1.Name = "label1";
            label1.Size = new Size(200, 25);
            label1.TabIndex = 4;
            label1.Text = "Equipos informáticos";
            // 
            // grillaEquiposDadosDeBaja
            // 
            grillaEquiposDadosDeBaja.AllowUserToAddRows = false;
            grillaEquiposDadosDeBaja.AllowUserToDeleteRows = false;
            grillaEquiposDadosDeBaja.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaEquiposDadosDeBaja.Location = new Point(12, 290);
            grillaEquiposDadosDeBaja.Name = "grillaEquiposDadosDeBaja";
            grillaEquiposDadosDeBaja.ReadOnly = true;
            grillaEquiposDadosDeBaja.Size = new Size(551, 150);
            grillaEquiposDadosDeBaja.TabIndex = 5;
            // 
            // grillaConsultaIncrementalCodigo
            // 
            grillaConsultaIncrementalCodigo.AllowUserToAddRows = false;
            grillaConsultaIncrementalCodigo.AllowUserToDeleteRows = false;
            grillaConsultaIncrementalCodigo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaConsultaIncrementalCodigo.Location = new Point(597, 290);
            grillaConsultaIncrementalCodigo.Name = "grillaConsultaIncrementalCodigo";
            grillaConsultaIncrementalCodigo.ReadOnly = true;
            grillaConsultaIncrementalCodigo.Size = new Size(586, 150);
            grillaConsultaIncrementalCodigo.TabIndex = 6;
            // 
            // grillaEquiposValorResidual
            // 
            grillaEquiposValorResidual.AllowUserToAddRows = false;
            grillaEquiposValorResidual.AllowUserToDeleteRows = false;
            grillaEquiposValorResidual.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaEquiposValorResidual.Location = new Point(12, 497);
            grillaEquiposValorResidual.Name = "grillaEquiposValorResidual";
            grillaEquiposValorResidual.ReadOnly = true;
            grillaEquiposValorResidual.Size = new Size(551, 150);
            grillaEquiposValorResidual.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 262);
            label2.Name = "label2";
            label2.Size = new Size(551, 25);
            label2.TabIndex = 8;
            label2.Text = "Equipos dados de baja ordenado por la cantidad de días ASC";
            // 
            // txtBusquedaPorCodigo
            // 
            txtBusquedaPorCodigo.Location = new Point(597, 446);
            txtBusquedaPorCodigo.Name = "txtBusquedaPorCodigo";
            txtBusquedaPorCodigo.Size = new Size(225, 23);
            txtBusquedaPorCodigo.TabIndex = 9;
            txtBusquedaPorCodigo.TextChanged += txtBusquedaPorCodigo_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(597, 262);
            label3.Name = "label3";
            label3.Size = new Size(304, 25);
            label3.TabIndex = 10;
            label3.Text = "Consulta incremental por código";
            // 
            // txtValorResidualDesde
            // 
            txtValorResidualDesde.Location = new Point(67, 660);
            txtValorResidualDesde.Name = "txtValorResidualDesde";
            txtValorResidualDesde.Size = new Size(157, 23);
            txtValorResidualDesde.TabIndex = 11;
            // 
            // txtValorResidualHasta
            // 
            txtValorResidualHasta.Location = new Point(294, 660);
            txtValorResidualHasta.Name = "txtValorResidualHasta";
            txtValorResidualHasta.Size = new Size(157, 23);
            txtValorResidualHasta.TabIndex = 12;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(22, 663);
            label4.Name = "label4";
            label4.Size = new Size(39, 15);
            label4.TabIndex = 13;
            label4.Text = "Desde";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(249, 663);
            label5.Name = "label5";
            label5.Size = new Size(37, 15);
            label5.TabIndex = 14;
            label5.Text = "Hasta";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(12, 469);
            label6.Name = "label6";
            label6.Size = new Size(417, 25);
            label6.TabIndex = 15;
            label6.Text = "Búsqueda de equipos por valor residual DESC";
            // 
            // btnBuscarValorResidualDesdeHasta
            // 
            btnBuscarValorResidualDesdeHasta.Location = new Point(488, 660);
            btnBuscarValorResidualDesdeHasta.Name = "btnBuscarValorResidualDesdeHasta";
            btnBuscarValorResidualDesdeHasta.Size = new Size(75, 23);
            btnBuscarValorResidualDesdeHasta.TabIndex = 16;
            btnBuscarValorResidualDesdeHasta.Text = "Buscar";
            btnBuscarValorResidualDesdeHasta.UseVisualStyleBackColor = true;
            btnBuscarValorResidualDesdeHasta.Click += btnBuscarValorResidualDesdeHasta_Click;
            // 
            // btnGuardarEnXml
            // 
            btnGuardarEnXml.Location = new Point(597, 624);
            btnGuardarEnXml.Name = "btnGuardarEnXml";
            btnGuardarEnXml.Size = new Size(137, 23);
            btnGuardarEnXml.TabIndex = 17;
            btnGuardarEnXml.Text = "Guardar en XML";
            btnGuardarEnXml.UseVisualStyleBackColor = true;
            btnGuardarEnXml.Click += btnGuardarEnXml_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1195, 700);
            Controls.Add(btnGuardarEnXml);
            Controls.Add(btnBuscarValorResidualDesdeHasta);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(txtValorResidualHasta);
            Controls.Add(txtValorResidualDesde);
            Controls.Add(label3);
            Controls.Add(txtBusquedaPorCodigo);
            Controls.Add(label2);
            Controls.Add(grillaEquiposValorResidual);
            Controls.Add(grillaConsultaIncrementalCodigo);
            Controls.Add(grillaEquiposDadosDeBaja);
            Controls.Add(label1);
            Controls.Add(btnModificar);
            Controls.Add(btnBorrar);
            Controls.Add(btnAgregar);
            Controls.Add(grillaEquipos);
            Name = "Form1";
            Text = "Gestión de Equipos Informáticos";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)grillaEquipos).EndInit();
            ((System.ComponentModel.ISupportInitialize)grillaEquiposDadosDeBaja).EndInit();
            ((System.ComponentModel.ISupportInitialize)grillaConsultaIncrementalCodigo).EndInit();
            ((System.ComponentModel.ISupportInitialize)grillaEquiposValorResidual).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView grillaEquipos;
        private Button btnAgregar;
        private Button btnBorrar;
        private Button btnModificar;
        private Label label1;
        private DataGridView grillaEquiposDadosDeBaja;
        private DataGridView grillaConsultaIncrementalCodigo;
        private DataGridView grillaEquiposValorResidual;
        private Label label2;
        private TextBox txtBusquedaPorCodigo;
        private Label label3;
        private TextBox txtValorResidualDesde;
        private TextBox txtValorResidualHasta;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button btnBuscarValorResidualDesdeHasta;
        private Button btnGuardarEnXml;
    }
}
