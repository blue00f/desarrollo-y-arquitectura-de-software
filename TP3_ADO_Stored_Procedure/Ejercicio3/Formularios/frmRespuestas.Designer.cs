namespace Ejercicio3.Formularios
{
    partial class frmRespuestas
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
            cbxJugadores = new ComboBox();
            label1 = new Label();
            lblPregunta = new Label();
            flpOpciones = new FlowLayoutPanel();
            btnCargarPregunta = new Button();
            btnResponder = new Button();
            lblNivel = new Label();
            grillaRespuestas = new DataGridView();
            lblPuntos = new Label();
            ((System.ComponentModel.ISupportInitialize)grillaRespuestas).BeginInit();
            SuspendLayout();
            // 
            // cbxJugadores
            // 
            cbxJugadores.FormattingEnabled = true;
            cbxJugadores.Location = new Point(17, 269);
            cbxJugadores.Name = "cbxJugadores";
            cbxJugadores.Size = new Size(483, 23);
            cbxJugadores.TabIndex = 0;
            cbxJugadores.SelectedIndexChanged += cbxJugadores_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 251);
            label1.Name = "label1";
            label1.Size = new Size(128, 15);
            label1.TabIndex = 1;
            label1.Text = "Seleccionar un jugador";
            // 
            // lblPregunta
            // 
            lblPregunta.AutoSize = true;
            lblPregunta.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPregunta.Location = new Point(12, 55);
            lblPregunta.Name = "lblPregunta";
            lblPregunta.Size = new Size(95, 25);
            lblPregunta.TabIndex = 2;
            lblPregunta.Text = "Pregunta";
            // 
            // flpOpciones
            // 
            flpOpciones.AutoScroll = true;
            flpOpciones.Location = new Point(17, 83);
            flpOpciones.Name = "flpOpciones";
            flpOpciones.Size = new Size(483, 136);
            flpOpciones.TabIndex = 3;
            // 
            // btnCargarPregunta
            // 
            btnCargarPregunta.Location = new Point(17, 12);
            btnCargarPregunta.Name = "btnCargarPregunta";
            btnCargarPregunta.Size = new Size(117, 23);
            btnCargarPregunta.TabIndex = 4;
            btnCargarPregunta.Text = "Cargar pregunta";
            btnCargarPregunta.UseVisualStyleBackColor = true;
            btnCargarPregunta.Click += btnCargarPregunta_Click;
            // 
            // btnResponder
            // 
            btnResponder.Location = new Point(144, 12);
            btnResponder.Name = "btnResponder";
            btnResponder.Size = new Size(117, 23);
            btnResponder.TabIndex = 5;
            btnResponder.Text = "Responder";
            btnResponder.UseVisualStyleBackColor = true;
            btnResponder.Click += btnResponder_Click;
            // 
            // lblNivel
            // 
            lblNivel.AutoSize = true;
            lblNivel.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNivel.Location = new Point(278, 10);
            lblNivel.Name = "lblNivel";
            lblNivel.Size = new Size(62, 25);
            lblNivel.TabIndex = 6;
            lblNivel.Text = "Nivel:";
            // 
            // grillaRespuestas
            // 
            grillaRespuestas.AllowUserToAddRows = false;
            grillaRespuestas.AllowUserToDeleteRows = false;
            grillaRespuestas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaRespuestas.Location = new Point(17, 338);
            grillaRespuestas.Name = "grillaRespuestas";
            grillaRespuestas.ReadOnly = true;
            grillaRespuestas.Size = new Size(483, 198);
            grillaRespuestas.TabIndex = 7;
            // 
            // lblPuntos
            // 
            lblPuntos.AutoSize = true;
            lblPuntos.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPuntos.Location = new Point(395, 10);
            lblPuntos.Name = "lblPuntos";
            lblPuntos.Size = new Size(80, 25);
            lblPuntos.TabIndex = 8;
            lblPuntos.Text = "Puntos:";
            // 
            // frmRespuestas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(530, 548);
            Controls.Add(lblPuntos);
            Controls.Add(grillaRespuestas);
            Controls.Add(lblNivel);
            Controls.Add(btnResponder);
            Controls.Add(btnCargarPregunta);
            Controls.Add(flpOpciones);
            Controls.Add(lblPregunta);
            Controls.Add(label1);
            Controls.Add(cbxJugadores);
            Name = "frmRespuestas";
            Text = "frmRespuestas";
            Load += frmRespuestas_Load;
            ((System.ComponentModel.ISupportInitialize)grillaRespuestas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbxJugadores;
        private Label label1;
        private Label lblPregunta;
        private FlowLayoutPanel flpOpciones;
        private Button btnCargarPregunta;
        private Button btnResponder;
        private Label lblNivel;
        private DataGridView grillaRespuestas;
        private Label lblPuntos;
    }
}