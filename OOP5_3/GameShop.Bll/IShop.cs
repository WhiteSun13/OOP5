namespace GameShop.Bll
{
    public interface IShop
    {
        string Name { get; }
        string Address { get; }

        void Add(IGame game);
        IEnumerable<IGame> GetAllGames();
        ICheck Sell(IGame game);
    }
}
