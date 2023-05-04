using GameShop.Bll;
using GameShop.Data.Memory;
using GameShop.DI;
using SimpleInjector;

namespace GameShop.Settings
{
    public class Configuration
    {
        public Container Container { get; }

        public Configuration()
        {
            Container = new Container();

            Setup();
        }

        public virtual void Setup()
        {
            Container.Register<IGame, Game>(Lifestyle.Transient);
            Container.Register<ICheck, Check>(Lifestyle.Transient);
            Container.Register<IShop, Shop>(Lifestyle.Singleton);
            Container.Register<IData<IGame>, GameMemoryData>(Lifestyle.Singleton);
            Container.Register<IData<ICheck>, CheckMemoryData>(Lifestyle.Singleton);
        }
    }
}