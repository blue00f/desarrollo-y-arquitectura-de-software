namespace Ejercicio3
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
            operacionesToolStripMenuItem = new ToolStripMenuItem();
            jugadoresToolStripMenuItem = new ToolStripMenuItem();
            categoriasToolStripMenuItem = new ToolStripMenuItem();
            preguntasToolStripMenuItem = new ToolStripMenuItem();
            opcionesToolStripMenuItem1 = new ToolStripMenuItem();
            respuestasToolStripMenuItem = new ToolStripMenuItem();
            salirToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { operacionesToolStripMenuItem, salirToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // operacionesToolStripMenuItem
            // 
            operacionesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { jugadoresToolStripMenuItem, categoriasToolStripMenuItem, preguntasToolStripMenuItem, opcionesToolStripMenuItem1, respuestasToolStripMenuItem });
            operacionesToolStripMenuItem.Name = "operacionesToolStripMenuItem";
            operacionesToolStripMenuItem.Size = new Size(85, 20);
            operacionesToolStripMenuItem.Text = "Operaciones";
            // 
            // jugadoresToolStripMenuItem
            // 
            jugadoresToolStripMenuItem.Name = "jugadoresToolStripMenuItem";
            jugadoresToolStripMenuItem.Size = new Size(132, 22);
            jugadoresToolStripMenuItem.Text = "Jugadores";
            jugadoresToolStripMenuItem.Click += jugadoresToolStripMenuItem_Click;
            // 
            // categoriasToolStripMenuItem
            // 
            categoriasToolStripMenuItem.Name = "categoriasToolStripMenuItem";
            categoriasToolStripMenuItem.Size = new Size(132, 22);
            categoriasToolStripMenuItem.Text = "Categorias";
            categoriasToolStripMenuItem.Click += categoriasToolStripMenuItem_Click;
            // 
            // preguntasToolStripMenuItem
            // 
            preguntasToolStripMenuItem.Name = "preguntasToolStripMenuItem";
            preguntasToolStripMenuItem.Size = new Size(132, 22);
            preguntasToolStripMenuItem.Text = "Preguntas";
            preguntasToolStripMenuItem.Click += preguntasToolStripMenuItem_Click;
            // 
            // opcionesToolStripMenuItem1
            // 
            opcionesToolStripMenuItem1.Name = "opcionesToolStripMenuItem1";
            opcionesToolStripMenuItem1.Size = new Size(132, 22);
            opcionesToolStripMenuItem1.Text = "Opciones";
            opcionesToolStripMenuItem1.Click += opcionesToolStripMenuItem1_Click;
            // 
            // respuestasToolStripMenuItem
            // 
            respuestasToolStripMenuItem.Name = "respuestasToolStripMenuItem";
            respuestasToolStripMenuItem.Size = new Size(132, 22);
            respuestasToolStripMenuItem.Text = "Respuestas";
            respuestasToolStripMenuItem.Click += respuestasToolStripMenuItem_Click;
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
            ClientSize = new Size(800, 632);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "frmMenu";
            Text = "Juego de preguntas";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem operacionesToolStripMenuItem;
        private ToolStripMenuItem jugadoresToolStripMenuItem;
        private ToolStripMenuItem categoriasToolStripMenuItem;
        private ToolStripMenuItem preguntasToolStripMenuItem;
        private ToolStripMenuItem salirToolStripMenuItem;
        private ToolStripMenuItem opcionesToolStripMenuItem1;
        private ToolStripMenuItem respuestasToolStripMenuItem;
    }
}
