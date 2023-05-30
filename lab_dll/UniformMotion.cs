using System;


namespace Lab.Dll
{
    /// <summary>
    /// Класс "Равномерное движение".
    /// Используется для расчета перемещения при равномерном движении
    /// </summary>
    [Serializable()]
    public class UniformMotion : MotionBase
    {
        /// <summary>
        /// Конструктор класса "Равномерное движение", используется
        /// для создания класса
        /// </summary>
        /// <param name="coordinate">Начальное значение координаты</param>
        /// <param name="velocity">Начальное значение скорости</param>
        public UniformMotion(double coordinate, double velocity)
        {
            Coordinate = coordinate;
            Velocity = velocity;
        }

        /// <summary>
        /// Метод, используемый для расчета перемещания за время deltaTime
        /// </summary>
        /// <param name="deltaTime">Время, за которое рассчитывается
        /// перемещание</param>
        public override void Move(double deltaTime)
        {
            Coordinate += Velocity * deltaTime;
        }
    }
}
