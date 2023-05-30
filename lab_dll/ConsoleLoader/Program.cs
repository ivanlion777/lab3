using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Lab.Dll;


namespace ConsoleLoader
{
    /// <summary>
    /// Класс "Основная программа"
    /// В данной работе используется для выполнения основного кода
    /// </summary>
    class Program
    {
        /// <summary>
        /// Метод, используемый для ввода параметра
        /// </summary>
        /// <param name="var">Имя параметра для показа в приглашении
        /// ко вводу</param>
        /// <param name="min">Минимально допустимое значение</param>
        /// <param name="max">Максимально допустимое значение. Если
        /// меньше min, то проверки нет</param>
        /// <returns>Введенное с клавиатуры значение</returns>
        static double InputValue(String var, double min = 0.0,
            double max = -1.0)
        {
            do
            {
                try
                {
                    Console.Write(var + " = ");
                    double result = Convert.ToDouble(Console.ReadLine());
                    if (!Double.IsInfinity(result) && !Double.IsNaN(result))
                        if (max < min || result >= min && result <= max)
                            return result;
                    Console.WriteLine(
                        "Такое значение не имеет физического смысла!");
                    Console.WriteLine(
                        "Введите значение в диапазоне [{0}..{1}]", min, max);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Непонятный формат числа.");
                    if (max > min)
                        Console.WriteLine(
                         "Введите вещественное число в диапазоне [{0}..{1}]",
                         min, max);
                    else
                        Console.WriteLine(
                         "Введите корректное вещественное число");
                }
            }
            while (true);
        }

        /// <summary>
        /// Метод, используемый для вывода разделительной линии
        /// </summary>
        static void PrintSeparator()
        {
            Console.WriteLine("-------------------------");
        }

        /// <summary>
        /// Метод, используемый для вывода заголовка с информацией
        /// о виде движения
        /// </summary>
        /// <param name="motionType">Название вида движения</param>
        static void PrintHeader(String motionType)
        {
            PrintSeparator();
            Console.WriteLine(motionType);
        }

        /// <summary>
        /// Метод, используемый для вывода информации о текущей координате
        /// сразу после разделительной линии
        /// </summary>
        /// <param name="coordinate">Текущая координата</param>
        static void PrintCoordinateOnly(double coordinate)
        {
            PrintSeparator();
            Console.WriteLine("X1 = {0}", coordinate);
        }

        /// <summary>
        /// Метод, используемый для вывода информации о текущих координате
        /// и скорости (сразу после разделительной линии)
        /// </summary>
        /// <param name="coordinate">Текущая координата</param>
        /// <param name="velocity">Текущая скорость</param>
        static void PrintFullParameters(double coordinate, double velocity)
        {
            PrintCoordinateOnly(coordinate);
            Console.WriteLine("V1 = {0}", velocity);
        }

        /// <summary>
        /// Метод, выводящий информацию о произошедшем исключении
        /// с рекомендацией о дальнейших действиях
        /// </summary>
        /// <param name="e">Объект с информацией о произошедшем
        /// исключении</param>
        static void ExplicateError(Exception e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine("Повторите ввод с новыми данными!");
        }

        /// <summary>
        /// Главная функция, содержит основной код, исполняемый
        /// при запуске программы
        /// </summary>
        /// <param name="args">Массив аргументов командной строки,
        /// позволяет получать информацию,
        /// переданную из командной строки</param>
        static void Main(string[] args)
        {
            PrintHeader("Равномерное движение");

            do
            {
                try
                {
                    double coordinate = InputValue("X0");
                    double velocity = InputValue("V", 0.0, 3E8);
                    double deltaTime = InputValue("dT", 0.0, 1E300);

                    IMoveable movement = new UniformMotion(coordinate,
                        velocity);
                    movement.Move(deltaTime);

                    PrintCoordinateOnly(movement.Coordinate);

                    break;
                }
                catch (Exception e)
                {
                    ExplicateError(e);
                }
            } while (true);

            PrintHeader("Равноускоренное движение");

            do
            {
                try
                {
                    double coordinate = InputValue("X0");
                    double velocity = InputValue("V0", 0.0, 3E8);

                    double acceleration = InputValue("A");

                    double deltaTime = InputValue("dT", 0.0, 1E300);

                    IMoveable movement = new AcceleratedMotion(coordinate,
                        velocity, acceleration);

                    movement.Move(deltaTime);

                    PrintFullParameters(movement.Coordinate,
                        movement.Velocity);

                    break;
                }
                catch (Exception e)
                {
                    ExplicateError(e);
                }
            } while (true);

            PrintHeader("Колебательное движение");

            do
            {
                try
                {
                    double amplitude = InputValue("Амплитуда", 0.0, 1E300);
                    double cyclicFrequency = InputValue("Циклическая частота",
                        0.0, 1E300);
                    double phase = InputValue("Начальная фаза");
                    double time = InputValue("T", 0.0, 1E300);

                    IMoveable movement = new OscillatedMotion(time, amplitude,
                        cyclicFrequency, phase);

                    movement.Move(time);

                    PrintFullParameters(movement.Coordinate,
                        movement.Velocity);

                    break;
                }
                catch (Exception e)
                {
                    ExplicateError(e);
                }
            } while (true);

            PrintSeparator();

            Console.ReadLine();
        }
    }
}
