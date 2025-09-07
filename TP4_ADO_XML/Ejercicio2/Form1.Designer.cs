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
            label2 = new Label();
            grillaPreguntas = new DataGridView();
            label1 = new Label();
            grillaOpciones = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)grillaPreguntas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grillaOpciones).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 8);
            label2.Name = "label2";
            label2.Size = new Size(127, 25);
            label2.TabIndex = 5;
            label2.Text = "Preguntados";
            // 
            // grillaPreguntas
            // 
            grillaPreguntas.AllowUserToAddRows = false;
            grillaPreguntas.AllowUserToDeleteRows = false;
            grillaPreguntas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaPreguntas.Location = new Point(12, 36);
            grillaPreguntas.Name = "grillaPreguntas";
            grillaPreguntas.ReadOnly = true;
            grillaPreguntas.Size = new Size(541, 210);
            grillaPreguntas.TabIndex = 4;
            grillaPreguntas.RowEnter += grillaPreguntas_RowEnter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(576, 8);
            label1.Name = "label1";
            label1.Size = new Size(94, 25);
            label1.TabIndex = 7;
            label1.Text = "Opciones";
            // 
            // grillaOpciones
            // 
            grillaOpciones.AllowUserToAddRows = false;
            grillaOpciones.AllowUserToDeleteRows = false;
            grillaOpciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaOpciones.Location = new Point(576, 36);
            grillaOpciones.Name = "grillaOpciones";
            grillaOpciones.ReadOnly = true;
            grillaOpciones.Size = new Size(419, 210);
            grillaOpciones.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1014, 280);
            Controls.Add(label1);
            Controls.Add(grillaOpciones);
            Controls.Add(label2);
            Controls.Add(grillaPreguntas);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)grillaPreguntas).EndInit();
            ((System.ComponentModel.ISupportInitialize)grillaOpciones).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private DataGridView grillaPreguntas;
        private Label label1;
        private DataGridView grillaOpciones;
    }
}
