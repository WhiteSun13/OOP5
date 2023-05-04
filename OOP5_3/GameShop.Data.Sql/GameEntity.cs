using GameShop.DI;

namespace GameShop.Data.Sql
{
    public class GameEntity : IGame
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Platform { get; set; }
        public string Publisher { get; set; }
        public string Genre { get; set; }
        public int Price { get; set; }

        public GameEntity() { }

        public GameEntity(IGame item)
        {
            Id = 0;
            Name = item.Name;
            Platform = item.Platform;
            Publisher = item.Publisher;
            Genre = item.Genre;
            Price = item.Price;
        }

        public override string ToString()
        {
            return $"{Name}{Platform}{Publisher}{Genre}";
        }
    }
}