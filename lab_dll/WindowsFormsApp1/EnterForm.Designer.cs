using System.Windows.Forms;

namespace WindowsFormsApp1
{
    partial class EnterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if 
        /// managed resources should be disposed; otherwise, false.</param>
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
            this.components = new System.ComponentModel.Container();
            this._radioButton1 = new System.Windows.Forms.RadioButton();
            this.label0 = new System.Windows.Forms.Label();
            this._groupBox1 = new System.Windows.Forms.GroupBox();
            this._textBox4 = new System.Windows.Forms.TextBox();
            this._textBox3 = new System.Windows.Forms.TextBox();
            this._textBox2 = new System.Windows.Forms.TextBox();
            this._textBox1 = new System.Windows.Forms.TextBox();
            this._label9 = new System.Windows.Forms.Label();
            this._label8 = new System.Windows.Forms.Label();
            this._label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this._label5 = new System.Windows.Forms.Label();
            this._button3 = new System.Windows.Forms.Button();
            this._button2 = new System.Windows.Forms.Button();
            this._button1 = new System.Windows.Forms.Button();
            this._label4 = new System.Windows.Forms.Label();
            this._label3 = new System.Windows.Forms.Label();
            this._label2 = new System.Windows.Forms.Label();
            this._label1 = new System.Windows.Forms.Label();
            this._radioButton3 = new System.Windows.Forms.RadioButton();
            this._radioButton2 = new System.Windows.Forms.RadioButton();
            this._toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this._groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _radioButton1
            // 
            this._radioButton1.AutoSize = true;
            this._radioButton1.Location = new System.Drawing.Point(14, 86);
            this._radioButton1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this._radioButton1.Name = "_radioButton1";
            this._radioButton1.Size = new System.Drawing.Size(136, 24);
            this._radioButton1.TabIndex = 0;
            this._radioButton1.TabStop = true;
            this._radioButton1.Text = "Равномерное";
            this._radioButton1.UseVisualStyleBackColor = true;
            this._radioButton1.CheckedChanged += new System.EventHandler(this.AnyRadioButtonCheckedChanged);
            // 
            // label0
            // 
            this.label0.AutoSize = true;
            this.label0.Location = new System.Drawing.Point(9, 46);
            this.label0.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label0.Name = "label0";
            this.label0.Size = new System.Drawing.Size(338, 20);
            this.label0.TabIndex = 1;
            this.label0.Text = "Выберете рассчитываемый тип движения: ";
            // 
            // _groupBox1
            // 
            this._groupBox1.Controls.Add(this._textBox4);
            this._groupBox1.Controls.Add(this._textBox3);
            this._groupBox1.Controls.Add(this._textBox2);
            this._groupBox1.Controls.Add(this._textBox1);
            this._groupBox1.Controls.Add(this._label9);
            this._groupBox1.Controls.Add(this._label8);
            this._groupBox1.Controls.Add(this._label7);
            this._groupBox1.Controls.Add(this.label6);
            this._groupBox1.Controls.Add(this._label5);
            this._groupBox1.Controls.Add(this._button3);
            this._groupBox1.Controls.Add(this._button2);
            this._groupBox1.Controls.Add(this._button1);
            this._groupBox1.Controls.Add(this._label4);
            this._groupBox1.Controls.Add(this._label3);
            this._groupBox1.Controls.Add(this._label2);
            this._groupBox1.Controls.Add(this._label1);
            this._groupBox1.Controls.Add(this._radioButton3);
            this._groupBox1.Controls.Add(this._radioButton2);
            this._groupBox1.Controls.Add(this._radioButton1);
            this._groupBox1.Controls.Add(this.label0);
            this._groupBox1.Location = new System.Drawing.Point(18, 18);
            this._groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this._groupBox1.Name = "_groupBox1";
            this._groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this._groupBox1.Size = new System.Drawing.Size(414, 485);
            this._groupBox1.TabIndex = 2;
            this._groupBox1.TabStop = false;
            this._groupBox1.Text = "Данные для расчёта";
            // 
            // _textBox4
            // 
            this._textBox4.ForeColor = System.Drawing.SystemColors.ControlDark;
            this._textBox4.Location = new System.Drawing.Point(220, 362);
            this._textBox4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this._textBox4.Name = "_textBox4";
            this._textBox4.Size = new System.Drawing.Size(148, 26);
            this._textBox4.TabIndex = 29;
            this._textBox4.Text = "1234567,89";
            this._textBox4.TextChanged += new System.EventHandler(this._textBox4_TextChanged);
            // 
            // _textBox3
            // 
            this._textBox3.ForeColor = System.Drawing.SystemColors.ControlDark;
            this._textBox3.Location = new System.Drawing.Point(220, 322);
            this._textBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this._textBox3.Name = "_textBox3";
            this._textBox3.Size = new System.Drawing.Size(148, 26);
            this._textBox3.TabIndex = 28;
            this._textBox3.Text = "1234567,89";
            this._textBox3.TextChanged += new System.EventHandler(this._textBox3_TextChanged);
            // 
            // _textBox2
            // 
            this._textBox2.ForeColor = System.Drawing.SystemColors.ControlDark;
            this._textBox2.Location = new System.Drawing.Point(220, 282);
            this._textBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this._textBox2.Name = "_textBox2";
            this._textBox2.Size = new System.Drawing.Size(148, 26);
            this._textBox2.TabIndex = 27;
            this._textBox2.Text = "1234567,89";
            this._textBox2.TextChanged += new System.EventHandler(this._textBox2_TextChanged);
            // 
            // _textBox1
            // 
            this._textBox1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this._textBox1.Location = new System.Drawing.Point(220, 242);
            this._textBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this._textBox1.Name = "_textBox1";
            this._textBox1.Size = new System.Drawing.Size(148, 26);
            this._textBox1.TabIndex = 26;
            this._textBox1.Text = "1234567,89";
            this._textBox1.TextChanged += new System.EventHandler(this._textBox1_TextChanged);
            // 
            // _label9
            // 
            this._label9.AutoSize = true;
            this._label9.Location = new System.Drawing.Point(372, 326);
            this._label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._label9.Name = "_label9";
            this._label9.Size = new System.Drawing.Size(31, 20);
            this._label9.TabIndex = 25;
            this._label9.Text = "≥ 0";
            // 
            // _label8
            // 
            this._label8.AutoSize = true;
            this._label8.Location = new System.Drawing.Point(372, 286);
            this._label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._label8.Name = "_label8";
            this._label8.Size = new System.Drawing.Size(31, 20);
            this._label8.TabIndex = 24;
            this._label8.Text = "≥ 0";
            // 
            // _label7
            // 
            this._label7.AutoSize = true;
            this._label7.Location = new System.Drawing.Point(372, 246);
            this._label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._label7.Name = "_label7";
            this._label7.Size = new System.Drawing.Size(31, 20);
            this._label7.TabIndex = 23;
            this._label7.Text = "≥ 0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(352, 245);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 20);
            this.label6.TabIndex = 22;
            // 
            // _label5
            // 
            this._label5.AutoSize = true;
            this._label5.Location = new System.Drawing.Point(9, 202);
            this._label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._label5.Name = "_label5";
            this._label5.Size = new System.Drawing.Size(210, 20);
            this._label5.TabIndex = 21;
            this._label5.Text = "Введите исходные даные:";
            // 
            // _button3
            // 
            this._button3.Location = new System.Drawing.Point(292, 434);
            this._button3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this._button3.Name = "_button3";
            this._button3.Size = new System.Drawing.Size(112, 35);
            this._button3.TabIndex = 20;
            this._button3.Text = "Отмена";
            this._button3.UseVisualStyleBackColor = true;
            // 
            // _button2
            // 
            this._button2.Location = new System.Drawing.Point(148, 434);
            this._button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this._button2.Name = "_button2";
            this._button2.Size = new System.Drawing.Size(112, 35);
            this._button2.TabIndex = 19;
            this._button2.Text = "Случайн.";
            this._button2.UseVisualStyleBackColor = true;
            // 
            // _button1
            // 
            this._button1.Location = new System.Drawing.Point(9, 434);
            this._button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this._button1.Name = "_button1";
            this._button1.Size = new System.Drawing.Size(112, 35);
            this._button1.TabIndex = 18;
            this._button1.Text = "OK";
            this._button1.UseVisualStyleBackColor = true;
            // 
            // _label4
            // 
            this._label4.AutoSize = true;
            this._label4.Location = new System.Drawing.Point(9, 366);
            this._label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._label4.Name = "_label4";
            this._label4.Size = new System.Drawing.Size(144, 20);
            this._label4.TabIndex = 11;
            this._label4.Text = "Starting coordinate";
            // 
            // _label3
            // 
            this._label3.AutoSize = true;
            this._label3.Location = new System.Drawing.Point(9, 326);
            this._label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._label3.Name = "_label3";
            this._label3.Size = new System.Drawing.Size(144, 20);
            this._label3.TabIndex = 10;
            this._label3.Text = "Starting coordinate";
            // 
            // _label2
            // 
            this._label2.AutoSize = true;
            this._label2.Location = new System.Drawing.Point(9, 286);
            this._label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._label2.Name = "_label2";
            this._label2.Size = new System.Drawing.Size(144, 20);
            this._label2.TabIndex = 9;
            this._label2.Text = "Starting coordinate";
            // 
            // _label1
            // 
            this._label1.AutoSize = true;
            this._label1.Location = new System.Drawing.Point(9, 246);
            this._label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._label1.Name = "_label1";
            this._label1.Size = new System.Drawing.Size(187, 20);
            this._label1.TabIndex = 7;
            this._label1.Text = "Временной интервал, с";
            // 
            // _radioButton3
            // 
            this._radioButton3.AutoSize = true;
            this._radioButton3.Location = new System.Drawing.Point(14, 157);
            this._radioButton3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this._radioButton3.Name = "_radioButton3";
            this._radioButton3.Size = new System.Drawing.Size(154, 24);
            this._radioButton3.TabIndex = 3;
            this._radioButton3.TabStop = true;
            this._radioButton3.Text = "Колебательное";
            this._radioButton3.UseVisualStyleBackColor = true;
            this._radioButton3.CheckedChanged += new System.EventHandler(this.AnyRadioButtonCheckedChanged);
            // 
            // _radioButton2
            // 
            this._radioButton2.AutoSize = true;
            this._radioButton2.Location = new System.Drawing.Point(14, 122);
            this._radioButton2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this._radioButton2.Name = "_radioButton2";
            this._radioButton2.Size = new System.Drawing.Size(166, 24);
            this._radioButton2.TabIndex = 2;
            this._radioButton2.TabStop = true;
            this._radioButton2.Text = "Равноускоренное";
            this._radioButton2.UseVisualStyleBackColor = true;
            this._radioButton2.CheckedChanged += new System.EventHandler(this.AnyRadioButtonCheckedChanged);
            // 
            // EnterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 495);
            this.Controls.Add(this._groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximumSize = new System.Drawing.Size(463, 551);
            this.MinimumSize = new System.Drawing.Size(463, 551);
            this.Name = "EnterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Новый расчёт";
            this._groupBox1.ResumeLayout(false);
            this._groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton _radioButton1;
        private System.Windows.Forms.Label label0;
        private System.Windows.Forms.GroupBox _groupBox1;
        private System.Windows.Forms.RadioButton _radioButton3;
        private System.Windows.Forms.RadioButton _radioButton2;
        private System.Windows.Forms.Label _label1;
        private System.Windows.Forms.Label _label4;
        private System.Windows.Forms.Label _label3;
        private System.Windows.Forms.Label _label2;
        private System.Windows.Forms.ToolTip _toolTip1;
        private Button _button3;
        private Button _button2;
        private Button _button1;
        private Label label6;
        private Label _label5;
        private Label _label7;
        private Label _label8;
        private Label _label9;
        private TextBox _textBox4;
        private TextBox _textBox3;
        private TextBox _textBox2;
        private TextBox _textBox1;
    }
}