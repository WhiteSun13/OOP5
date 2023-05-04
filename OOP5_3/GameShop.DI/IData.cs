using System.Collections.Generic;

namespace GameShop.DI
{
    public interface IData<T>
    {
        IEnumerable<T> ReadAll();
        void Add(T item);
        void Remove(T item);
    }
}
