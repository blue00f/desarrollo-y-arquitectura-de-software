namespace UsoDeRegExp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            txtEntradaExpReg = new TextBox();
            txtParrafo = new TextBox();
            txtResultadosDeRegExp = new TextBox();
            btnReemplazar = new Button();
            SuspendLayout();
            // 
            // txtEntradaExpReg
            // 
            txtEntradaExpReg.Font = new Font("Segoe UI", 14F);
            txtEntradaExpReg.Location = new Point(30, 30);
            txtEntradaExpReg.Margin = new Padding(2, 1, 2, 1);
            txtEntradaExpReg.Name = "txtEntradaExpReg";
            txtEntradaExpReg.Size = new Size(801, 32);
            txtEntradaExpReg.TabIndex = 0;
            txtEntradaExpReg.TextChanged += txtEntradaExpReg_TextChanged;
            // 
            // txtParrafo
            // 
            txtParrafo.Font = new Font("Segoe UI", 14F);
            txtParrafo.Location = new Point(30, 75);
            txtParrafo.Margin = new Padding(2, 1, 2, 1);
            txtParrafo.Multiline = true;
            txtParrafo.Name = "txtParrafo";
            txtParrafo.Size = new Size(801, 450);
            txtParrafo.TabIndex = 1;
            txtParrafo.Text = resources.GetString("txtParrafo.Text");
            txtParrafo.TextChanged += txtParrafo_TextChanged;
            // 
            // txtResultadosDeRegExp
            // 
            txtResultadosDeRegExp.Font = new Font("Segoe UI", 14F);
            txtResultadosDeRegExp.Location = new Point(850, 75);
            txtResultadosDeRegExp.Margin = new Padding(2, 1, 2, 1);
            txtResultadosDeRegExp.Multiline = true;
            txtResultadosDeRegExp.Name = "txtResultadosDeRegExp";
            txtResultadosDeRegExp.Size = new Size(397, 450);
            txtResultadosDeRegExp.TabIndex = 2;
            // 
            // btnReemplazar
            // 
            btnReemplazar.Font = new Font("Segoe UI", 14F);
            btnReemplazar.Location = new Point(850, 30);
            btnReemplazar.Margin = new Padding(2, 1, 2, 1);
            btnReemplazar.Name = "btnReemplazar";
            btnReemplazar.Size = new Size(118, 32);
            btnReemplazar.TabIndex = 3;
            btnReemplazar.Text = "Replace";
            btnReemplazar.UseVisualStyleBackColor = true;
            btnReemplazar.Click += btnReemplazar_Click;
            // 
            // Form1
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1271, 544);
            Controls.Add(btnReemplazar);
            Controls.Add(txtResultadosDeRegExp);
            Controls.Add(txtParrafo);
            Controls.Add(txtEntradaExpReg);
            Margin = new Padding(2, 1, 2, 1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtEntradaExpReg;
        private TextBox txtParrafo;
        private TextBox txtResultadosDeRegExp;
        private Button btnReemplazar;
    }
}
