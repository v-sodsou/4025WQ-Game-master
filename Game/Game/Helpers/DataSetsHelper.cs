using Game.ViewModels;
using System.Threading.Tasks;

namespace Game.Helpers
{
    /// <summary>
    /// DataSetsHelper class
    /// </summary>
    static public class DataSetsHelper
    {
        /// <summary>
        /// Warm up method
        /// </summary>
        /// <returns></returns>
        static public bool WarmUp()
        {
            ScoreIndexViewModel.Instance.GetCurrentDataSource();
            ItemIndexViewModel.Instance.GetCurrentDataSource();
            CharacterIndexViewModel.Instance.GetCurrentDataSource();

            return true;
        }

        /// <summary>
        /// Wipe data method
        /// </summary>
        /// <returns></returns>
        static public async Task<bool> WipeData()
        {
            await ScoreIndexViewModel.Instance.WipeDataListAsync();
            await ItemIndexViewModel.Instance.WipeDataListAsync();
            await CharacterIndexViewModel.Instance.WipeDataListAsync();

            return true;
        }
    }
}