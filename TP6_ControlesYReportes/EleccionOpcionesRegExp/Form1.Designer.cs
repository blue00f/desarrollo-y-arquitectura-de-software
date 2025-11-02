namespace EleccionOpcionesRegExp
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
            components = new System.ComponentModel.Container();
            cbxOpciones = new ComboBox();
            txtTexto = new TextBox();
            btnValidar = new Button();
            label1 = new Label();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // cbxOpciones
            // 
            cbxOpciones.FormattingEnabled = true;
            cbxOpciones.Location = new Point(257, 60);
            cbxOpciones.Name = "cbxOpciones";
            cbxOpciones.Size = new Size(192, 23);
            cbxOpciones.TabIndex = 0;
            // 
            // txtTexto
            // 
            txtTexto.Location = new Point(25, 60);
            txtTexto.Name = "txtTexto";
            txtTexto.Size = new Size(173, 23);
            txtTexto.TabIndex = 1;
            // 
            // btnValidar
            // 
            btnValidar.Location = new Point(25, 89);
            btnValidar.Name = "btnValidar";
            btnValidar.Size = new Size(173, 23);
            btnValidar.TabIndex = 2;
            btnValidar.Text = "Validar";
            btnValidar.UseVisualStyleBackColor = true;
            btnValidar.Click += btnValidar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 42);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 3;
            label1.Text = "Entrada";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(474, 167);
            Controls.Add(label1);
            Controls.Add(btnValidar);
            Controls.Add(txtTexto);
            Controls.Add(cbxOpciones);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbxOpciones;
        private TextBox txtTexto;
        private Button btnValidar;
        private Label label1;
        private ErrorProvider errorProvider1;
    }
}
