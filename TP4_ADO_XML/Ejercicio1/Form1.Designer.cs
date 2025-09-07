namespace Ejercicio1
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
            grillaReservas = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            grillaItems = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)grillaReservas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grillaItems).BeginInit();
            SuspendLayout();
            // 
            // grillaReservas
            // 
            grillaReservas.AllowUserToAddRows = false;
            grillaReservas.AllowUserToDeleteRows = false;
            grillaReservas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaReservas.Location = new Point(12, 47);
            grillaReservas.Name = "grillaReservas";
            grillaReservas.ReadOnly = true;
            grillaReservas.Size = new Size(373, 150);
            grillaReservas.TabIndex = 0;
            grillaReservas.RowEnter += grillaReservas_RowEnter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 19);
            label1.Name = "label1";
            label1.Size = new Size(163, 25);
            label1.TabIndex = 1;
            label1.Text = "Agencia de viajes";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(412, 19);
            label2.Name = "label2";
            label2.Size = new Size(165, 25);
            label2.TabIndex = 3;
            label2.Text = "Items de reservas";
            // 
            // grillaItems
            // 
            grillaItems.AllowUserToAddRows = false;
            grillaItems.AllowUserToDeleteRows = false;
            grillaItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaItems.Location = new Point(412, 47);
            grillaItems.Name = "grillaItems";
            grillaItems.ReadOnly = true;
            grillaItems.Size = new Size(541, 150);
            grillaItems.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(966, 227);
            Controls.Add(label2);
            Controls.Add(grillaItems);
            Controls.Add(label1);
            Controls.Add(grillaReservas);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)grillaReservas).EndInit();
            ((System.ComponentModel.ISupportInitialize)grillaItems).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView grillaReservas;
        private Label label1;
        private Label label2;
        private DataGridView grillaItems;
    }
}
