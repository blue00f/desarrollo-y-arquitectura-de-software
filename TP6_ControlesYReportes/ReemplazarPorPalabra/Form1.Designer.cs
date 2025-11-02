namespace ReemplazarPorPalabra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btnReemplazar = new Button();
            txtBiografia = new TextBox();
            txtPalabra = new TextBox();
            SuspendLayout();
            // 
            // btnReemplazar
            // 
            btnReemplazar.Location = new Point(271, 25);
            btnReemplazar.Name = "btnReemplazar";
            btnReemplazar.Size = new Size(94, 23);
            btnReemplazar.TabIndex = 1;
            btnReemplazar.Text = "Reemplazar";
            btnReemplazar.UseVisualStyleBackColor = true;
            btnReemplazar.Click += btnReemplazar_Click;
            // 
            // txtBiografia
            // 
            txtBiografia.Location = new Point(35, 54);
            txtBiografia.Multiline = true;
            txtBiografia.Name = "txtBiografia";
            txtBiografia.ReadOnly = true;
            txtBiografia.Size = new Size(958, 450);
            txtBiografia.TabIndex = 2;
            txtBiografia.Text = resources.GetString("txtBiografia.Text");
            // 
            // txtPalabra
            // 
            txtPalabra.Location = new Point(35, 25);
            txtPalabra.Name = "txtPalabra";
            txtPalabra.Size = new Size(211, 23);
            txtPalabra.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1028, 535);
            Controls.Add(txtPalabra);
            Controls.Add(txtBiografia);
            Controls.Add(btnReemplazar);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnReemplazar;
        private TextBox txtBiografia;
        private TextBox txtPalabra;
    }
}
