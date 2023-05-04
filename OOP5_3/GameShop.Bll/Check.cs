using GameShop.DI;
using System;

namespace GameShop.Bll
{
    public class Check : ICheck
    {
        public IShop Shop { get; set; }
        public IGame Game { get; set; }
        public DateTime DateTime { get; set; }

        public override string ToString()
        {
            return DateTime.ToString();
        }
    }
}