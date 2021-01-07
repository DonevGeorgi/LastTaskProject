using LastTask.DL.Interface;
using LastTask.Models.Products;
using Project.DL.InMemoryDB;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LastTask.DL.Services
{
    public class LaptopRepository : ILaptopRepository
    {
        private static List<Laptop> DataBaseTable;

        public LaptopRepository()
        {
            DataBaseTable = InMemoryDb.Laptops;
        }

        public Task<Laptop> Create(Laptop laptop)
        {
            DataBaseTable.Add(laptop);
            return Task.FromResult(laptop);
        }

        public Task Delete(int LaptopId)
        {
            var result = DataBaseTable.FirstOrDefault(x => x.LaptopId == LaptopId);

            if (result != null)
            {
                DataBaseTable.Remove(result);
            }

            return Task.CompletedTask;
        }

        public async Task<IEnumerable<Laptop>> GetAll()
        {
            return await Task.FromResult(DataBaseTable);
        }

        public async Task<Laptop> GetById(int LaptopId)
        {
            return await Task.FromResult(DataBaseTable.FirstOrDefault(x => x.LaptopId == LaptopId));
        }

        public async Task<Laptop> Update(Laptop LaptopId)
        {
            var result = DataBaseTable.FirstOrDefault(x => x.LaptopId == LaptopId.LaptopId);

            if (result != null)
            {
                await Delete(LaptopId.LaptopId);
                return await Create(LaptopId);
            }

            return null;
        }
    }
}
