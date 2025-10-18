namespace EjemploComposite
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
            treeView1 = new TreeView();
            btnCargarEstructura = new Button();
            SuspendLayout();
            // 
            // treeView1
            // 
            treeView1.Location = new Point(31, 30);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(299, 386);
            treeView1.TabIndex = 0;
            // 
            // btnCargarEstructura
            // 
            btnCargarEstructura.Location = new Point(31, 422);
            btnCargarEstructura.Name = "btnCargarEstructura";
            btnCargarEstructura.Size = new Size(299, 39);
            btnCargarEstructura.TabIndex = 1;
            btnCargarEstructura.Text = "Cargar estructura";
            btnCargarEstructura.UseVisualStyleBackColor = true;
            btnCargarEstructura.Click += btnCargarEstructura_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(360, 473);
            Controls.Add(btnCargarEstructura);
            Controls.Add(treeView1);
            Name = "Form1";
            Text = "Sistema de archivos";
            ResumeLayout(false);
        }

        #endregion

        private TreeView treeView1;
        private Button btnCargarEstructura;
    }
}
