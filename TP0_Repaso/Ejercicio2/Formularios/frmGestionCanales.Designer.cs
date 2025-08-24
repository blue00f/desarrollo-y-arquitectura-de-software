namespace Ejercicio2.Formularios
{
    partial class frmGestionCanales
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            btnModificarCanal = new Button();
            btnBorrarCanal = new Button();
            btnAgregarCanal = new Button();
            grillaCanales = new DataGridView();
            cbxPaquetes = new ComboBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)grillaCanales).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(55, 33);
            label1.Name = "label1";
            label1.Size = new Size(79, 25);
            label1.TabIndex = 9;
            label1.Text = "Canales";
            // 
            // btnModificarCanal
            // 
            btnModificarCanal.Location = new Point(265, 305);
            btnModificarCanal.Name = "btnModificarCanal";
            btnModificarCanal.Size = new Size(75, 23);
            btnModificarCanal.TabIndex = 8;
            btnModificarCanal.Text = "Modificar";
            btnModificarCanal.UseVisualStyleBackColor = true;
            btnModificarCanal.Click += btnModificarCanal_Click;
            // 
            // btnBorrarCanal
            // 
            btnBorrarCanal.Location = new Point(164, 305);
            btnBorrarCanal.Name = "btnBorrarCanal";
            btnBorrarCanal.Size = new Size(75, 23);
            btnBorrarCanal.TabIndex = 7;
            btnBorrarCanal.Text = "Borrar";
            btnBorrarCanal.UseVisualStyleBackColor = true;
            btnBorrarCanal.Click += btnBorrarCanal_Click;
            // 
            // btnAgregarCanal
            // 
            btnAgregarCanal.Location = new Point(55, 305);
            btnAgregarCanal.Name = "btnAgregarCanal";
            btnAgregarCanal.Size = new Size(75, 23);
            btnAgregarCanal.TabIndex = 6;
            btnAgregarCanal.Text = "Agregar";
            btnAgregarCanal.UseVisualStyleBackColor = true;
            btnAgregarCanal.Click += btnAgregarCanal_Click;
            // 
            // grillaCanales
            // 
            grillaCanales.AllowUserToAddRows = false;
            grillaCanales.AllowUserToDeleteRows = false;
            grillaCanales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaCanales.Location = new Point(55, 61);
            grillaCanales.Name = "grillaCanales";
            grillaCanales.ReadOnly = true;
            grillaCanales.Size = new Size(674, 238);
            grillaCanales.TabIndex = 5;
            // 
            // cbxPaquetes
            // 
            cbxPaquetes.FormattingEnabled = true;
            cbxPaquetes.Location = new Point(529, 305);
            cbxPaquetes.Name = "cbxPaquetes";
            cbxPaquetes.Size = new Size(200, 23);
            cbxPaquetes.TabIndex = 10;
            cbxPaquetes.SelectedIndexChanged += cbxPaquetes_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(473, 309);
            label2.Name = "label2";
            label2.Size = new Size(50, 15);
            label2.TabIndex = 11;
            label2.Text = "Paquete";
            // 
            // frmGestionCanales
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 361);
            Controls.Add(label2);
            Controls.Add(cbxPaquetes);
            Controls.Add(label1);
            Controls.Add(btnModificarCanal);
            Controls.Add(btnBorrarCanal);
            Controls.Add(btnAgregarCanal);
            Controls.Add(grillaCanales);
            Name = "frmGestionCanales";
            Text = "Gestión de canales";
            Load += frmGestionCanales_Load;
            ((System.ComponentModel.ISupportInitialize)grillaCanales).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnModificarCanal;
        private Button btnBorrarCanal;
        private Button btnAgregarCanal;
        private DataGridView grillaCanales;
        private ComboBox cbxPaquetes;
        private Label label2;
    }
}