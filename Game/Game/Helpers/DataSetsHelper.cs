using Game.ViewModels;
using System.Threading.Tasks;

namespace Game.Helpers
{
    static public class DataSetsHelper
    {
        static public bool WarmUp()
        {
            ScoreIndexViewModel.Instance.GetCurrentDataSource();
            ItemIndexViewModel.Instance.GetCurrentDataSource();
            CharacterIndexViewModel.Instance.GetCurrentDataSource();

            return true;
        }

        static public async Task<bool> WipeData()
        {
            await ScoreIndexViewModel.Instance.WipeDataListAsync();
            await ItemIndexViewModel.Instance.WipeDataListAsync();
            await CharacterIndexViewModel.Instance.WipeDataListAsync();

            return true;
        }
    }
}