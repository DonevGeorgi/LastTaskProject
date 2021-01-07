using LastTask.DL.Interface;
using LastTask.Models.Products;
using Project.DL.InMemoryDB;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LastTask.DL.Services
{
    public class SmartphoneRepository : ISmartphoneRepository
    {
        private static List<Smartphone> DataBaseTable;

        public SmartphoneRepository()
        {
            DataBaseTable = InMemoryDb.Smartphones;
        }

        public Task<Smartphone> Create(Smartphone smartphone)
        {
            DataBaseTable.Add(smartphone);
            return Task.FromResult(smartphone);
        }

        public async Task<Smartphone> Update(Smartphone smartphone)
        {
            var result = DataBaseTable.FirstOrDefault(x => x.SmartphoneId == smartphone.SmartphoneId);

            if (result != null)
            {
                await Delete(result.SmartphoneId);
                return await Create(smartphone);
            }

            return null;
        }

        public Task Delete(int SmartphoneId)
        {
            var result = DataBaseTable.FirstOrDefault(x => x.SmartphoneId == SmartphoneId);

            if (result != null)
            {
                DataBaseTable.Remove(result);
            }

            return Task.CompletedTask;
        }

        public async Task<IEnumerable<Smartphone>> GetAll()
        {
            return await Task.FromResult(DataBaseTable);
        }

        public async Task<Smartphone> GetById(int SmartphoneId)
        {
            return await Task.FromResult(DataBaseTable.FirstOrDefault(x => x.SmartphoneId == SmartphoneId));
        }
    }
}
