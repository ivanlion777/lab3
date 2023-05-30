

namespace WindowsFormsApp1
{
    partial class MotionCalculatorForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, 
        /// если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._groupBox1 = new System.Windows.Forms.GroupBox();
            this._button5 = new System.Windows.Forms.Button();
            this._button4 = new System.Windows.Forms.Button();
            this._button3 = new System.Windows.Forms.Button();
            this._button2 = new System.Windows.Forms.Button();
            this._button1 = new System.Windows.Forms.Button();
            this._dataGridView1 = new System.Windows.Forms.DataGridView();
            this.iMoveableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this._Col1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Col2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Col3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Col4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iMoveableBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // _groupBox1
            // 
            this._groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._groupBox1.Controls.Add(this._button5);
            this._groupBox1.Controls.Add(this._button4);
            this._groupBox1.Controls.Add(this._button3);
            this._groupBox1.Controls.Add(this._button2);
            this._groupBox1.Controls.Add(this._button1);
            this._groupBox1.Controls.Add(this._dataGridView1);
            this._groupBox1.Location = new System.Drawing.Point(12, 13);
            this._groupBox1.Name = "_groupBox1";
            this._groupBox1.Size = new System.Drawing.Size(446, 370);
            this._groupBox1.TabIndex = 0;
            this._groupBox1.TabStop = false;
            this._groupBox1.Text = "Список произведённых расчётов";
            // 
            // _button5
            // 
            this._button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._button5.Location = new System.Drawing.Point(310, 265);
            this._button5.Name = "_button5";
            this._button5.Size = new System.Drawing.Size(110, 23);
            this._button5.TabIndex = 5;
            this._button5.Text = "Сохранить как...";
            this._button5.UseVisualStyleBackColor = true;
            this._button5.Click += new System.EventHandler(this.SaveLoadFileClick);
            // 
            // _button4
            // 
            this._button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._button4.Location = new System.Drawing.Point(26, 265);
            this._button4.Name = "_button4";
            this._button4.Size = new System.Drawing.Size(158, 23);
            this._button4.TabIndex = 4;
            this._button4.Text = "Поиск...";
            this._button4.UseVisualStyleBackColor = true;
            this._button4.Click += new System.EventHandler(this.FormCreatorClick);
            // 
            // _button3
            // 
            this._button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._button3.Location = new System.Drawing.Point(310, 294);
            this._button3.Name = "_button3";
            this._button3.Size = new System.Drawing.Size(110, 23);
            this._button3.TabIndex = 3;
            this._button3.Text = "Загрузить";
            this._button3.UseVisualStyleBackColor = true;
            this._button3.Click += new System.EventHandler(this.SaveLoadFileClick);
            // 
            // _button2
            // 
            this._button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._button2.Location = new System.Drawing.Point(26, 323);
            this._button2.Name = "_button2";
            this._button2.Size = new System.Drawing.Size(158, 23);
            this._button2.TabIndex = 2;
            this._button2.Text = "Удалить выбранный расчёт";
            this._button2.UseVisualStyleBackColor = true;
            this._button2.Click += new System.EventHandler(this.DeleteClick);
            // 
            // _button1
            // 
            this._button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._button1.Location = new System.Drawing.Point(26, 294);
            this._button1.Name = "_button1";
            this._button1.Size = new System.Drawing.Size(158, 23);
            this._button1.TabIndex = 1;
            this._button1.Text = "Добавить расчёт движения";
            this._button1.UseVisualStyleBackColor = true;
            this._button1.Click += new System.EventHandler(this.FormCreatorClick);
            // 
            // _dataGridView1
            // 
            this._dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._Col1,
            this._Col2,
            this._Col3,
            this._Col4});
            this._dataGridView1.Location = new System.Drawing.Point(26, 32);
            this._dataGridView1.Name = "_dataGridView1";
            this._dataGridView1.Size = new System.Drawing.Size(394, 213);
            this._dataGridView1.TabIndex = 0;
            // 
            // _Col1
            // 
            this._Col1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._Col1.FillWeight = 10F;
            this._Col1.HeaderText = "№";
            this._Col1.Name = "_Col1";
            this._Col1.ReadOnly = true;
            this._Col1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // _Col2
            // 
            this._Col2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._Col2.FillWeight = 40F;
            this._Col2.HeaderText = "Вид движения";
            this._Col2.Name = "_Col2";
            this._Col2.ReadOnly = true;
            this._Col2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // _Col3
            // 
            this._Col3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._Col3.FillWeight = 25F;
            this._Col3.HeaderText = "Координата";
            this._Col3.Name = "_Col3";
            this._Col3.ReadOnly = true;
            this._Col3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // _Col4
            // 
            this._Col4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._Col4.FillWeight = 25F;
            this._Col4.HeaderText = "Скорость";
            this._Col4.Name = "_Col4";
            this._Col4.ReadOnly = true;
            this._Col4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // MotionCalculatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 395);
            this.Controls.Add(this._groupBox1);
            this.MinimumSize = new System.Drawing.Size(485, 271);
            this.Name = "MotionCalculatorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MotionCalculatorForm";
            this._groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iMoveableBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox _groupBox1;
        private System.Windows.Forms.Button _button2;
        private System.Windows.Forms.Button _button1;
        private System.Windows.Forms.DataGridView _dataGridView1;
        private System.Windows.Forms.BindingSource iMoveableBindingSource;
        private System.Windows.Forms.Button _button3;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button _button4;
        private System.Windows.Forms.Button _button5;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Col1;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Col2;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Col3;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Col4;
    }
}

