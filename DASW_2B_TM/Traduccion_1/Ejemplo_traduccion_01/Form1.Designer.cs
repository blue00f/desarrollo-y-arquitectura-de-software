
namespace Ejemplo_traduccion_01
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.botonPersonal3 = new ContolesPropios.BotonPersonal();
            this.botonPersonal2 = new ContolesPropios.BotonPersonal();
            this.botonPersonal1 = new ContolesPropios.BotonPersonal();
            this.SuspendLayout();
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(336, 66);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(70, 17);
            this.radioButton1.TabIndex = 3;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Usuario 1";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.PreparaUsuario);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(336, 95);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(70, 17);
            this.radioButton2.TabIndex = 4;
            this.radioButton2.Text = "Usuario 2";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.PreparaUsuario);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(336, 124);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(70, 17);
            this.radioButton3.TabIndex = 5;
            this.radioButton3.Text = "Usuario 3";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.PreparaUsuario);
            // 
            // botonPersonal3
            // 
            this.botonPersonal3.Identificador = null;
            this.botonPersonal3.Location = new System.Drawing.Point(52, 126);
            this.botonPersonal3.Name = "botonPersonal3";
            this.botonPersonal3.Size = new System.Drawing.Size(162, 24);
            this.botonPersonal3.TabIndex = 8;
            this.botonPersonal3.Tag = "B03";
            // 
            // botonPersonal2
            // 
            this.botonPersonal2.Identificador = null;
            this.botonPersonal2.Location = new System.Drawing.Point(52, 96);
            this.botonPersonal2.Name = "botonPersonal2";
            this.botonPersonal2.Size = new System.Drawing.Size(162, 24);
            this.botonPersonal2.TabIndex = 7;
            this.botonPersonal2.Tag = "B02";
            // 
            // botonPersonal1
            // 
            this.botonPersonal1.Identificador = null;
            this.botonPersonal1.Location = new System.Drawing.Point(52, 66);
            this.botonPersonal1.Name = "botonPersonal1";
            this.botonPersonal1.Size = new System.Drawing.Size(162, 24);
            this.botonPersonal1.TabIndex = 6;
            this.botonPersonal1.Tag = "B01";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 215);
            this.Controls.Add(this.botonPersonal3);
            this.Controls.Add(this.botonPersonal2);
            this.Controls.Add(this.botonPersonal1);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private ContolesPropios.BotonPersonal botonPersonal1;
        private ContolesPropios.BotonPersonal botonPersonal2;
        private ContolesPropios.BotonPersonal botonPersonal3;
    }
}

