using Lulalend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lulalend.IRepositories
{
    public interface IStudentsRepository
    {
        Task<IEnumerable<Students>> GetAll();
        Task<Students> GetBy(int id);
        Task Add(Students student);
        Task Update(int id);
        Task Delete(int id);
    }
}