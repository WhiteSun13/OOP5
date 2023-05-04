using GameShop.DI;
using System.Collections.Generic;
using System.Linq;

namespace GameShop.Data.Sql
{
    public class GameSqlData : IData<IGame>
    {
        public void Add(IGame item)
        {
            using (var db = new GameShopContext())
            {
                var game = new GameEntity(item);
                db.Games.Add(game);
                db.SaveChanges();
            }
        }

        public IEnumerable<IGame> ReadAll()
        {
            using (var db = new GameShopContext())
            {
                return db.Games.ToList();
            }
        }

        public void Remove(IGame item)
        {
            using (var db = new GameShopContext())
            {
                var game = db.Games.SingleOrDefault(b => b.Platform.Equals(item.Platform) &&
                    b.Name.Equals(item.Name) &&
                    b.Price.Equals(item.Price));
                db.Games.Remove(game);
                db.SaveChanges();
            }
        }
    }
}