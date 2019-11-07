using System.Collections.Generic;
using System.Threading.Tasks;
using Lulalend.Models;

namespace Lulalend.IServices
{
    public interface ILecturersService
    {
        Task<IEnumerable<Lecturers>> GetAll();
        Task<Lecturers> GetBy(int id);
        Task Add(Lecturers lecturer);
        Task Update(int id);
        Task Delete(int id);
    }
}