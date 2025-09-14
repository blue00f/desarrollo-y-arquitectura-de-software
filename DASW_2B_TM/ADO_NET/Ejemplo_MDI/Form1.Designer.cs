namespace EjemploMDI
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
            menuStrip1 = new MenuStrip();
            formlariosToolStripMenuItem = new ToolStripMenuItem();
            crearToolStripMenuItem = new ToolStripMenuItem();
            cerrarTodosToolStripMenuItem = new ToolStripMenuItem();
            salirToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(32, 32);
            menuStrip1.Items.AddRange(new ToolStripItem[] { formlariosToolStripMenuItem, salirToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1336, 53);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // formlariosToolStripMenuItem
            // 
            formlariosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { crearToolStripMenuItem, cerrarTodosToolStripMenuItem });
            formlariosToolStripMenuItem.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            formlariosToolStripMenuItem.ForeColor = Color.Blue;
            formlariosToolStripMenuItem.Name = "formlariosToolStripMenuItem";
            formlariosToolStripMenuItem.Size = new Size(201, 49);
            formlariosToolStripMenuItem.Text = "Formlarios";
            // 
            // crearToolStripMenuItem
            // 
            crearToolStripMenuItem.Name = "crearToolStripMenuItem";
            crearToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.C;
            crearToolStripMenuItem.Size = new Size(359, 54);
            crearToolStripMenuItem.Text = "Crear";
            crearToolStripMenuItem.Click += crearToolStripMenuItem_Click;
            // 
            // cerrarTodosToolStripMenuItem
            // 
            cerrarTodosToolStripMenuItem.Name = "cerrarTodosToolStripMenuItem";
            cerrarTodosToolStripMenuItem.Size = new Size(359, 54);
            cerrarTodosToolStripMenuItem.Text = "Cerrar Todos";
            cerrarTodosToolStripMenuItem.Click += cerrarTodosToolStripMenuItem_Click;
            // 
            // salirToolStripMenuItem
            // 
            salirToolStripMenuItem.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            salirToolStripMenuItem.ForeColor = Color.Red;
            salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            salirToolStripMenuItem.Size = new Size(106, 49);
            salirToolStripMenuItem.Text = "Salir";
            salirToolStripMenuItem.Click += salirToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1336, 626);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem formlariosToolStripMenuItem;
        private ToolStripMenuItem crearToolStripMenuItem;
        private ToolStripMenuItem cerrarTodosToolStripMenuItem;
        private ToolStripMenuItem salirToolStripMenuItem;
    }
}
