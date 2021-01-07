using LastTask.BL.Interface;
using LastTask.DL.Interface;
using LastTask.Models.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LastTask.BL.Services
{
    public class TelevisorService : ITelevisorService
    {
        private readonly ITelevisorRepository _televiorRepository;

        public TelevisorService(ITelevisorRepository televisorRepository)
        {
            _televiorRepository = televisorRepository;
        }

        public async Task<Televisor> Create(Televisor televisor)
        {
            return await _televiorRepository.Create(televisor);
        }

        public async Task<Televisor> Update(Televisor televisor)
        {
            return await _televiorRepository.Update(televisor);
        }

        public async Task Delete(int TelevisorId)
        {
            await _televiorRepository.Delete(TelevisorId);
        }

        public async Task<IEnumerable<Televisor>> GetAll()
        {
            return await _televiorRepository.GetAll();
        }

    }
}
