namespace ADO_Conectado
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
            button1 = new Button();
            button2 = new Button();
            dataGridView1 = new DataGridView();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            label1 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(167, 45);
            button1.Margin = new Padding(6);
            button1.Name = "button1";
            button1.Size = new Size(184, 49);
            button1.TabIndex = 0;
            button1.Text = "Conectar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(167, 132);
            button2.Margin = new Padding(6);
            button2.Name = "button2";
            button2.Size = new Size(184, 49);
            button2.TabIndex = 1;
            button2.Text = "Desconectar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(429, 45);
            dataGridView1.Margin = new Padding(6);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 82;
            dataGridView1.Size = new Size(1150, 320);
            dataGridView1.TabIndex = 2;
            // 
            // button3
            // 
            button3.Location = new Point(429, 378);
            button3.Margin = new Padding(6);
            button3.Name = "button3";
            button3.Size = new Size(139, 49);
            button3.TabIndex = 3;
            button3.Text = "Agregar";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(601, 378);
            button4.Margin = new Padding(6);
            button4.Name = "button4";
            button4.Size = new Size(139, 49);
            button4.TabIndex = 4;
            button4.Text = "Borrar";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(774, 378);
            button5.Margin = new Padding(6);
            button5.Name = "button5";
            button5.Size = new Size(139, 49);
            button5.TabIndex = 5;
            button5.Text = "Modificar";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold | FontStyle.Italic);
            label1.ForeColor = Color.White;
            label1.Location = new Point(429, 484);
            label1.Name = "label1";
            label1.Size = new Size(320, 41);
            label1.TabIndex = 6;
            label1.Text = "Consulta incremental";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 11F);
            textBox1.Location = new Point(429, 549);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(485, 47);
            textBox1.TabIndex = 7;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Bold | FontStyle.Italic);
            label2.ForeColor = Color.White;
            label2.Location = new Point(429, 654);
            label2.Name = "label2";
            label2.Size = new Size(497, 41);
            label2.TabIndex = 8;
            label2.Text = "Consulta Desde - Hasta por legajo";
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 11F);
            textBox2.Location = new Point(429, 741);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(206, 47);
            textBox2.TabIndex = 9;
            // 
            // textBox3
            // 
            textBox3.Font = new Font("Segoe UI", 11F);
            textBox3.Location = new Point(708, 741);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(206, 47);
            textBox3.TabIndex = 10;
            // 
            // button6
            // 
            button6.Location = new Point(967, 739);
            button6.Margin = new Padding(6);
            button6.Name = "button6";
            button6.Size = new Size(139, 49);
            button6.TabIndex = 11;
            button6.Text = "Consultar";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Location = new Point(1591, 45);
            button7.Margin = new Padding(6);
            button7.Name = "button7";
            button7.Size = new Size(169, 49);
            button7.TabIndex = 12;
            button7.Text = "Agregar_SP";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.Location = new Point(1591, 115);
            button8.Margin = new Padding(6);
            button8.Name = "button8";
            button8.Size = new Size(169, 49);
            button8.TabIndex = 13;
            button8.Text = "Borrar_SP";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // button9
            // 
            button9.Location = new Point(1591, 183);
            button9.Name = "button9";
            button9.Size = new Size(173, 53);
            button9.TabIndex = 14;
            button9.Text = "Modificar_SP";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Red;
            ClientSize = new Size(1846, 960);
            Controls.Add(button9);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(dataGridView1);
            Controls.Add(button2);
            Controls.Add(button1);
            Margin = new Padding(6);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private DataGridView dataGridView1;
        private Button button3;
        private Button button4;
        private Button button5;
        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private TextBox textBox2;
        private TextBox textBox3;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
    }
}
