using System;

namespace GameShop.DI
{
    public interface ICheck
    {
        IShop Shop { get; set; }
        IGame Game { get; set; }
        DateTime DateTime { get; set; }

        string Print();
    }
}
