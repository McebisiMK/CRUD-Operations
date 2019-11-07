using Lulalend.IRepositories;
using Lulalend.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lulalend.Repositories
{
    public class StudentRepoitory : IStudentsRepository
    {
        private readonly IGenericRepository<Students> _studentRepoitory;

        public StudentRepoitory(IGenericRepository<Students> studentRepoitory)
        {
            _studentRepoitory = studentRepoitory;
        }

        public async Task<IEnumerable<Students>> GetAll()
        {
            return await _studentRepoitory.GetAll().ToListAsync();
        }

        public async Task<Students> GetBy(int id)
        {
            return await _studentRepoitory.GetBy(student => student.Id == id).SingleAsync();
        }

        public async Task Add(Students student)
        {
            _studentRepoitory.Add(student);
            await _studentRepoitory.Save();
        }

        public async Task Update(int id)
        {
            _studentRepoitory.Update(id);
            await _studentRepoitory.Save();
        }

        public async Task Delete(int id)
        {
            _studentRepoitory.Delete(id);
            await _studentRepoitory.Save();
        }
    }
}