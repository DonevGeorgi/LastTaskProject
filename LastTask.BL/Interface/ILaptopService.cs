using LastTask.Models.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LastTask.BL.Interface
{
    public interface ILaptopService
    {
        Task<Laptop> Create(Laptop smartphone);
        Task<Laptop> Update(Laptop smartphone);
        Task Delete(int SmartphoneId);
        Task<IEnumerable<Laptop>> GetAll();
    }
}
