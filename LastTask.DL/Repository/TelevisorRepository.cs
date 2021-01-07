using LastTask.DL.Interface;
using LastTask.Models.Products;
using Project.DL.InMemoryDB;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LastTask.DL.Services
{
    public class TelevisorRepository : ITelevisorRepository
    {
        private static List<Televisor> DataBaseTable;

        public TelevisorRepository()
        {
            DataBaseTable = InMemoryDb.Televisors;
        }

        public Task<Televisor> Create(Televisor televisor)
        {
            DataBaseTable.Add(televisor);
            return Task.FromResult(televisor);
        }

        public async Task<Televisor> Update(Televisor televisor)
        {
            var result = DataBaseTable.FirstOrDefault(x => x.TelevisorId == televisor.TelevisorId);

            if (result != null)
            {
                await Delete(result.TelevisorId);
                return await Create(televisor);
            }

            return null;
        }

        public Task Delete(int TelevisorId)
        {
            var result = DataBaseTable.FirstOrDefault(x => x.TelevisorId == TelevisorId);

            if (result != null)
            {
                DataBaseTable.Remove(result);
            }

            return Task.CompletedTask;
        }

        public async Task<IEnumerable<Televisor>> GetAll()
        {
            return await Task.FromResult(DataBaseTable);
        }

        public async Task<Televisor> GetById(int TelevisorId)
        {
            return await Task.FromResult(DataBaseTable.FirstOrDefault(x => x.TelevisorId == TelevisorId));
        }
    }
}
