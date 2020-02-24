using System.Collections.Generic;
using System.Threading.Tasks;

namespace Game.Services
{
    /// <summary>
    /// Interface for data interactions
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDataStore<T>
    {
        /// <summary>
        /// Create Async Method
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        Task<bool> CreateAsync(T Data);
        
        /// <summary>
        /// Read Async Method
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> ReadAsync(string id);
        
        /// <summary>
        /// Update Async Method
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        Task<bool> UpdateAsync(T Data);
        
        /// <summary>
        /// Delete Async Method
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(string id);
        
        /// <summary>
        /// Index Async Method
        /// </summary>
        /// <returns></returns>
        Task<List<T>> IndexAsync();
      
        /// <summary>
        /// Wipe DataList Async Method
        /// </summary>
        /// <returns></returns>
        Task<bool> WipeDataListAsync();
        
        /// <summary>
        /// Get Needs Init Async Method
        /// </summary>
        /// <returns></returns>
        Task<bool> GetNeedsInitializationAsync();
    }
}