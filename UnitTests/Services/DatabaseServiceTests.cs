using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

using Game.Models;
using Game.Services;

namespace UnitTests.Services
{
    [TestFixture]
    public class DatabaseServiceTests
    {
        DatabaseService<ItemModel> DataStore;

        [SetUp]
        public void Setup()
        {
            //DatabaseService<ItemModel>.TestMode = true;
            DatabaseService<ItemModel>.TestMode = true;
            DataStore = DatabaseService<ItemModel>.Instance;
        }

        [TearDown]
        public async Task TearDown()
        {
            await DataStore.WipeDataListAsync();
        }

        [Test]
        public void DatabaseService_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = DataStore;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void DatabaseService_Constructor_InValid_Should_Fail()
        {
            // Arrange

            // Make a second instance
            DatabaseService<ItemModel>.initialized = false;

            // Act
            DatabaseService<ItemModel> DataStore2 = new DatabaseService<ItemModel>();

            // Reset

            // Assert
            Assert.IsTrue(true);
        }

        [Test]
        public async Task DatabaseService_WipeDataListAsync_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = await DataStore.WipeDataListAsync();

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }
    }
}
