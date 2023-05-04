using GameShop.DI;
using GameShop.Bll;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameShop.Bll
{
    public class Shop : IShop
    {
        private readonly IData<IGame> _gameData;
        private readonly IData<ICheck> _checkData;

        public string Name { get; set; }
        public string Address { get; set; }

        public Shop(IData<IGame> gameData, IData<ICheck> checkData)
        {
            _gameData = gameData ?? throw new ArgumentNullException(nameof(gameData));
            _checkData = checkData ?? throw new ArgumentNullException(nameof(checkData));
        }

        public void Add(IGame game)
        {
            _gameData.Add(game);
        }

        public IEnumerable<IGame> GetAllGames()
        {
            return _gameData.ReadAll();
        }

        public ICheck Sell(IGame game, int copies)
        {
            game.Copies -= copies;
            //_gameData.Remove(game);

            var check = new Check()
            {
                Game = game,
                Shop = this,
                DateTime = DateTime.Now
            };

            _checkData.Add(check);
            return check;
        }

        public override string ToString()
        {
            return Name;
        }

        public void AddCopies(IGame game, int copies)
        {
            game.Copies += copies;
        }
    }
}