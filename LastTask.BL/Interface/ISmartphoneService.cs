using LastTask.Models.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LastTask.BL.Interface
{
    public interface ISmartphoneService
    {
        Task<Smartphone> Create(Smartphone laptop);
        Task<Smartphone> Update(Smartphone laptop);
        Task Delete(int LaptopId);
        Task<IEnumerable<Smartphone>> GetAll();
    }
}
