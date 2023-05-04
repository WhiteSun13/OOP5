using GameShop.DI;
namespace GameShop.Bll
{
    public class Game : IGame
    {
        public string Name { get; set; }
        public string Publisher { get; set; }
        public string Platform { get; set; }
        public string Genre { get; set; }
        public int Price { get; set; }
        public int Copies { get; set; }

        public override string ToString()
        {
            return $"{Name} | {Platform} | {Publisher} | {Genre}";
        }
    }
}