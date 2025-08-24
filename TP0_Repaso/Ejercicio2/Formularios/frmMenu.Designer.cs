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
            operacionesToolStripMenuItem1 = new ToolStripMenuItem();
            gestionClientesToolStripMenuItem1 = new ToolStripMenuItem();
            gestionPaquetesToolStripMenuItem = new ToolStripMenuItem();
            gestionCanalesToolStripMenuItem = new ToolStripMenuItem();
            gestionSeriesToolStripMenuItem = new ToolStripMenuItem();
            operacionesToolStripMenuItem = new ToolStripMenuItem();
            contrataciónToolStripMenuItem = new ToolStripMenuItem();
            informesToolStripMenuItem = new ToolStripMenuItem();
            salirToolStripMenuItem = new ToolStripMenuItem();
            gestionClientesToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { operacionesToolStripMenuItem1, operacionesToolStripMenuItem, contrataciónToolStripMenuItem, informesToolStripMenuItem, salirToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(484, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // operacionesToolStripMenuItem1
            // 
            operacionesToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { gestionClientesToolStripMenuItem1, gestionPaquetesToolStripMenuItem, gestionCanalesToolStripMenuItem, gestionSeriesToolStripMenuItem });
            operacionesToolStripMenuItem1.Name = "operacionesToolStripMenuItem1";
            operacionesToolStripMenuItem1.Size = new Size(85, 20);
            operacionesToolStripMenuItem1.Text = "Operaciones";
            // 
            // gestionClientesToolStripMenuItem1
            // 
            gestionClientesToolStripMenuItem1.Name = "gestionClientesToolStripMenuItem1";
            gestionClientesToolStripMenuItem1.Size = new Size(165, 22);
            gestionClientesToolStripMenuItem1.Text = "Gestion clientes";
            gestionClientesToolStripMenuItem1.Click += gestionClientesToolStripMenuItem1_Click;
            // 
            // gestionPaquetesToolStripMenuItem
            // 
            gestionPaquetesToolStripMenuItem.Name = "gestionPaquetesToolStripMenuItem";
            gestionPaquetesToolStripMenuItem.Size = new Size(165, 22);
            gestionPaquetesToolStripMenuItem.Text = "Gestion paquetes";
            gestionPaquetesToolStripMenuItem.Click += gestionPaquetesToolStripMenuItem_Click_1;
            // 
            // gestionCanalesToolStripMenuItem
            // 
            gestionCanalesToolStripMenuItem.Name = "gestionCanalesToolStripMenuItem";
            gestionCanalesToolStripMenuItem.Size = new Size(165, 22);
            gestionCanalesToolStripMenuItem.Text = "Gestion canales";
            gestionCanalesToolStripMenuItem.Click += gestionCanalesToolStripMenuItem_Click;
            // 
            // gestionSeriesToolStripMenuItem
            // 
            gestionSeriesToolStripMenuItem.Name = "gestionSeriesToolStripMenuItem";
            gestionSeriesToolStripMenuItem.Size = new Size(165, 22);
            gestionSeriesToolStripMenuItem.Text = "Gestion series";
            gestionSeriesToolStripMenuItem.Click += gestionSeriesToolStripMenuItem_Click;
            // 
            // operacionesToolStripMenuItem
            // 
            operacionesToolStripMenuItem.Name = "operacionesToolStripMenuItem";
            operacionesToolStripMenuItem.Size = new Size(12, 20);
            // 
            // contrataciónToolStripMenuItem
            // 
            contrataciónToolStripMenuItem.Name = "contrataciónToolStripMenuItem";
            contrataciónToolStripMenuItem.Size = new Size(88, 20);
            contrataciónToolStripMenuItem.Text = "Contratación";
            contrataciónToolStripMenuItem.Click += contratacionToolStripMenuItem_Click;
            // 
            // informesToolStripMenuItem
            // 
            informesToolStripMenuItem.Name = "informesToolStripMenuItem";
            informesToolStripMenuItem.Size = new Size(66, 20);
            informesToolStripMenuItem.Text = "Informes";
            informesToolStripMenuItem.Click += informesToolStripMenuItem_Click;
            // 
            // salirToolStripMenuItem
            // 
            salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            salirToolStripMenuItem.Size = new Size(41, 20);
            salirToolStripMenuItem.Text = "Salir";
            salirToolStripMenuItem.Click += salirToolStripMenuItem_Click;
            // 
            // gestionClientesToolStripMenuItem
            // 
            gestionClientesToolStripMenuItem.Name = "gestionClientesToolStripMenuItem";
            gestionClientesToolStripMenuItem.Size = new Size(32, 19);
            // 
            // frmMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(484, 261);
            Controls.Add(menuStrip1);
            ForeColor = SystemColors.ControlText;
            MainMenuStrip = menuStrip1;
            Name = "frmMenu";
            Text = "Empresa de cables";
            Load += frmMenu_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem gestionClientesToolStripMenuItem;
        private ToolStripMenuItem informesToolStripMenuItem;
        private ToolStripMenuItem salirToolStripMenuItem;
        private ToolStripMenuItem contrataciónToolStripMenuItem;
        private ToolStripMenuItem operacionesToolStripMenuItem;
        private ToolStripMenuItem operacionesToolStripMenuItem1;
        private ToolStripMenuItem gestionClientesToolStripMenuItem1;
        private ToolStripMenuItem gestionPaquetesToolStripMenuItem;
        private ToolStripMenuItem gestionCanalesToolStripMenuItem;
        private ToolStripMenuItem gestionSeriesToolStripMenuItem;
    }
}
