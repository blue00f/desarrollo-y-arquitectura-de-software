namespace Ejercicio1
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
            btnAbrirExe = new Button();
            SuspendLayout();
            // 
            // btnAbrirExe
            // 
            btnAbrirExe.Location = new Point(95, 104);
            btnAbrirExe.Name = "btnAbrirExe";
            btnAbrirExe.Size = new Size(149, 63);
            btnAbrirExe.TabIndex = 0;
            btnAbrirExe.Text = "Abrir ILDASM";
            btnAbrirExe.UseVisualStyleBackColor = true;
            btnAbrirExe.Click += btnAbrirExe_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(370, 284);
            Controls.Add(btnAbrirExe);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button btnAbrirExe;
    }
}
