using LastTask.BL.Interface;
using LastTask.DL.Interface;
using LastTask.Models.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LastTask.BL.Services
{
    public class SmartphoneService : ISmartphoneService
    {
        private readonly ISmartphoneRepository _smartphoneRepository;

        public SmartphoneService(ISmartphoneRepository smartphoneRepository)
        {
            _smartphoneRepository = smartphoneRepository;
        }

        public async Task<Smartphone> Create(Smartphone smartphone)
        {
            return await _smartphoneRepository.Create(smartphone);
        }

        public async Task<Smartphone> Update(Smartphone smartphone)
        {
            return await _smartphoneRepository.Update(smartphone);
        }

        public async Task Delete(int SmartphoneId)
        {
            await _smartphoneRepository.Delete(SmartphoneId);
        }

        public async Task<IEnumerable<Smartphone>> GetAll()
        {
            return await _smartphoneRepository.GetAll();
        }

    }
}
