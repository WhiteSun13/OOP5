using GameShop.Data.Sql;
using GameShop.DI;
using System.Collections.Generic;
using System.Linq;

namespace GameShop.Data.Sql
{
    public class CheckSqlData : IData<ICheck>
    {
        public void Add(ICheck item)
        {
            using (var db = new GameShopContext())
            {
                var check = new CheckEntity(item);
                db.Checks.Add(check);
                db.SaveChanges();
            }
        }

        public IEnumerable<ICheck> ReadAll()
        {
            using (var db = new GameShopContext())
            {
                return db.Checks.ToList();
            }
        }

        public void Remove(ICheck item)
        {
            using (var db = new GameShopContext())
            {
                var check = new CheckEntity(item);
                db.Checks.Remove(check);
                db.SaveChanges();
            }
        }
    }
}