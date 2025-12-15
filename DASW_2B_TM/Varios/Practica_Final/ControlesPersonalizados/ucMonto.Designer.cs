namespace ControlesPersonalizados
{
    partial class ucMonto
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
            txtMonto = new TextBox();
            SuspendLayout();
            // 
            // txtMonto
            // 
            txtMonto.Location = new Point(0, 3);
            txtMonto.Name = "txtMonto";
            txtMonto.Size = new Size(138, 23);
            txtMonto.TabIndex = 0;
            txtMonto.TextChanged += txtMonto_TextChanged;
            txtMonto.KeyPress += txtMonto_KeyPress;
            // 
            // ucMonto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(txtMonto);
            Name = "ucMonto";
            Size = new Size(142, 30);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtMonto;
    }
}
