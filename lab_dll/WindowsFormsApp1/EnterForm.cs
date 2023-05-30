using Lab.Dll;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    /// <summary>
    /// Класс "Форма для ввода данных".
    /// Используется для ввода в общий список 
    /// и валидации данных о различных видах движения.
    /// </summary>
    public partial class EnterForm : HelpingForms
    {

        /// <summary>
        /// Поле, содержащее информацию о том,
        /// на сколько рангов (1 или 0) сократить опрос
        ///  validValuesFlags при конечной проверке 
        ///  валидации данных
        /// </summary>
        private static byte _rangeShorter = 0;

        /// <summary>
        /// Свойство, организующее доступ к полю
        /// _rangeShorter
        /// </summary>
        public static byte RangeShorter 
        {
            get
            {
                return _rangeShorter; 
            }
        }

        /// <summary>
        /// Конструктор класса "Форма для ввода данных", используется
        /// для создания класса
        /// </summary>
        public EnterForm()
        {
            InitializeComponent();
            _radioButton1.Checked = true;
            DefaultValues(false, _toolTip1, 
                _textBox1, _textBox2, _textBox3, _textBox4);
            AdditionallyInitialization();

            FormClosing += new FormClosingEventHandler(AnyFormClosing);
            _button1.Click += new System.EventHandler(ApplyButtonClick);
            _button2.Click += new System.EventHandler(RandomClick);
            _button3.Click += new System.EventHandler(AnyCancelClick);

#if !DEBUG
            _button2.Visible = false;
#endif
        }

        /// <summary>
        /// Переопределение метода Operation
        /// для обработчика событий ApplyClick
        /// базового класса 
        /// в случае работы в данной форме
        /// </summary>
        protected override void Operation()
        {
            IMoveable movement;

            if (_radioButton1.Checked)
            {
                movement = new UniformMotion(
                    Convert.ToDouble(_textBox2.Text),
                    Convert.ToDouble(_textBox3.Text));
            }
            else if (_radioButton2.Checked)
            {
                movement = new AcceleratedMotion(
                    Convert.ToDouble(_textBox2.Text),
                    Convert.ToDouble(_textBox3.Text),
                    Convert.ToDouble(_textBox4.Text));
            }
            else
            {
                movement = new OscillatedMotion(
                    Convert.ToDouble(_textBox1.Text),
                    Convert.ToDouble(_textBox2.Text),
                    Convert.ToDouble(_textBox3.Text),
                    Convert.ToDouble(_textBox4.Text));
            }

            movement.Move(Convert.ToDouble(_textBox1.Text));
            Data.Measurements.Add(movement);

            MessageBox.Show("Расчёты успешно внесены в список.",
                "Информация",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            Data.DefaultSearchFlags(true);
        }

        /// <summary>
        /// Обработчик события, который вызывается,
        /// когда пользователь изменил выбор
        /// любой radioButton в этой форме
        /// </summary>
        private void AnyRadioButtonCheckedChanged(object sender, EventArgs e)
        {
            SpeedEnterable = 
                _radioButton2.Checked | _radioButton1.Checked;
            _textBox4.Visible = _radioButton2.Checked | _radioButton3.Checked;
            _label4.Visible = _textBox4.Visible;
            _label8.Visible = _radioButton3.Checked;
            _rangeShorter = Convert.ToByte(_radioButton1.Checked);

            if (_radioButton1.Checked || _radioButton2.Checked)
            {
                _label2.Text = "Начальная коорданата, м";
                _label3.Text = "Начальная скорость, м/c";
                if (_radioButton2.Checked)
                    _label4.Text = "Ускорение, м/с\u00b2";
            }
            else
            {
                _label2.Text = "Амплитуда, м";
                _label3.Text = "Цикл. частота, рад/с";
                _label4.Text = "Начальная фаза, рад";
            }

            for (int i = 0; i < TextBoxesList.Count; i++)
                DefaultingText(i);
        }

        /// <summary>
        /// Обработчик события, который вызывается,
        /// когда пользователь кликнул по кнопке "Случайн.".
        /// </summary>
        private void RandomClick(object sender, EventArgs e)
        {
            var rand = new Random();
            for (int i = 0; i < TextBoxesList.Count; i++)
            {
                TextBoxesList[i].Text = 
                    Convert.ToString(rand.NextDouble() * 15);
                ValuesPermission(i);
            }
        }
        void ValidateNumber(object sender, EventArgs e, bool positive)
        {
            TextBox textBox = sender as TextBox;
            if (textBox == null)
                return;
            string pattern;
            string text = textBox.Text;
            int cursorPosition = textBox.SelectionStart;
            if (positive)
                pattern = @"^[+]?\d*(\,\d*)?$";
            else
                pattern = @"^[+-]?\d*(\,\d*)?$";

            if (!Regex.IsMatch(text, pattern))
            {
                textBox.Text = text.Remove(cursorPosition - 1, 1);
                textBox.SelectionStart = cursorPosition - 1;
            }
        }
        private void _textBox1_TextChanged(object sender, EventArgs e)
        {
            ValidateNumber(sender, e, true);

        }

        private void _textBox2_TextChanged(object sender, EventArgs e)
        {
            ValidateNumber(sender, e, false);
        }

        private void _textBox3_TextChanged(object sender, EventArgs e)
        {
            ValidateNumber(sender, e, true);
        }

        private void _textBox4_TextChanged(object sender, EventArgs e)
        {
            ValidateNumber(sender, e, false);
        }
    }
}
