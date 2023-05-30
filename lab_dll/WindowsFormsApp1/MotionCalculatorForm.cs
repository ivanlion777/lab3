using Lab.Dll;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace WindowsFormsApp1
{

    /// <summary>
    /// Класс "Форма для расчёта видов движений".
    /// Используется визуализации полученних ранее данных,
    /// а также служит отправной точкой для поиска, добавления
    /// или удаления новых данных.
    /// </summary>
    public partial class MotionCalculatorForm : Form
    {
        /// <summary>
        /// Свойство, организующее доступ к полю
        /// _dataGridView1 извне класса
        /// </summary>
        public static DataGridView Table { get; set; }

        /// <summary>
        /// Поле, содержащее информацию о названиях
        /// типов движения на русском языке
        /// </summary>
        private readonly static string[] _namesOfMotionsRussian =
        {
        "Равномерное",
        "Равноускоренное",
        "Колебательное"
        };

        /// <summary>
        /// Конструктор класса "Форма для расчёта видов движений",
        /// используется
        /// для создания класса
        /// </summary>
        public MotionCalculatorForm()
        {
            InitializeComponent();
            Table = _dataGridView1;
        }

        /// <summary>
        /// Обработчик события, который вызывается,
        /// когда пользователь кликнул по кнопке,
        /// подразумевающую вызов новой формы 
        /// (Поиск, доб. новый расчёт).
        /// </summary>
        private void FormCreatorClick(object sender, EventArgs e)
        {
            Button b = sender as Button;
            Form f = null;

            try
            {
                if (b == _button1)
                    f = new EnterForm();
                else if (Data.Measurements.Count != 0
                    && b == _button4)
                    f = new SearchForm();
                f.ShowDialog();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Список пуст. Поиск невзможен.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Обработчик события, который вызывается,
        /// когда пользователь кликнул по кнопке "Удалить выбранный расчёт".
        /// </summary>
        private void DeleteClick(object sender, EventArgs e)
        {
            try
            {
                int index = 0;
                int quantity = _dataGridView1.SelectedRows.Count;

                for (int i = 0; i < quantity; i++)
                {
                    index = (int)
                        _dataGridView1.SelectedRows[0].Cells[0].Value
                        - 1;
                    Data.Measurements[index] = null;
                    _dataGridView1.Rows.Remove(
                        _dataGridView1.SelectedRows[0]);
                }

                bool removing = false;

                do
                {
                    removing = Data.Measurements.Remove(null);
                }
                while (removing);

                Data.DefaultSearchFlags(true);
                ShowInTable();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Выберете строки, которые хотите удалить.",
                    "Ошибка!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Строку, " +
                    "не содержащую информацию," +
                    "удалить нельзя.",
                    "Ошибка!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Обработчик события, который вызывается,
        /// когда пользователь кликнул по кнопке "Загрузить"
        /// или по кнопке "Сохранить"
        /// </summary>
        private void SaveLoadFileClick(object sender, EventArgs e)
        {
            Button b = sender as Button;

            SaveLoadFile(b == _button5);
            Data.DefaultSearchFlags(true);
            ShowInTable();
        }

        /// <summary>
        /// Метод, организующий сериализацию данных.
        /// </summary>
        private void SerialAll(string fileName)
        {
            Stream saveFileStream = File.Create(fileName);
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(saveFileStream, Data.Measurements);
            saveFileStream.Close();
        }

        /// <summary>
        /// Метод, организующий десериализацию данных.
        /// </summary>
        private void DeserialAll(string fileName)
        {
            if (File.Exists(fileName))
            {
                Stream openFileStream = File.OpenRead(fileName);
                BinaryFormatter deserializer = new BinaryFormatter();
                Data.Measurements = (List<IMoveable>)
                    deserializer.Deserialize(openFileStream);
                openFileStream.Close();
            }
            else
                MessageBox.Show("Файл не найден.", "Ошибка!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Метод, организующий настройку
        /// диалогового окна загрузки/сохранения
        /// данных.
        /// </summary>
        /// <param name="save"> true,
        /// если требуется сохранить файл,
        /// false, если загрузить существующий
        /// </param>
        private void SaveLoadFile(bool save)
        {
            FileDialog element = null;
            if (save)
                element = new SaveFileDialog();
            else
                element = new OpenFileDialog();

            element.Filter =
                "BinarySerializedMeasurementList (*.motions) | " +
                "*.motions";
            element.AddExtension = true;
            element.CheckPathExists = true;

            SaveFileDialog saveWindow = element as SaveFileDialog;
            bool condition = saveWindow != null;

            if (condition)
            {
                saveWindow.OverwritePrompt = true;
                saveWindow.Title = "Сохранить как...";
            }
            else
                element.Title = "Загрузить...";

            if (element.ShowDialog() == DialogResult.OK)
                if (condition)
                    SerialAll(element.FileName);
                else
                    DeserialAll(element.FileName);
        }

        /// <summary>
        /// Метод, организующий визуализацию в
        /// виде таблицы списка из введённых
        /// пользователем данных.
        /// </summary>
        public static void ShowInTable()
        {
            MotionCalculatorForm.Table.Rows.Clear();
            string motionType;

            for (int i = 0; i < Data.Measurements.Count; i++)
            {
                if (Data.SearchFlags[i] == true)
                {
                    motionType = Convert.ToString(Data.Measurements[i]);

                    for (int j = 0; j < Data.NamesOfMotions.Length; j++)
                        if (motionType.Contains(Data.NamesOfMotions[j]))
                            MotionCalculatorForm.Table.Rows.Add(
                                i + 1, _namesOfMotionsRussian[j],
                                Data.Measurements[i].Coordinate,
                                Data.Measurements[i].Velocity);
                }
            }
        }
    }
}