using System;


namespace Lab.Dll
{
    /// <summary>
    /// Класс "Колебательное движение"
    /// Используется для расчета перемещения при колебательном движении
    /// </summary>
    [Serializable()]
    public class OscillatedMotion : MotionBase
    {
        /// <summary>
        /// Внутреннее поле, используется для хранения текущего времени
        /// </summary>
        private double _time;

        /// <summary>
        /// Внутреннее поле, используется для хранения амплитуды
        /// </summary>
        private double _amplitude;

        /// <summary>
        /// Внутреннее поле, используется для хранения циклической частоты
        /// </summary>
        private double _cyclicFrequency;

        /// <summary>
        /// Внутреннее поля, используется для хранения начальной фазы
        /// </summary>
        private double _phase;

        /// <summary>
        /// Свойство "Амплитуда", используемое для доступа к амплитуде
        /// Свойство "Амплитуда" может принимать только положительные значения
        /// </summary>
        public double Amplitude
        {
            set
            {
                if (value >= 0.0)
                    _amplitude = value;
                else
                    throw new ArgumentOutOfRangeException(
                        "Отрицательная амплитуда! Укажите значение >= 0");
            }
            get { return _amplitude; }
        }

        /// <summary>
        /// Свойство "Фаза", используемое для доступа к фазе извне класса
        /// Свойство "Фаза" может принимать любые значения
        /// </summary>
        public double Phase { set { _phase = value; } get { return _phase; } }

        /// <summary>
        /// Свойство "Время", используемое для доступа ко времени извне класса
        /// Свойство "Время" может принимать только положительные значения
        /// </summary>
        public double Time
        {
            set
            {
                if (value >= 0.0)
                    _time = value;
                else
                    throw new ArgumentOutOfRangeException(
                        "Отрицательное время! Укажите значение >= 0");
            }
            get { return _time; }
        }

        /// <summary>
        /// Свойство "Циклическая частота", используемое для доступа
        /// к циклической частоте извне класса
        /// Свойство "Циклическая частота" может принимать только положительные значения
        /// </summary>
        public double CyclicFrequency
        {
            set
            {
                if (value >= 0.0)
                    _cyclicFrequency = value;
                else
                    throw new ArgumentOutOfRangeException(
                        "Отрицательная частота! Укажите значение >= 0");
            }
            get { return _cyclicFrequency; }
        }

        /// <summary>
        /// Конструктор класса "Колебательное движение", используется
        /// для создания класса
        /// </summary>
        /// <param name="time">Начальное значение времени</param>
        /// <param name="amplitude">Амплитуда</param>
        /// <param name="cyclicFrequency">Циклическая частота</param>
        /// <param name="phase">Фаза</param>
        public OscillatedMotion(double time, double amplitude,
            double cyclicFrequency, double phase)
        {
            Time = time;
            Amplitude = amplitude;
            CyclicFrequency = cyclicFrequency;
            Phase = phase;

            Move(0.0);
        }

        /// <summary>
        /// Метод, используемый для расчета перемещания за время deltaTime
        /// </summary>
        /// <param name="deltaTime">Время, за которое рассчитывается
        /// перемещание</param>
        public override void Move(double deltaTime)
        {
            Time += deltaTime;
            Coordinate = Amplitude * Math.Sin(CyclicFrequency * Time + Phase);
            Velocity = Amplitude * CyclicFrequency *
                Math.Cos(CyclicFrequency * Time + Phase);
        }
    }
}
