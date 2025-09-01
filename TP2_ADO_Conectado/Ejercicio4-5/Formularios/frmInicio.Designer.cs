namespace Ejercicio4_5.Formularios
{
    partial class frmInicio
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
            btnCerrarSesion = new Button();
            grillaProductos = new DataGridView();
            grillaCategorias = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            btnAgregarProducto = new Button();
            btnBorrarProducto = new Button();
            btnModificarProducto = new Button();
            btnModificarCategoria = new Button();
            btnBorrarCategoria = new Button();
            btnAgregarCategoria = new Button();
            label3 = new Label();
            grillaLogs = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)grillaProductos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grillaCategorias).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grillaLogs).BeginInit();
            SuspendLayout();
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.Location = new Point(33, 508);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(184, 57);
            btnCerrarSesion.TabIndex = 4;
            btnCerrarSesion.Text = "Cerrar sesión";
            btnCerrarSesion.UseVisualStyleBackColor = true;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // grillaProductos
            // 
            grillaProductos.AllowUserToAddRows = false;
            grillaProductos.AllowUserToDeleteRows = false;
            grillaProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaProductos.Location = new Point(33, 57);
            grillaProductos.Name = "grillaProductos";
            grillaProductos.ReadOnly = true;
            grillaProductos.Size = new Size(515, 206);
            grillaProductos.TabIndex = 5;
            // 
            // grillaCategorias
            // 
            grillaCategorias.AllowUserToAddRows = false;
            grillaCategorias.AllowUserToDeleteRows = false;
            grillaCategorias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaCategorias.Location = new Point(585, 57);
            grillaCategorias.Name = "grillaCategorias";
            grillaCategorias.ReadOnly = true;
            grillaCategorias.Size = new Size(360, 206);
            grillaCategorias.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(33, 29);
            label1.Name = "label1";
            label1.Size = new Size(104, 25);
            label1.TabIndex = 7;
            label1.Text = "Productos";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(585, 29);
            label2.Name = "label2";
            label2.Size = new Size(106, 25);
            label2.TabIndex = 8;
            label2.Text = "Categorías";
            // 
            // btnAgregarProducto
            // 
            btnAgregarProducto.Location = new Point(33, 269);
            btnAgregarProducto.Name = "btnAgregarProducto";
            btnAgregarProducto.Size = new Size(75, 23);
            btnAgregarProducto.TabIndex = 9;
            btnAgregarProducto.Text = "Agregar";
            btnAgregarProducto.UseVisualStyleBackColor = true;
            btnAgregarProducto.Click += btnAgregarProducto_Click;
            // 
            // btnBorrarProducto
            // 
            btnBorrarProducto.Location = new Point(142, 269);
            btnBorrarProducto.Name = "btnBorrarProducto";
            btnBorrarProducto.Size = new Size(75, 23);
            btnBorrarProducto.TabIndex = 10;
            btnBorrarProducto.Text = "Borrar";
            btnBorrarProducto.UseVisualStyleBackColor = true;
            btnBorrarProducto.Click += btnBorrarProducto_Click;
            // 
            // btnModificarProducto
            // 
            btnModificarProducto.Location = new Point(246, 269);
            btnModificarProducto.Name = "btnModificarProducto";
            btnModificarProducto.Size = new Size(75, 23);
            btnModificarProducto.TabIndex = 11;
            btnModificarProducto.Text = "Modificar";
            btnModificarProducto.UseVisualStyleBackColor = true;
            btnModificarProducto.Click += btnModificarProducto_Click;
            // 
            // btnModificarCategoria
            // 
            btnModificarCategoria.Location = new Point(798, 269);
            btnModificarCategoria.Name = "btnModificarCategoria";
            btnModificarCategoria.Size = new Size(75, 23);
            btnModificarCategoria.TabIndex = 14;
            btnModificarCategoria.Text = "Modificar";
            btnModificarCategoria.UseVisualStyleBackColor = true;
            btnModificarCategoria.Click += btnModificarCategoria_Click;
            // 
            // btnBorrarCategoria
            // 
            btnBorrarCategoria.Location = new Point(694, 269);
            btnBorrarCategoria.Name = "btnBorrarCategoria";
            btnBorrarCategoria.Size = new Size(75, 23);
            btnBorrarCategoria.TabIndex = 13;
            btnBorrarCategoria.Text = "Borrar";
            btnBorrarCategoria.UseVisualStyleBackColor = true;
            btnBorrarCategoria.Click += btnBorrarCategoria_Click;
            // 
            // btnAgregarCategoria
            // 
            btnAgregarCategoria.Location = new Point(585, 269);
            btnAgregarCategoria.Name = "btnAgregarCategoria";
            btnAgregarCategoria.Size = new Size(75, 23);
            btnAgregarCategoria.TabIndex = 12;
            btnAgregarCategoria.Text = "Agregar";
            btnAgregarCategoria.UseVisualStyleBackColor = true;
            btnAgregarCategoria.Click += btnAgregarCategoria_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(585, 331);
            label3.Name = "label3";
            label3.Size = new Size(54, 25);
            label3.TabIndex = 16;
            label3.Text = "Logs";
            // 
            // grillaLogs
            // 
            grillaLogs.AllowUserToAddRows = false;
            grillaLogs.AllowUserToDeleteRows = false;
            grillaLogs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaLogs.Location = new Point(585, 359);
            grillaLogs.Name = "grillaLogs";
            grillaLogs.ReadOnly = true;
            grillaLogs.Size = new Size(530, 206);
            grillaLogs.TabIndex = 15;
            // 
            // frmInicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1166, 598);
            Controls.Add(label3);
            Controls.Add(grillaLogs);
            Controls.Add(btnModificarCategoria);
            Controls.Add(btnBorrarCategoria);
            Controls.Add(btnAgregarCategoria);
            Controls.Add(btnModificarProducto);
            Controls.Add(btnBorrarProducto);
            Controls.Add(btnAgregarProducto);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(grillaCategorias);
            Controls.Add(grillaProductos);
            Controls.Add(btnCerrarSesion);
            Name = "frmInicio";
            Text = "frmInicio";
            Load += frmInicio_Load;
            ((System.ComponentModel.ISupportInitialize)grillaProductos).EndInit();
            ((System.ComponentModel.ISupportInitialize)grillaCategorias).EndInit();
            ((System.ComponentModel.ISupportInitialize)grillaLogs).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCerrarSesion;
        private DataGridView grillaProductos;
        private DataGridView grillaCategorias;
        private Label label1;
        private Label label2;
        private Button btnAgregarProducto;
        private Button btnBorrarProducto;
        private Button btnModificarProducto;
        private Button btnModificarCategoria;
        private Button btnBorrarCategoria;
        private Button btnAgregarCategoria;
        private Label label3;
        private DataGridView grillaLogs;
    }
}