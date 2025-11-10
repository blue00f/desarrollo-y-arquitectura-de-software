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
            ctrlEquipo = new ControlesPersonalizados.CtrlABM();
            ctrlProveedor = new ControlesPersonalizados.CtrlABM();
            btnAsociar = new Button();
            grillaEquipoProveedor = new DataGridView();
            grillaDadosDeBaja = new DataGridView();
            grillaValorResidual = new DataGridView();
            grillaCodigos = new DataGridView();
            btnBuscarPorValorResidual = new Button();
            txtBusquedaIncremental = new TextBox();
            label1 = new Label();
            grillaEquiposDeleted = new DataGridView();
            grillaEquiposModified = new DataGridView();
            grillaEquiposAdded = new DataGridView();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            btnConfirmarCambiosEquipo = new Button();
            btnGrabarXml = new Button();
            btnAbrirXml = new Button();
            ((System.ComponentModel.ISupportInitialize)grillaEquipoProveedor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grillaDadosDeBaja).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grillaValorResidual).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grillaCodigos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grillaEquiposDeleted).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grillaEquiposModified).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grillaEquiposAdded).BeginInit();
            SuspendLayout();
            // 
            // ctrlEquipo
            // 
            ctrlEquipo.Location = new Point(12, 40);
            ctrlEquipo.Name = "ctrlEquipo";
            ctrlEquipo.Size = new Size(679, 248);
            ctrlEquipo.TabIndex = 0;
            // 
            // ctrlProveedor
            // 
            ctrlProveedor.Location = new Point(772, 40);
            ctrlProveedor.Name = "ctrlProveedor";
            ctrlProveedor.Size = new Size(679, 248);
            ctrlProveedor.TabIndex = 1;
            // 
            // btnAsociar
            // 
            btnAsociar.Location = new Point(691, 120);
            btnAsociar.Name = "btnAsociar";
            btnAsociar.Size = new Size(75, 47);
            btnAsociar.TabIndex = 2;
            btnAsociar.Text = "Asociar";
            btnAsociar.UseVisualStyleBackColor = true;
            btnAsociar.Click += btnAsociar_Click;
            // 
            // grillaEquipoProveedor
            // 
            grillaEquipoProveedor.AllowUserToAddRows = false;
            grillaEquipoProveedor.AllowUserToDeleteRows = false;
            grillaEquipoProveedor.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaEquipoProveedor.Location = new Point(772, 329);
            grillaEquipoProveedor.Name = "grillaEquipoProveedor";
            grillaEquipoProveedor.ReadOnly = true;
            grillaEquipoProveedor.Size = new Size(679, 150);
            grillaEquipoProveedor.TabIndex = 3;
            // 
            // grillaDadosDeBaja
            // 
            grillaDadosDeBaja.AllowUserToAddRows = false;
            grillaDadosDeBaja.AllowUserToDeleteRows = false;
            grillaDadosDeBaja.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaDadosDeBaja.Location = new Point(12, 329);
            grillaDadosDeBaja.Name = "grillaDadosDeBaja";
            grillaDadosDeBaja.ReadOnly = true;
            grillaDadosDeBaja.Size = new Size(679, 150);
            grillaDadosDeBaja.TabIndex = 4;
            // 
            // grillaValorResidual
            // 
            grillaValorResidual.AllowUserToAddRows = false;
            grillaValorResidual.AllowUserToDeleteRows = false;
            grillaValorResidual.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaValorResidual.Location = new Point(12, 497);
            grillaValorResidual.Name = "grillaValorResidual";
            grillaValorResidual.ReadOnly = true;
            grillaValorResidual.Size = new Size(679, 150);
            grillaValorResidual.TabIndex = 5;
            // 
            // grillaCodigos
            // 
            grillaCodigos.AllowUserToAddRows = false;
            grillaCodigos.AllowUserToDeleteRows = false;
            grillaCodigos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaCodigos.Location = new Point(12, 662);
            grillaCodigos.Name = "grillaCodigos";
            grillaCodigos.ReadOnly = true;
            grillaCodigos.Size = new Size(679, 150);
            grillaCodigos.TabIndex = 6;
            // 
            // btnBuscarPorValorResidual
            // 
            btnBuscarPorValorResidual.Location = new Point(697, 605);
            btnBuscarPorValorResidual.Name = "btnBuscarPorValorResidual";
            btnBuscarPorValorResidual.Size = new Size(182, 42);
            btnBuscarPorValorResidual.TabIndex = 7;
            btnBuscarPorValorResidual.Text = "Buscar por valor residual (Desde-Hasta)";
            btnBuscarPorValorResidual.UseVisualStyleBackColor = true;
            btnBuscarPorValorResidual.Click += btnBuscarPorValorResidual_Click;
            // 
            // txtBusquedaIncremental
            // 
            txtBusquedaIncremental.Location = new Point(697, 789);
            txtBusquedaIncremental.Name = "txtBusquedaIncremental";
            txtBusquedaIncremental.Size = new Size(182, 23);
            txtBusquedaIncremental.TabIndex = 8;
            txtBusquedaIncremental.TextChanged += txtBusquedaIncremental_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(697, 771);
            label1.Name = "label1";
            label1.Size = new Size(186, 15);
            label1.TabIndex = 9;
            label1.Text = "Búsqueda incremental por código";
            // 
            // grillaEquiposDeleted
            // 
            grillaEquiposDeleted.AllowUserToAddRows = false;
            grillaEquiposDeleted.AllowUserToDeleteRows = false;
            grillaEquiposDeleted.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaEquiposDeleted.Location = new Point(943, 695);
            grillaEquiposDeleted.Name = "grillaEquiposDeleted";
            grillaEquiposDeleted.ReadOnly = true;
            grillaEquiposDeleted.Size = new Size(508, 150);
            grillaEquiposDeleted.TabIndex = 10;
            // 
            // grillaEquiposModified
            // 
            grillaEquiposModified.AllowUserToAddRows = false;
            grillaEquiposModified.AllowUserToDeleteRows = false;
            grillaEquiposModified.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaEquiposModified.Location = new Point(943, 851);
            grillaEquiposModified.Name = "grillaEquiposModified";
            grillaEquiposModified.ReadOnly = true;
            grillaEquiposModified.Size = new Size(508, 150);
            grillaEquiposModified.TabIndex = 11;
            // 
            // grillaEquiposAdded
            // 
            grillaEquiposAdded.AllowUserToAddRows = false;
            grillaEquiposAdded.AllowUserToDeleteRows = false;
            grillaEquiposAdded.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaEquiposAdded.Location = new Point(943, 539);
            grillaEquiposAdded.Name = "grillaEquiposAdded";
            grillaEquiposAdded.ReadOnly = true;
            grillaEquiposAdded.Size = new Size(508, 150);
            grillaEquiposAdded.TabIndex = 12;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 12);
            label2.Name = "label2";
            label2.Size = new Size(83, 25);
            label2.TabIndex = 13;
            label2.Text = "Equipos";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(772, 12);
            label3.Name = "label3";
            label3.Size = new Size(124, 25);
            label3.TabIndex = 14;
            label3.Text = "Proveedores";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(772, 301);
            label4.Name = "label4";
            label4.Size = new Size(320, 25);
            label4.TabIndex = 15;
            label4.Text = "Equipo y Proveedores - Asociación";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(12, 301);
            label5.Name = "label5";
            label5.Size = new Size(193, 25);
            label5.TabIndex = 16;
            label5.Text = "Consultas de equipo";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(943, 510);
            label6.Name = "label6";
            label6.Size = new Size(271, 25);
            label6.TabIndex = 17;
            label6.Text = "Estado de filas de los equipos";
            // 
            // btnConfirmarCambiosEquipo
            // 
            btnConfirmarCambiosEquipo.Location = new Point(1296, 506);
            btnConfirmarCambiosEquipo.Name = "btnConfirmarCambiosEquipo";
            btnConfirmarCambiosEquipo.Size = new Size(155, 27);
            btnConfirmarCambiosEquipo.TabIndex = 18;
            btnConfirmarCambiosEquipo.Text = "Confirmar cambios";
            btnConfirmarCambiosEquipo.UseVisualStyleBackColor = true;
            btnConfirmarCambiosEquipo.Click += btnConfirmarCambiosEquipo_Click;
            // 
            // btnGrabarXml
            // 
            btnGrabarXml.Location = new Point(12, 851);
            btnGrabarXml.Name = "btnGrabarXml";
            btnGrabarXml.Size = new Size(113, 23);
            btnGrabarXml.TabIndex = 19;
            btnGrabarXml.Text = "Grabar en XML";
            btnGrabarXml.UseVisualStyleBackColor = true;
            btnGrabarXml.Click += btnGrabarXml_Click;
            // 
            // btnAbrirXml
            // 
            btnAbrirXml.Location = new Point(12, 880);
            btnAbrirXml.Name = "btnAbrirXml";
            btnAbrirXml.Size = new Size(113, 23);
            btnAbrirXml.TabIndex = 20;
            btnAbrirXml.Text = "Abrir XML";
            btnAbrirXml.UseVisualStyleBackColor = true;
            btnAbrirXml.Click += btnAbrirXml_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1470, 1026);
            Controls.Add(btnAbrirXml);
            Controls.Add(btnGrabarXml);
            Controls.Add(btnConfirmarCambiosEquipo);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(grillaEquiposAdded);
            Controls.Add(grillaEquiposModified);
            Controls.Add(grillaEquiposDeleted);
            Controls.Add(label1);
            Controls.Add(txtBusquedaIncremental);
            Controls.Add(btnBuscarPorValorResidual);
            Controls.Add(grillaCodigos);
            Controls.Add(grillaValorResidual);
            Controls.Add(grillaDadosDeBaja);
            Controls.Add(grillaEquipoProveedor);
            Controls.Add(btnAsociar);
            Controls.Add(ctrlProveedor);
            Controls.Add(ctrlEquipo);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)grillaEquipoProveedor).EndInit();
            ((System.ComponentModel.ISupportInitialize)grillaDadosDeBaja).EndInit();
            ((System.ComponentModel.ISupportInitialize)grillaValorResidual).EndInit();
            ((System.ComponentModel.ISupportInitialize)grillaCodigos).EndInit();
            ((System.ComponentModel.ISupportInitialize)grillaEquiposDeleted).EndInit();
            ((System.ComponentModel.ISupportInitialize)grillaEquiposModified).EndInit();
            ((System.ComponentModel.ISupportInitialize)grillaEquiposAdded).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ControlesPersonalizados.CtrlABM ctrlEquipo;
        private ControlesPersonalizados.CtrlABM ctrlProveedor;
        private Button btnAsociar;
        private DataGridView grillaEquipoProveedor;
        private DataGridView grillaDadosDeBaja;
        private DataGridView grillaValorResidual;
        private DataGridView grillaCodigos;
        private Button btnBuscarPorValorResidual;
        private TextBox txtBusquedaIncremental;
        private Label label1;
        private DataGridView grillaEquiposDeleted;
        private DataGridView grillaEquiposModified;
        private DataGridView grillaEquiposAdded;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button btnConfirmarCambiosEquipo;
        private Button btnGrabarXml;
        private Button btnAbrirXml;
    }
}
