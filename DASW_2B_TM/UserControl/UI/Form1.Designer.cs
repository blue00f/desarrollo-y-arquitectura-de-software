namespace EJ_01_US_CTR
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
            numericTextBox2 = new Controles_personalizados.NumericTextBox();
            button1 = new Button();
            numericUpDown1 = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // numericTextBox2
            // 
            numericTextBox2.CantidadDecimales = 2;
            numericTextBox2.ColorLetra = Color.FromArgb(71, 71, 250);
            numericTextBox2.Letra = new Font("Cambria", 36F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            numericTextBox2.Location = new Point(150, 74);
            numericTextBox2.Margin = new Padding(1, 0, 1, 0);
            numericTextBox2.Name = "numericTextBox2";
            numericTextBox2.Size = new Size(495, 60);
            numericTextBox2.TabIndex = 1;
            numericTextBox2.Valor = "58";
            // 
            // button1
            // 
            button1.Location = new Point(150, 150);
            button1.Margin = new Padding(2, 1, 2, 1);
            button1.Name = "button1";
            button1.Size = new Size(81, 22);
            button1.TabIndex = 2;
            button1.Text = "Limpiar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Font = new Font("Segoe UI", 16F);
            numericUpDown1.Location = new Point(672, 98);
            numericUpDown1.Margin = new Padding(2, 1, 2, 1);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(129, 36);
            numericUpDown1.TabIndex = 3;
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(988, 277);
            Controls.Add(numericUpDown1);
            Controls.Add(button1);
            Controls.Add(numericTextBox2);
            Margin = new Padding(2, 1, 2, 1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load_1;
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Controles_personalizados.NumericTextBox numericTextBox2;
        private Button button1;
        private NumericUpDown numericUpDown1;
    }
}
