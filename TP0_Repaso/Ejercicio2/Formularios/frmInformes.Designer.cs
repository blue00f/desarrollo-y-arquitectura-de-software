namespace Ejercicio2.Formularios
{
    partial class frmInformes
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
            grillaInfoPaquete = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            grillaComprasDelCliente = new DataGridView();
            label3 = new Label();
            txtTotalRecaudado = new TextBox();
            label4 = new Label();
            grillaSeriesRankingMayor = new DataGridView();
            label5 = new Label();
            cbxPaquetes = new ComboBox();
            label6 = new Label();
            label7 = new Label();
            cbxClientes = new ComboBox();
            grillaInfoPaqueteMasVendido = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)grillaInfoPaquete).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grillaComprasDelCliente).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grillaSeriesRankingMayor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grillaInfoPaqueteMasVendido).BeginInit();
            SuspendLayout();
            // 
            // grillaInfoPaquete
            // 
            grillaInfoPaquete.AllowUserToAddRows = false;
            grillaInfoPaquete.AllowUserToDeleteRows = false;
            grillaInfoPaquete.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaInfoPaquete.Location = new Point(32, 49);
            grillaInfoPaquete.Name = "grillaInfoPaquete";
            grillaInfoPaquete.ReadOnly = true;
            grillaInfoPaquete.Size = new Size(587, 200);
            grillaInfoPaquete.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(32, 21);
            label1.Name = "label1";
            label1.Size = new Size(232, 25);
            label1.TabIndex = 1;
            label1.Text = "Información del paquete";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(32, 292);
            label2.Name = "label2";
            label2.Size = new Size(186, 25);
            label2.TabIndex = 3;
            label2.Text = "Compras del cliente";
            // 
            // grillaComprasDelCliente
            // 
            grillaComprasDelCliente.AllowUserToAddRows = false;
            grillaComprasDelCliente.AllowUserToDeleteRows = false;
            grillaComprasDelCliente.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaComprasDelCliente.Location = new Point(32, 320);
            grillaComprasDelCliente.Name = "grillaComprasDelCliente";
            grillaComprasDelCliente.ReadOnly = true;
            grillaComprasDelCliente.Size = new Size(587, 200);
            grillaComprasDelCliente.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(816, 557);
            label3.Name = "label3";
            label3.Size = new Size(195, 20);
            label3.TabIndex = 4;
            label3.Text = "Total recaudado en el mes:";
            // 
            // txtTotalRecaudado
            // 
            txtTotalRecaudado.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTotalRecaudado.Location = new Point(1026, 550);
            txtTotalRecaudado.Name = "txtTotalRecaudado";
            txtTotalRecaudado.ReadOnly = true;
            txtTotalRecaudado.Size = new Size(199, 27);
            txtTotalRecaudado.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(638, 21);
            label4.Name = "label4";
            label4.Size = new Size(203, 25);
            label4.TabIndex = 6;
            label4.Text = "Paquete más vendido";
            // 
            // grillaSeriesRankingMayor
            // 
            grillaSeriesRankingMayor.AllowUserToAddRows = false;
            grillaSeriesRankingMayor.AllowUserToDeleteRows = false;
            grillaSeriesRankingMayor.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaSeriesRankingMayor.Location = new Point(638, 320);
            grillaSeriesRankingMayor.Name = "grillaSeriesRankingMayor";
            grillaSeriesRankingMayor.ReadOnly = true;
            grillaSeriesRankingMayor.Size = new Size(587, 200);
            grillaSeriesRankingMayor.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(638, 292);
            label5.Name = "label5";
            label5.Size = new Size(286, 25);
            label5.TabIndex = 10;
            label5.Text = "Series con ranking mayor a 3,5";
            // 
            // cbxPaquetes
            // 
            cbxPaquetes.FormattingEnabled = true;
            cbxPaquetes.Location = new Point(108, 255);
            cbxPaquetes.Name = "cbxPaquetes";
            cbxPaquetes.Size = new Size(197, 23);
            cbxPaquetes.TabIndex = 11;
            cbxPaquetes.SelectedIndexChanged += cbxPaquetes_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(32, 255);
            label6.Name = "label6";
            label6.Size = new Size(70, 20);
            label6.TabIndex = 12;
            label6.Text = "Paquete:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(32, 526);
            label7.Name = "label7";
            label7.Size = new Size(61, 20);
            label7.TabIndex = 14;
            label7.Text = "Cliente:";
            // 
            // cbxClientes
            // 
            cbxClientes.FormattingEnabled = true;
            cbxClientes.Location = new Point(108, 526);
            cbxClientes.Name = "cbxClientes";
            cbxClientes.Size = new Size(197, 23);
            cbxClientes.TabIndex = 13;
            cbxClientes.SelectedIndexChanged += cbxClientes_SelectedIndexChanged;
            // 
            // grillaInfoPaqueteMasVendido
            // 
            grillaInfoPaqueteMasVendido.AllowUserToAddRows = false;
            grillaInfoPaqueteMasVendido.AllowUserToDeleteRows = false;
            grillaInfoPaqueteMasVendido.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaInfoPaqueteMasVendido.Location = new Point(638, 49);
            grillaInfoPaqueteMasVendido.Name = "grillaInfoPaqueteMasVendido";
            grillaInfoPaqueteMasVendido.ReadOnly = true;
            grillaInfoPaqueteMasVendido.Size = new Size(587, 200);
            grillaInfoPaqueteMasVendido.TabIndex = 15;
            // 
            // frmInformes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1269, 589);
            Controls.Add(grillaInfoPaqueteMasVendido);
            Controls.Add(label7);
            Controls.Add(cbxClientes);
            Controls.Add(label6);
            Controls.Add(cbxPaquetes);
            Controls.Add(label5);
            Controls.Add(grillaSeriesRankingMayor);
            Controls.Add(label4);
            Controls.Add(txtTotalRecaudado);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(grillaComprasDelCliente);
            Controls.Add(label1);
            Controls.Add(grillaInfoPaquete);
            Name = "frmInformes";
            Text = "Informes";
            Load += frmInformes_Load;
            ((System.ComponentModel.ISupportInitialize)grillaInfoPaquete).EndInit();
            ((System.ComponentModel.ISupportInitialize)grillaComprasDelCliente).EndInit();
            ((System.ComponentModel.ISupportInitialize)grillaSeriesRankingMayor).EndInit();
            ((System.ComponentModel.ISupportInitialize)grillaInfoPaqueteMasVendido).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView grillaInfoPaquete;
        private Label label1;
        private Label label2;
        private DataGridView grillaComprasDelCliente;
        private Label label3;
        private TextBox txtTotalRecaudado;
        private Label label4;
        private DataGridView grillaSeriesRankingMayor;
        private Label label5;
        private ComboBox cbxPaquetes;
        private Label label6;
        private Label label7;
        private ComboBox cbxClientes;
        private DataGridView grillaInfoPaqueteMasVendido;
    }
}