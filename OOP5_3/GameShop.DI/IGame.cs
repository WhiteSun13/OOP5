namespace GameShop.DI
{
    public interface IGame
    {
        string Name { get; set; }
        string Platform { get; set; }
        string Publisher { get; set; }
        string Genre { get; set; }
        int Price { get; set; }
        int Copies { get; set; }
    }
}