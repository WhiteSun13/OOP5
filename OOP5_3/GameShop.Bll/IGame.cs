﻿namespace GameShop.Bll
{
    public interface IGame
    {
        string Name { get; }
        string Platform { get; }
        string Publisher { get; }
        string Developer { get; }
        int Price { get; }
    }
}
