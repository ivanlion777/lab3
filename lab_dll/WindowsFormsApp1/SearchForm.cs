using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    /// <summary>
    /// Класс "Форма для поиска".
    /// Используется для ввода критериев,
    /// по которым будет осуществлён
    /// поиск среди данных, полученных ранее.
    /// </summary>
    public partial class SearchForm : HelpingForms
    {
        /// <summary>
        /// Поле, содержащее информацию о том,
        /// какие типы движения отмечены для поиска
        /// пользователем
        /// </summary>
        private CheckBox[] _checkedMotionsType = 
            new CheckBox[3];

        /// <summary>
        /// Конструктор класса "Форма для поиска", используется
        /// для создания класса
        /// </summary>
        public SearchForm()
        {
            InitializeComponent();

            DefaultValues(true, _toolTip1, 
                _textBox1, _textBox2, _textBox3, _textBox4);
            AdditionallyInitialization();

            FormClosing += new FormClosingEventHandler(AnyFormClosing);
            _button1.Click += new System.EventHandler(ApplyButtonClick);
            _button2.Click += new System.EventHandler(AnyCancelClick);

            _checkedMotionsType[0] = _checkBox1;
            _checkedMotionsType[1] = _checkBox2;
            _checkedMotionsType[2] = _checkBox3;

            foreach (CheckBox element in _checkedMotionsType)
                element.Checked = true;
            _checkBox6.Enabled = false;
        }

        /// <summary>
        /// Переопределение метода Operation
        /// для обработчика событий ApplyClick
        /// базового класса 
        /// в случае работы в данной форме
        /// </summary>
        protected override void Operation()
        {
            int resultsQuantity = Searh();

            if (resultsQuantity == 0)
            {
                MessageBox.Show(
                    "Соответсвующим " +
                    "введённым атрибутам поиска объектов не найдено.",
                    "Результаты поиска.",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                Data.DefaultSearchFlags(true);
            }
        }

        /// <summary>
        /// Обработчик события, который вызывается,
        /// когда пользователь изменил выбор
        /// _checkBox4 либо _checkBox5
        /// </summary>
        private void AnyCheckBoxCheckedChanged(object sender, EventArgs e)
        {
            _textBox1.Enabled = _checkBox4.Checked;
            _textBox2.Enabled = _checkBox5.Checked;
            _textBox3.Enabled = _checkBox4.Checked;
            _textBox4.Enabled = _checkBox5.Checked;
            _checkBox6.Enabled = _checkBox4.Checked 
                & _checkBox5.Checked;
        }

        /// <summary>
        /// Обработчик события, который вызывается,
        /// когда пользователь навёл курсор мыши на область,
        /// занимаемую checkBox6
        /// </summary>
        private void CheckBox6MouseHover(object sender, EventArgs e)
        {
            _toolTip2.ToolTipTitle = "Выбрать строгий подбор по X и V";
            _toolTip2.Show(
                "Если отмечено, " +
                "то объекты поиска подбираются по совпадению" +
                "\nИ координаты И скорости." +
                "\nВ противном случае объект должен попадать " +
                "хотя бы под один параметр.",
                _checkBox6, -135, 25, 15000);
        }

        /// <summary>
        /// Метод, реализующий
        /// алгоритм поиска по заданным
        /// пользователем критериям. Возвращает
        /// количество найденных объектов.
        /// </summary>
        private int Searh()
        {
            int counter = 0;
            Data.DefaultSearchFlags(false);

            for (int i = 0; i < Data.NamesOfMotions.Length; i++)
            MotionTypeFind(_checkedMotionsType[i].Checked, 
                ref counter, Data.NamesOfMotions[i]);

            if (_checkBox4.Checked | _checkBox5.Checked)
            {
                counter = 0;
                List<bool> searchFlagsCoordinate = 
                    new List<bool>(Data.SearchFlags.Count);
                List<bool> searchFlagsVelocity = 
                    new List<bool>(Data.SearchFlags.Count);

                for (int i = 0; i < Data.Measurements.Count; i++)
                {
                    searchFlagsCoordinate.Insert(i, MotionValuesFind(
                        i, Data.Measurements[i].Coordinate,
                        _checkBox4.Checked, true));
                    searchFlagsVelocity.Insert(i, MotionValuesFind(
                        i, Data.Measurements[i].Velocity,
                        _checkBox5.Checked, false));

                    if (!_checkBox6.Checked)
                        Data.SearchFlags[i] = 
                            searchFlagsCoordinate[i] | 
                            searchFlagsVelocity[i];
                    else
                        Data.SearchFlags[i] = 
                            searchFlagsCoordinate[i] & 
                            searchFlagsVelocity[i];
                    
                    if (Data.SearchFlags[i] == true) 
                        counter++;
                }
            }
            return counter;
        }

        /// <summary>
        /// Метод, реализующий
        /// алгоритм поиска по заданным
        /// пользователем типам движения. 
        /// </summary>
        /// <param name="isRequired"> Указывает,
        /// требуется ли вообще искать результаты
        /// по указанному параметру.</param>
        /// <param name="counter"> Показывает,
        /// сколько результатов нашлось
        /// по указанному параметру.</param>
        /// <param name="parameter"> Указывает,
        /// по какому параметру будет
        /// осуществляться поиск.</param>
        private void MotionTypeFind(bool isRequired, 
            ref int counter, string parameter)
        {
            if (isRequired)
            {
                for (int i = 0; i < Data.Measurements.Count; i++)
                {
                    if (Convert.ToString(Data.Measurements[i])
                        .Contains(parameter))
                    {
                        Data.SearchFlags[i] = true;
                        counter++;
                    }
                }
            }
        }

        /// <summary>
        /// Метод, реализующий
        /// алгоритм поиска по заданному
        /// пользователем значению параметра движения. 
        /// Возвращает логическое значение соответствия
        /// указанного параметра условиям поиска.
        /// </summary>
        /// <param name="isRequired"> Указывает,
        /// требуется ли вообще искать результаты
        /// по указанному параметру.</param>
        /// <param name="index"> Индекс объекта
        /// в списке Measurements </param>
        /// <param name="parameter"> Указывает,
        /// по какому параметру будет
        /// осуществляться поиск.</param>
        /// <param name="isCoordinate"> Указывает,
        /// является ли указанный параметр координатой
        /// </param>
        private bool MotionValuesFind(int index, double parameter,
            bool isRequired, bool isCoordinate)
        {
            byte addRange = 1;

            if (isCoordinate)
                addRange = 0;

            if (Data.SearchFlags[index] == true 
                && parameter <= ExtremValues[2 + addRange] + 1e-10
                && parameter >= ExtremValues[0 + addRange] - 1e-10
                && isRequired)
                return true;
            else
                return false;
        }

        private void _button1_Click(object sender, EventArgs e)
        {

        }
    }
}