namespace GameShop.App.Cmd
{
    partial class Program
    {
        private static string ReadNotEmptyLine(string title)
        {
            while (true)
            {
                Console.Write($"Введите {title}: ");
                var input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input))
                {
                    return input;
                }

                WriteErrorMessage($"Значение {title} не должен быть пустым");
            }
        }

        private static int ReadIntLine(string title)
        {
            while (true)
            {
                var input = ReadNotEmptyLine(title);
                if (int.TryParse(input, out int result) && result > 0)
                {
                    return result;
                }

                WriteErrorMessage($"Введите целое положительное число");
            }
        }

        private static void WriteErrorMessage(string message)
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"ОШИБКА! {message}");
            Console.ForegroundColor = color;
        }

        private static Command ReadCommand()
        {
            while (true)
            {
                var input = ReadNotEmptyLine("команду");
                if (Enum.TryParse(input, true, out Command command))
                {
                    return command;
                }

                WriteErrorMessage("Не известная команда. Введите help для подсказки");
            }
        }

        private static void WriteHelpMessage()
        {
            Console.WriteLine($"{Command.AddGame} - Добавить новую игру;");
            Console.WriteLine($"{Command.AddGameCopies} - Увеличить количество товара;");
            Console.WriteLine($"{Command.GetAllGames} - Вывести полный список доступных игр;");
            Console.WriteLine($"{Command.SellGame} - Продать игру;");
            Console.WriteLine($"{Command.Exit} - Выход из приложения;");
            Console.WriteLine($"{Command.Help} - Помощь;");
            Console.WriteLine();
        }
    }
}