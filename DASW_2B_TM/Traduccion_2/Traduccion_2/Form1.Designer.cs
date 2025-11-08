namespace Traduccion_2
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
            botonPersonal1 = new ControlesPropios.BotonPersonal();
            botonPersonal2 = new ControlesPropios.BotonPersonal();
            botonPersonal3 = new ControlesPropios.BotonPersonal();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton3 = new RadioButton();
            SuspendLayout();
            // 
            // botonPersonal1
            // 
            botonPersonal1.Identificador = null;
            botonPersonal1.Location = new Point(592, 103);
            botonPersonal1.Name = "botonPersonal1";
            botonPersonal1.Size = new Size(350, 120);
            botonPersonal1.TabIndex = 1;
            // 
            // botonPersonal2
            // 
            botonPersonal2.Identificador = null;
            botonPersonal2.Location = new Point(592, 277);
            botonPersonal2.Name = "botonPersonal2";
            botonPersonal2.Size = new Size(350, 120);
            botonPersonal2.TabIndex = 2;
            // 
            // botonPersonal3
            // 
            botonPersonal3.Identificador = null;
            botonPersonal3.Location = new Point(592, 450);
            botonPersonal3.Name = "botonPersonal3";
            botonPersonal3.Size = new Size(350, 120);
            botonPersonal3.TabIndex = 3;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Checked = true;
            radioButton1.Location = new Point(1130, 103);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(145, 36);
            radioButton1.TabIndex = 4;
            radioButton1.TabStop = true;
            radioButton1.Text = "Usuario 1";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(1130, 176);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(145, 36);
            radioButton2.TabIndex = 5;
            radioButton2.Text = "Usuario 2";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(1130, 248);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(145, 36);
            radioButton3.TabIndex = 6;
            radioButton3.Text = "Usuario 3";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1714, 939);
            Controls.Add(radioButton3);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(botonPersonal3);
            Controls.Add(botonPersonal2);
            Controls.Add(botonPersonal1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ControlesPropios.BotonPersonal botonPersonal1;
        private ControlesPropios.BotonPersonal botonPersonal2;
        private ControlesPropios.BotonPersonal botonPersonal3;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private RadioButton radioButton3;
    }
}
