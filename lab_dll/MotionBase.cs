using System;


namespace Lab.Dll
{
    /// <summary>
    /// Абстрактный класс -- движение вообще
    /// Используется для декларации общих свойств и абстрактных методов,
    /// свойственных движению вообще
    /// </summary>
    [Serializable()]
    public abstract class MotionBase : IMoveable
    {
        /// <summary>
        /// Скорость света. Используется для задания ограничений на
        /// максимально возможную скорость
        /// </summary>
        private const double _maxVelocity = 300000000;

        /// <summary>
        /// Внутреннее поле для хранения координаты
        /// </summary>
        private double _coordinate;

        /// <summary>
        /// Внутреннее поле для хранения скорости
        /// </summary>
        private double _velocity;

        /// <summary>
        /// Метод, рассчитывающий перемещание за время deltaTime
        /// </summary>
        /// <param name="deltaTime">Время, за которое рассчитывается
        /// перемещание</param>
        public abstract void Move(double deltaTime);

        /// <summary>
        /// Координата -- свойство, используемое для доступа к координате
        /// извне класса
        /// </summary>
        public double Coordinate
        {
            set { _coordinate = value; }
            get { return _coordinate; }
        }

        /// <summary>
        /// Скорость -- свойство,используемое для доступа к скорости
        /// извне класса
        /// </summary>
        public double Velocity
        {
            set
            {
                if (Math.Abs(value) <= _maxVelocity)
                    _velocity = value;
                else
                    throw new ArgumentOutOfRangeException(
                        "Больше скорости света! Укажите меньшее значение");
            }
            get { return _velocity; }
        }
    }
}
