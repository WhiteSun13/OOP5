namespace GameShop.DI
{
    public interface IShop
    {
        string Name { get; set; }
        string Address { get; set; }

        void Add(IGame game);
        IEnumerable<IGame> GetAllGames();
        ICheck Sell(IGame game);
    }
}
