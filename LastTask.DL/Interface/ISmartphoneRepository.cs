using LastTask.Models.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LastTask.DL.Interface
{
    public interface ISmartphoneRepository
    {
        Task<Smartphone> Create(Smartphone smartphone);
        Task<Smartphone> Update(Smartphone smartphone);
        Task<Smartphone> GetById(int SmartphoneId);
        Task Delete(int SmartphoneId);
        Task<IEnumerable<Smartphone>> GetAll();

    }
}
