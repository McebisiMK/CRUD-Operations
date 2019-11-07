using System.Collections.Generic;
using System.Threading.Tasks;
using Lulalend.Models;

namespace Lulalend.IServices
{
    public interface IStudentsService
    {
        Task<IEnumerable<Students>> GetAll();
        Task<Students> GetBy(int id);
        Task Add(Students student);
        Task Update(int id);
        Task Delete(int id);
    }
}