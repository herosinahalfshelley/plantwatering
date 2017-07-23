using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using waterPlants.Models;

namespace waterPlants
{
    public interface IDataStore<T>
    {
        Task<bool> AddPlantAsync(T Plant);
        Task<bool> UpdatePlantAsync(T Plant);
        Task<bool> DeletePlantAsync(string id);
        Task<T> GetPlantAsync(string id);
        Task<IEnumerable<T>> GetPlantsAsync(bool forceRefresh = false);
    }
}
