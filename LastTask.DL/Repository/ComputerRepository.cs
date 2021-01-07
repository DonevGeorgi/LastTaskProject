using LastTask.DL.Interface;
using LastTask.Models.Products;
using Project.DL.InMemoryDB;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LastTask.DL.Services
{
    public class ComputerRepository : IComputerRepository
    {
        private static List<Computer> DataBaseTable;

        public ComputerRepository()
        {
            DataBaseTable = InMemoryDb.Computers;
        }

        public Task<Computer> Create(Computer computer)
        {
            DataBaseTable.Add(computer);
            return Task.FromResult(computer);
        }

        public async Task<Computer> Update(Computer computer)
        {
            var result = DataBaseTable.FirstOrDefault(x => x.ComputerId == computer.ComputerId);

            if (result != null)
            {
                await Delete(result.ComputerId);
                return await Create(computer);
            }

            return null;
        }

        public Task Delete(int ComputerId)
        {
            var result = DataBaseTable.FirstOrDefault(x => x.ComputerId == ComputerId);

            if (result != null)
            {
                DataBaseTable.Remove(result);
            }

            return Task.CompletedTask;
        }

        public async Task<IEnumerable<Computer>> GetAll()
        {
            return await Task.FromResult(DataBaseTable);
        }

        public async Task<Computer> GetById(int ComputerId)
        {
            return await Task.FromResult(DataBaseTable.FirstOrDefault(x => x.ComputerId == ComputerId));
        }
    }
}
