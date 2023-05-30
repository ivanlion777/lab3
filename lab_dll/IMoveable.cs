namespace Lab.Dll
{
    /// <summary>
    /// Интерфейс классов-видов движения.
    /// Используется для объявления ссылок на объекты, относящиеся
    /// к видам движения
    /// </summary>
    public interface IMoveable
    {
        /// <summary>
        /// Метод, используемый для расчета перемещания за время deltaTime
        /// </summary>
        /// <param name="deltaTime">Время, за которое рассчитывается
        /// перемещание</param>
        void Move(double deltaTime);

        /// <summary>
        /// Координата -- свойство, используемое для доступа к координате
        /// извне класса
        /// </summary>
        double Coordinate { set; get; }

        /// <summary>
        /// Скорость -- свойство, используемое для доступа к скорости
        /// извне класса
        /// </summary>
        double Velocity { set; get; }
    }
}
