namespace Ejercicio2.Formularios
{
    partial class frmGestionClientes
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
            grillaClientes = new DataGridView();
            btnAgregarCliente = new Button();
            btnBorrarCliente = new Button();
            btnModificarCliente = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)grillaClientes).BeginInit();
            SuspendLayout();
            // 
            // grillaClientes
            // 
            grillaClientes.AllowUserToAddRows = false;
            grillaClientes.AllowUserToDeleteRows = false;
            grillaClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaClientes.Location = new Point(55, 51);
            grillaClientes.Name = "grillaClientes";
            grillaClientes.ReadOnly = true;
            grillaClientes.Size = new Size(674, 238);
            grillaClientes.TabIndex = 0;
            // 
            // btnAgregarCliente
            // 
            btnAgregarCliente.Location = new Point(55, 295);
            btnAgregarCliente.Name = "btnAgregarCliente";
            btnAgregarCliente.Size = new Size(75, 23);
            btnAgregarCliente.TabIndex = 1;
            btnAgregarCliente.Text = "Agregar";
            btnAgregarCliente.UseVisualStyleBackColor = true;
            btnAgregarCliente.Click += btnAgregarCliente_Click;
            // 
            // btnBorrarCliente
            // 
            btnBorrarCliente.Location = new Point(164, 295);
            btnBorrarCliente.Name = "btnBorrarCliente";
            btnBorrarCliente.Size = new Size(75, 23);
            btnBorrarCliente.TabIndex = 2;
            btnBorrarCliente.Text = "Borrar";
            btnBorrarCliente.UseVisualStyleBackColor = true;
            btnBorrarCliente.Click += btnBorrarCliente_Click;
            // 
            // btnModificarCliente
            // 
            btnModificarCliente.Location = new Point(265, 295);
            btnModificarCliente.Name = "btnModificarCliente";
            btnModificarCliente.Size = new Size(75, 23);
            btnModificarCliente.TabIndex = 3;
            btnModificarCliente.Text = "Modificar";
            btnModificarCliente.UseVisualStyleBackColor = true;
            btnModificarCliente.Click += btnModificarCliente_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(55, 23);
            label1.Name = "label1";
            label1.Size = new Size(81, 25);
            label1.TabIndex = 4;
            label1.Text = "Clientes";
            // 
            // frmGestionClientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 361);
            Controls.Add(label1);
            Controls.Add(btnModificarCliente);
            Controls.Add(btnBorrarCliente);
            Controls.Add(btnAgregarCliente);
            Controls.Add(grillaClientes);
            Name = "frmGestionClientes";
            Text = "Gestión Clientes";
            Load += frmGestionClientes_Load;
            ((System.ComponentModel.ISupportInitialize)grillaClientes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView grillaClientes;
        private Button btnAgregarCliente;
        private Button btnBorrarCliente;
        private Button btnModificarCliente;
        private Label label1;
    }
}