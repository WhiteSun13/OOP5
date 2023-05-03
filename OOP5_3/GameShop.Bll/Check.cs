using GameShop.DI;
namespace GameShop.Bll
{
    public class Check : ICheck
    {
        public IShop Shop { get; set; }
        public IGame Game { get; set; }
        public DateTime DateTime { get; set; }
        public string Print()
        {
            return $"Новая продажа в магазине {Shop.Name}\r\n" +
                   $"по адресу {Shop.Address}\r\n" +
                   $"{DateTime}\r\n\r\n" +
                   $"Наименование товара: {Game}\r\n" +
                   $"Платформа: {Game.Platform}\r\n" +
                   $"Стоимость: {Game.Price}₽\r\n";
        }
        public override string ToString()
        {
            return DateTime.ToString();
        }
    }
}
