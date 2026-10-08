namespace Tumakov_lab
{
    internal class Program
    {
        #region Проверка числа
        /// <summary>
        /// Проверка верного введения числа
        /// </summary>
        /// <param name="prompt">Текст, написанный перед введением числа</param>
        /// <returns>Число</returns>
        public static int ReadNumber(string prompt)
        {
            int number;
            bool isValid;
            do
            {
                Console.Write(prompt);
                isValid = int.TryParse(Console.ReadLine(), out number);
                if (!isValid)
                    Console.WriteLine("Ошибка! Введите корректно.");
            } while (!isValid);
            return number;
        }
        #endregion

        #region Упражнение 5.1
        /// <summary>
        /// Нахождение наибольшего из двух чисел
        /// </summary>
        /// <param name="number1">Первое число</param>
        /// <param name="number2">Второе число</param>
        /// <returns>Наибольшее число</returns>
        public static int GetMax(int number1, int number2)
        {
            return number1 > number2 ? number1 : number2;
        }
        #endregion

        #region Упражнение 5.2
        /// <summary>
        /// Поменять местами значения двух переменных
        /// </summary>
        /// <param name="number1">Первое число</param>
        /// <param name="number2">Второе число</param>
        public static void Swap(ref int number1, ref int number2)
        {
            int temporary = number1;
            number1 = number2;
            number2 = temporary;
        }
        #endregion

        #region Упражнение 5.3
        /// <summary>
        /// Вычисление факториала числа
        /// </summary>
        /// <param name="number">Число, факториал которого находим</param>
        /// <param name="result">Факториал</param>
        /// <returns>True, если вычисление выполнено успешно, иначе False</returns>
        public static bool Factorial(int number, out long result)
        {
            result = 1; 

            if (number < 0)
            {
                result = 0;
                return false;
            }
                
            try
            {
                checked
                {
                    for (int i = 2; i <= number; i++)
                        result *= i;
                }
                return true;
            }
            catch (OverflowException)
            {
                //Переполнение: результат невалиден
                result = 0;
                return false;
            }
        }
        #endregion

        #region Упражнение 5.4
        /// <summary>
        /// Рекурсивное вычисление факториала
        /// </summary>
        /// <param name="number">Число, факториал которого находим</param>
        /// <returns>Факториал, указанного числа</returns>
        public static long RecursiveFactorial(int number)
        {
            if (number < 0)
                throw new ArgumentException("Число должно быть неотрицательным");

            if (number <= 1)
                return 1;
            return number * RecursiveFactorial(number - 1);
        }
        #endregion

        #region Домашнее задание 5.1
        // GCD - Greatest Common Divisor
        /// <summary>
        /// Нахождение НОД двух натуральных чисел методом Евклида
        /// </summary>
        /// <param name="number1">Первое число</param>
        /// <param name="number2">Второе число</param>
        /// <returns>НОД двух чисел</returns>
        public static int Gcd(int number1, int number2)
        {
            if (number1 <= 0 || number2 <= 0)
                throw new ArgumentException("Числа должны быть натуральными");

            while (number2 != 0)
            {
                int remainder = number1 % number2;
                number1 = number2;
                number2 = remainder;
            }
            return number1;
        }
        

        /// <summary>
        /// Нахождение НОД трех натуральных чисел
        /// </summary> 
        /// <param name="number1">Первое число</param>
        /// <param name="number2">Второе число</param>
        /// <param name="number3">Третье число</param>
        /// <returns>НОД трех чисел</returns>
        public static int Gcd(int number1,  int number2, int number3)
        {
            if (number1 <= 0 || number2 <= 0 || number3 <= 0)
                throw new ArgumentException("Числа должны быть натуральными");

            // Так как НОД - ассоциативная операция (НОД( (a, b), c ) = НОД( a, (b, c) ) то мы можем сначала найти НОД первых двух чисел, а потом НОД этого результата и третьего числа
            return Gcd(Gcd(number1, number2), number3);
        }
        #endregion

        #region Домашнее задание 5.2
        /// <summary>
        /// Вычисление значения n-го числа ряда Фибоначчи
        /// </summary>
        /// <param name="number">Порядковый номер числа</param>
        /// <returns>Значение n-го числа Фибоначчи</returns>
        public static long Fibonacci(int number)
        {
            if (number < 0)
                throw new ArgumentException("Номер числа Фибоначчи не может быть отрицательным");

            if (number == 0)
                return 0;

            if (number == 1 || number == 2)
                return 1;

            return Fibonacci(number - 1) + Fibonacci(number - 2);
        }
        #endregion


        static void Main(string[] args)
        {
            Console.WriteLine("Упражнение 5.1");
            int number1 = 58;
            int number2 = 16;
            Console.WriteLine($"Наибольшее число из {number1} и {number2} - это {GetMax(number1, number2)}");


            Console.WriteLine("\nУпражнение 5.2");
            number1 = 17;
            number2 = 72;
            Console.WriteLine($"Первоначальный набор чисел: 1 число - {number1}, 2 число - {number2}");
            Swap(ref number1, ref number2);
            Console.WriteLine($"Результат обмена: 1 число - {number1}, 2 число - {number2}");


            Console.WriteLine("\nУпражнение 5.3");
            var number = ReadNumber("Введите число: ");
            if (Factorial(number, out long result))
                Console.WriteLine($"Факториал числа {number} равен: {result}");
            else
                Console.WriteLine("Произошло переполнение или Вы ввели отрицательное число");


            Console.WriteLine("\nУпражнение 5.4");
            var num = ReadNumber("Введите число: ");
            Console.WriteLine($"Факториал числа {num} равен: {RecursiveFactorial(num)}");


            Console.WriteLine("\nДомашнее задание 5.1\nНОД для двух чисел: ");
            var num1 = ReadNumber("Введите первое натуральное число: ");
            var num2 = ReadNumber("Введите второе натуральное число: ");
            try
            {
                Console.WriteLine($"НОД чисел {num1} и {num2} равен: {Gcd(num1,num2)}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка! {ex.Message}");
            }

            Console.WriteLine("\nНОД для трех чисел:");
            num1 = ReadNumber("Введите первое натуральное число: ");
            num2 = ReadNumber("Введите второе натуральное число: ");
            var num3 = ReadNumber("Введите третье натуральное число: ");
            try
            {
                Console.WriteLine($"НОД чисел {num1}, {num2} и {num3} равен: {Gcd(num1, num2, num3)}");
                
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка! {ex.Message}");
            }
            

            Console.WriteLine("\nДомашнее задание 5.2");
            num = ReadNumber("Введите номер члена последовательности Фибоначчи: ");
            Console.WriteLine($"Значение {num}-го члена последовательности Фибоначчи: {Fibonacci(num)}");
        }
    }
}