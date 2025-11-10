namespace ControlesPersonalizados
{
    partial class ucLegajo
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtLegajo = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // txtLegajo
            // 
            txtLegajo.Location = new Point(0, 18);
            txtLegajo.Name = "txtLegajo";
            txtLegajo.Size = new Size(148, 23);
            txtLegajo.TabIndex = 0;
            txtLegajo.TextChanged += txtLegajo_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 1;
            label1.Text = "Legajo";
            // 
            // ucLegajo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label1);
            Controls.Add(txtLegajo);
            Name = "ucLegajo";
            Size = new Size(151, 51);
            Load += ucLegajo_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtLegajo;
        private Label label1;
    }
}
