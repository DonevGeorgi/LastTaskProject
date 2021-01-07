using LastTask.Models.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LastTask.DL.Interface
{
    public interface ITelevisorRepository
    {
        Task<Televisor> Create(Televisor televisor);
        Task<Televisor> Update(Televisor televisor);
        Task<Televisor> GetById(int TelevisorId);
        Task Delete(int TelevisorId);
        Task<IEnumerable<Televisor>> GetAll();

    }
}
