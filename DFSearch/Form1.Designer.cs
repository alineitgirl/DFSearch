﻿namespace DFSearch
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
            menuStrip1 = new MenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            сохранитьКакToolStripMenuItem = new ToolStripMenuItem();
            файлToolStripMenuItem = new ToolStripMenuItem();
            изображениеToolStripMenuItem = new ToolStripMenuItem();
            открытьToolStripMenuItem = new ToolStripMenuItem();
            выходToolStripMenuItem1 = new ToolStripMenuItem();
            правкаToolStripMenuItem = new ToolStripMenuItem();
            очиститьToolStripMenuItem = new ToolStripMenuItem();
            историяСессийToolStripMenuItem = new ToolStripMenuItem();
            справкаToolStripMenuItem = new ToolStripMenuItem();
            просмотрСправкиToolStripMenuItem = new ToolStripMenuItem();
            техническаяПоддержкаToolStripMenuItem = new ToolStripMenuItem();
            выходToolStripMenuItem = new ToolStripMenuItem();
            panel1 = new Panel();
            dataGridView1 = new DataGridView();
            textBox4 = new TextBox();
            button5 = new Button();
            textBox5 = new TextBox();
            panel2 = new Panel();
            comboBox1 = new ComboBox();
            button4 = new Button();
            label1 = new Label();
            textBox3 = new TextBox();
            button2 = new Button();
            textBox2 = new TextBox();
            button1 = new Button();
            textBox1 = new TextBox();
            splitContainer1 = new SplitContainer();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            label2 = new Label();
            numericUpDown1 = new NumericUpDown();
            panel3 = new Panel();
            label4 = new Label();
            label3 = new Label();
            panel4 = new Panel();
            label5 = new Label();
            menuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, правкаToolStripMenuItem, справкаToolStripMenuItem, выходToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1335, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { сохранитьКакToolStripMenuItem, открытьToolStripMenuItem, выходToolStripMenuItem1 });
            toolStripMenuItem1.Image = (Image)resources.GetObject("toolStripMenuItem1.Image");
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(79, 24);
            toolStripMenuItem1.Text = "Файл";
            // 
            // сохранитьКакToolStripMenuItem
            // 
            сохранитьКакToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { файлToolStripMenuItem, изображениеToolStripMenuItem });
            сохранитьКакToolStripMenuItem.Name = "сохранитьКакToolStripMenuItem";
            сохранитьКакToolStripMenuItem.Size = new Size(192, 26);
            сохранитьКакToolStripMenuItem.Text = "Сохранить как";
            // 
            // файлToolStripMenuItem
            // 
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Size = new Size(190, 26);
            файлToolStripMenuItem.Text = "Файл";
            файлToolStripMenuItem.Click += файлToolStripMenuItem_Click;
            // 
            // изображениеToolStripMenuItem
            // 
            изображениеToolStripMenuItem.Name = "изображениеToolStripMenuItem";
            изображениеToolStripMenuItem.Size = new Size(190, 26);
            изображениеToolStripMenuItem.Text = "Изображение";
            изображениеToolStripMenuItem.Click += изображениеToolStripMenuItem_Click;
            // 
            // открытьToolStripMenuItem
            // 
            открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            открытьToolStripMenuItem.Size = new Size(192, 26);
            открытьToolStripMenuItem.Text = "Открыть";
            открытьToolStripMenuItem.Click += открытьToolStripMenuItem_Click;
            // 
            // выходToolStripMenuItem1
            // 
            выходToolStripMenuItem1.Name = "выходToolStripMenuItem1";
            выходToolStripMenuItem1.Size = new Size(192, 26);
            выходToolStripMenuItem1.Text = "Выход";
            выходToolStripMenuItem1.Click += выходToolStripMenuItem1_Click;
            // 
            // правкаToolStripMenuItem
            // 
            правкаToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { очиститьToolStripMenuItem, историяСессийToolStripMenuItem });
            правкаToolStripMenuItem.Image = (Image)resources.GetObject("правкаToolStripMenuItem.Image");
            правкаToolStripMenuItem.Name = "правкаToolStripMenuItem";
            правкаToolStripMenuItem.Size = new Size(94, 24);
            правкаToolStripMenuItem.Text = "Правка";
            // 
            // очиститьToolStripMenuItem
            // 
            очиститьToolStripMenuItem.Name = "очиститьToolStripMenuItem";
            очиститьToolStripMenuItem.Size = new Size(202, 26);
            очиститьToolStripMenuItem.Text = "Очистить";
            очиститьToolStripMenuItem.Click += очиститьToolStripMenuItem_Click;
            // 
            // историяСессийToolStripMenuItem
            // 
            историяСессийToolStripMenuItem.Name = "историяСессийToolStripMenuItem";
            историяСессийToolStripMenuItem.Size = new Size(202, 26);
            историяСессийToolStripMenuItem.Text = "История сессий";
            историяСессийToolStripMenuItem.Click += историяСессийToolStripMenuItem_Click;
            // 
            // справкаToolStripMenuItem
            // 
            справкаToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { просмотрСправкиToolStripMenuItem, техническаяПоддержкаToolStripMenuItem });
            справкаToolStripMenuItem.Image = (Image)resources.GetObject("справкаToolStripMenuItem.Image");
            справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            справкаToolStripMenuItem.Size = new Size(101, 24);
            справкаToolStripMenuItem.Text = "Справка";
            // 
            // просмотрСправкиToolStripMenuItem
            // 
            просмотрСправкиToolStripMenuItem.Name = "просмотрСправкиToolStripMenuItem";
            просмотрСправкиToolStripMenuItem.Size = new Size(260, 26);
            просмотрСправкиToolStripMenuItem.Text = "Просмотр справки";
            просмотрСправкиToolStripMenuItem.Click += просмотрСправкиToolStripMenuItem_Click;
            // 
            // техническаяПоддержкаToolStripMenuItem
            // 
            техническаяПоддержкаToolStripMenuItem.Name = "техническаяПоддержкаToolStripMenuItem";
            техническаяПоддержкаToolStripMenuItem.Size = new Size(260, 26);
            техническаяПоддержкаToolStripMenuItem.Text = "Техническая поддержка";
            техническаяПоддержкаToolStripMenuItem.Click += техническаяПоддержкаToolStripMenuItem_Click;
            // 
            // выходToolStripMenuItem
            // 
            выходToolStripMenuItem.Image = (Image)resources.GetObject("выходToolStripMenuItem.Image");
            выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            выходToolStripMenuItem.Size = new Size(87, 24);
            выходToolStripMenuItem.Text = "Выход";
            выходToolStripMenuItem.Click += выходToolStripMenuItem_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(dataGridView1);
            panel1.Controls.Add(textBox4);
            panel1.Controls.Add(button5);
            panel1.Controls.Add(textBox5);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(textBox3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(textBox1);
            panel1.Location = new Point(0, 31);
            panel1.Name = "panel1";
            panel1.Size = new Size(1323, 138);
            panel1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.ButtonFace;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(702, 14);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(229, 108);
            dataGridView1.TabIndex = 12;
            // 
            // textBox4
            // 
            textBox4.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBox4.Location = new Point(571, 17);
            textBox4.Multiline = true;
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(105, 32);
            textBox4.TabIndex = 11;
            // 
            // button5
            // 
            button5.BackColor = SystemColors.ScrollBar;
            button5.FlatAppearance.BorderColor = Color.White;
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatAppearance.MouseDownBackColor = Color.Gainsboro;
            button5.FlatAppearance.MouseOverBackColor = Color.WhiteSmoke;
            button5.FlatStyle = FlatStyle.Flat;
            button5.ForeColor = SystemColors.ActiveCaptionText;
            button5.Location = new Point(442, 55);
            button5.Margin = new Padding(0, 3, 3, 3);
            button5.Name = "button5";
            button5.Size = new Size(234, 67);
            button5.TabIndex = 10;
            button5.Text = "Удалить ребро";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // textBox5
            // 
            textBox5.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBox5.Location = new Point(442, 17);
            textBox5.Multiline = true;
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(105, 32);
            textBox5.TabIndex = 9;
            // 
            // panel2
            // 
            panel2.Controls.Add(comboBox1);
            panel2.Controls.Add(button4);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(945, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(375, 125);
            panel2.TabIndex = 8;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Поиск в глубину", "Определение связности графа", "Компоненты связности", "Поиск циклов" });
            comboBox1.Location = new Point(23, 43);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(290, 28);
            comboBox1.TabIndex = 10;
            // 
            // button4
            // 
            button4.BackColor = SystemColors.ScrollBar;
            button4.FlatAppearance.BorderColor = Color.White;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatAppearance.MouseDownBackColor = Color.Gainsboro;
            button4.FlatAppearance.MouseOverBackColor = Color.WhiteSmoke;
            button4.FlatStyle = FlatStyle.Flat;
            button4.ForeColor = SystemColors.ActiveCaptionText;
            button4.Location = new Point(83, 77);
            button4.Margin = new Padding(0, 3, 3, 3);
            button4.Name = "button4";
            button4.Size = new Size(132, 40);
            button4.TabIndex = 9;
            button4.Text = "Применить";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(83, 12);
            label1.Name = "label1";
            label1.Size = new Size(197, 28);
            label1.TabIndex = 7;
            label1.Text = "Выберите алгоритм:";
            // 
            // textBox3
            // 
            textBox3.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBox3.Location = new Point(320, 17);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(105, 32);
            textBox3.TabIndex = 5;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ScrollBar;
            button2.FlatAppearance.BorderColor = Color.White;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.MouseDownBackColor = Color.Gainsboro;
            button2.FlatAppearance.MouseOverBackColor = Color.WhiteSmoke;
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = SystemColors.ActiveCaptionText;
            button2.Location = new Point(191, 55);
            button2.Margin = new Padding(0, 3, 3, 3);
            button2.Name = "button2";
            button2.Size = new Size(234, 67);
            button2.TabIndex = 4;
            button2.Text = "Добавить новое ребро";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBox2.Location = new Point(191, 17);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(105, 32);
            textBox2.TabIndex = 3;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ScrollBar;
            button1.FlatAppearance.BorderColor = Color.White;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseDownBackColor = Color.Gainsboro;
            button1.FlatAppearance.MouseOverBackColor = Color.WhiteSmoke;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = SystemColors.ActiveCaptionText;
            button1.Location = new Point(12, 58);
            button1.Margin = new Padding(0, 3, 3, 3);
            button1.Name = "button1";
            button1.Size = new Size(154, 67);
            button1.TabIndex = 2;
            button1.Text = "Задать количество вершин";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBox1.Location = new Point(12, 20);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(154, 32);
            textBox1.TabIndex = 2;
            // 
            // splitContainer1
            // 
            splitContainer1.Location = new Point(12, 217);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(pictureBox1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(pictureBox2);
            splitContainer1.Size = new Size(1311, 383);
            splitContainer1.SplitterDistance = 667;
            splitContainer1.TabIndex = 2;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.Control;
            pictureBox1.Location = new Point(0, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(664, 406);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            pictureBox1.MouseMove += pictureBox1_MouseMove;
            pictureBox1.MouseUp += pictureBox1_MouseUp;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = SystemColors.Control;
            pictureBox2.Location = new Point(-1, 0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(641, 412);
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(12, 182);
            label2.Name = "label2";
            label2.Size = new Size(230, 23);
            label2.TabIndex = 3;
            label2.Text = "Выбор стартовой вершины:";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(248, 182);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(48, 27);
            numericUpDown1.TabIndex = 4;
            numericUpDown1.TextAlign = HorizontalAlignment.Center;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // panel3
            // 
            panel3.Controls.Add(label4);
            panel3.Controls.Add(label3);
            panel3.Location = new Point(12, 606);
            panel3.Name = "panel3";
            panel3.Size = new Size(637, 101);
            panel3.TabIndex = 5;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point, 204);
            label4.Location = new Point(13, 43);
            label4.Name = "label4";
            label4.Size = new Size(345, 28);
            label4.TabIndex = 7;
            label4.Text = "Сложность алгоритма по времени:";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point, 204);
            label3.Location = new Point(13, 3);
            label3.Name = "label3";
            label3.Size = new Size(299, 28);
            label3.TabIndex = 6;
            label3.Text = "Время выполнения программы:";
            // 
            // panel4
            // 
            panel4.Controls.Add(label5);
            panel4.Location = new Point(682, 606);
            panel4.Name = "panel4";
            panel4.Size = new Size(638, 101);
            panel4.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label5.ForeColor = SystemColors.ActiveCaptionText;
            label5.Location = new Point(20, 6);
            label5.Name = "label5";
            label5.Size = new Size(238, 25);
            label5.TabIndex = 7;
            label5.Text = "Порядок обхода вершин:\r\n";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1335, 762);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(numericUpDown1);
            Controls.Add(label2);
            Controls.Add(splitContainer1);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Алгоритмы на графах";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem правкаToolStripMenuItem;
        private ToolStripMenuItem справкаToolStripMenuItem;
        private ToolStripMenuItem выходToolStripMenuItem;
        private ToolStripMenuItem сохранитьКакToolStripMenuItem;
        private ToolStripMenuItem открытьToolStripMenuItem;
        private ToolStripMenuItem выходToolStripMenuItem1;
        private ToolStripMenuItem просмотрСправкиToolStripMenuItem;
        private ToolStripMenuItem техническаяПоддержкаToolStripMenuItem;
        private Panel panel1;
        private Button button1;
        private TextBox textBox1;
        private TextBox textBox3;
        private Button button2;
        private TextBox textBox2;
        private SplitContainer splitContainer1;
        private Panel panel2;
        private Label label1;
        private Button button4;
        private TextBox textBox4;
        private Button button5;
        private TextBox textBox5;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private ComboBox comboBox1;
        private Label label2;
        private NumericUpDown numericUpDown1;
        private Panel panel3;
        private Label label3;
        private Panel panel4;
        private Label label5;
        private ToolStripMenuItem очиститьToolStripMenuItem;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem изображениеToolStripMenuItem;
        private Label label4;
        private DataGridView dataGridView1;
        private ToolStripMenuItem историяСессийToolStripMenuItem;
    }
}
