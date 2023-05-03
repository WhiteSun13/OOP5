using System;
using System.Collections.Generic;
using GameShop.DI;
namespace GameShop.Bll
{
    public class Shop : IShop
    {
        private readonly IData<IGame> _gameData;
        private readonly IData<ICheck> _checkData;
        public string Name { get; }
        public string Address { get; }

        public Shop(string name, string address, IData<IGame> gameData, IData<ICheck> checkData)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            if (string.IsNullOrWhiteSpace(address)) throw new ArgumentNullException(nameof(address));

            _gameData = gameData ?? throw new ArgumentNullException(nameof(gameData));
            _checkData = checkData ?? throw new ArgumentNullException(nameof(checkData));

            Name = name;
            Address = address;
        }

        public void Add(IGame game)
        {
            _gameData.Add(game);
        }

        public IEnumerable<IGame> GetAllGames()
        {
            return _gameData.ReadAll();
        }

        public ICheck Sell(IGame game)
        {
            var check = new Check(this, game);
            _checkData.Add(check);
            return check;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
