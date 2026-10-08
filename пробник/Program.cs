namespace пробник
{
    internal class Program
    {
        public static int ReadNumber(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int number))
                    return number;
                else
                    Console.WriteLine("Ошибка! Введите корректно.");
            }
        }

        static readonly string[][] Digits = new string[][]
       {
        new string[] { " ### ", "#   #", "#   #", "#   #", " ### " }, // 0
        new string[] { "  #  ", " ##  ", "  #  ", "  #  ", " ### " }, // 1
        new string[] { " ### ", "#   #", "   # ", "  #  ", "#####" }, // 2
        new string[] { " ### ", "#   #", "  ## ", "#   #", " ### " }, // 3
        new string[] { "#   #", "#   #", "#####", "    #", "    #" }, // 4
        new string[] { "#####", "#    ", "#### ", "    #", "#### " }, // 5
        new string[] { " ### ", "#    ", "#### ", "#   #", " ### " }, // 6
        new string[] { "#####", "    #", "   # ", "  #  ", "  #  " }, // 7
        new string[] { " ### ", "#   #", " ### ", "#   #", " ### " }, // 8
        new string[] { " ### ", "#   #", " ####", "    #", " ### " } // 9
       };

        /// <summary>
        /// Выводит цифру в виде символов #
        /// </summary>
        /// <param name="number">Цифра от 0 до 9</param>
        public static void PrintDigit(int number)
        {
            foreach (string line in Digits[number])
                Console.WriteLine(line);
        }

        static void Main(string[] args)
        {
            if (!Task3())
                return;
        }

        static bool Task3()
        {
            Console.WriteLine("\nЗадание 3");

            Console.Write("Введите цифру (от 0 до 9): ");

            if (!int.TryParse(Console.ReadLine(), out var number))
                throw new FormatException("Вы должны были ввести число!");

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
            if (inputExit?.ToLower() == "закрыть" || inputExit?.ToLower() == "Exit")
                return false;
            return true;
        }
    }
}
