using GameShop.DI;
namespace GameShop.Bll
{
    public class Game : IGame
    {
        public string Name { get; }
        public string Platform { get; }
        public string Publisher { get; }
        public string Developer { get; }
        public int Price { get; }

        public override string ToString()
        {
            return $"{Name}{Platform}{Publisher}{Developer}";
        }
    }
}