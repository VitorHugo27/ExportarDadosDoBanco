namespace ExportarDoBanco
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btnFiltro = new Button();
            dataGridView1 = new DataGridView();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            textBuscar = new TextBox();
            SelectColuns = new ComboBox();
            SelectTable = new ComboBox();
            button1 = new Button();
            Limpar = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // btnFiltro
            // 
            btnFiltro.Location = new Point(826, 14);
            btnFiltro.Name = "btnFiltro";
            btnFiltro.Size = new Size(75, 23);
            btnFiltro.TabIndex = 0;
            btnFiltro.Text = "Filtrar";
            btnFiltro.UseVisualStyleBackColor = true;
            btnFiltro.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.BackgroundColor = Color.DarkSlateGray;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.GridColor = Color.Black;
            dataGridView1.Location = new Point(268, 42);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(714, 476);
            dataGridView1.TabIndex = 1;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 521);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(994, 22);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(118, 17);
            toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // textBuscar
            // 
            textBuscar.Location = new Point(651, 14);
            textBuscar.Name = "textBuscar";
            textBuscar.Size = new Size(169, 23);
            textBuscar.TabIndex = 3;
            // 
            // SelectColuns
            // 
            SelectColuns.Location = new Point(468, 14);
            SelectColuns.Name = "SelectColuns";
            SelectColuns.Size = new Size(177, 23);
            SelectColuns.TabIndex = 4;
            SelectColuns.Text = "Colunas";
            SelectColuns.SelectedIndexChanged += SelectColuns_SelectedIndexChanged;
            // 
            // SelectTable
            // 
            SelectTable.Location = new Point(268, 14);
            SelectTable.Name = "SelectTable";
            SelectTable.Size = new Size(194, 23);
            SelectTable.TabIndex = 5;
            SelectTable.Text = "Tabela";
            SelectTable.SelectedIndexChanged += SelectTable_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Location = new Point(12, 67);
            button1.Name = "button1";
            button1.Size = new Size(239, 72);
            button1.TabIndex = 6;
            button1.Text = "EXPORTAR";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // Limpar
            // 
            Limpar.Location = new Point(907, 14);
            Limpar.Name = "Limpar";
            Limpar.Size = new Size(75, 23);
            Limpar.TabIndex = 7;
            Limpar.Text = "Limpar";
            Limpar.UseVisualStyleBackColor = true;
            Limpar.Click += Limpar_Click;
            // 
            // button2
            // 
            button2.Location = new Point(12, 145);
            button2.Name = "button2";
            button2.Size = new Size(239, 72);
            button2.TabIndex = 8;
            button2.Text = "IMPORTAR";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(12, 223);
            button3.Name = "button3";
            button3.Size = new Size(239, 72);
            button3.TabIndex = 9;
            button3.Text = "DETALHES DA TABELA";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(12, 446);
            button4.Name = "button4";
            button4.Size = new Size(239, 72);
            button4.TabIndex = 10;
            button4.Text = "MANUAL DO SISTEMA";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Teal;
            ClientSize = new Size(994, 543);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(Limpar);
            Controls.Add(button1);
            Controls.Add(SelectTable);
            Controls.Add(SelectColuns);
            Controls.Add(textBuscar);
            Controls.Add(statusStrip1);
            Controls.Add(dataGridView1);
            Controls.Add(btnFiltro);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Manipular dados do banco";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnFiltro;
        private DataGridView dataGridView1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private TextBox textBuscar;
        private ComboBox SelectColuns;
        private ComboBox SelectTable;
        private Button button1;
        private Button Limpar;
        private Button button2;
        private Button button3;
        private Button button4;
    }
}
