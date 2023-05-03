namespace GameShop.Bll
{
    public interface ICheck
    {
        IShop Shop { get; }
        IGame Game { get; }
        DateTime DateTime { get; }

        void Print();
    }
}
