namespace GameShop.Bll
{
    public class Check : ICheck
    {
        public IShop Shop { get; }
        public IGame Game { get; }
        public DateTime DateTime { get; }
        public Check(IShop shop, IGame game)
        {
            Shop = shop ?? throw new ArgumentNullException(nameof(shop));
            Game = game ?? throw new ArgumentNullException(nameof(game));

            DateTime = DateTime.Now;
        }
        public void Print()
        {
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            return DateTime.ToString();
        }
    }
}
