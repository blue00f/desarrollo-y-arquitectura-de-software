namespace HospitalDemo
{
    partial class Indicaciones
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
            richTextBox1 = new RichTextBox();
            btnSalir = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(38, 43);
            label1.Name = "label1";
            label1.Size = new Size(154, 25);
            label1.TabIndex = 0;
            label1.Text = "Indicaciones del";
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(38, 87);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(441, 163);
            richTextBox1.TabIndex = 1;
            richTextBox1.Text = "";
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.PaleTurquoise;
            btnSalir.FlatAppearance.BorderSize = 0;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSalir.ForeColor = Color.Black;
            btnSalir.Location = new Point(213, 270);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(93, 37);
            btnSalir.TabIndex = 2;
            btnSalir.Text = "SALIR";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // Indicaciones
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSkyBlue;
            ClientSize = new Size(509, 329);
            Controls.Add(btnSalir);
            Controls.Add(richTextBox1);
            Controls.Add(label1);
            Name = "Indicaciones";
            Text = "Indicaciones";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private RichTextBox richTextBox1;
        private Button btnSalir;
    }
}