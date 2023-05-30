using System;


namespace Lab.Dll
{
    /// <summary>
    /// Класс "Равноускоренное движение".
    /// Используется для расчета перемещения при равноускоренном движении
    /// </summary>
    [Serializable()]
    public class AcceleratedMotion : MotionBase
    {
        /// <summary>
        /// Внутреннее поле, хранящее ускорение
        /// </summary>
        private double _acceleration;

        /// <summary>
        /// Свойство -- ускорение, используемое для доступа к ускорению
        /// извне класса
        /// Свойство "Ускорение" может принимать любые значения
        /// </summary>
        public double Acceleration
        {
            set { _acceleration = value; }
            get { return _acceleration; }
        }

        /// <summary>
        /// Конструктор класса "Равноускоренное движение", используется
        /// для создания класса
        /// </summary>
        /// <param name="coordinate">Начальное значение координаты</param>
        /// <param name="velocity">Начальное значение скорости</param>
        /// <param name="acceleration">Начальное значение ускорения</param>
        public AcceleratedMotion(double coordinate, double velocity,
            double acceleration)
        {
            Coordinate = coordinate;
            Velocity = velocity;
            Acceleration = acceleration;
        }

        /// <summary>
        /// Метод, используемый для расчета перемещания за время deltaTime
        /// </summary>
        /// <param name="deltaTime">Время, за которое рассчитывается
        /// перемещение</param>
        public override void Move(double deltaTime)
        {
            Coordinate += Velocity * deltaTime +
                Acceleration * deltaTime * deltaTime / 2.0;
            Velocity += Acceleration * deltaTime;
        }
    }
}
