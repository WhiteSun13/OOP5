﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.DI
{
    public interface IData<T>
    {
        IEnumerable<T> ReadAll();
        void Add(T item);
        void Remove(T item);
    }
}
