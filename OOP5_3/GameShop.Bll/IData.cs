using System.Collections.Generic;
namespace GameShop.Bll
{
    public interface IData<T>
    {
        IEnumerable<T> ReadAll();
        void Add(T item);
    }
}