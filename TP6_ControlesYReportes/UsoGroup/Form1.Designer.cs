namespace UsoGroup
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
            txtFecha = new TextBox();
            label1 = new Label();
            lstGrupoFecha = new ListBox();
            btnValidar = new Button();
            SuspendLayout();
            // 
            // txtFecha
            // 
            txtFecha.Location = new Point(44, 56);
            txtFecha.Name = "txtFecha";
            txtFecha.Size = new Size(150, 23);
            txtFecha.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(44, 38);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 1;
            label1.Text = "Fecha";
            // 
            // lstGrupoFecha
            // 
            lstGrupoFecha.FormattingEnabled = true;
            lstGrupoFecha.ItemHeight = 15;
            lstGrupoFecha.Location = new Point(247, 38);
            lstGrupoFecha.Name = "lstGrupoFecha";
            lstGrupoFecha.Size = new Size(386, 154);
            lstGrupoFecha.TabIndex = 2;
            // 
            // btnValidar
            // 
            btnValidar.Location = new Point(44, 85);
            btnValidar.Name = "btnValidar";
            btnValidar.Size = new Size(150, 23);
            btnValidar.TabIndex = 3;
            btnValidar.Text = "Validar";
            btnValidar.UseVisualStyleBackColor = true;
            btnValidar.Click += btnValidar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(645, 236);
            Controls.Add(btnValidar);
            Controls.Add(lstGrupoFecha);
            Controls.Add(label1);
            Controls.Add(txtFecha);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtFecha;
        private Label label1;
        private ListBox lstGrupoFecha;
        private Button btnValidar;
    }
}
