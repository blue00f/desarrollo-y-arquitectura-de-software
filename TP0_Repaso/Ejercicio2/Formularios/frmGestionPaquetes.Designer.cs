namespace Ejercicio2.Formularios
{
    partial class frmGestionPaquetes
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
            label1 = new Label();
            btnModificarPaquete = new Button();
            btnBorrarPaquete = new Button();
            btnAgregarPaquete = new Button();
            grillaPaquetes = new DataGridView();
            groupBox1 = new GroupBox();
            radSilver = new RadioButton();
            radPremium = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)grillaPaquetes).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(54, 23);
            label1.Name = "label1";
            label1.Size = new Size(93, 25);
            label1.TabIndex = 9;
            label1.Text = "Paquetes";
            // 
            // btnModificarPaquete
            // 
            btnModificarPaquete.Location = new Point(264, 295);
            btnModificarPaquete.Name = "btnModificarPaquete";
            btnModificarPaquete.Size = new Size(75, 23);
            btnModificarPaquete.TabIndex = 8;
            btnModificarPaquete.Text = "Modificar";
            btnModificarPaquete.UseVisualStyleBackColor = true;
            btnModificarPaquete.Click += btnModificarPaquete_Click;
            // 
            // btnBorrarPaquete
            // 
            btnBorrarPaquete.Location = new Point(163, 295);
            btnBorrarPaquete.Name = "btnBorrarPaquete";
            btnBorrarPaquete.Size = new Size(75, 23);
            btnBorrarPaquete.TabIndex = 7;
            btnBorrarPaquete.Text = "Borrar";
            btnBorrarPaquete.UseVisualStyleBackColor = true;
            btnBorrarPaquete.Click += btnBorrarPaquete_Click;
            // 
            // btnAgregarPaquete
            // 
            btnAgregarPaquete.Location = new Point(54, 295);
            btnAgregarPaquete.Name = "btnAgregarPaquete";
            btnAgregarPaquete.Size = new Size(75, 23);
            btnAgregarPaquete.TabIndex = 6;
            btnAgregarPaquete.Text = "Agregar";
            btnAgregarPaquete.UseVisualStyleBackColor = true;
            btnAgregarPaquete.Click += btnAgregarPaquete_Click;
            // 
            // grillaPaquetes
            // 
            grillaPaquetes.AllowUserToAddRows = false;
            grillaPaquetes.AllowUserToDeleteRows = false;
            grillaPaquetes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaPaquetes.Location = new Point(54, 51);
            grillaPaquetes.Name = "grillaPaquetes";
            grillaPaquetes.ReadOnly = true;
            grillaPaquetes.Size = new Size(464, 238);
            grillaPaquetes.TabIndex = 5;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radSilver);
            groupBox1.Controls.Add(radPremium);
            groupBox1.Location = new Point(524, 51);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(150, 80);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "Tipo de paquete";
            // 
            // radSilver
            // 
            radSilver.AutoSize = true;
            radSilver.Location = new Point(24, 47);
            radSilver.Name = "radSilver";
            radSilver.Size = new Size(53, 19);
            radSilver.TabIndex = 1;
            radSilver.Text = "Silver";
            radSilver.UseVisualStyleBackColor = true;
            // 
            // radPremium
            // 
            radPremium.AutoSize = true;
            radPremium.Checked = true;
            radPremium.Location = new Point(24, 22);
            radPremium.Name = "radPremium";
            radPremium.Size = new Size(74, 19);
            radPremium.TabIndex = 0;
            radPremium.TabStop = true;
            radPremium.Text = "Premium";
            radPremium.UseVisualStyleBackColor = true;
            // 
            // frmGestionPaquetes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(720, 361);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Controls.Add(btnModificarPaquete);
            Controls.Add(btnBorrarPaquete);
            Controls.Add(btnAgregarPaquete);
            Controls.Add(grillaPaquetes);
            Name = "frmGestionPaquetes";
            Text = "Gestión paquetes";
            Load += frmGestionPaquetes_Load;
            ((System.ComponentModel.ISupportInitialize)grillaPaquetes).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnModificarPaquete;
        private Button btnBorrarPaquete;
        private Button btnAgregarPaquete;
        private DataGridView grillaPaquetes;
        private GroupBox groupBox1;
        private RadioButton radSilver;
        private RadioButton radPremium;
    }
}