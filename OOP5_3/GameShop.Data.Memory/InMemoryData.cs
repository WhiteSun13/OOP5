using GameShop.DI;
using System.Collections.Generic;

namespace GameShop.Data.Memory
{
    public class GameMemoryData : IData<IGame>
    {
        private readonly List<IGame> _games;

        public GameMemoryData()
        {
            _games = new List<IGame>();
        }

        public void Add(IGame item)
        {
            _games.Add(item);
        }

        public IEnumerable<IGame> ReadAll()
        {
            return _games;
        }

        public void Remove(IGame item)
        {
            _games.Remove(item);
        }
    }
}