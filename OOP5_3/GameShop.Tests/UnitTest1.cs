using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameShop.Data.Sql;
using System.Linq;
using GameShop.Data.Memory;

namespace GameShop.Bll.Tests
{
    [TestClass()]
    public class ShopTests
    {
        [TestMethod(), TestCategory("Integration")]
        public void Sell_NewGame_CheckCreatedInDb()
        {
            // Arrange
            var gameData = new GameSqlData();
            var checkData = new CheckSqlData();
            var shop = new Shop(gameData, checkData);

            var game = new Game
            {
                Name = "TestName",
                Platform = "TestPlatform",
                Publisher = "Test",
                Genre = "Test",
                Price = 100
            };

            // Act
            shop.Add(game);
            var games = shop.GetAllGames().ToList();
            var check = shop.Sell(game);

            // Assert
            Assert.IsNotNull(games);
            Assert.IsNotNull(check);
        }

        [TestMethod(), TestCategory("Unit")]
        public void Sell_NewGame_CheckCreatedInMemory()
        {
            // Arrange
            var gameData = new GameMemoryData();
            var checkData = new CheckMemoryData();
            var shop = new Shop(gameData, checkData);

            var game = new Game
            {
                Name = "TestName",
                Platform = "TestPlatform",
                Publisher = "Test",
                Genre = "Test",
                Price = 100
            };

            // Act
            shop.Add(game);
            var games = shop.GetAllGames().ToList();
            var check = shop.Sell(game);

            // Assert
            Assert.IsNotNull(games);
            Assert.IsNotNull(check);
        }
    }
}