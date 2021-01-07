using LastTask.Models.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LastTask.DL.Interface
{
    public interface ILaptopRepository
    {
        Task<Laptop> Create(Laptop laptop);
        Task<Laptop> Update(Laptop laptop);
        Task<Laptop> GetById(int LaptopId);
        Task Delete(int LaptopId);
        Task<IEnumerable<Laptop>> GetAll();

    }
}
