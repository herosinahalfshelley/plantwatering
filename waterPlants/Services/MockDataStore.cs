using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using waterPlants.Models;

namespace waterPlants
{
    public class MockDataStore : IDataStore<Plant>
    {
        bool isInitialized;
        List<Plant> items;

        public MockDataStore()
        {
            items = new List<Plant>();
            var _items = new List<Plant>
            {
                new Plant { Id = Guid.NewGuid().ToString(), PlantName = "First item", Description="This is a nice description"},
                new Plant { Id = Guid.NewGuid().ToString(), PlantName = "Second item", Description="This is a nice description"},
                new Plant { Id = Guid.NewGuid().ToString(), PlantName = "Third item", Description="This is a nice description"},
                new Plant { Id = Guid.NewGuid().ToString(), PlantName = "Fourth item", Description="This is a nice description"},
                new Plant { Id = Guid.NewGuid().ToString(), PlantName = "Fifth item", Description="This is a nice description"},
                new Plant { Id = Guid.NewGuid().ToString(), PlantName = "Sixth item", Description="This is a nice description"},
            };

            foreach (Plant item in _items)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddPlantAsync(Plant item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdatePlantAsync(Plant item)
        {
            var _item = items.Where((Plant arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeletePlantAsync(string id)
        {
            var _item = items.Where((Plant arg) => arg.Id == id).FirstOrDefault();
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<Plant> GetPlantAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Plant>> GetPlantsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}
