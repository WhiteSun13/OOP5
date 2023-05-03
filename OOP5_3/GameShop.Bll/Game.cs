using GameShop.DI
namespace GameShop.Bll
{
    public class Game : IGame
    {
        public string Name { get; }
        public string Platform { get; }
        public string Publisher { get; }
        public string Developer { get; }
        public int Price { get; }

        public Game(string name, string platform, string publisher, string developer, int price)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            if (string.IsNullOrWhiteSpace(platform)) throw new ArgumentNullException(nameof(platform));
            if (string.IsNullOrWhiteSpace(publisher)) throw new ArgumentNullException(nameof(publisher));
            if (string.IsNullOrWhiteSpace(developer)) throw new ArgumentNullException(nameof(developer));
            if (price < 0) throw new ArgumentException("Price < 0", nameof(price));

            Name = name;
            Platform = platform;
            Publisher = publisher;
            Developer = developer;
            Price = price;
        }

        public override string ToString()
        {
            return $"{Name}{Platform}{Publisher}{Developer}";
        }
    }
}