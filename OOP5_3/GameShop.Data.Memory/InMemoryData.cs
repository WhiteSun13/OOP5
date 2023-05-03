using GameShop.Bll;
using System.Collections.Generic;

namespace GameShop.Data.Memory
{
    public class InMemoryData : IData<IGame>, IData<ICheck>
    {
        private readonly List<IGame> _games;
        private readonly List<ICheck> _checks;

        public InMemoryData()
        {
            _games = new List<IGame>();
            _checks = new List<ICheck>();
        }

        public void Add(ICheck item)
        {
            _checks.Add(item);
        }

        public void Add(IGame item)
        {
            _games.Add(item);
        }

        public IEnumerable<ICheck> ReadAll()
        {
            return _checks;
        }

        IEnumerable<IGame> IData<IGame>.ReadAll()
        {
            return _games;
        }
    }
}