using System.Text;
using GameShop.Bll;

namespace GameShop.App.Cmd
{
    partial class Program
    {
        #region DI - Внедрение зависимости
        private static IGame CreateGame(string name, string platform, string publisher, string developer, int price)
        {
            var game = new Game(name, platform, publisher, developer, price);
            return game;
        }

        private static ICheck CreateCheck(IShop shop, IGame game)
        {
            var check = new Check(shop, game);
            return check;
        }

        private static IShop CreateShop(string name, string address)
        {
            var shop = new Shop(name, address);
            return shop;
        }
        #endregion

        static void Main(string[] args)
        {
            try
            {
                var shop = CreateShop("GameStop", "13 Little Bevan Street, Bloomsbury, London");

                Console.OutputEncoding = Encoding.UTF8;
                Console.WriteLine("Добрый день. Добро пожаловать в панель управления магазином");
                Console.WriteLine("Пожалуйста, введите нужную команду или help для помощи");
                Console.WriteLine();

                while (true)
                {
                    switch (ReadCommand())
                    {
                        case Command.Exit:
                            Environment.Exit(0);
                            break;
                        case Command.Help:
                            WriteHelpMessage();
                            break;
                        case Command.AddGame:
                            AddGame();
                            break;
                        case Command.GetAllGames:
                            GetAllGames(shop);
                            break;
                        case Command.SellGame:
                            SellGame(shop);
                            break;
                        default:
                            WriteErrorMessage("Не обрабатываемая команда. Свяжитесь с разработчиком");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

        private static IGame AddGame()
        {
            Console.WriteLine("Добавление новой игры");

            var name = ReadNotEmptyLine("Название игры");
            var platform = ReadNotEmptyLine("Платформа");
            var publisher = ReadNotEmptyLine("Издатель игры");
            var developer = ReadNotEmptyLine("Разработчик игры");
            var price = ReadIntLine("Стоимость игры");

            var game = CreateGame(name, platform, publisher,developer, price);

            if (game != null)
            {
                Console.WriteLine("Игра успешно добавлена");
                Console.WriteLine();
                return game;
            }

            throw new Exception("Ошибка при добавлении книги");
        }

        private static void GetAllGames(IShop shop)
        {
            Console.WriteLine("Список всех доступных в магазине игр:");

            var games = shop.GetAllGames();
            foreach (var game in games)
            {
                Console.WriteLine(game);
            }
            Console.WriteLine();
        }

        private static void SellGame(IShop shop)
        {
            Console.WriteLine("Новая продажа игры");

            IGame game;
            while (true)
            {
                var name = ReadNotEmptyLine("Название игры");
                var books = shop.GetAllGames();
                var result = books.FirstOrDefault(b => b.Name.Equals(name));

                if (result != null)
                {
                    game = result;
                    break;
                }

                WriteErrorMessage("Данная игра не найдена");
            }

            var check = CreateCheck(shop, game);
            check.Print();
            Console.WriteLine();
        }
    }
}