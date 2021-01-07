using LastTask.BL.Interface;
using LastTask.DL.Interface;
using LastTask.Models.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LastTask.BL.Services
{
    public class LaptopService : ILaptopService
    {
        private readonly ILaptopRepository _laptopRepository;

        public LaptopService(ILaptopRepository laptopRepository)
        {
            _laptopRepository = laptopRepository;
        }

        public async Task<Laptop> Create(Laptop laptop)
        {
            return await _laptopRepository.Create(laptop);
        }

        public async Task<Laptop> Update(Laptop laptop)
        {
            return await _laptopRepository.Update(laptop);
        }

        public async Task Delete(int LaptopId)
        {
            await _laptopRepository.Delete(LaptopId);
        }

        public async Task<IEnumerable<Laptop>> GetAll()
        {
            return await _laptopRepository.GetAll();
        }

    }
}
