namespace Ejercicio2.Formularios
{
    partial class frmContratacion
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
            cbxClientes = new ComboBox();
            cbxPaquetes = new ComboBox();
            btnContratar = new Button();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // cbxClientes
            // 
            cbxClientes.FormattingEnabled = true;
            cbxClientes.Location = new Point(112, 92);
            cbxClientes.Name = "cbxClientes";
            cbxClientes.Size = new Size(219, 23);
            cbxClientes.TabIndex = 0;
            // 
            // cbxPaquetes
            // 
            cbxPaquetes.FormattingEnabled = true;
            cbxPaquetes.Location = new Point(374, 92);
            cbxPaquetes.Name = "cbxPaquetes";
            cbxPaquetes.Size = new Size(219, 23);
            cbxPaquetes.TabIndex = 1;
            // 
            // btnContratar
            // 
            btnContratar.Location = new Point(299, 148);
            btnContratar.Name = "btnContratar";
            btnContratar.Size = new Size(113, 49);
            btnContratar.TabIndex = 2;
            btnContratar.Text = "Contratar";
            btnContratar.UseVisualStyleBackColor = true;
            btnContratar.Click += btnContratar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(112, 69);
            label1.Name = "label1";
            label1.Size = new Size(57, 20);
            label1.TabIndex = 3;
            label1.Text = "Cliente";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(374, 69);
            label2.Name = "label2";
            label2.Size = new Size(66, 20);
            label2.TabIndex = 4;
            label2.Text = "Paquete";
            // 
            // frmContratacion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 361);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnContratar);
            Controls.Add(cbxPaquetes);
            Controls.Add(cbxClientes);
            Name = "frmContratacion";
            Text = "Contratación";
            Load += frmContratacion_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbxClientes;
        private ComboBox cbxPaquetes;
        private Button btnContratar;
        private Label label1;
        private Label label2;
    }
}