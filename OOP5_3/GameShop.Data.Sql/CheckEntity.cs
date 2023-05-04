using GameShop.DI;
using System;

namespace GameShop.Data.Sql
{
    public class CheckEntity : ICheck
    {
        public int Id { get; set; }
        public string ShopName { get; set; }
        public string GameName { get; set; }
        public IShop Shop { get; set; }
        public IGame Game { get; set; }
        public DateTime DateTime { get; set; }

        public CheckEntity() { }

        public CheckEntity(ICheck item)
        {
            Id = 0;
            Shop = item.Shop;
            ShopName = item.Shop.Name;
            Game = item.Game;
            GameName = item.Game.Name;
            DateTime = item.DateTime;
        }

        public override string ToString()
        {
            return DateTime.ToString();
        }
    }
}