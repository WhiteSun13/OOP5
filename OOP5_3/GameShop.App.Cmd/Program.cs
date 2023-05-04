using GameShop.DI;
using GameShop.Settings;
using GameShop.App.Cmd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameShop.Bll;

namespace GameShop.App.Cmd
{
    partial class Program
    {
        #region DI - Внедрение зависимости
        private static Configuration _configuration;

        private static IGame CreateGame(string name, string platform, string publisher, string genre, int price, int copies)
        {
            var game = _configuration.Container.GetInstance<IGame>();
            game.Name = name;
            game.Platform = platform;
            game.Publisher = publisher;
            game.Genre = genre;
            game.Price = price;
            game.Copies = copies;

            var shop = _configuration.Container.GetInstance<IShop>();
            shop.Add(game);

            return game;
        }

        private static ICheck CreateCheck(IGame game, int copies)
        {
            var shop = _configuration.Container.GetInstance<IShop>();
            var check = shop.Sell(game,copies);

            return check;
        }

        private static IShop CreateShop(string name, string address)
        {
            var shop = _configuration.Container.GetInstance<IShop>();
            shop.Name = name;
            shop.Address = address;

            return shop;
        }

        private static IEnumerable<IGame> GetAllGames()
        {
            var shop = _configuration.Container.GetInstance<IShop>();
            var games = shop.GetAllGames();

            return games;
        }
        #endregion

        static void Main(string[] args)
        {
            try
            {
                _configuration = new Configuration();

                var shop = CreateShop("Black Games", "13 Little Bevan Street, Bloomsbury, London");

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
                        case Command.AddGameCopies:
                            AddGameCopies();
                            break;
                        case Command.GetAllGames:
                            ShowAllGames();
                            break;
                        case Command.SellGame:
                            SellGame();
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

        private static void AddGame()
        {
            Console.WriteLine("Добавление новой игры");

            var name = ReadNotEmptyLine("Название игры");
            var platform = ReadNotEmptyLine("Платформа");
            var publisher = ReadNotEmptyLine("Издатель");
            var genre = ReadNotEmptyLine("Жанр");
            var price = ReadIntLine("Стоимость игры");
            var copies = ReadIntLine("Количество товара");

            var game = CreateGame(name, platform, publisher, genre, price, copies) ?? throw new Exception("Ошибка при добавлении игры");

            Console.WriteLine($"Игра [{game}] успешно добавлена");
            Console.WriteLine();
        }

        private static void AddGameCopies()
        {
            IGame game;
            int copies;
            while (true)
            {
                var name = ReadNotEmptyLine("Название игры");
                var platform = ReadNotEmptyLine("Платформу");
                var games = GetAllGames();
                var result = games.FirstOrDefault(b => b.Name.Equals(name) && b.Platform.Equals(platform));

                if (result != null)
                {
                    game = result;
                    break;
                }

                WriteErrorMessage("Данная игра не найдена");
            }
            copies = ReadIntLine("Количество товара");
            var shop = _configuration.Container.GetInstance<IShop>();
            shop.AddCopies(game, copies);
            Console.WriteLine($"Количество товара {game.Name} ({game.Platform}) увеличилось!");
        }

        private static void ShowAllGames()
        {
            Console.WriteLine("Список всех доступных в магазине игр:");

            var games = GetAllGames();
            foreach (var game in games)
            {
                Console.WriteLine($"{game}" + $" | В наличии: {game.Copies}");
            }
            Console.WriteLine();
        }

        private static void SellGame()
        {
            Console.WriteLine("Новая продажа игры");

            IGame game;
            int copies;
            while (true)
            {
                var name = ReadNotEmptyLine("Название игры");
                var platform = ReadNotEmptyLine("Платформу");
                var games = GetAllGames();
                var result = games.FirstOrDefault(b => b.Name.Equals(name) && b.Platform.Equals(platform));

                if (result != null)
                {
                    game = result;
                    break;
                }

                WriteErrorMessage("Данная игра не найдена");
            }
            while (true)
            {
                copies = ReadIntLine("Колчество");
                if ((copies <= game.Copies) && (copies > 0)) break;
                WriteErrorMessage($"Введено не правильное количество. В наличии: {game.Copies}");
            }
            var check = CreateCheck(game, copies);
            Console.WriteLine($"Новая продажа в магазине {check.Shop.Name}");
            Console.WriteLine($"по адресу {check.Shop.Address}");
            Console.WriteLine($"{check.DateTime}");
            Console.WriteLine($"Наименование товара: {check.Game}");
            Console.WriteLine($"Стоимость: {check.Game.Price}₽");
            Console.WriteLine();
        }
    }
}