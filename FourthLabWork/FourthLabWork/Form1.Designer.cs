namespace FourthLabWork
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.rbFunc2_3 = new System.Windows.Forms.RadioButton();
            this.rbFunc2_2 = new System.Windows.Forms.RadioButton();
            this.rbFunc2_1 = new System.Windows.Forms.RadioButton();
            this.rbTestFunc = new System.Windows.Forms.RadioButton();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnCount = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.answerBox = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.nudR0 = new System.Windows.Forms.NumericUpDown();
            this.nudZ = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nudEps = new System.Windows.Forms.NumericUpDown();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.nudX2 = new System.Windows.Forms.NumericUpDown();
            this.nudX1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbCarrollFunc = new System.Windows.Forms.RadioButton();
            this.rbFrischFunc = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudR0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEps)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudX2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudX1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Controls.Add(this.groupBox7);
            this.groupBox1.Controls.Add(this.groupBox6);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(704, 225);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Настройки вычислений";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.rbFunc2_3);
            this.groupBox7.Controls.Add(this.rbFunc2_2);
            this.groupBox7.Controls.Add(this.rbFunc2_1);
            this.groupBox7.Controls.Add(this.rbTestFunc);
            this.groupBox7.Location = new System.Drawing.Point(10, 101);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(449, 67);
            this.groupBox7.TabIndex = 16;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Расчетные функции";
            // 
            // rbFunc2_3
            // 
            this.rbFunc2_3.AutoSize = true;
            this.rbFunc2_3.Location = new System.Drawing.Point(350, 31);
            this.rbFunc2_3.Name = "rbFunc2_3";
            this.rbFunc2_3.Size = new System.Drawing.Size(86, 17);
            this.rbFunc2_3.TabIndex = 3;
            this.rbFunc2_3.Text = "Учебная 2.3";
            this.rbFunc2_3.UseVisualStyleBackColor = true;
            this.rbFunc2_3.CheckedChanged += new System.EventHandler(this.rbFunc2_3_CheckedChanged);
            // 
            // rbFunc2_2
            // 
            this.rbFunc2_2.AutoSize = true;
            this.rbFunc2_2.Location = new System.Drawing.Point(241, 31);
            this.rbFunc2_2.Name = "rbFunc2_2";
            this.rbFunc2_2.Size = new System.Drawing.Size(86, 17);
            this.rbFunc2_2.TabIndex = 2;
            this.rbFunc2_2.Text = "Учебная 2.2";
            this.rbFunc2_2.UseVisualStyleBackColor = true;
            this.rbFunc2_2.CheckedChanged += new System.EventHandler(this.rbFunc2_2_CheckedChanged);
            // 
            // rbFunc2_1
            // 
            this.rbFunc2_1.AutoSize = true;
            this.rbFunc2_1.Location = new System.Drawing.Point(115, 31);
            this.rbFunc2_1.Name = "rbFunc2_1";
            this.rbFunc2_1.Size = new System.Drawing.Size(86, 17);
            this.rbFunc2_1.TabIndex = 1;
            this.rbFunc2_1.Text = "Учебная 2.1";
            this.rbFunc2_1.UseVisualStyleBackColor = true;
            this.rbFunc2_1.CheckedChanged += new System.EventHandler(this.rbFunc2_1_CheckedChanged);
            // 
            // rbTestFunc
            // 
            this.rbTestFunc.AutoSize = true;
            this.rbTestFunc.Checked = true;
            this.rbTestFunc.Location = new System.Drawing.Point(16, 31);
            this.rbTestFunc.Name = "rbTestFunc";
            this.rbTestFunc.Size = new System.Drawing.Size(73, 17);
            this.rbTestFunc.TabIndex = 0;
            this.rbTestFunc.TabStop = true;
            this.rbTestFunc.Text = "Тестовая";
            this.rbTestFunc.UseVisualStyleBackColor = true;
            this.rbTestFunc.CheckedChanged += new System.EventHandler(this.rbTestFunc_CheckedChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnCount);
            this.groupBox6.Controls.Add(this.label6);
            this.groupBox6.Controls.Add(this.answerBox);
            this.groupBox6.Location = new System.Drawing.Point(10, 174);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(688, 45);
            this.groupBox6.TabIndex = 15;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Расчеты";
            // 
            // btnCount
            // 
            this.btnCount.Location = new System.Drawing.Point(486, 13);
            this.btnCount.Name = "btnCount";
            this.btnCount.Size = new System.Drawing.Size(189, 23);
            this.btnCount.TabIndex = 2;
            this.btnCount.Text = "Рассчитать";
            this.btnCount.UseVisualStyleBackColor = true;
            this.btnCount.Click += new System.EventHandler(this.btnCount_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Минимум:";
            // 
            // answerBox
            // 
            this.answerBox.Location = new System.Drawing.Point(86, 15);
            this.answerBox.Name = "answerBox";
            this.answerBox.Size = new System.Drawing.Size(394, 20);
            this.answerBox.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.nudR0);
            this.groupBox5.Controls.Add(this.nudZ);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.nudEps);
            this.groupBox5.Location = new System.Drawing.Point(221, 19);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(477, 75);
            this.groupBox5.TabIndex = 14;
            this.groupBox5.TabStop = false;
            // 
            // nudR0
            // 
            this.nudR0.DecimalPlaces = 3;
            this.nudR0.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudR0.Location = new System.Drawing.Point(244, 45);
            this.nudR0.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudR0.Name = "nudR0";
            this.nudR0.Size = new System.Drawing.Size(220, 20);
            this.nudR0.TabIndex = 11;
            this.nudR0.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // nudZ
            // 
            this.nudZ.DecimalPlaces = 3;
            this.nudZ.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudZ.Location = new System.Drawing.Point(210, 19);
            this.nudZ.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudZ.Name = "nudZ";
            this.nudZ.Size = new System.Drawing.Size(79, 20);
            this.nudZ.TabIndex = 10;
            this.nudZ.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(186, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Коэффициент изменения штрафа z";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(295, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Точность eps";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(224, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Начальное значение параметра штрафа r0";
            // 
            // nudEps
            // 
            this.nudEps.DecimalPlaces = 3;
            this.nudEps.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudEps.Location = new System.Drawing.Point(386, 19);
            this.nudEps.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudEps.Name = "nudEps";
            this.nudEps.Size = new System.Drawing.Size(79, 20);
            this.nudEps.TabIndex = 8;
            this.nudEps.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.nudX2);
            this.groupBox4.Controls.Add(this.nudX1);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Location = new System.Drawing.Point(10, 19);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 75);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Начальная точка";
            // 
            // nudX2
            // 
            this.nudX2.DecimalPlaces = 1;
            this.nudX2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudX2.Location = new System.Drawing.Point(57, 48);
            this.nudX2.Name = "nudX2";
            this.nudX2.Size = new System.Drawing.Size(120, 20);
            this.nudX2.TabIndex = 2;
            // 
            // nudX1
            // 
            this.nudX1.DecimalPlaces = 1;
            this.nudX1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudX1.Location = new System.Drawing.Point(57, 22);
            this.nudX1.Name = "nudX1";
            this.nudX1.Size = new System.Drawing.Size(120, 20);
            this.nudX1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "X1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "X2";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbCarrollFunc);
            this.groupBox3.Controls.Add(this.rbFrischFunc);
            this.groupBox3.Location = new System.Drawing.Point(465, 101);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(233, 67);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Функция барьера";
            // 
            // rbCarrollFunc
            // 
            this.rbCarrollFunc.AutoSize = true;
            this.rbCarrollFunc.Checked = true;
            this.rbCarrollFunc.Location = new System.Drawing.Point(16, 28);
            this.rbCarrollFunc.Name = "rbCarrollFunc";
            this.rbCarrollFunc.Size = new System.Drawing.Size(74, 17);
            this.rbCarrollFunc.TabIndex = 11;
            this.rbCarrollFunc.TabStop = true;
            this.rbCarrollFunc.Text = "Кэрролла";
            this.rbCarrollFunc.UseVisualStyleBackColor = true;
            // 
            // rbFrischFunc
            // 
            this.rbFrischFunc.AutoSize = true;
            this.rbFrischFunc.Location = new System.Drawing.Point(142, 28);
            this.rbFrischFunc.Name = "rbFrischFunc";
            this.rbFrischFunc.Size = new System.Drawing.Size(62, 17);
            this.rbFrischFunc.TabIndex = 10;
            this.rbFrischFunc.Text = "Фриша";
            this.rbFrischFunc.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.rtbLog);
            this.groupBox2.Location = new System.Drawing.Point(12, 243);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(704, 171);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ход вычислений";
            // 
            // rtbLog
            // 
            this.rtbLog.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rtbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbLog.Location = new System.Drawing.Point(3, 16);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.ReadOnly = true;
            this.rtbLog.Size = new System.Drawing.Size(698, 152);
            this.rtbLog.TabIndex = 0;
            this.rtbLog.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 426);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximumSize = new System.Drawing.Size(738, 465);
            this.MinimumSize = new System.Drawing.Size(738, 465);
            this.Name = "Form1";
            this.Text = "Лабораторная работа №4";
            this.groupBox1.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudR0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEps)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudX2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudX1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbCarrollFunc;
        private System.Windows.Forms.RadioButton rbFrischFunc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudEps;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudX2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudX1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnCount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox answerBox;
        private System.Windows.Forms.RadioButton rbFunc2_2;
        private System.Windows.Forms.RadioButton rbFunc2_1;
        private System.Windows.Forms.RadioButton rbTestFunc;
        private System.Windows.Forms.RadioButton rbFunc2_3;
        private System.Windows.Forms.NumericUpDown nudR0;
        private System.Windows.Forms.NumericUpDown nudZ;
    }
}

