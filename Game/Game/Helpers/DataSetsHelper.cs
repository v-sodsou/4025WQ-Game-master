using Game.ViewModels;
using System;
using System.Diagnostics;
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

        private static readonly object WipeLock = new object();

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

        /// <summary>
        /// Call the Wipe routines in order one by one
        /// </summary>
        /// <returns></returns>
        static public async Task<bool> WipeDataInSequence()
        {
            lock (WipeLock)
            {
                var runSyncScore = Task.Factory.StartNew(new Func<Task>(async () =>
                {
                    await ScoreIndexViewModel.Instance.DataStoreWipeDataListAsync();
                    await Task.Delay(100);
                })).Unwrap();
                runSyncScore.Wait();


                var runSyncItem = Task.Factory.StartNew(new Func<Task>(async () =>
                {
                    await ItemIndexViewModel.Instance.DataStoreWipeDataListAsync();
                    await Task.Delay(100);
                })).Unwrap();
                runSyncItem.Wait();

                var runSyncCharacter = Task.Factory.StartNew(new Func<Task>(async () =>
                {
                    await CharacterIndexViewModel.Instance.DataStoreWipeDataListAsync();
                    await Task.Delay(100);
                })).Unwrap();
                runSyncCharacter.Wait();

                var runSyncMonster = Task.Factory.StartNew(new Func<Task>(async () =>
                {
                    await MonsterIndexViewModel.Instance.DataStoreWipeDataListAsync();
                    await Task.Delay(100);
                })).Unwrap();
                runSyncMonster.Wait();
            }

            return await Task.FromResult(true);
        }
    }
}