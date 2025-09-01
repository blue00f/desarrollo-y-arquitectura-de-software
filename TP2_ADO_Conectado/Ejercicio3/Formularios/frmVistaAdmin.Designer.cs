namespace Ejercicio3
{
    partial class frmVistaAdmin
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
            grillaUsuarios = new DataGridView();
            label1 = new Label();
            btnDesbloquearUsuario = new Button();
            btnCerrarSesion = new Button();
            ((System.ComponentModel.ISupportInitialize)grillaUsuarios).BeginInit();
            SuspendLayout();
            // 
            // grillaUsuarios
            // 
            grillaUsuarios.AllowUserToAddRows = false;
            grillaUsuarios.AllowUserToDeleteRows = false;
            grillaUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaUsuarios.Location = new Point(59, 68);
            grillaUsuarios.Name = "grillaUsuarios";
            grillaUsuarios.ReadOnly = true;
            grillaUsuarios.Size = new Size(516, 198);
            grillaUsuarios.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(59, 40);
            label1.Name = "label1";
            label1.Size = new Size(89, 25);
            label1.TabIndex = 1;
            label1.Text = "Usuarios";
            // 
            // btnDesbloquearUsuario
            // 
            btnDesbloquearUsuario.Location = new Point(59, 272);
            btnDesbloquearUsuario.Name = "btnDesbloquearUsuario";
            btnDesbloquearUsuario.Size = new Size(150, 23);
            btnDesbloquearUsuario.TabIndex = 2;
            btnDesbloquearUsuario.Text = "Bloquear/Desbloquear";
            btnDesbloquearUsuario.UseVisualStyleBackColor = true;
            btnDesbloquearUsuario.Click += btnDesbloquearUsuario_Click;
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.Location = new Point(433, 272);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(142, 23);
            btnCerrarSesion.TabIndex = 3;
            btnCerrarSesion.Text = "Cerrar sesión";
            btnCerrarSesion.UseVisualStyleBackColor = true;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // frmVistaAdmin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(636, 350);
            Controls.Add(btnCerrarSesion);
            Controls.Add(btnDesbloquearUsuario);
            Controls.Add(label1);
            Controls.Add(grillaUsuarios);
            Name = "frmVistaAdmin";
            Text = "frmVistaAdmin";
            Load += frmVistaAdmin_Load;
            ((System.ComponentModel.ISupportInitialize)grillaUsuarios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView grillaUsuarios;
        private Label label1;
        private Button btnDesbloquearUsuario;
        private Button btnCerrarSesion;
    }
}