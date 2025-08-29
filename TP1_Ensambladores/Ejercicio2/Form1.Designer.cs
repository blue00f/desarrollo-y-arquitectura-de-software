namespace Ejercicio2
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
            btnInstalar = new Button();
            btnVerificar = new Button();
            listBox1 = new ListBox();
            SuspendLayout();
            // 
            // btnInstalar
            // 
            btnInstalar.Location = new Point(53, 134);
            btnInstalar.Name = "btnInstalar";
            btnInstalar.Size = new Size(129, 23);
            btnInstalar.TabIndex = 0;
            btnInstalar.Text = "Instalar";
            btnInstalar.UseVisualStyleBackColor = true;
            btnInstalar.Click += btnInstalar_Click;
            // 
            // btnVerificar
            // 
            btnVerificar.Location = new Point(53, 185);
            btnVerificar.Name = "btnVerificar";
            btnVerificar.Size = new Size(129, 23);
            btnVerificar.TabIndex = 1;
            btnVerificar.Text = "Verificar";
            btnVerificar.UseVisualStyleBackColor = true;
            btnVerificar.Click += btnVerificar_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(229, 47);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(223, 289);
            listBox1.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(548, 376);
            Controls.Add(listBox1);
            Controls.Add(btnVerificar);
            Controls.Add(btnInstalar);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button btnInstalar;
        private Button btnVerificar;
        private ListBox listBox1;
    }
}
