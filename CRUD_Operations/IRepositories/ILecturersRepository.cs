using Lulalend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lulalend.IRepositories
{
    public interface ILecturersRepository
    {
        Task<IEnumerable<Lecturers>> GetAll();
        Task<Lecturers> GetBy(int id);
        Task Add(Lecturers lecturer);
        Task Update(int id);
        Task Delete(int id);
    }
}
