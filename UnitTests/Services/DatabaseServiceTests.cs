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
    }
}
