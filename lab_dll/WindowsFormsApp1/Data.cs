using Lab.Dll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{    
     /// <summary>
     /// Класс "Данные".
     /// Используется для декларациии, хранения
     /// и преобразования информации, 
     /// перемещаемой между формами.
     /// </summary>
    public static class Data
    {
        /// <summary>
        /// Свойство "Список измерений".
        /// Используется для хранения
        /// успешно введённой пользователем информации
        /// и полученных расчётов на её основе
        /// по различным видам движения.
        /// </summary>
        public static List<IMoveable> Measurements { get; set; } =
            new List<IMoveable>();

        /// <summary>
        /// Свойство "Флаги поиска".
        /// Используется для разрешения
        /// видимости объектов из "списка измерений",
        /// согласно критериям, установленных пользователем.
        /// </summary>
        public static List<bool> SearchFlags { get; set; } =
            new List<bool>();

        /// <summary>
        /// Поле, содержащее информацию о названиях
        /// типов движения
        /// </summary>
        private readonly static string[] _namesOfMotions =
        {
        "UniformMotion",
        "AcceleratedMotion",
        "OscillatedMotion"
        };

        /// <summary>
        /// Свойство, организующее доступ к полю
        /// _namesOfMotions извне класса
        /// </summary>
        public static string[] NamesOfMotions
        {
            get
            {
                return _namesOfMotions;
            }
        }

        /// <summary>
        /// Метод, организующий сброс 
        /// флагов поиска и приведение
        /// их количества к количеству
        /// элементов списка Measurements,
        /// </summary>
        /// <param name="value">
        /// true - если все объекты списка
        /// требуется сделать видимыми пользователю,
        /// false - если невидимыми.
        ///</param>
        public static void DefaultSearchFlags(bool value)
        {
            SearchFlags.Clear();
            for (int i = 0; i < Measurements.Count; i++)
                SearchFlags.Insert(i, value);
        }
    }
}
