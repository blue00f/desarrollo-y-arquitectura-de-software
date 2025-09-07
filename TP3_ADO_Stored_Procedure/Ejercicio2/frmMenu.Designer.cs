namespace Ejercicio2
{
    partial class frmMenu
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
            formulariosToolStripMenuItem = new ToolStripMenuItem();
            vehiculosToolStripMenuItem = new ToolStripMenuItem();
            propietariosToolStripMenuItem = new ToolStripMenuItem();
            multasToolStripMenuItem = new ToolStripMenuItem();
            salirToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { formulariosToolStripMenuItem, salirToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // formulariosToolStripMenuItem
            // 
            formulariosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { vehiculosToolStripMenuItem, propietariosToolStripMenuItem, multasToolStripMenuItem });
            formulariosToolStripMenuItem.Name = "formulariosToolStripMenuItem";
            formulariosToolStripMenuItem.Size = new Size(82, 20);
            formulariosToolStripMenuItem.Text = "Formularios";
            // 
            // vehiculosToolStripMenuItem
            // 
            vehiculosToolStripMenuItem.Name = "vehiculosToolStripMenuItem";
            vehiculosToolStripMenuItem.Size = new Size(137, 22);
            vehiculosToolStripMenuItem.Text = "Vehiculos";
            vehiculosToolStripMenuItem.Click += vehiculosToolStripMenuItem_Click;
            // 
            // propietariosToolStripMenuItem
            // 
            propietariosToolStripMenuItem.Name = "propietariosToolStripMenuItem";
            propietariosToolStripMenuItem.Size = new Size(137, 22);
            propietariosToolStripMenuItem.Text = "Propietarios";
            propietariosToolStripMenuItem.Click += propietariosToolStripMenuItem_Click;
            // 
            // multasToolStripMenuItem
            // 
            multasToolStripMenuItem.Name = "multasToolStripMenuItem";
            multasToolStripMenuItem.Size = new Size(137, 22);
            multasToolStripMenuItem.Text = "Multas";
            multasToolStripMenuItem.Click += multasToolStripMenuItem_Click;
            // 
            // salirToolStripMenuItem
            // 
            salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            salirToolStripMenuItem.Size = new Size(41, 20);
            salirToolStripMenuItem.Text = "Salir";
            salirToolStripMenuItem.Click += salirToolStripMenuItem_Click;
            // 
            // frmMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "frmMenu";
            Text = "Sistema de transito";
            Load += frmMenu_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem formulariosToolStripMenuItem;
        private ToolStripMenuItem vehiculosToolStripMenuItem;
        private ToolStripMenuItem propietariosToolStripMenuItem;
        private ToolStripMenuItem multasToolStripMenuItem;
        private ToolStripMenuItem salirToolStripMenuItem;
    }
}
