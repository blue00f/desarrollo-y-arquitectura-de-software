namespace ADO_Transaction_1
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
            btnCargar = new Button();
            btnCargarUsandoSP = new Button();
            SuspendLayout();
            // 
            // btnCargar
            // 
            btnCargar.Location = new Point(77, 75);
            btnCargar.Name = "btnCargar";
            btnCargar.Size = new Size(116, 50);
            btnCargar.TabIndex = 0;
            btnCargar.Text = "Cargar empleado";
            btnCargar.UseVisualStyleBackColor = true;
            btnCargar.Click += btnCargar_Click;
            // 
            // btnCargarUsandoSP
            // 
            btnCargarUsandoSP.Location = new Point(77, 144);
            btnCargarUsandoSP.Name = "btnCargarUsandoSP";
            btnCargarUsandoSP.Size = new Size(116, 50);
            btnCargarUsandoSP.TabIndex = 1;
            btnCargarUsandoSP.Text = "Cargar empleado usando SP";
            btnCargarUsandoSP.UseVisualStyleBackColor = true;
            btnCargarUsandoSP.Click += btnCargarUsandoSP_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 261);
            Controls.Add(btnCargarUsandoSP);
            Controls.Add(btnCargar);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button btnCargar;
        private Button btnCargarUsandoSP;
    }
}
