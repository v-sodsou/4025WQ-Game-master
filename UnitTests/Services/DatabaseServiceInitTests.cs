using NUnit.Framework;
using System.Threading.Tasks;

using Game.Models;
using Game.Services;

namespace UnitTests.Services
{
    /// <summary>
    /// This test file is separate from the DatabaseService Tests because it allows it to run in standard mode, rather than test mode.
    /// 
    /// Only test needed is the if statement on the mode
    /// 
    /// Constructor is enough to get to that code
    /// 
    /// </summary>
    [TestFixture]
    public class DatabaseServiceInitTests
    {
        DatabaseService<ItemModel> DataStore;

        [SetUp]
        public void Setup()
        {
            DataStore = DatabaseService<ItemModel>.Instance;
        }

        [TearDown]
        public async Task TearDown()
        {
            await DataStore.WipeDataListAsync();
        }
    }
}
