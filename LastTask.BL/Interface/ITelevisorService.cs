using LastTask.Models.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LastTask.BL.Interface
{
    public interface ITelevisorService
    {
        Task<Televisor> Create(Televisor televisor);
        Task<Televisor> Update(Televisor televisor);
        Task Delete(int TelevisorId);
        Task<IEnumerable<Televisor>> GetAll();
    }
}
