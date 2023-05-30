using Lab.Dll;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    static class Program
    {

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MotionCalculatorForm());
        }
    }

    /// <summary>
    /// Класс "Вспомогательные формы".
    /// Используется для обобщения
    /// классов "Форма для поиска" и 
    /// "Форма для ввода данных".
    /// </summary>
    public class HelpingForms : Form
    {
        /// <summary>
        /// Свойство "Сообщение для диалогового окна".
        /// Используется для хранения
        /// иформации о причине, 
        /// по которой введённые пользователем
        /// данные не прошли валидацию.
        /// </summary>
        protected static string MessageForMessageBox { get; set; }

        /// <summary>
        /// Свойство, содержащее информацию о том,
        /// какие TextBox были очищены.
        /// </summary>
        protected static bool[] СlearedTextboxFlags { get; set; } =
            new bool[4];

        /// <summary>
        /// Свойство, содержащее информацию о том,
        /// какие из данных, введённых пользователем в 
        /// соответствующий textBox прошли валидацию.
        /// </summary>
        protected static bool[] ValidValuesFlags { get; set; } =
            new bool[4];

        /// <summary>
        /// Свойство, содержащее
        /// список всех textBox
        /// в этой форме.
        /// </summary>
        protected static List<TextBox> TextBoxesList { get; set; } =
            new List<TextBox>(4);

        /// <summary>
        /// Свойство, содержащее информацию о
        /// максимально и минимально допустимых значениях,
        /// в пределах которых пользователь может ввести данные
        /// в соответствующий textBox.
        /// </summary>
        protected static double[] ExtremValues =
            new double[4];

        /// <summary>
        /// Свойство, указывающее на всплывающую
        /// подсказку типа ToolTip
        /// </summary>
        protected static ToolTip Hint { get; set; }

        /// <summary>
        /// Свойство, отвечающее на то,
        /// является ли текущая форма классом "Форма для поиска".
        /// </summary>
        protected static bool IsSearchForm { get; set; }

        /// <summary>
        /// Свойство, содержащее информацию о том, имеется ли
        /// возможность вводить параметр скорости в 
        /// форму "Форма для ввода данных".
        /// </summary>
        protected static bool SpeedEnterable { get; set; }

        /// <summary>
        /// Метод, устанавлювающий
        /// значения по умолчанию для свойств 
        /// </summary>
        /// <param name="isSearchForm">
        /// true, если утверждаем значения для
        /// формы поиска </param>
        /// <param name="t">
        /// Подсказка типа ToolTip в текущей форме
        /// формы поиска </param>
        /// <param name="element1">Поле для ввода текста №1 </param>
        /// <param name="element2">Поле для ввода текста №2 </param>
        /// <param name="element3">Поле для ввода текста №3 </param>
        /// <param name="element4">Поле для ввода текста №4 </param>
        protected static void DefaultValues(bool search, ToolTip t,
            TextBox element1, TextBox element2,
            TextBox element3, TextBox element4)
        {
            IsSearchForm = search;

            for (int i = 0; i < 4; i++)
            {
                СlearedTextboxFlags[i] = false;
                ValidValuesFlags[i] = IsSearchForm;

                if (i < 2)
                    ExtremValues[i] = -double.MaxValue;
                else
                    ExtremValues[i] = double.MaxValue;
            }

            TextBoxesList.Clear();
            TextBoxesList.Insert(0, element1);
            TextBoxesList.Insert(1, element2);
            TextBoxesList.Insert(2, element3);
            TextBoxesList.Insert(3, element4);

            Hint = t;
        }

        /// <summary>
        /// Метод, используемый для утверждения 
        /// правильности введённых 
        /// пользователем данных 
        /// </summary>
        /// <param name="index"> индекс TextBox,
        /// в списке TextBoxesList</param>
        protected static void ValuesPermission(int index)
        {
            TextBoxesList[index].ForeColor = Color.ForestGreen;
            ValidValuesFlags[index] = true;

            if (IsSearchForm)
            {
                SByte rangeShorter = -2;

                if (index < 2)
                    rangeShorter = 2;

                if (ValidValuesFlags[index + rangeShorter] == false)
                {
                    TextBoxesList[index + rangeShorter].ForeColor =
                        Color.ForestGreen;
                    ValidValuesFlags[index + rangeShorter] = true;
                }
            }


        }

        /// <summary>
        /// Метод, используемый для уведомления 
        /// пользователя о неправильности  
        /// введённых им данных 
        /// </summary>
        /// <param name="index"> Индекс textBox,
        /// в списке TextBoxesList.</param>
        /// <param name="message"> Сообщение,
        /// разъясняющее характер ошибки.</param>
        protected static void ErrorReport(int index, string message)
        {
            Hint.ToolTipTitle = "Неверные данные!";
            Hint.Show(message, TextBoxesList[index], -135, 25, 15000);
            SystemSounds.Beep.Play();
            TextBoxesList[index].ForeColor = Color.DarkRed;
            ValidValuesFlags[index] = false;
            MessageForMessageBox = message;
        }

        /// <summary>
        /// Метод, используемый для сброса
        /// текста в текстовом поле на текст 
        /// по умолчанию
        /// </summary>
        /// <param name="index"> Индекс textBox,
        /// в списке TextBoxesList.</param>
        protected static void DefaultingText(int index)
        {
            string defaultText1;
            string defaultText2;

            if (IsSearchForm)
            {
                defaultText1 = "\u2796Ꝏ";
                defaultText2 = "\u2795Ꝏ";

                ValuesPermission(index);
            }
            else
            {
                defaultText1 = "1234567,89";
                defaultText2 = "1234567,89";

                ValidValuesFlags[index] = false;
            }
            if (index < 2)
            {
                TextBoxesList[index].Text = defaultText1;
                ExtremValues[index] = -double.MaxValue;
            }
            else
            {
                TextBoxesList[index].Text = defaultText2;
                ExtremValues[index] = double.MaxValue;
            }

            СlearedTextboxFlags[index] = false;
            TextBoxesList[index].ForeColor = SystemColors.ControlDark;
        }

        /// <summary>
        /// Метод, используемый для оценки
        /// корректности пользовательских 
        /// данных в неком одном textBox
        /// </summary>
        /// <param name="index"> Индекс textBox,
        /// в списке TextBoxesList.</param>
        protected static void ValidationUserData(int index)
        {

            ExtremValues[index] =
                Convert.ToDouble(TextBoxesList[index].Text);
            double result = ExtremValues[index];
            bool condition = false;

            sbyte rangeShorter = -2;
            string errorMessage;

            if (IsSearchForm)
            {
                string txt;

                if (index % 2 == 0)
                    txt = "X";
                else
                    txt = "V";

                errorMessage = "Левое значение не должно " +
                    "превосходить правое!" +
                    "\nНапример: -1,1 " + txt + " 2,02";

                if (index < 2)
                {
                    condition = ExtremValues[index] >
                        ExtremValues[index + 2];
                    rangeShorter = 2;
                }
                else
                    condition = ExtremValues[index - 2] >
                        ExtremValues[index];

                if (!TextBoxesList[index + rangeShorter].Text.Contains("Ꝏ"))
                    ExtremValues[index + rangeShorter] = Convert.ToDouble(
                        TextBoxesList[index + rangeShorter].Text);
            }
            else
            {
                errorMessage = "Значение не может быть отрицательным.";

                switch (index)
                {
                    case 0:
                    case 2:
                        condition = result < 0;
                        break;
                    case 1:
                        condition = result < 0 && !SpeedEnterable;
                        break;
                    case 3:
                        condition = false;
                        break;
                    default:
                        break;
                }
            }

            if (condition)
            {
                ErrorReport(index, errorMessage);

                if (IsSearchForm)
                {
                    TextBoxesList[index + rangeShorter].ForeColor =
                        Color.DarkRed;
                    ValidValuesFlags[index + rangeShorter] = false;
                }
            }
            else if (index == 2 && SpeedEnterable &&
                result > 3E8 && !IsSearchForm)
                ErrorReport(index,
                    "Ваш объект быстрее света! " +
                    "\n Введите значение скорости, " +
                    "не превосходящее 3*10\u2078 м/с");
            else
                ValuesPermission(index);
        }

        /// <summary>
        /// Метод, используемый для дополнительной
        /// инициализации элементов формы 
        /// </summary>
        protected static void AdditionallyInitialization()
        {
            SByte index = 0;
            foreach (TextBox element in TextBoxesList)
            {
                DefaultingText(index);

                element.Leave += new EventHandler(AnyTextBoxLeave);
                element.Enter += new EventHandler(AnyTextBoxEnter);
                element.KeyDown +=
                    new KeyEventHandler(AnyTextBoxKeyDown);
                element.Enabled = !IsSearchForm;

                index++;
            }
        }

        /// <summary>
        /// Метод, используемый для окончательной
        /// валидации всех пользовательских данных
        /// </summary>
        /// <param name="rangeShorter">
        /// Параметр,показывающий,
        /// на сколько рангов (1 или 0) сократить опрос
        ///  validValuesFlags при конечной проверке 
        ///  валидации данных</param>
        protected static bool FinalValidationFlags(byte rangeShorter = 0)
        {
            bool valid = true;
            for (int i = 0; i < ValidValuesFlags.Length - rangeShorter; i++)
                valid &= ValidValuesFlags[i];
            return valid;
        }

        /// <summary>
        /// Метод, вызываемый в случае неудачной 
        /// окончательной валидации пользовательских данных
        /// </summary>
        /// <param name="rangeShorter">
        /// Параметр,показывающий,
        /// на сколько рангов (1 или 0) сократить опрос
        /// СlearedTextboxFlags при конечной проверке 
        /// причины неудачной валидации данных</param>
        protected static void InvalidUserData(byte rangeShorter = 0)
        {
            bool cleared = true;
            for (int i = 0;
                i < СlearedTextboxFlags.Length - rangeShorter; i++)
                cleared &= СlearedTextboxFlags[i];
            if (!cleared && !IsSearchForm)
                MessageBox.Show("Заполните пустные поля.",
                    "Неверные данные!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show(MessageForMessageBox,
                    "Неверные данные!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Обработчик события, который вызывается,
        /// когда пользователь кликнул по кнопке "ОК"/"Найти"
        /// </summary>
        protected void ApplyButtonClick(object sender, EventArgs e)
        {
            if (FinalValidationFlags(EnterForm.RangeShorter))
            {
                Operation();
                Close();
            }
            else
                InvalidUserData(EnterForm.RangeShorter);
        }

        /// <summary> 
        /// Метод, переопределяемый
        /// каждой вспомогательной формой
        /// соответственно
        /// </summary>
        protected virtual void Operation()
        {

        }

        /// <summary>
        /// Обработчик события, который вызывается,
        /// когда пользователь кликнул по кнопке "Отмена"
        /// в некторой форме.
        /// </summary>
        protected static void AnyCancelClick(object sender, EventArgs e)
        {
            Button b = sender as Button;
            Form f = (Form)b.TopLevelControl;
            f.Close();
        }

        /// <summary>
        /// Обработчик события, который вызывается,
        /// когда закрывается любая вспомогательная форма
        /// в некторой форме.
        /// </summary>
        protected static void AnyFormClosing(object sender, EventArgs e)
        {
            MotionCalculatorForm.ShowInTable();
        }

        /// <summary>
        /// Обработчик события, который вызывается,
        /// когда фокус ввода входит в
        /// любой TextBox в некоторой форме
        /// </summary>
        protected static void AnyTextBoxEnter(object sender, EventArgs e)
        {
            if (sender is TextBox element)
            {
                for (int i = 0; i < TextBoxesList.Count; i++)
                    if (element == TextBoxesList[i]
                        && СlearedTextboxFlags[i] == false)
                    {
                        element.Text = "";
                        СlearedTextboxFlags[i] = true;
                    }
                element.ForeColor = Color.Black;
            }
        }

        /// <summary>
        /// Обработчик события, который вызывается,
        /// когда пользователь ввёл любые данные
        /// в любой TextBox в некоторой форме
        /// </summary>
        protected static void AnyTextBoxKeyDown(object sender,
            KeyEventArgs e)
        {
            if (sender is TextBox element)
                Hint.Hide(element);
        }

        /// <summary>
        /// Обработчик события, который вызывается,
        /// когда фокус ввода покидает
        /// любой TextBox в некоторой форме
        /// </summary>
        protected static void AnyTextBoxLeave(object sender, EventArgs e)
        {
            if (sender is TextBox element)
            {
                int index = TextBoxesList.IndexOf(element);

                if (element.Text == "")
                    DefaultingText(index);

                else if (element.Text != "")
                {
                    try
                    {
                        ValidationUserData(index);
                    }
                    catch (System.OverflowException)
                    {
                        ErrorReport(index,
                            "Слишком большое значение." +
                            "\n Введите число, не превосходящее по модулю " +
                            "1,7*10\u00b3\u2070\u2078," +
                            "\n либо не точнее " +
                            "1,7*10\u207b\u00b3\u2070\u2078");
                    }
                    catch (System.FormatException)
                    {
                        ErrorReport(index,
                            "Введите численное значение вида: " +
                            "\n \"1234567,89\" или \"1234567\".");
                    }
                }
            }
        }
    }
}