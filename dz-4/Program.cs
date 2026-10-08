using dz_4.enums;
using dz_4.structs;

namespace dz_4
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

        #region Вывод массива
        static void PrintArray(int[] array)
        {
            Console.WriteLine(string.Join(", ", array));
        }
        #endregion

        #region Упражнение 1 (из лабораторной Тумакова упр. 5.2)
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

        #region Упражнение 2 
        /// <summary>
        /// Вычисление суммы, произведения и среднего арифметического массива
        /// </summary>
        /// <param name="product">Произведение элементов массива</param>
        /// <param name="average">Среднее арифметическое элементов массива</param>
        /// <param name="numbers">Массив чисел</param>
        /// <returns>Сумма элементов массива</returns>
        public static int CalculateArray(ref int product, out double average, params int[] numbers)
        {
            // добавим проверку пустого массива, иначе будет ошибка деления на ноль в average
            if (numbers == null || numbers.Length == 0)
            {
                product = 0;
                average = 0;
                return 0;
            }

            int sum = 0;
            product = 1;

            foreach (int number in numbers)
            {
                sum += number;
                product *= number;
            }

            average = (double)sum / numbers.Length;
            return sum;
        }
        #endregion

        #region Упражнение 3
        static readonly string[][] Digits = 
        {
        new[] { " ### ", "#   #", "#   #", "#   #", " ### " }, // 0
        new[] { "  #  ", " ##  ", "  #  ", "  #  ", " ### " }, // 1
        new[] { " ### ", "#   #", "   # ", "  #  ", "#####" }, // 2
        new[] { " ### ", "#   #", "  ## ", "#   #", " ### " }, // 3
        new[] { "#   #", "#   #", "#####", "    #", "    #" }, // 4
        new[] { "#####", "#    ", "#### ", "    #", "#### " }, // 5
        new[] { " ### ", "#    ", "#### ", "#   #", " ### " }, // 6
        new[] { "#####", "    #", "   # ", "  #  ", "  #  " }, // 7
        new[] { " ### ", "#   #", " ### ", "#   #", " ### " }, // 8
        new[] { " ### ", "#   #", " ####", "    #", " ### " } // 9
        };

        /// <summary>
        /// Выводит цифру в виде символов #
        /// </summary>
        /// <param name="number">Цифра от 0 до 9</param>
        static void PrintDigit(int number)
        {
            foreach (string line in Digits[number]) 
                Console.WriteLine(line);
        }
        #endregion

        #region Упражнение 4
        /// <summary>
        /// Вывод данных дедушки
        public static void PrintDed(Grandfather ded)
        {
            Console.WriteLine($"Имя: {ded.Name}\nУровень ворчливости: {ded.Grumpiness}\nКоличество фингалов от бабушки: {ded.Bruises}\n");
        }
        #endregion


        static void Task1()
        {
            Console.WriteLine("Задание 1");

            const int Length = 20;
            Random random = new Random();
            int[] numbers = new int[Length];
            for (int i = 0; i < Length; i++)
                numbers[i] = random.Next(1, 101);

            Console.Write("Исходный массив: ");
            PrintArray(numbers);

            int first = ReadNumber("Введите первое число для обмена: ");
            int index1 = Array.IndexOf(numbers, first);
            const int NotFound = -1; // IndexOf возвращает -1, если элемент не найден
            if (index1 == NotFound)
            {
                Console.WriteLine("Число не найдено в массиве!");
                return;
            }

            int second = ReadNumber("Введите второе число для обмена: ");
            int index2 = Array.IndexOf(numbers, second);
            if (index2 == NotFound)
            {
                Console.WriteLine("Число не найдено в массиве!");
                return;
            }

            else if (index1 == index2)
            {
                Console.WriteLine("Это одно и то же число, менять нечего");
                return;
            }
            else
            {
                Swap(ref numbers[index1], ref numbers[index2]);
                Console.Write("Массив после обмена: ");
                PrintArray(numbers);
            }

        }

        static void Task2()
        {
            Console.WriteLine("\nЗадание 2");

            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Console.Write("Массив чисел: ");
            PrintArray(numbers);

            int product = 1;
            int sum = CalculateArray(ref product, out double average, numbers);
            Console.WriteLine($"Сумма элементов в массиве: {sum}");
            Console.WriteLine($"Произведение элементов в массиве: {product}");
            Console.WriteLine($"Среднее арифметическое элементов в массиве: {average}");
        }

        static bool Task3()
        {
            Console.WriteLine("\nЗадание 3");

            Console.Write("Введите цифру (от 0 до 9): ");
            // Намеренно не будем использовать TryParse, так как программа должна выпасть в исключение
            int number = int.Parse(Console.ReadLine());

            if (number < 0 || number > 9)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Clear();
                Console.WriteLine("Ошибка! Необходимо было ввести число от 0 до 9.");
                Thread.Sleep(3000);
                Console.ResetColor();
                Console.Clear();

                return false;
            }

            Console.WriteLine($"Цифра {number}:");
            PrintDigit(number);

            Console.Write("Введите 'Exit' или 'Закрыть' для завершения программы: ");
            string? inputExit = Console.ReadLine();
            if (inputExit?.ToLower() == "закрыть" || inputExit?.ToLower() == "exit")
                return false;
            return true;
        }

        static void Task4()
        {
            Console.WriteLine("\nЗадание 4");

            string[] swearWords = { "Гады", "Простофиля", "Дуралей", "Олух", "Оболтус", "Балбес", "Негодяй" };

            Grandfather ded1 = new Grandfather("Иван", GrumpinessLevel.Низкий, new[] { "Гады!", "Зумеры!" });
            Grandfather ded2 = new Grandfather("Ильнур", GrumpinessLevel.Средний, new[] { "Гады!", "Негодяй!", "Простофиля!" });
            Grandfather ded3 = new Grandfather("Ансар", GrumpinessLevel.Высокий, new[] { "Дуралей!", "Олух!", "Тунеядец!", "Оболтус!" });
            Grandfather ded4 = new Grandfather("Марат", GrumpinessLevel.ОченьВысокий, new[] { "Дуралей!", "Балбес!", "Шолопай!", "Оболтус!", "Олух!" });
            Grandfather ded5 = new Grandfather("Булат", GrumpinessLevel.Средний, new[] { "Простофиля!", "Ялкау!", "Гады!", "Негодяй!" });

            ded1.Bruises = Grandfather.CheckPhrases(ded1, swearWords);
            ded2.Bruises = Grandfather.CheckPhrases(ded2, swearWords);
            ded3.Bruises = Grandfather.CheckPhrases(ded3, swearWords);
            ded4.Bruises = Grandfather.CheckPhrases(ded4, swearWords);
            ded5.Bruises = Grandfather.CheckPhrases(ded5, swearWords);

            PrintDed(ded1);
            PrintDed(ded2);
            PrintDed(ded3);
            PrintDed(ded4);
            PrintDed(ded5);
        }

        static void Main(string[] args)
        {
            Task1();
            Task2();
            if (!Task3())
                return;
            Task4();
        }
    }
}

